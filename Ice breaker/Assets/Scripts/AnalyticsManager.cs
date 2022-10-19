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
    
    public void Send(int level, int complete, int lives)
    {
        _levelId = level;
        _completed = complete;
        // StartCoroutine(Post(_sessionID.ToString(), _levelId.ToString(), _completed.ToString(), lives.ToString()));
    }
    public void Send2(int level)
    {
        _levelId = level;
        // StartCoroutine(Post2(_sessionID.ToString(), _levelId.ToString()));
    }
    private IEnumerator Post(string sessionID, string levelId, string completed, string lives)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.1119744781", sessionID);
        form.AddField("entry.1559713782", levelId);
        form.AddField("entry.978301150", completed);
        form.AddField("entry.1147931607", lives);
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

    private IEnumerator Post2(string sessionID, string levelId)
    {
        string url2 = @"https://docs.google.com/forms/d/e/1FAIpQLSekO5H88I6NQW9SlL_z5QD3F_JrSyAzd_l1Rs25voHCmIN9Sw/formResponse";
        WWWForm form = new WWWForm();
        form.AddField("entry.129703209", sessionID);
        form.AddField("entry.1248466397", levelId.ToString());
        
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
