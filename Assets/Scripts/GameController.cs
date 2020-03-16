using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject startUI;
    public GameObject inGameUI;
    public Text scoreText;
    public GameObject gameOverObject;
    public Rigidbody2D[] envRigid;
    private bool isGameOver = false;
    private int score = 0;
    public Rigidbody2D playerRigid;
    public bool isInMenu = true;
    private float scrollSpeed = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        TogglePauseGame();
    }

    void Update()
    {
        if (IsGamePaused() && Input.GetMouseButtonDown(0)) { TogglePauseGame(); }

        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool IsGamePaused()
    {
        return Time.timeScale == 0;
    }

    public void TogglePauseGame()
    {
        bool isPaused = Time.timeScale == 0;
        Time.timeScale = isPaused ? 1 : 0;
        startUI.SetActive(!isPaused);
        inGameUI.SetActive(isPaused);
    }

    public void PauseGame()
    {
        playerRigid.isKinematic = true;
        for (int i = 0; i < envRigid.Length; i++)
        {
            envRigid[i].velocity = Vector2.zero;
        }
    }

    public void UnPauseGame()
    {
        playerRigid.isKinematic = false;
        for (int i = 0; i < envRigid.Length; i++)
        {
            envRigid[i].velocity = new Vector2(scrollSpeed, 0);
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverObject.SetActive(true);
    }

    public void PlayerScored()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
