using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;



public class Authentication : MonoBehaviour
{
   public InputField bodyMessage;
   public InputField recipientEmail;

   // public void SendEmail()
   //  {
   //      try
   //      {
   //          using (MailMessage mail = new MailMessage())
   //          using (SmtpClient SmtpServer = new SmtpClient("smtp.protonmail.com"))
   //          {
   //              SmtpServer.Timeout = 10000;
   //              SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
   //              SmtpServer.UseDefaultCredentials = false;
   //              SmtpServer.Port = 587;
   //              mail.From = new MailAddress("BrainyBay@protonmail.com");
   //              mail.To.Add(new MailAddress("fomina@chapman.edu"));
   //              mail.Subject = "Test Email through C Sharp App";
   //              mail.Body = "This is a random body";
   //              SmtpServer.Credentials = new System.Net.NetworkCredential("do.not.reply.brainybay@gmail.com", "BrainyBay2024");
   //              SmtpServer.EnableSsl = true;
   //              mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
   //              SmtpServer.Send(mail);
   //          }
   //      }
   //      catch (SmtpException ex)
   //      {
   //          Debug.LogError("SMTP error: " + ex.Message);
   //      }
   //      catch (Exception ex)
   //      {
   //          Debug.LogError("Failed to send verification email: " + ex.Message);
   //      }
   //  }


    // void Start() {
    //   try
    //   {
    //     MailMessage mail = new MailMessage();
    //     SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
    //     SmtpServer.Timeout = 10000;
    //     SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
    //     SmtpServer.UseDefaultCredentials = false;
    //     SmtpServer.Port = 587;
    //     mail.From = new MailAddress("mego@chapman.edu");
    //     mail.To.Add(new MailAddress("fomina@chapman.edu"));
    //     mail.Subject = "Test Email through C Sharp App";
    //     mail.Body = "This is a random body";
    //     SmtpServer.Credentials = new System.Net.NetworkCredential("mego@chapman.edu", "") as ICredentialsByHost;
    //     SmtpServer.EnableSsl = true;
    //     ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
    //       return true;
    //       };
    //     mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //     SmtpServer.Send(mail);
    //   }
    //   catch (Exception ex)
    //   {
    //       Debug.LogError("Failed to send verification email");
    //   }
    //
    //
    //
    // }

    // void Start() {
    //     MailMessage mail = new MailMessage();
    //     SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
    //     SmtpServer.Timeout = 10000;
    //     SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
    //     SmtpServer.UseDefaultCredentials = false;
    //     mail.From = new MailAddress("do.not.reply.brainybay@gmail.com");
    //     mail.To.Add(new MailAddress("9495996788" + "@txt.att.net"));
    //     //See carrier destinations below
    //     //message.To.Add(new MailAddress("5551234568@txt.att.net"));
    //     mail.To.Add(new MailAddress("9495996788" + "@vtext.com"));
    //     mail.To.Add(new MailAddress("9495996788" + "@messaging.sprintpcs.com"));
    //     mail.To.Add(new MailAddress("9495996788" + "@tmomail.net"));
    //     mail.To.Add(new MailAddress("9495996788" + "@vmobl.com"));
    //     mail.To.Add(new MailAddress("9495996788" + "@messaging.nextel.com"));
    //     mail.To.Add(new MailAddress("9495996788" + "@myboostmobile.com"));
    //     mail.To.Add(new MailAddress("9495996788" + "@message.alltel.com"));
    //     mail.To.Add(new MailAddress("9495996788" + "@mms.ee.co.uk"));
    //     mail.Subject = "Subject";
    //     mail.Body = "";
    //     SmtpServer.Port = 587;
    //     SmtpServer.Credentials = new System.Net.NetworkCredential("BrainyBay@protonmail.com", "BrainyBay2024") as ICredentialsByHost;
    //     SmtpServer.EnableSsl = true;
    //     ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
    //     mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    //     SmtpServer.Send(mail);
    // }



     // void Start(){
     //    var fromEmail = "do.not.reply.brainybay@gmail.com";
     //
     //    var mail = new MailMessage();
     //    mail.From = new MailAddress(fromEmail);
     //    mail.To.Add("fomina@chapman.edu");
     //
     //    mail.Subject = "EMAIL_SUBJECT";
     //    mail.Body = "BODY_OF_EMAIL";
     //
     //    var smtpServer = new SmtpClient("smtp.gmail.com"); // Gmail smtp client
     //    smtpServer.Port = 587; // Gmail smtp port
     //
     //    smtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, "BrainyBay2024") as ICredentialsByHost;
     //    smtpServer.EnableSsl = true;
     //    ServicePointManager.ServerCertificateValidationCallback =
     //    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
     //    {
     //        return true;
     //    };
     //
     //    smtpServer.Send(mail);

        // // Sender's email address and password
        // string fromEmail = "do.not.reply.brainybay@gmail.com";
        // string password = "BrainyBay2024"; // Use an app-specific password for better security
        //
        // // Receiver's email address
        // string toEmail = "fomina@chapman.edu";
        //
        // // Generate a random verification code
        // System.Random random = new System.Random();
        // int verificationCode = random.Next(100000, 999999); // Generate a 6-digit code
        //
        // // Email subject and body with the verification code
        // string subject = "Verification Code for 2FA";
        // string body = $"Your verification code is: {verificationCode}";
        //
        // // Create an instance of the SmtpClient class
        // SmtpClient smtpClient = new SmtpClient("smtp-relay.gmail.com")
        // {
        //     Port = 465, // Port number for TLS/STARTTLS
        //     Credentials = new NetworkCredential(fromEmail, password),
        //     EnableSsl = true // Enable SSL/TLS encryption
        // };
        //
        // // Create a MailMessage object
        // MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);
        //
        //
        // try
        // {
        //     // Send the email
        //     smtpClient.Send(mailMessage);
        //     Debug.Log("Verification email sent successfully");
        //     Debug.Log("Authentication number sent: " + verificationCode);
        // }
        // catch (Exception ex)
        // {
        //     Debug.LogError("Failed to send verification email: " + ex.Message);
        // }

    // }



    // static void Main()
    // {
    //     // Sender's email address and password
    //     string fromEmail = "your_email@gmail.com";
    //     string password = "your_password"; // Use an app-specific password for better security
    //
    //     // Receiver's email address
    //     string toEmail = "recipient@example.com";
    //
    //     // Generate a random verification code
    //     Random random = new Random();
    //     int verificationCode = random.Next(100000, 999999); // Generate a 6-digit code
    //
    //     // Email subject and body with the verification code
    //     string subject = "Verification Code for 2FA";
    //     string body = $"Your verification code is: {verificationCode}";
    //
    //     // Create an instance of the SmtpClient class
    //     SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
    //     {
    //         Port = 587, // Port number for TLS/STARTTLS
    //         Credentials = new NetworkCredential(fromEmail, password),
    //         EnableSsl = true // Enable SSL/TLS encryption
    //     };
    //
    //     // Create a MailMessage object
    //     MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);
    //
    //     try
    //     {
    //         // Send the email
    //         smtpClient.Send(mailMessage);
    //         Console.WriteLine("Verification code sent successfully.");
    //
    //         // Prompt the user to enter the verification code
    //         Console.Write("Enter the verification code: ");
    //         int userInput = int.Parse(Console.ReadLine());
    //
    //         // Verify the entered code
    //         if (userInput == verificationCode)
    //         {
    //             Console.WriteLine("Verification successful. Access granted.");
    //         }
    //         else
    //         {
    //             Console.WriteLine("Invalid verification code. Access denied.");
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("Failed to send verification code via email. Error message: " + ex.Message);
    //     }
    // }
    //


    // // Start is called before the first frame update
    // void Start()
    // {
    //
    // }

    // Update is called once per frame
    void Update()
    {

    }
}
