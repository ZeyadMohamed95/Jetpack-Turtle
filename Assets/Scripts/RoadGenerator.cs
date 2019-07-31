using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public Transform MiddleGround;
    public Transform LeftGround;
    public Transform RightGround;
    public Transform Crate;
    public int numberofObjects;
    public Vector2 startPosition;
    public float recycleOffset;
    public float HighGroundHeight;
    

    public List<GameObject> ForestGrounds;
    public List<GameObject> DesertGrounds;
    public List<GameObject> SnowGrounds;
    public List<GameObject> GraveyardGrounds;
    public List<GameObject> ForestObjects;
    public List<GameObject> DesertObjects;
    public List<GameObject> SnowObjects;
    public List<GameObject> GraveyardObjects;
    public List<GameObject> CoinStacks;
    public List<GameObject> CrateStacks;

    public TurtleControl turtle;

    [Range(0,1)]
    public float SpawnCratePercentage,SpawnObjectPer,spawnInteractablePer;
    private float MinSpawnDistance=20.0f;
    private Vector2 nextPosition;
    private Vector2 NewHighGround;
    private bool HoleSpawned = false, LGround = false,HGround = false;
    private delegate void SpawnGroundMethod();
    private delegate GameObject SpawnInteractable();
    private List<SpawnGroundMethod> spawnGround = new List<SpawnGroundMethod>();
    private List<SpawnInteractable> Spawninter = new List<SpawnInteractable>();
    private LevelGenerator lvlgen;
    private float PieceScale;
    private float distanceBetweenObjects=6f,objectPosition;
    private float distanceBetweenInteractable = 8f, InteractablePosition;
    // Use this for initialization
    void Awake()
    {     
        spawnGround.Add(SpawnLowGround);
        spawnGround.Add(SpawnHole);
        spawnGround.Add(SpawnHighGround);

        Spawninter.Add(SpawnCrates);
        Spawninter.Add(SpawnCoins);

        lvlgen = turtle.GetComponent<LevelGenerator>();
        PieceScale = ForestGrounds[2].transform.localScale.x;
        objectPosition = turtle.gameObject.transform.position.x;
        InteractablePosition = turtle.gameObject.transform.position.x;
    }
    void Start()
    {
        nextPosition = startPosition;
        NewHighGround.x = startPosition.x;
        NewHighGround.y =nextPosition.y+HighGroundHeight;
        for (int i = 0; i < numberofObjects; i++)
        {
            Transform obj = (Transform)Instantiate(MiddleGround);
            obj.localPosition = nextPosition;
            nextPosition.x += obj.localScale.x;
            NewHighGround.x += obj.localScale.x;
            //MidobjectQueue.Enqueue(obj);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextPosition.x - TurtleControl.distanceTraveled < MinSpawnDistance)
        {
            spawnGround[Random.Range(0, 3)]();
        }
        //if (MidobjectQueue.Peek().localPosition.x + recycleOffset < TurtleControl.distanceTraveled)
        //{
        //    Transform o = MidobjectQueue.Dequeue();
        //    o.localPosition = nextPosition;
        //    nextPosition.x += o.localScale.x;
        //    MidobjectQueue.Enqueue(o);
        //}
    }
    void SpawnLowGround()
    {
        if (!LGround)
        {
            int RanNum = Random.Range(10, 25);
            List<GameObject> SpawnGr = ToBeSpawned();  
            for (int i = 0; i < RanNum; i++)
            {
                if (i == 0)
                {
                    GameObject Leftobj = (GameObject)Instantiate(SpawnGr[0]);
                    Leftobj.transform.localPosition = nextPosition;
                    nextPosition.x += PieceScale;
                    NewHighGround.x += PieceScale;
            
                    //  LeftobjectQueue.Enqueue(Leftobj);
                }
                else if (i == RanNum - 1)
                {
                    GameObject Rightobj =  (GameObject)Instantiate(SpawnGr[1]);
                    Rightobj.transform.localPosition = nextPosition;
                    nextPosition.x += PieceScale;
                    NewHighGround.x += PieceScale;
                    // RightdobjectQueue.Enqueue(Rightobj);

                }
                else
                //if (MidobjectQueue.Peek().localPosition.x + recycleOffset < TurtleControl.distanceTraveled)
                {
                    GameObject obj = (GameObject)Instantiate(SpawnGr[2]);
                    obj.transform.localPosition = nextPosition;
                    if (Random.value <= SpawnCratePercentage)
                    {
                       
                    }
                    if(Random.value <= SpawnObjectPer)
                    {
                        SpawnObject(obj.transform);
                    }
                    if (Random.value <= spawnInteractablePer)
                    {
                        SpawnInteractables(obj.transform);
                    }
                  //  GenerateCrate(nextPosition);
                    nextPosition.x += PieceScale;
                    NewHighGround.x += PieceScale;
                    
                  //  MidobjectQueue.Enqueue(obj);
                }
            }
            HoleSpawned = false;
            LGround = true;
            HGround = false;
        }
    }
    void SpawnHole()
    {
        if (!HoleSpawned)
        {
            int RanNum = Random.Range(4, 9);
            for (int i = 0; i < RanNum; i++)
            {
                nextPosition.x += PieceScale;
                NewHighGround.x += PieceScale;
            }
            HoleSpawned = true;
            LGround = false;
            HGround = false;
        }
    }
    void SpawnHighGround()
    {

        if (!HGround)
        {
            int RanNum = Random.Range(10, 25);
            List<GameObject> SpawnGr = ToBeSpawned();  
            for (int i = 0; i < RanNum; i++)
            {
                if (i == 0)
                {
                    GameObject Leftobj = (GameObject)Instantiate(SpawnGr[0]);
                    Leftobj.transform.localPosition = NewHighGround;
                    nextPosition.x += PieceScale;
                    NewHighGround.x += PieceScale;
                    //  LeftobjectQueue.Enqueue(Leftobj);
                }
                else if (i == RanNum - 1)
                {
                    GameObject Rightobj = (GameObject)Instantiate(SpawnGr[1]);
                    Rightobj.transform.localPosition = NewHighGround;
                    nextPosition.x += PieceScale;
                    NewHighGround.x += PieceScale;

                    // RightdobjectQueue.Enqueue(Rightobj);
                }
                else
                //if (MidobjectQueue.Peek().localPosition.x + recycleOffset < TurtleControl.distanceTraveled)
                {
                    GameObject obj = (GameObject)Instantiate(SpawnGr[2]);
                    obj.transform.localPosition = NewHighGround;
                    if (Random.value <= SpawnCratePercentage)
                    {

                    }
                    if (Random.value <= SpawnObjectPer)
                    {
                        SpawnObject(obj.transform);
                    }
                    if (Random.value <= spawnInteractablePer)
                    {
                        SpawnInteractables(obj.transform);
                    }
                    nextPosition.x += PieceScale;
                    NewHighGround.x += PieceScale;
                   // MidobjectQueue.Enqueue(obj);
                    
                }
            }
            HoleSpawned = false;
            LGround = false;
            HGround = true;
        }
    }
    //void GenerateCrate(Vector2 Ground)
    //{
    //    Ground.y += 4f;
    //    int RanNum = Random.Range(1, 7);
    //    for(int i =0; i<RanNum; i++)
    //    {
    //        Transform CrateObj = (Transform)Instantiate(Crate);
    //        CrateObj.localPosition = Ground;
    //        Ground.y += CrateObj.localScale.y;
    //    }
    //}
    List<GameObject> ToBeSpawned()
    {
        List<GameObject> ToSpawnGround;
        if(lvlgen.CA==LevelGenerator.CurrentArea.Forest)
        {
            ToSpawnGround = ForestGrounds;
            return ToSpawnGround;
        }
        else if (lvlgen.CA == LevelGenerator.CurrentArea.Desert)
        {
            ToSpawnGround = DesertGrounds;
            return ToSpawnGround;
        }
        else  if (lvlgen.CA == LevelGenerator.CurrentArea.Snow)
        {
            ToSpawnGround = SnowGrounds;
            return ToSpawnGround;
        }
        
        else
        {
            return null;
        }

    }
    void SpawnObject(Transform Ground)
    {
        
        List<GameObject> ObjSp;
        ObjSp = ToSpawnObject();
        GameObject currentObj = ObjSp[Random.Range(0, ObjSp.Count)];
        if (Mathf.Abs(objectPosition - Ground.localPosition.x) >= distanceBetweenObjects)
        {
            GameObject SpawnedObj = (GameObject)Instantiate(currentObj);
            SpawnedObj.transform.position = Ground.localPosition + new Vector3(0f, Ground.localScale.y / 2, 0f);
            objectPosition = Ground.localPosition.x;
        }
    }
    
    void SpawnInteractables(Transform Ground)
    {
        GameObject objToSpawn = Spawninter[Random.Range(0, Spawninter.Count)]();
        if (Mathf.Abs(InteractablePosition - Ground.localPosition.x) >= distanceBetweenInteractable)
        {
            GameObject SpawnedObj = (GameObject)Instantiate(objToSpawn);
            SpawnedObj.transform.position = Ground.localPosition + new Vector3(0f, Ground.localScale.y / 2, 0f);
            InteractablePosition = Ground.localPosition.x;
        }
    }
    GameObject SpawnCrates()
    {
        GameObject CrateStack = CrateStacks[Random.Range(0, CrateStacks.Count)];
        return CrateStack;
    }
    GameObject SpawnCoins()
    {
        GameObject CoinStack = CoinStacks[Random.Range(0, CoinStacks.Count)];
        return CoinStack;
    }
    List<GameObject> ToSpawnObject()
    {
        List<GameObject> ToSpawnObjects;
        if (lvlgen.CA == LevelGenerator.CurrentArea.Forest)
        {
            ToSpawnObjects = ForestObjects;
            return ToSpawnObjects;
        }
        else if (lvlgen.CA == LevelGenerator.CurrentArea.Desert)
        {
            ToSpawnObjects = DesertObjects;
            return ToSpawnObjects;
        }
        else if (lvlgen.CA == LevelGenerator.CurrentArea.Snow)
        {
            ToSpawnObjects = SnowObjects;
            return ToSpawnObjects;
        }
       
        else
        {
            return null;
        }

    }
}