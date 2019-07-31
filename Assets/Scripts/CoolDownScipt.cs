using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoolDownScipt : MonoBehaviour {
    public Text coolDownText;
    public float CooldwonTimer;
    public Button button;
    private float CurrentTIMER;
    public bool OnCooldown;
	// Use this for initialization
   void Awake()
    {
        button = GetComponent<Button>();
        coolDownText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (CurrentTIMER >= 0)
        {
            CurrentTIMER -= Time.deltaTime;
            coolDownText.text = CurrentTIMER.ToString("0");
            OnCooldown = true;
        }
        if(CurrentTIMER<=0)
        {
            button.enabled = true;
            coolDownText.enabled = false;
            OnCooldown = false;
        }
        
        
	}
   public void CooldwonStart()
    {
        CurrentTIMER = CooldwonTimer;
        button.enabled = false;
        coolDownText.enabled = true;
        OnCooldown = true;
    }
}
