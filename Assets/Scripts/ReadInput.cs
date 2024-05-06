using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    [SerializeField] GameObject EmailErrorMessage;
    // [SerializeField] GameObject TwoFactorCode;


    public static string userEmail;
    public static string userPassword;
    public static string classCode; //student only
    public static string TwoFCode; //teacher only

    public void OpenEmailWarning() {
      EmailErrorMessage.SetActive(true);
    }

    public void CloseEmailWarning() {
      EmailErrorMessage.SetActive(false);
    }

    // public void Open2Fcode() {
    //   TwoFactorCode.SetActive(true);
    // }
    //
    // public void Close2Fcode() {
    //   TwoFactorCode.SetActive(false);
    // }


    //setters
    public void setReadEmail(string s){
      Debug.Log("Email: " + userEmail); //prints variable in console

      if (s.EndsWith(".edu")) {
        userEmail = s;
        CloseEmailWarning();
        // Debug.Log("String ends with .edu");
      } else {
        OpenEmailWarning();
      }

    }

    public void setUserPassword(string s){
      userPassword = s;
      Debug.Log("Password: " + userPassword);

      //decryption code to compare entered password to the one from the database
    }

    public void setTwoFCode(string s){ // for teachers
      TwoFCode = s;
      Debug.Log(TwoFCode);
    }
}
