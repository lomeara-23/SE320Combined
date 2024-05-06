using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using System.Threading.Tasks;
using UnityEngine.Networking;


public class LoginAdditionalField : MonoBehaviour
{
  [SerializeField] GameObject AdditionalField;
  [SerializeField] GameObject AdditionalText;

  public void OpenAdditional() {
    AdditionalText.SetActive(true);
    AdditionalField.SetActive(true);
  }

  public void CloseAdditional() {
    AdditionalText.SetActive(false);
    AdditionalField.SetActive(false);
  }

  //if button clicked
  public void compareCredentials(){
    Debug.Log("Clicked");
    StartCoroutine(login());
    Debug.Log("Login Attempted");
  }

  // UnityWebRequest Version


  IEnumerator login()
  {
      string username = "123@chapman.edu";
      string password = "12345";

      WWWForm form = new WWWForm();
      form.AddField("username", username);
      form.AddField("password", password);
      Debug.Log("Form Created");
      using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/login", form))
      {
        Debug.Log("Request Built");
          yield return www.SendWebRequest();
          Debug.Log("Sent");

          if (www.result == UnityWebRequest.Result.Success)
          {
              Debug.Log("Success!");
          }
          else
          {
              Debug.Log("Error: " + www.error);
          }
          Debug.Log("Received?");
      }
  }


}
