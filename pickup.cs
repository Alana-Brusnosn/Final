using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    //One other thing is since the power up is a entity in game you may need to look at what all other entities in game are tagged with if you have problems implimenting the movement scripting(RB)
    void OnTriggerEnter(Collider other)
    {
        // if this instead is where you are housing its destruction reaction you may need to impliment some checks to see if it has been hit and if so by what
        if (other.tag == "Pickups")
        {
            return;
        }
        gameController.AddScore(scoreValue);

    }

    void Update()
    {
        
    }
}

