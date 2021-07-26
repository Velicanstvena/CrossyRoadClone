using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;
    [SerializeField] private Text coinsText;
    private int coins;

    private int highScore;
    private int totalCoins;

    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas deathCanvas;
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Text finalCoinsText;
    [SerializeField] private Text highScoreText;

    private bool canPress;


    void Start()
    {
        deathCanvas.gameObject.SetActive(false);
        highScore = PlayerPrefsController.GetHighScore();
        totalCoins = PlayerPrefsController.GetTotalCoins();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        coinsText.text = coins.ToString();
    }

    public void AddScore()
    {
        score++;
    }

    public void DecreaseScore()
    {
        score--;
    }

    public void CollectCoin()
    {
        coins++;
    }

    private void SaveData()
    {
        if (highScore < score) PlayerPrefsController.SetHighScore(score);
        PlayerPrefsController.SetTotalCoins(totalCoins + coins);
    }

    public IEnumerator DisplayResults()
    {
        gameCanvas.gameObject.SetActive(false);
        deathCanvas.gameObject.SetActive(true);

        finalScoreText.text = "Score: " + score.ToString();
        finalCoinsText.text = "Coins: " + coins.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();

        SaveData();

        Time.timeScale = 0.3f;

        yield return new WaitForSeconds(3);

        Debug.Log("Can press");

        while (!Input.anyKey)
            yield return null;

        Debug.Log("A key or mouse click has been detected");
        FindObjectOfType<LevelLoader>().ReloadScene();
    }
}
