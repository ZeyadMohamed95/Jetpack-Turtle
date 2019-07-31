using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinAmount : MonoBehaviour {
    public Text coinText;
    public Text CrystalText;

    public Slider MusicSlider, EffectsSlider;
   
    void Start ()
    {
        if (MainGameController.main != null)
        {
            MusicSlider.value = MainGameController.main.MusicLevel;
            EffectsSlider.value = MainGameController.main.EffectsLevel;
        }
    }
	void Update() {
        if (MainGameController.main != null)
        {
            coinText.text = MainGameController.main.TotalCoins.ToString();
            CrystalText.text = MainGameController.main.TotalCrystals.ToString();
        }
    }
	
	// Update is called once per frame

    //private void CoinUpdate()
    //{
    //    coinText.text = CoinCount.ToString();
    //}
    //public void AddCoins ()
    //{
    //    CoinCount += 20;
    //    coinText.text = CoinCount.ToString();
    
    //}
   
}
