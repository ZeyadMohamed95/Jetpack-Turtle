using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        MainGameController.main.LoadMainScene();
        UnityAdsPlacement.instance.ShowBanner();
        FindObjectOfType<AudioManger>().Stop();
        FindObjectOfType<AudioManger>().Play("GamePlay");
       
    }
}
