using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class DataReceiver : MonoBehaviour
{
    public TextMeshPro mText;
    public SystemManager mSystemManager;

    UnityWebRequest GetRequest(string keyword, int id)
    {
        string addr2 = mSystemManager.AppData.Address + "/Load?keyword=" + keyword + "&id=" + id + "&src=" + mSystemManager.User.UserName;
        UnityWebRequest request = new UnityWebRequest(addr2);
        request.method = "POST";
        request.downloadHandler = new DownloadHandlerBuffer();
        //request.SendWebRequest();
        return request;
    }
    UnityWebRequest GetRequest(string keyword, int id, string src)
    {
        string addr2 = mSystemManager.AppData.Address + "/Load?keyword=" + keyword + "&id=" + id + "&src=" + src;
        UnityWebRequest request = new UnityWebRequest(addr2);
        request.method = "POST";
        request.downloadHandler = new DownloadHandlerBuffer();
        //request.SendWebRequest();
        return request;
    }

    void Process(object sender, UdpEventArgs e)
    {
        try
        {
            int size = e.bdata.Length;
            string msg = System.Text.Encoding.Default.GetString(e.bdata);
            UdpData data = JsonUtility.FromJson<UdpData>(msg);
            data.receivedTime = DateTime.Now;
            StartCoroutine(MessageParsing(data));
        }
        catch (Exception ex)
        {
            mText.text = ex.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UdpAsyncHandler.Instance.UdpDataReceived += Process;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MessageParsing(UdpData data)
    {
        yield break;
    }

}
