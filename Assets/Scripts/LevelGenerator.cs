using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public float LevelDistance;
    //public List<Transform> Middle,Left,Right=new List<Transform>();
    //public float TranslateSpeed=3.0f;
    //private Vector2 BGPos;
    //private RoadGenerator RoadGenInst;
    //private GameObject BGS;
    //private int index=0;
    //bool IndexChanged = true;
  
    public GameObject[] availableRooms;
    public List<GameObject> currentRooms;
    public GameObject Barrier_1, Barrier_2;
    private float screenWidthInPoints;
    private bool barrier_1_spawned=false, barrier_2_spawned=false;
    public enum CurrentArea
    {
        Forest,
        Desert,
        Snow
    }
   public CurrentArea CA;
	// Use this for initialization
	void Awake () {
         CA= CurrentArea.Forest;
    //    RoadGenInst = GetComponent<RoadGenerator>();
    //    BGS=GameObject.FindGameObjectWithTag("BGs");
    //    BGPos = BGS.transform.localPosition;
    }
	void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
        StartCoroutine(GeneratorCheck());
    }

	// Update is called once per frame
	void Update () {
       ChangeLevel();
        //if (!IndexChanged)
        //{
        //    RoadGenInst.LeftGround = Left[(index + 1)];
        //    RoadGenInst.MiddleGround = Middle[index + 1];
        //    RoadGenInst.RightGround = Right[index + 1];
        //    IndexChanged = true;
        //}
    // if (TurtleControl.distanceTraveled>=LevelDistance)
    //    {
    //        //float distance=TurtleControl.distanceTraveled;
    //        //Debug.Log(LevelDistance);
            
    //        BGS.transform.Translate(Vector3.right*TranslateSpeed *-1.0f* Time.deltaTime);
    //        if (BGS.transform.localPosition.x <= BGPos.x-20.0f)
    //        {
                
    //            BGPos = BGS.transform.localPosition;
    //            LevelDistance +=LevelDistance;
    //            IndexChanged = false;
    //        }
    //    }
		
    }
    void AddBG(float farthestRoomEndX)
    {
        //1
        int randomRoomIndex = Random.Range(0, availableRooms.Length);
        //2
        GameObject room = ChooseBG();
        GameObject Barr= SpawnBarriers();
        //3
        float roomWidth = 15f;
        //4
        float roomCenter = farthestRoomEndX + roomWidth * 0.5f;
        //5
        if (Barr != null)
        {
            Barr.transform.position = new Vector3(farthestRoomEndX, -4.4f, 1f);
        }
        room.transform.position = new Vector3(roomCenter, 1, 5);
        //6
        currentRooms.Add(room);
    }
    GameObject ChooseBG()
    {
        if(CA==CurrentArea.Forest)
        {
         GameObject ChosenRoom=(GameObject)Instantiate(availableRooms[0]);
         return ChosenRoom; 
        }
        else if (CA == CurrentArea.Desert)
        {
            GameObject ChosenRoom = (GameObject)Instantiate(availableRooms[1]);
            
            return ChosenRoom;
        }
        else if (CA == CurrentArea.Snow)
        {
            GameObject ChosenRoom = (GameObject)Instantiate(availableRooms[2]);
            
            return ChosenRoom;
        }
        else
        {
            return null;
        }
    }
    private void GenerateRoomIfRequired()
    {
        //1
        List<GameObject> roomsToRemove = new List<GameObject>();
        //2
        bool addRooms = true;
        //3
        float playerX = transform.position.x;
        //4
        float removeRoomX = playerX - screenWidthInPoints;
        //5
        float addRoomX = playerX + screenWidthInPoints;
        //6
        float farthestRoomEndX = 0;
        foreach (var room in currentRooms)
        {
            //7
            float roomWidth = 15f;
            float roomStartX = room.transform.position.x - (roomWidth * 0.5f);
            float roomEndX = roomStartX + roomWidth;
            //8
            if (roomStartX > addRoomX)
            {
                addRooms = false;
            }
            //9
            if (roomEndX < removeRoomX)
            {
                roomsToRemove.Add(room);
            }
            //10
            farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
        }
        //11
        foreach (var room in roomsToRemove)
        {
            currentRooms.Remove(room);
            Destroy(room);
        }
        //12
        if (addRooms)
        {
            AddBG(farthestRoomEndX);
        }
    }
    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            GenerateRoomIfRequired();
            yield return new WaitForSeconds(0.25f);
        }
    }
    void ChangeLevel()
    {
        if (TurtleControl.distanceTraveled==LevelDistance&&CA==CurrentArea.Forest)
        {
            CA = CurrentArea.Desert;
            LevelDistance += LevelDistance;
        }
        if (TurtleControl.distanceTraveled == LevelDistance && CA == CurrentArea.Desert)
        {
            CA = CurrentArea.Snow;
            LevelDistance += LevelDistance;
        }
    }
    GameObject SpawnBarriers()
    {
        if (CA == CurrentArea.Desert&&!barrier_1_spawned)
        {
            
            GameObject bar = (GameObject)Instantiate(Barrier_1);
            barrier_1_spawned = true;
           
            return bar;
        }
        if (CA == CurrentArea.Snow&&!barrier_2_spawned)
        {
            GameObject bar = (GameObject)Instantiate(Barrier_2);
            barrier_2_spawned = true;
            return bar;
        }
        else
        {
            return null;
        }
    }

}
