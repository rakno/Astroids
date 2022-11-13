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
    private int Level_No=1;
    private int IncreasingAstroCountBy = 3;

    public Text ScoreText;
    public Text LivesText;
    public Text LevelText;
    public Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        LiveScore = 0;
        LifeLine = 3;
        Level_No = 1;

        CreateAstro();
        //ScoreText.text= "SCORE: "+ LiveScore;
        //HighScoreText.text= "HIGH SCORE: "+ HighScore ;
        //LivesText.text= "LIVES: "+ LifeLine;
        //LevelText.text = "LEVEL: " + Level_No;
    }


    void CreateAstro()
    {
        DestroyAstro();
        astroRemainingCount = Level_No * IncreasingAstroCountBy;

        for (int i = 0; i < astroRemainingCount; i++)
        {
            Instantiate(astro, 
              new Vector3(Random.Range(0.5f, 22.3f), Random.Range(0.5f, 12.5f),0),
               Quaternion.Euler(0, 0,Random.Range(0,359)));
            
        }


    }
    void DestroyAstro()
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


    
}
