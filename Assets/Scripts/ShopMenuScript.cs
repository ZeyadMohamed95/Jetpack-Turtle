using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopMenuScript : MonoBehaviour {
    public int Coins;

    public int Magnet_price;
    public int Star_price;
    public int Shroom_Price;


    public int Magnet_Amount;
    public int Star_Amount;
    public int Shroom_Amount;


    public Text coinText;
    public Text Magnet_Text;
    public Text Star_Text;
    public Text Shroom_Text;

    public Text MagnetAmount_Text;
    public Text StarAmount_Text;
    public Text ShroomAmount_Text;
	void Update () {
        Coins = MainGameController.main.TotalCoins;
        Magnet_Amount = MainGameController.main.no_magnets;
        Star_Amount = MainGameController.main.no_Stars;
        Shroom_Amount=MainGameController.main.no_Shrooms;
        coinText.text = Coins.ToString();
        Star_Text.text = Star_price.ToString();
        Magnet_Text.text = Magnet_price.ToString();
        Shroom_Text.text= Shroom_Price.ToString();
        MagnetAmount_Text.text = "You Have : " + Magnet_Amount.ToString();
        StarAmount_Text.text = "You Have : " + Star_Amount.ToString();
        ShroomAmount_Text.text="You Have : "+ Shroom_Amount.ToString();
    }
	
}
