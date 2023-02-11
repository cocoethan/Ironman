using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPhysics : MonoBehaviour
{

    GameObject hand;
    SteamVR_Input_Sources leftGrip;
    SteamVR_Input_Sources rightGrip;
    SteamVR_Action_Boolean gripAction;

    void Awake()
    {
        leftGrip = SteamVR_Input_Sources.LeftHand;
        rightGrip = SteamVR_Input_Sources.RightHand;
        gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    }

    void Start()
    {
	if (gripAction.GetStateDown(leftGrip)) {		// may not work
            hand = GameObject.Find("LeftHand");
        }
        if (gripAction.GetStateDown(rightGrip)) {
            hand = GameObject.Find("RightHand");
        }
	else{ hand = GameObject.Find("Player");}
        this.gameObject.transform.LookAt(hand.transform);
	this.gameObject.transform.Translate(-(Vector3.forward * 5.0f * Time.smoothDeltaTime)); //25
    }

    void Update()
    {
	this.gameObject.transform.Translate(-(Vector3.forward * 5.0f * Time.smoothDeltaTime));
    }

    void OnCollisionEnter() {
	Destroy(this.gameObject, 0.0f);
    }
}
