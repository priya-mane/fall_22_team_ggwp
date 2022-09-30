using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
// using System.Collections;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    [SerializeField] private string URL = @"https://docs.google.com/forms/d/1sVwYPrYkX4fS6puE_-Oc7hU7ZfxaORwZhxLaNZ2hFK8/formResponse";
    public int _sessionID;
    private int _levelId;
    private int _completed ;
    public int ballReset =0;

    private void Awake(){
        instance = this;
        _sessionID = Random.Range(0,100000);
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void Send(int level, int complete)
    {
        _levelId = level;
        _completed = complete;
        StartCoroutine(Post(_sessionID.ToString(), _levelId.ToString(), _completed.ToString()));
    }
    public void Send2(int level, int bricks)
    {
        _levelId = level;
        StartCoroutine(Post2(_sessionID.ToString(), _levelId.ToString(), bricks));
    }
    private IEnumerator Post(string sessionID, string levelId, string completed)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.1119744781", sessionID);
        form.AddField("entry.1559713782", levelId);
        form.AddField("entry.978301150", completed);
        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
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

    private IEnumerator Post2(string sessionID, string levelId, int bricks )
    {
        string url2 = @"https://docs.google.com/forms/d/e/1FAIpQLScz7lvjsuysxh04EtFZksBaAQ73MFVlr_wlKz-s34Pwnf1xVQ/formResponse";
        WWWForm form = new WWWForm();
        form.AddField("entry.908848918", sessionID);
        form.AddField("entry.1907133741", levelId.ToString());
        form.AddField("entry.1724795905", bricks.ToString());
        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(url2, form))
        {
        yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
            Debug.Log(www.error);
            }
            else
            {
            Debug.Log("Form2 upload complete!");
            }
        }
    }
}
