using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGamesController : MonoBehaviour
{
    public Text mainText;
    public Text feedbackTest;
    public static string text;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        AuthenticateUser();
        feedbackTest = GameObject.Find("FeedBackText").GetComponent<Text>();
    }



    void AuthenticateUser()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                Debug.Log("Logged in to Google Play games Services");
                sendfeedbacktest("Logged in to Google Play games Services");
                //GetComponent<ScoreBoardManager>().ShowLeaderBoard();
            }
            else
            {
                Debug.Log("Error logging in ");
                sendfeedbacktest("Error logging in ");
            }
        });
    }


    #region Achievment
        public static void unlockAchievment(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }
    #endregion /Achievment

    #region Leaderboard
    public static void PostToLeaderboard(long NewScore)
    {
        Social.ReportScore(NewScore, GPGSIds.leaderboard_high_score, (bool success) =>
          {
              if (success)
              {
                  Debug.Log("Score posted");
                  sendfeedbacktest("Score posted");
              }
              else
              {
                  Debug.Log("Error posting");
                  sendfeedbacktest("Error posting" + NewScore);

              }
          });
    }

    public static void ShowLeaderboard()
    {
        
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }

    #endregion /Leaderboard




    public static void sendfeedbacktest ( string text1)
    {
        text = text1;
    }

    // Update is called once per frame
    void Update()
    {
        feedbackTest.text = text;
    }
}
