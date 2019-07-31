//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class ShopMenu : MonoBehaviour
//{
//    public CoinAmount coin;
//    public int Star = 0;
//    public int Blaster = 0;
//    public int Magnet = 0;
//    public int Cost1;
//    public int Cost2;
//    public int Cost3;
//    public Text StarText;
//    public Text BlasterText;
//    public Text MagnetText;
    
//    // Use this for initialization
//    void Start()
//    {
//        CoinAmount.CoinCount = PlayerPrefs.GetInt("Coins,0");
//        Star = PlayerPrefs.GetInt("item1", 0);
//        Blaster = PlayerPrefs.GetInt("item2", 0);
//        Magnet = PlayerPrefs.GetInt("item3", 0);
//    }

//    // Update is called once per frame
//    void UpdateStarsText()
//    {
//        StarText.text = Star.ToString();
//    }
//    void UpdateBlasterText()
//    {
//        BlasterText.text = Blaster.ToString();
//    }
//    void UpdateMagnetsText()
//    {
//        MagnetText.text = Magnet.ToString();
//    }
//    public void BuyStars()
//    {
//        if(CoinAmount.CoinCount>=Cost1)
//        {
//            CoinAmount.CoinCount -= Cost1;
//            Star++;
//            UpdateStarsText();
//        }
//    }
//    public void BuyBlaster()
//    {
//        if (CoinAmount.CoinCount >= Cost2)
//        {
//            CoinAmount.CoinCount -= Cost2;
//            Blaster++;
//            UpdateBlasterText();
//        }
//    }
//    public void BuyMagnets()
//    {
//        if (CoinAmount.CoinCount >= Cost3)
//        {
//            CoinAmount.CoinCount -= Cost3;
//            Magnet++;
//            UpdateMagnetsText();
//        }
//    }
//    void OnDestroy()
//    {
//        PlayerPrefs.SetInt("Star", Star);
//        PlayerPrefs.SetInt("Blaster", Blaster);
//        PlayerPrefs.SetInt("Magnet", Magnet);
//        PlayerPrefs.SetInt("Coins", CoinAmount.CoinCount);
//        PlayerPrefs.Save();
//    }
//}