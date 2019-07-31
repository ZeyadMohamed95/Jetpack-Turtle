using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public TurtleControl inst;
	
	// Update is called once per frame
	void Update () {

        if (MainGameController.main.mainGameState == MainGameController.MainGameState.GameOver)
        {
            inst.speed = Mathf.Lerp(inst.speedOriginal, 0, 1f);
            //inst.speedOriginal = Mathf.Lerp(inst.speedOriginal, 0, 1);
        }
        if(MainGameController.main.mainGameState==MainGameController.MainGameState.Playing||MainGameController.main.mainGameState == MainGameController.MainGameState.Died||MainGameController.main.mainGameState == MainGameController.MainGameState.Reviving)
        {
            transform.Translate(inst.speed * Time.deltaTime, 0f, 0f);
        }

        }
        
}
