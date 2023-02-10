using UnityEngine;
using Valve.VR;

public class FireLaser : MonoBehaviour
{
    public GameObject laserPrefab;
    private SteamVR_Input_Sources leftGrip;
    private SteamVR_Input_Sources rightGrip;
    private SteamVR_Action_Boolean gripAction;

    private void Awake()
    {
        leftGrip = SteamVR_Input_Sources.LeftHand;
        rightGrip = SteamVR_Input_Sources.RightHand;
        gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    }

    private void Update()
    {
	if (gripAction.GetStateDown(leftGrip) && gripAction.GetStateDown(rightGrip)) {
	    // CREATE UNIBEAM ORIGINATING FROM PLAYER CHEST
		// Can create GameObject unibeamPrefab similar to laserPrefab
 	    // DEDUCT AN AMOUNT FROM ENERGY BAR, ENSURE ENOUGH ENERGY REMAINS
	}
	else if (gripAction.GetStateDown(leftGrip)) {	//need to add velocity, orientation, bind spawning
            Vector3 spawnPosition = transform.position + transform.forward;
            Quaternion spawnRotation = Quaternion.identity;
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
	    //* DEDUCT AN AMOUNT FROM ENERGY BAR, ENSURE ENOUGH ENERGY REMAINS *//
        }
        else if (gripAction.GetStateDown(rightGrip)) {	//need to add velocity, orientation, bind spawning
            Vector3 spawnPosition = transform.position + transform.forward;
            Quaternion spawnRotation = Quaternion.identity;
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
	    //* DEDUCT AN AMOUNT FROM ENERGY BAR, ENSURE ENOUGH ENERGY REMAINS *//
        }

	
	//* Add if statement reading if (left trigger?) is pressed, spawn sword bound to Player->SteamVRObjects->LeftHand(If we use left trigger)->ObjectAttachmentPoint *//
	//* Will need to check if the sword should spawn or despawn, i.e. if sword exists despawn on click, if sword does not exist spawn on click *//

    }
}