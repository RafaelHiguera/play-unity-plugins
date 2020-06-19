using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static ServerResponseModel;

public class SecurityController
{
  const string REGISTER_URL = "https://us-central1-simpleserver-d2cf5.cloudfunctions.net/register_user?deviceId=";

  public static bool registerUserDevice()
  {
    bool registrationSuccess = false;
    WWWForm form = new WWWForm();
    form.AddField("deviceId", SystemInfo.deviceUniqueIdentifier);
    UnityWebRequest uwr = UnityWebRequest.Post(REGISTER_URL, form);

    uwr.SendWebRequest();
    while (!uwr.isDone){}

    if (uwr.isNetworkError){
      Debug.Log("Error While Sending: " + uwr.error);
    }
    else
    {
      registrationSuccess = JsonUtility.FromJson<ServerResponseModel>(uwr.downloadHandler.text).success;
    }
    return registrationSuccess;
  }
}
