using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DatabaseAccess : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    // Direct connection to MongoDB from Unity
    const string connectionUri = "mongodb+srv://<username>:<password>@cluster0.f8wrnuy.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
    // var settings = MongoClientSettings.FromConnectionString(connectionUri);

    // // Set the ServerApi field of the settings object to set the version of the Stable API on the client
    // settings.ServerApi = new ServerApi(ServerApiVersion.V1);
    //
    // // Create a new client and connect to the server
    // var client = new MongoClient(settings);
    //
    // // Send a ping to confirm a successful connection
    // try {
    //   var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    //   Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
    // } catch (Exception e) {
    //   Console.WriteLine(e);
    // }
    //
    // var filter = Builders<BsonDocument>.Filter.And(
    //     Builders<BsonDocument>.Filter.Eq("username", username),
    //     Builders<BsonDocument>.Filter.Eq("password", password)
    // );
    //
    // public async Task<bool> CheckUserCredentialsAsync(string username, string password)
    // {
    //     var filter = Builders<BsonDocument>.Filter.And(
    //         Builders<BsonDocument>.Filter.Eq("username", username),
    //         Builders<BsonDocument>.Filter.Eq("password", password)
    //     );
    //
    //     var result = await _usersCollection.CountDocumentsAsync(filter);
    //
    //     return result > 0;
    // }
    //
    // static async Task Login(string username, string password)
    // {
    //     var client = new MongoClient("mongodb://localhost:27017");
    //     var database = client.GetDatabase("mydatabase");
    //
    //     var credentialsChecker = new UserCredentialsChecker(database);
    //
    //     string user = username;
    //     string pass = password;
    //
    //     bool credentialsValid = await credentialsChecker.CheckUserCredentialsAsync(user, pass);
    //
    //     if (credentialsValid)
    //     {
    //         Console.WriteLine("User credentials are valid.");
    //     }
    //     else
    //     {
    //         Console.WriteLine("User credentials are invalid.");
    //     }
    // }
}
