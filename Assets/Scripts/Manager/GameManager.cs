using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool levelWin;
    
    public GameObject gameOverPanel;
    public GameObject levelWinPanel;

    public static int CurrentLevelIdx;
    public static int noOfPassedRings;

    public Text currLevelText;
    public Text nextLevelText;

    public Slider progressBar;

    private void Awake()
    {
        CurrentLevelIdx = PlayerPrefs.GetInt("CurrentLevel",1);
    }

    private void Start()
    {
        Time.timeScale = 1;
        noOfPassedRings = 0;
        isGameOver = false;
        levelWin = false;

        currLevelText.text = CurrentLevelIdx.ToString();
        nextLevelText.text = (CurrentLevelIdx + 1).ToString();
    }

    private void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        progressBar.value = (float)noOfPassedRings / FindFirstObjectByType<HelixSpawnController>().noOfRings;

        if (levelWin)
        {
            levelWinPanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
                CurrentLevelIdx++;
                PlayerPrefs.SetInt("CurrentLevel", CurrentLevelIdx);
                currLevelText.text = CurrentLevelIdx.ToString();
                nextLevelText.text = (CurrentLevelIdx + 1).ToString();
            }
        }
    }
}
