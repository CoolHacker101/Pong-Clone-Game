using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    //create GameObject variable to place the Ball prefab
    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //instantiate a new ball if there isn't a ball in the scene
        if (GameObject.Find("Ball(Clone)") == null)
        {
        Instantiate(ball);
        }
    }
    
}