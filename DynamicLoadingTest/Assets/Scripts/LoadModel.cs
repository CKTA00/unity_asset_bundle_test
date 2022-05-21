using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadModel : MonoBehaviour
{
    public void GetBundleObject(string filePath, UnityAction<GameObject> callback, Transform bundleParent)
    {
        StartCoroutine(GetDisplayBundleRoutine(filePath, callback, bundleParent));
    }

    IEnumerator GetDisplayBundleRoutine(string filePath, UnityAction<GameObject> callback, Transform bundleParent)
    {
        Debug.Log("Hello");

        // file:///C://Test//obelisk.blend

        string bundleURL = "file:///" + filePath;

        Debug.Log("Requesting bundle at " + bundleURL);

        //request asset bundle
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL);
        yield return www.SendWebRequest();

        if(www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError("Connection error");
        }
        else if (www.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.LogError("data processing error");
        }
        else if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Protocol error");
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            if (bundle != null)
            {
                string rootAssetPath = bundle.GetAllAssetNames()[0];
                GameObject loadedObject = Instantiate(bundle.LoadAsset(rootAssetPath) as GameObject, bundleParent);
                bundle.Unload(false);
                callback(loadedObject);
            }
            else
            {
                Debug.LogError("Not a valid asset bundle");
            }
        }


    }


}
