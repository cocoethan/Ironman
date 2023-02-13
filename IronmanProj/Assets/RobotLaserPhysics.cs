using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RobotLaserPhysics : MonoBehaviour
{
    GameObject player;

    void Start()
    {
	player = GameObject.Find("Player");
        this.gameObject.transform.LookAt(player.transform);
	this.gameObject.transform.Translate(Vector3.forward * 20.0f * Time.smoothDeltaTime); //25
    }

    void Update()
    {
	this.gameObject.transform.LookAt(player.transform);
	this.gameObject.transform.Translate(Vector3.forward * 20.0f * Time.smoothDeltaTime);
    }

    void OnCollisionEnter(Collision collision) {
	if (collision.gameObject.name == "Player") {
	Destroy(this.gameObject, 0.0f);
	}
    }
}
