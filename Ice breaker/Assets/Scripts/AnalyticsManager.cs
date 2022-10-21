using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// using System.Collections;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;
    // [SerializeField] private string URL = @"https://docs.google.com/forms/d/1sVwYPrYkX4fS6puE_-Oc7hU7ZfxaORwZhxLaNZ2hFK8/formResponse";
    public IDictionary<int, int> level_brick_hit_count = new Dictionary<int, int>();
    public List<int> levels_passed = new List<int>(); // analytics 4
    public IDictionary<int, int> level_death_by_blocker = new Dictionary<int, int>();
    public IDictionary<int, int> level_mishit_count = new Dictionary<int, int>();

    [SerializeField] public string bricks_hit_URL = @"https://docs.google.com/forms/d/e/1FAIpQLScfWoTnNR2rMemOm8u04IPk9L2v4PqGCpQFsoFX9rP72DEmkw/formResponse";   //analytics 1
    [SerializeField] public string lives_cost_URL = @"https://docs.google.com/forms/d/e/1FAIpQLSdFjYCTtZ9w7xv26vLjuowz9moCklnx7pvlE5deEUT345m1CQ/formResponse";   //analytics 2
    [SerializeField] public string time_taken_URL = @"https://docs.google.com/forms/d/e/1FAIpQLSepd_SFA2r9DwdLJ0otSAwnr2XPcqAa_Mhpb37-x7ZpVYumEA/formResponse";   //analytics 3
    [SerializeField] public string max_level_URL = @"https://docs.google.com/forms/d/e/1FAIpQLScluX6ADKCqTm2FTBoLt1ZnWX1659tCMQMsvSf5Et20YExVLw/formResponse";    //analytics 4
    [SerializeField] public string mishit_URL  = @"https://docs.google.com/forms/d/e/1FAIpQLSdS_jiB8V-aAIHab36LTcdZWgrcTuzuEflet-psk0OD2xNTlA/formResponse";                //analytics 5
    [SerializeField] public string death_by_blocker_URL = @"https://docs.google.com/forms/d/e/1FAIpQLSe-jHVQeRA-S237gkAi9AZJSg4lM7svNbt-m1a6LwPcIEZtCg/formResponse";  //analytics 6
    public int _sessionID;


    private void Awake(){
        instance = this;
        _sessionID = Random.Range(0,100000);
        DontDestroyOnLoad(this.gameObject);
    }
    
    //Analytics-1 No of bricks hit in first 20 seconds
    //First 20 seconds logic in GameManager
    public   void brick_hit(int level){  
        int brick_count;
        if(level_brick_hit_count.TryGetValue(level, out brick_count))
        {
            level_brick_hit_count[level] = brick_count + 1;
        }
        else{
            level_brick_hit_count[level] = 1;
        }
    }

    public void process_analytics_one(){
       
        foreach (var item in level_brick_hit_count)
        {
            WWWForm form = new WWWForm();
            form.AddField("entry.1266269878", _sessionID);
            form.AddField("entry.1202470862", item.Key); // level
            form.AddField("entry.258623282", item.Value); // bricks count
            StartCoroutine(Post(form, bricks_hit_URL));
            // Debug.Log(form);
        }
        if (level_brick_hit_count.Count == 0){
             WWWForm form = new WWWForm();
            form.AddField("entry.1266269878", _sessionID);
            form.AddField("entry.1202470862", GameManager.level); // level
            form.AddField("entry.258623282", 0); // bricks count
            StartCoroutine(Post(form, bricks_hit_URL));
        }
        level_brick_hit_count = new Dictionary<int, int>();
    }

    public void process_analytics_two(int lives_cost, int level){
        Debug.Log("timeLeft "+ LevelManager.timeLeft);
        WWWForm form = new WWWForm();
        form.AddField("entry.511485717", _sessionID);
        form.AddField("entry.1011449850", level.ToString());
        form.AddField("entry.816053623", lives_cost.ToString());
        StartCoroutine(Post(form, lives_cost_URL));
    }

    public void process_analytics_three(int time_taken, int level ){
        WWWForm form = new WWWForm();
        form.AddField("entry.427192064", _sessionID.ToString());
        form.AddField("entry.1498674420", level.ToString());
        form.AddField("entry.1509854174", time_taken.ToString());
        // Debug.Log(_sessionID + "Ana-3 time_taken");
        StartCoroutine(Post(form, time_taken_URL));
    }

    public void level_completed(int level){
        levels_passed.Add(level);
    }

    public  void process_analytics_four(int level){
        int max_level = -1;
        foreach(int a in levels_passed){
            max_level = Mathf.Max(a, max_level);
        }

        WWWForm form = new WWWForm();
        form.AddField("entry.261504393", _sessionID);
        form.AddField("entry.346310055", level);
        form.AddField("entry.618082589",max_level);
        StartCoroutine(Post(form, max_level_URL));
        levels_passed = new List<int>(); 
    }

    public    void mishit_capture(int level){
        int mishit;
        if(level_mishit_count.TryGetValue(level, out mishit))
        {
            level_mishit_count[level] = mishit + 1;
        }
        else{
            level_mishit_count[level] = 1;
        }
    }

    public void process_analytics_five(){
         foreach (var item in level_mishit_count)
        {
            WWWForm form = new WWWForm();
            form.AddField("entry.1764438209", _sessionID);
            form.AddField("entry.1170564469", item.Key); // level
            form.AddField("entry.756688492", item.Value); // mishit count
            StartCoroutine(Post(form, mishit_URL));
        }
        level_mishit_count = new Dictionary<int, int>();
    }

    public    void death_by_blocker(int level){
        int death_count;
        if(level_death_by_blocker.TryGetValue(level, out death_count))
        {
            level_death_by_blocker[level] = death_count + 1;
        }
        else{
            level_death_by_blocker[level] = 1;
        }
    }


    public void process_analytics_six(){
        Debug.Log("Inside analytics 6");
         foreach (var item in level_death_by_blocker)
        {
            WWWForm form = new WWWForm();
            form.AddField("entry.1497055636", _sessionID);
            form.AddField("entry.1118183609", item.Key); // level
            form.AddField("entry.254628039", item.Value); // deaths by blocker count
            Debug.Log("Inside analytics 6 about to send req "+ form);
            StartCoroutine(Post(form, death_by_blocker_URL));
        }
        level_death_by_blocker = new Dictionary<int, int>();
    }


    private IEnumerator Post(WWWForm form, string URL)
    {
        // Create the form and enter responses
        // WWWForm form = new WWWForm();
        // form.AddField("entry.1119744781", sessionID);
        // form.AddField("entry.1559713782", levelId);
        // form.AddField("entry.978301150", completed);
        // form.AddField("entry.1147931607", lives);
        // Send responses and verify result
        //  Debug.Log(form.data.ToString());
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            Debug.Log("using Anan 2");
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

}
