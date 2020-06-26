using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static ServerResponseModel;
using static ServerURLs;

public class SecurityController
{
  private static string userIdentification =  SystemInfo.deviceUniqueIdentifier;

  public static bool registerUserDevice() {
    var values = new Dictionary<string, string>
    {
      ["userId"] = userIdentification
    };

    return sendUnityWebRequest(values, ServerURLs.REGISTER_URL);
  }

  public static bool verifyAndSaveUserPurchase(string purchaseToken) {
    var values = new Dictionary<string, string>
    {
      ["userId"] = userIdentification,
      ["purchaseToken"] = purchaseToken
    };

    return sendUnityWebRequest(values, ServerURLs.VERIFY_AND_SAVE_TOKEN_URL);
  }

  public static bool verifyPurchase(string packageName, string productId, string purchaseToken) {
    var values = new Dictionary<string, string>
    {
      ["packageName"] = packageName,
      ["productId"] = productId,
      ["purchaseToken"] = purchaseToken
    };
    return sendUnityWebRequest(values, ServerURLs.VERIFY_PURCHASE_WITH_API_URL);
  }

  private static bool sendUnityWebRequest(Dictionary<string, string> values, string url){
    bool successful = false;
    WWWForm form = new WWWForm();
    foreach(KeyValuePair<string, string> entry in values)
    {
      form.AddField(entry.Key, entry.Value);
    }
    UnityWebRequest uwr = UnityWebRequest.Post(url, form);

    uwr.SendWebRequest();
    while (!uwr.isDone){}
    
    if (uwr.isNetworkError)
    {
      Debug.Log("Error While Sending: " + uwr.error);
    }
    else
    {
      successful = JsonUtility.FromJson<ServerResponseModel>(uwr.downloadHandler.text).success;
    }
    return successful;
  }
}
