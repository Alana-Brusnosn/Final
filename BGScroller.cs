using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public GameController gamecon;
    private Vector3 startPosition;
    void Start()
    {
        gamecon = gamecon.GetComponent<GameController>();
        startPosition = transform.position;
    }

   
    void Update()
    {
        switch (gamecon.winstars)
        {
            case true:
                scrollSpeed = 100;
                break;
        }

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
       

    }
}
