using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectHolder : MonoBehaviour {

    public GameObject Con;
    public GameObject GameoverMenu;
    public TurtleControl turt;
    public GameData data;
    public Text no_stars_text;
    public Text no_Magnets_text;
    public Text no_Shrooms_text;
    public Text no_Crystal_Text;

    public GameObject Star, Magnet,Shroom;
	// Use this for initialization

   void	Update()
    {
        no_stars_text.text = MainGameController.main.no_Stars.ToString();
        no_Magnets_text.text = MainGameController.main.no_magnets.ToString();
        no_Shrooms_text.text = MainGameController.main.no_Shrooms.ToString();
        no_Crystal_Text.text = MainGameController.main.TotalCrystals.ToString();
       if(MainGameController.main.no_magnets==0)
       {
           Magnet.GetComponent<Image>().color = new Color32(255,0,0,100);
           Magnet.GetComponent<Button>().enabled = false;
           if (!Magnet.GetComponent<CoolDownScipt>().OnCooldown)
           {
               Magnet.GetComponent<CoolDownScipt>().enabled = false;
           }
       }
       if (MainGameController.main.no_Stars == 0)
       {
           Star.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
           Star.GetComponent<Button>().enabled = false;
           if (!Star.GetComponent<CoolDownScipt>().OnCooldown)
           {
               Star.GetComponent<CoolDownScipt>().enabled = false;
           }
       }
       if (MainGameController.main.no_Shrooms == 0)
       {
           Shroom.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
           Shroom.GetComponent<Button>().enabled = false;
           if (!Shroom.GetComponent<CoolDownScipt>().OnCooldown)
           {
               Shroom.GetComponent<CoolDownScipt>().enabled = false;
           }
       }
    }
	// Update is called once per frame
	public void SetConActive () 
    {
        Con.SetActive(true);
	}
    public void SetGOMActive()
    {
        GameoverMenu.SetActive(true);
    }
    public void SummingCoins(MainGameController main)
    {
        MainGameController.main.TotalCoins += TurtleControl.CoinsCollected;
        MainGameController.main.TotalCrystals += TurtleControl.CrystalsCollected;
       
        data.Coins = main.TotalCoins;
        data.Crystals = main.TotalCrystals;
        SaveSystem.SavePlayer(main);
    }
}
