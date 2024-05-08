const express = require('express');
const cors = require('cors'); 
const ObjectId = require('mongodb').ObjectId;


const app = express();
const port = 3000; 

// Middleware to parse JSON bodies
app.use(express.json());
app.use(cors());

let corsOptions = { 
  origin : ['http://localhost:3000', 'http://localhost:3001'] 
} 

const MongoClient = require('mongodb').MongoClient;
const uri = "mongodb+srv://dev:dev@cluster0.f8wrnuy.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
const client = new MongoClient(uri);
client.connect();
const users = client.db('users')

const students = users.collection('Students'); 
const teachers = users.collection('Teachers'); 


// Login endpoint
app.post('/login-teacher', async (req, res) => {
  const { username, password } = req.body;

  const user = await teachers.findOne({
    'username': username,
    'password': password
  })
  
  if (user) {
    // If user is found, return a success message or token
    res.status(200).json({
      message: 'Login successful',
      userID: user._id
    });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Invalid username or password' });
  }
});

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
      message: 'Acocunt creation successful',
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
      message: 'Login successful',
      name: user.name,
      students: studentArr
    });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Invalid username or password' });
  }
});




// Start the server
app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});