using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsScript : MonoBehaviour {

	// Use this for initialization
    public Slider EffectsSlider;
    public Slider MusicSlider;
    private AudioManger audioManger;
	
    void Awake()
    {
        audioManger = FindObjectOfType<AudioManger>();
    }
    void Start()
    {
        EffectsSlider.value = MainGameController.main.EffectsLevel;
        MusicSlider.value = MainGameController.main.MusicLevel;
    }
	// Update is called once per frame
	void Update () {
        audioManger.sounds[0].source.volume = MusicSlider.value;
        audioManger.sounds[1].source.volume = MusicSlider.value;
        audioManger.sounds[2].source.volume = MusicSlider.value;
        audioManger.sounds[3].source.volume = EffectsSlider.value;
        audioManger.sounds[4].source.volume = EffectsSlider.value;
        audioManger.sounds[5].source.volume = EffectsSlider.value;
	}
   public void BackPressed()
    {
        SaveSystem.SavePlayer(MainGameController.main);
        MainGameController.main.EffectsLevel = EffectsSlider.value;
        MainGameController.main.MusicLevel = MusicSlider.value;
    }
}
