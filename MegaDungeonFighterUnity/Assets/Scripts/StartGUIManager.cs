using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClose()
    {
        Application.Quit(); 
        
    }

    public void OnStart()
    {
        SceneManager.LoadScene("game_scene");
    }
}
