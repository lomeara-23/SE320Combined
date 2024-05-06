const express = require('express');
const cors = require('cors') 

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
const client = new MongoClient(uri, { useNewUrlParser: true });
client.connect();
const users = client.db('users')

// Login endpoint
app.post('/login-teacher', async (req, res) => {
  const { username, password } = req.body;
  const teachers = users.collection('Teachers'); 

  const user = await teachers.findOne({
    'username': username,
    'password': password
  })
  
  if (user) {
    // If user is found, return a success message or token
    res.status(200).json({ message: 'Login successful' });
  } else {
    // If user is not found, return an error message
    res.status(401).json({ error: 'Invalid username or password' });
  }
});

app.post('/login-student', async (req, res) => {
  const { username, code } = req.body;
  
  const students = users.collection('Students'); 

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

// Logout endpoint
app.post('/logout', (req, res) => {
  // Perform any necessary logout logic here
  res.json({ message: 'Logout successful' });
});



// Start the server
app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});