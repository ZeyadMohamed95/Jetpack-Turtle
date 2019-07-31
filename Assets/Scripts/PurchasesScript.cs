using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasesScript : MonoBehaviour {

    ShopMenuScript SMS;
    GameData data;
    void Awake()
    {
        SMS = GetComponent<ShopMenuScript>();
    }
   public void PurchaseMagnet()
    {
        if (MainGameController.main.TotalCoins>= SMS.Magnet_price)
        {
            MainGameController.main.TotalCoins -= SMS.Magnet_price;
            MainGameController.main.no_magnets++;
            MainGameController.main.saveData();
        }
    }
   public void PurchaseStar()
   {
       if (MainGameController.main.TotalCoins >= SMS.Star_price)
       {
           MainGameController.main.TotalCoins -= SMS.Star_price;
           MainGameController.main.no_Stars++;
           MainGameController.main.saveData();
       }
   
   }
   public void PurchaseShroom()
   {
       if (MainGameController.main.TotalCoins >= SMS.Shroom_Price)
       {
           MainGameController.main.TotalCoins -= SMS.Shroom_Price;
           MainGameController.main.no_Shrooms++;
           MainGameController.main.saveData();
       }
   }

}
