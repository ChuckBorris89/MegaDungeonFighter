using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject upgradePanel;
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
}
