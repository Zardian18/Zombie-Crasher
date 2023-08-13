using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    TextMeshProUGUI bulletCount;
    [SerializeField]
    TextMeshProUGUI score;
    int scoreActual=0;
    [SerializeField]
    GameObject pausePanel;
    [SerializeField]
    GameObject gameOverPanel;
    public bool isAlive = true;
    BackgroundMusic music;
    PlayerController player;
    //public bool gameStarted = false;
    void Start()
    {
        Time.timeScale = 1f;
        UpdateHealth(100);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        isAlive = true;
        music = GameObject.Find("BGM").GetComponent<BackgroundMusic>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (player != null)
        {
            player.PauseAudio(false);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
        if (!isAlive)
        {
            gameOverPanel.SetActive(true);
            player.PauseAudio(true);
            Time.timeScale = 0f;
        }
    }

    public void UpdateHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
        
    }
    public void UpdateBulletCount(int bullet)
    {
        bulletCount.text = bullet.ToString();
    }
    public void UpdateScore(int addScore)
    {
        scoreActual += addScore;
        score.text =scoreActual.ToString();
    }
    public void Resume()
    {
        pausePanel.gameObject.SetActive(!pausePanel.activeSelf);
        music.ToogleMusic(!pausePanel.activeSelf);
        player.PauseAudio(pausePanel.activeSelf);
        if (pausePanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else if (!pausePanel.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
