using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomGameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject upgradePanel;
    public GameObject finPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseClicked()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void OnPlayClicked()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        upgradePanel.SetActive(false);
        
    }
    
    public void OnRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("game_scene");
    }

    public void OnPause()
    {
        Time.timeScale = 0;
    }

    public void WonGame()
    {
        finPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToStartGUI()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("start_gui");
        
    }
}
