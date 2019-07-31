using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_duck : MonoBehaviour {

    public GameObject[] SpawnPnts;
    public float StartTimeWait,MinTime, MaxTime;
    public GameObject Duck_Prefab;

    void Start()
    {
            StartCoroutine(Spawn());     
    }
   IEnumerator Spawn()
    {
        yield return new WaitForSeconds(StartTimeWait);
        while (true)
        {
            
                float randomTime = Random.Range(MinTime, MaxTime);
                int RanPos = Random.Range(0, SpawnPnts.Length);
                if (MainGameController.main.mainGameState == MainGameController.MainGameState.Playing)
                {
                GameObject Duck = Instantiate(Duck_Prefab, SpawnPnts[RanPos].transform.position, SpawnPnts[RanPos].transform.rotation);
                }
                yield return new WaitForSeconds(randomTime);
        }
        }
    
}
