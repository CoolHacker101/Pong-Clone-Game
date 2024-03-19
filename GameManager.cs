using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    //score variables, to be accessed in the Ball script as well
    public int score1;
    public int score2;
    
    //Text variables. We are able to use these because we told the computer we are using the UnityEngine.UI and TMPro librairies
    public TMP_Text scoreOneText;
    public TMP_Text scoreTwoText;
    public TMP_Text winnerText;

    //create a GameObject for the ballSpawner because we will have to turn it off when a player wins
    public GameObject ballSpawner;

    //Singleton allows the access to variables from this script in other scripts
    #region SingletonDeclaration 
    private static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance; //that's just a singleton as the region says
    }

    void Awake() //this happens before the game even starts and it's a part of the singleton
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            //DontDestroyOnLoad(this);
            instance = this;
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        //assign the score text variables with the actual scores, convert them to strings to be displayed as text
        scoreOneText.text = score1.ToString();
        scoreTwoText.text = score2.ToString();

        //determine the winner - first player to get 11 points wins
        // The ' || ' symbol means OR. 
        if(score1 == 11 || score2 == 11)
        {
            //when the player wins, the ball spawner needs to be turned off, using SetActive function
            ballSpawner.SetActive(false);
            
            if(score1 == 11)
            {
                Debug.Log("Player one wins");
                winnerText.text = "Player 1 wins!";
            }

            if (score2 == 11)
            {
                Debug.Log("Player two wins");
                winnerText.text = "Player 2 wins!";
            }
        }
    }
}