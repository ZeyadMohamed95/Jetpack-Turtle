using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerUp : MonoBehaviour {

    public GameObject[] PowerUp;
    public GameObject Player;

    public void ActivateStar()
    {
        if (MainGameController.main.no_Stars > 0)
        {
            GameObject obj = (GameObject)Instantiate(PowerUp[0]);
            obj.transform.position = Player.transform.position;
            MainGameController.main.no_Stars--;
        }
    }
    public void ActivateMagnet()
    {
        if (MainGameController.main.no_magnets > 0)
        {
            GameObject obj = (GameObject)Instantiate(PowerUp[1]);
            obj.transform.position = Player.transform.position;
            MainGameController.main.no_magnets--;
        }
    }
    public void ActivateShroom()
    {
        if (MainGameController.main.no_Shrooms > 0)
        {
            GameObject obj = (GameObject)Instantiate(PowerUp[2]);
            obj.transform.position = Player.transform.position;
            MainGameController.main.no_Shrooms--;
        }
    }
}
