using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{

    public GameObject astro;
    private int LiveScore;
    private int HighScore;
    private int astroRemainingCount;
    private int LifeLine;
    private int Level_No;
    private int IncreasingAstroCountBy = 3;

    public AudioSource winSound;
    public AudioSource loseSound;
    AudioSource RocketBlast;

    public Text ScoreText;
    public Text LivesText;
    public Text LevelText;
    public Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        RocketBlast= gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void StartGame()
    {
        LiveScore = 0;
        LifeLine = 3;
        Level_No = 1;

        ScoreText.text= "SCORE: "+ LiveScore;
        HighScoreText.text= "HIGH SCORE: "+ HighScore ;
        LivesText.text= "LIVES: "+ LifeLine;
        LevelText.text = "LEVEL: " + Level_No;
        CreateAstro();
    }


    public void CreateAstro()
    {
        DestroyAstro();
        astroRemainingCount = Level_No * IncreasingAstroCountBy;

        for (int i = 0; i < astroRemainingCount; i++)
        {
            Instantiate(astro, 
              new Vector3(Random.Range(0.5f, 22.3f), Random.Range(0.5f, 12.5f),0),
               Quaternion.Euler(0, 0,Random.Range(0,359)));
            
        }

        LevelText.text = "LEVEL: " + Level_No;
    }
    public void DestroyAstro()
    {
        GameObject[] LargeAstroids = GameObject.FindGameObjectsWithTag("LargeAstro");

        foreach(GameObject astroLarge in LargeAstroids)
        {
            GameObject.Destroy(astroLarge);
        }

        GameObject[] SmallAstroids = GameObject.FindGameObjectsWithTag("SmallAstro");

        foreach (GameObject astroSmall in SmallAstroids)
        {
            GameObject.Destroy(astroSmall);
        }

    }

    public void ScoreIncrease()
    {
        LiveScore++;
        ScoreText.text = "SCORE:" + LiveScore;
        if(LiveScore>HighScore)
        {
            HighScore = LiveScore;
            HighScoreText.text = "HIGH SCORE: " + HighScore;
        }
        if (astroRemainingCount < 1)
        {
            LifeLine++;
            Level_No++;
           // winSound.Play();
            CreateAstro();
        }

    }

    public void LifeLoss()
    {
        RocketBlast.Play();
        LifeLine--;
        LivesText.text = "LIVES: " + LifeLine;

        if(LifeLine<1)
        {
           // loseSound.Play();
            StartGame();
        }
    }

    public void DestroyingNumberofAstro()
    {
        astroRemainingCount--;
    }

    public void SplitingAstro()
    {
        astroRemainingCount = astroRemainingCount + 2;
    }


    
}
