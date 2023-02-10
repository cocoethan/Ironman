using UnityEngine;
using Valve.VR;

public class FireLaser : MonoBehaviour
{

// add laser orientation & velocity, despawn on collision

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
        if (gripAction.GetStateDown(rightGrip))
        {
            Vector3 spawnPosition = transform.position + transform.forward;
            Quaternion spawnRotation = Quaternion.identity;
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
        }

	if (gripAction.GetStateDown(leftGrip))
        {
            Vector3 spawnPosition = transform.position + transform.forward;
            Quaternion spawnRotation = Quaternion.identity;
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
        }
    }
}