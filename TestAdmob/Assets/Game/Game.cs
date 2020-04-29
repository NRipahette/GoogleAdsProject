using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    Text ScoreText;
    GameObject clickerButton;
    public int Score;
    public int click;
    GoogleInterstitial inter;

    
    // Start is called before the first frame update
    void Start()
    { 
        ScoreText = GameObject.Find("TextScore").GetComponent<Text>();
        clickerButton = GameObject.Find("ClickerButton");
        inter = GameObject.Find("EventSystem").GetComponent<GoogleInterstitial>();
        Score = 0;
        click = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ""+Score;

        if(Score>= 10)
        {
            inter.ShowInter();
        }
    }

    public void clicked()
    {
        Score += click;
    }

    public void upgradeClick()
    {
        click *= 15;
    }
}
