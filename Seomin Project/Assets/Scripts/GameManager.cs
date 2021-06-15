using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text highScoreText = null;
    [SerializeField]
    private Text lifeText = null;
    [SerializeField]
    private GameObject meteor;

    private float healingChance = 0;
    public Vector2 minPosition { get; private set; }
    public Vector2 maxPosition { get; private set; }
    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        minPosition = new Vector2(-2.4f, -5.5f);
        maxPosition = new Vector2(2.4f, 5f);
        StartCoroutine(SpawnMeteor());
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
        UpdateUI();
    }
    public void Dead()
    {
        life--;
        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        UpdateUI();
    }
    public void UpdateUI()
    {
        lifeText.text = string.Format("Life: {0}", life);
        scoreText.text = string.Format("Score: {0}", score);
        highScoreText.text = string.Format("HighScore: {0}", highScore);
    }
    private IEnumerator SpawnMeteor()
    {
        int randomX = 0;
        float randomDelay = 0f;
        int phase = 0;
        while (true)
        {
            if(phase < 10)
                randomDelay = Random.Range(2f, 3f);
            else if (phase < 25)
                randomDelay = Random.Range(1.5f, 2f);
            else if (phase < 50)
                randomDelay = Random.Range(1f, 2f);
            else if (phase < 100)
                randomDelay = Random.Range(1f, 1.5f);
            else
                randomDelay = Random.Range(0.5f, 1f);
            for (int j = 0; j < 4; j++)
            {
                randomX = Random.Range(-2, 3);
                Instantiate(meteor, new Vector2(randomX, 5f), Quaternion.identity);
                phase++;
            }
            yield return new WaitForSeconds(randomDelay);
        }
    }
    public void Heal()
    {
        healingChance = Random.Range(0f, 10f);
        if(healingChance < 1f)
        {
            life++;
            UpdateUI();
        }
    }
}

