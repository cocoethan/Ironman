using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPhysics : MonoBehaviour
{
    GameObject player;
    SteamVR_Action_Boolean gripAction;

    void Start()
    {
        player = GameObject.Find("VRCamera");
        this.gameObject.transform.LookAt(player.transform);
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
