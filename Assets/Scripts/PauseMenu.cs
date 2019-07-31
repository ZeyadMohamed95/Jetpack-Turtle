using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour 
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        //enable the scripts again
    }
    public void ReloadLevel()
    {
        MainGameController.main.LoadMainScene();
        ContinueGame();
    }
    public void ReturnToMain()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.UnloadScene(scene.buildIndex);
        SceneManager.LoadScene("MenuScene");
        FindObjectOfType<AudioManger>().Stop();
        FindObjectOfType<AudioManger>().Play("Menu");
    
        ContinueGame();
    }
}
