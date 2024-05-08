// Imports and server setup
const express = require('express');
const cors = require('cors'); 
const nodemailer = require('nodemailer');
const ObjectId = require('mongodb').ObjectId;


const app = express();
const port = 3000; 

// Middleware to parse JSON bodies
app.use(express.json());
app.use(cors());

let corsOptions = { 
  origin : ['http://localhost:3000', 'http://localhost:3001'] 
} 


// MongoDB setup
const MongoClient = require('mongodb').MongoClient;
const uri = "mongodb+srv://dev:dev@cluster0.f8wrnuy.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
const client = new MongoClient(uri);
client.connect();
const users = client.db('users')

const students = users.collection('Students'); 
const teachers = users.collection('Teachers'); 

// Helper functions and constants
const authEmail = "do.not.reply.brainybay@gmail.com";
const authPass = "ylym cwzp qaxq butc";

function getRandomInt(min, max) {
  return Math.floor(min + (Math.random() * max));
}

// Teacher login endpoint
app.post('/login-teacher', async (req, res) => {
  const { email, password } = req.body;

  const user = await teachers.findOne({
    'email': email,
    'password': password
  })
  
  if (user) {
    // If user is found, return a success message or token
    res.status(200).json({
      userID: user._id
    });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Invalid username or password' });
  }
});

// Student login endpoint
app.post('/login-student', async (req, res) => {
  const { username, code } = req.body;
  
  const user = await students.findOne({
    'username': username,
    'teacherCode': code
  })
  
  if (user) {
    // If user is found, return a success message or token
    res.status(200).json({ message: 'Login successful' });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Invalid username or password' });
  }
});

// Create teacher endpoint
app.post('/create-teacher', async (req, res) => {
  const { name, password, email } = req.body;
  var codeValid = false;

  if(!(email.endsWith(".edu"))){
    res.status(403).json({ error: 'Email not affiliated with an educational institution.' });
    return;
  };
  const emailCheck = await teachers.findOne({
    'email': email
  })
  
  if (emailCheck) {
    // If user is not found, return an error message
    res.status(403).json({ error: 'Email already in use.' });
    return;
  }

  while(!codeValid){
    var currCode = getRandomInt(100000,999999)
    const codeCheck = await teachers.findOne({
      'code': currCode
    });
    if(!codeCheck){
      codeValid = true;
    }
  }

  

  const newTeacher = {
    name: name,
    password: password,
    code: currCode,
    email: email,
    studentIds : []
  }

  try {
    await teachers.insertOne(newTeacher)
    res.status(200).json({ teacherEmail: newTeacher.email });
  } catch (e) {
    res.status(401).json({ error: e });
  }
});

// Create student endpoint
app.post('/create-student', async (req, res) => {
  const { id, name, username } = req.body;

  const me = await teachers.findOne({
    '_id': ObjectId.createFromHexString(id)
  })
  
  if (me) {
    const newStudent = {
      name: name,
      username: username,
      teacherCode: me.code,
      gamesPlayed: 0
    }
    try {
      newStudentDoc = students.insertOne(newStudent)
    } catch (error) {
      res.status(401).json({ error: 'Account creation failed' });
      return
    }
    
    res.status(200).json({
      studentUsername: newStudentDoc.username,
    });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Teacher does not exist' });
  }
});

// Get students endpoint
app.post('/get-students', async (req, res) => {
  const { id } = req.body;

  const user = await teachers.findOne({
    '_id': ObjectId.createFromHexString(id)
  })
  
  if (user) {
    // If user is found, return a success message or token
    studentArr = []
    
    if (user.studentIds) {
      for(const studentId of user.studentIds) {

        const student = await students.findOne({
          '_id': ObjectId.createFromHexString(studentId)
        });
        if (student) {
          studentArr.push(student)
        }
      }
    }

    res.status(200).json({
      name: user.name,
      students: studentArr
    });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Invalid username or password' });
  }
});

// Send auth code
app.post('/send-auth-code', async (req, res) => {
  const { id, authCode } = req.body;

  const user = await teachers.findOne({
    '_id': ObjectId.createFromHexString(id)
  })
  
  if (user) {    
    // Send auth code in email
    var transporter = nodemailer.createTransport({
      service: 'gmail',
      auth: {
        user: authEmail,
        pass: authPass
      }
    });
    var mailOptions = {
      from: authEmail,
      to: user.email,
      subject: 'SkillGame 2FA',
      text: "Authentication code: "+authCode
    };
    
    transporter.sendMail(mailOptions, function(error){
      if (error) {
        console.log(error);
      }
    });
    res.status(200).json({
      email: user.email,
    });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Invalid account ID' });
  }
});




// Start the server
app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});