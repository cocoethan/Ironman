using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class LeftBehavior : MonoBehaviour
{
    public GameObject sword;
    public GameObject heal;
    private SteamVR_Input_Sources leftTrigger;
    private SteamVR_Action_Boolean triggerAction;
    int i = 0;

    private void Awake()
    {
        leftTrigger = SteamVR_Input_Sources.LeftHand;
        triggerAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    }

    // Start is called before the first frame update
    void Start()
    {
        //sword.SetActive(false);
        //heal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerAction.GetStateDown(leftTrigger) && i==0)
        {
            sword.SetActive(true);
            i = 1;
        }
        else if(triggerAction.GetStateDown(leftTrigger) && i==1)
        {
            sword.SetActive(false);
            heal.SetActive(true);
            i = 2;
        }
        else if(triggerAction.GetStateDown(leftTrigger) && i==2)
        {
            heal.SetActive(false);
            i = 0;
        }
    }
}
