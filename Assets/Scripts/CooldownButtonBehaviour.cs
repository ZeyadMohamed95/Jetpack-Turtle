using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownButtonBehaviour : StateMachineBehaviour {
    public ButtonScript buttonScript;
    float rechargeEndTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        buttonScript.StartRecharge();
        rechargeEndTime = buttonScript.rechargeEnd;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time >= rechargeEndTime)
        {
            animator.SetTrigger("CooldownFinished");
        }
        else
        {
            buttonScript.SetOverlay();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        buttonScript.EndRecharge();
        buttonScript.GetComponent<Button>().interactable = true;
    }
}
