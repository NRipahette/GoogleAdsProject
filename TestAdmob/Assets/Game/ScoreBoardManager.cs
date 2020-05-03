using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    public long ScoreToPost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PostToLeaderBoard()
    {
        ScoreToPost = GetComponent<Game>().Score;
        PlayGamesController.PostToLeaderboard(ScoreToPost);
    }

    public void ShowLeaderBoard()
    {
        PlayGamesController.ShowLeaderboard();
    }
}
