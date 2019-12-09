using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    public bool pickup;
   

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        bool pickup = false;
    }

    void OnTriggerEnter(Collider other)
    {
       
         if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Pickups")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
              Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
              gameController.GameOver();
            bool pickup = true; 
           
        }

        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}