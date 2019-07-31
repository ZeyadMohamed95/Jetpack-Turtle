using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainGameController : MonoBehaviour, IPowerUpEvents
{
    public static MainGameController main;
    public int TotalCoins;
    public int TotalCrystals;
    public int no_magnets;
    public int no_Stars;
    public int no_Shrooms;
    [Range(0f, 1f)]
    public float EffectsLevel,MusicLevel;

    public GameObject GameoverMenu;
    public ObjectHolder oh;
    

    private bool addonce=false;
    private float uiTextDisplayTimer;
    private List<PowerUp> activePowerUps;
    private GameObject PauseMenu;
    private GameObject MainCanvas;
    private GameObject obj;
    [HideInInspector]
    public enum MainGameState
    {
        Idle,
        Playing,
        Died,
        Reviving,
        GameOver
    }
    [HideInInspector]
    public MainGameState mainGameState = MainGameState.Idle;
    void IPowerUpEvents.OnPowerUpCollected(PowerUp powerUp, TurtleControl player)
    {
        if (!powerUp.expiresImmediately)
        {
            activePowerUps.Add(powerUp);
            //  UpdateActivePowerUpUi();
        }

    }
    void IPowerUpEvents.OnPowerUpExpired(PowerUp powerUp, TurtleControl player)
    {
        activePowerUps.Remove(powerUp);
       // UpdateActivePowerUpUi();
    }
    private void Awake()
    {
        if (main == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            main = this;
            activePowerUps = new List<PowerUp>();
           
        }
        else
        {
            Debug.LogWarning("GameController re-creation attempted, destroying the new one");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SceneManager.LoadScene("MenuScene");
        mainGameState = MainGameState.Idle;
        UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
        loadPlayer();
        LoadSettings();
        FindObjectOfType<AudioManger>().Stop();
        FindObjectOfType<AudioManger>().Play("Menu");
    
        // uiTextDisplayTimer = uiTextDisplayDuration * 3; // leave instructions on screen for longer
        // UpdateActivePowerUpUi();
    }
    void Update()
    {
        if(Application.loadedLevelName == "SampleScene")
        {
            obj=GameObject.FindGameObjectWithTag("OH");
            oh = obj.GetComponent<ObjectHolder>();
            addonce = false;
        }
    }

    public void AfterDeath()
    {
        if(oh!=null)
        {
                mainGameState = MainGameState.Died;
                GameObject obj;
                obj = GameObject.FindGameObjectWithTag("Star_Slider");
                Image StarSLider = obj.GetComponent<Image>();
                StarSLider.fillAmount = 0;
                obj = GameObject.FindGameObjectWithTag("Magnet_Slider");
                Image MagnetSLider = obj.GetComponent<Image>();
                MagnetSLider.fillAmount = 0;
                obj = GameObject.FindGameObjectWithTag("Shroom_Slider");
                Image ShroomSLider = obj.GetComponent<Image>();
                ShroomSLider.fillAmount = 0;

                
                if (TotalCrystals > 0)
                {
                    oh.SetConActive();
                    Invoke("GameOverLose", 5f);
                }
                else
                {
                    Invoke("GameOverLose", 1f);
                }
        } 
             //   mainGameState = MainGameState.GameOver;
             //Invoke("LoadGameoverMenu", 1f);
    }
    public void GameOverLose()
    {
        if (mainGameState == MainGameState.Died)
        {
            mainGameState = MainGameState.GameOver;
            oh.SummingCoins(main);
            oh.SetGOMActive();
            UnityAdsPlacement.instance.ShowAd();
            saveData();
            FindObjectOfType<AudioManger>().Stop();
            FindObjectOfType<AudioManger>().Play("Gameover");
        }
    }
    public void saveData()
    {
        SaveSystem.SavePlayer(main);
    }
    public void loadPlayer()
    {
      GameData data=  SaveSystem.LoadPlayer();
      TotalCoins = data.Coins;
      TotalCrystals = data.Crystals;
      no_magnets = data.no_Magnets;
      no_Stars = data.no_Stars;
      no_Shrooms = data.no_Shrooms;  
    }
    public void LoadSettings()
    {
        GameData data = SaveSystem.LoadPlayer();
        EffectsLevel = data.Effects;
        MusicLevel = data.Music;
    //    FindObjectOfType<AudioManger>().sounds[0].source.volume = MusicLevel;
    //    FindObjectOfType<AudioManger>().sounds[1].source.volume = MusicLevel;
    //    FindObjectOfType<AudioManger>().sounds[2].source.volume = MusicLevel;
    //    FindObjectOfType<AudioManger>().sounds[3].source.volume = EffectsLevel;
    //    FindObjectOfType<AudioManger>().sounds[4].source.volume = EffectsLevel;
    //    FindObjectOfType<AudioManger>().sounds[5].source.volume = EffectsLevel;
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("SampleScene");
        mainGameState = MainGameState.Playing;
        FindObjectOfType<AudioManger>().Stop();
        FindObjectOfType<AudioManger>().Play("GamePlay");
    
    }
}
