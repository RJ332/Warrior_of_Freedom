using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerTalker : MonoBehaviour
{
    // Start is called before the first frame update
    private string url = "http://localhost:3000/" ;
    void Start()
    {
        
        // Make a web request to get info from the server 
        // this will be a text response
        // This will return/continue IMMEDIATELY, but the coroutine
        // wiill take several MS to actually get a response from the server.

        StartCoroutine( GetWebData(url, "users/") );
        StartCoroutine(Upload());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetWebData( string address, string myID)
    {
        UnityWebRequest www = UnityWebRequest.Get(address + myID);
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Something went wrong:  "  + www.error);
        } else {
            Debug.Log( www.downloadHandler.text);
        }
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("test", "RJ332");
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}