using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GameObject pickups;

    public Text ScoreText;
    private int score;
    public Text gameOverText;
    public Text restartText;
    public Text winText;

    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    private GameObject other;
    private bool gameOver;
    private bool restart;
    public bool winstars;

    void Start()
    {
        hazardCount = 4;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        winstars = false;

    }

    [System.Obsolete]
    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        if (Input.GetKey("Escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)

            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "K to Restart";
                restart = true;
                break;
            }


        }
    }

    public void AddScore(int newScoreValue)

    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winstars = true;
            winText.text = "You win! Game Created By Alana Brunson";
            restart = true;
            musicSource.clip = musicClipOne;
            musicSource.Play();
            musicSource.loop = false;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
        musicSource.clip = musicClipTwo;
        musicSource.Play();
        musicSource.loop = false;
    }
}
   