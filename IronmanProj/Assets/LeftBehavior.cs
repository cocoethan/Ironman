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

    private void Awake()
    {
        leftTrigger = SteamVR_Input_Sources.LeftHand;
        triggerAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    }

    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false); //transform.GetChild(0).gameObject.setActive(false);
        heal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerAction.GetStateDown(leftTrigger))
        {
            sword.SetActive(true);
        }
    }
}
