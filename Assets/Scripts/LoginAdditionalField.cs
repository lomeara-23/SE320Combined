using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using System.Threading.Tasks;

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
    string name = "123@chapman.edu";
    string password = "12345";
    LoginAsync(name, password);
  }


  // Call JS server
  public async Task<bool> LoginAsync(string username, string password){
      try
      {
          var requestData = new { username, password };
          var jsonContent = JsonConvert.SerializeObject(requestData);
          var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

          var response = await _httpClient.PostAsync("http://localhost:3000/login", content);

          if (response.IsSuccessStatusCode)
          {
              // Login successful, navigate to a new webpage
              // You can redirect the user or render a new view here
              Console.WriteLine("Login successful");
              return true;
          }
          else
          {
              // Handle login error
              Console.WriteLine("Login failed");
              return false;
          }
      }
      catch (Exception e)
      {
          Debug.Log($"Error: {e.Message}");
          return false;
      }
  }

}
