using UnityEngine;
using Valve.VR;

public class FireLaser : MonoBehaviour
{
    public GameObject laserPrefab;
    private SteamVR_Input_Sources handType;
    private SteamVR_Action_Boolean gripAction;

    private void Awake()
    {
        handType = SteamVR_Input_Sources.RightHand;
        gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    }

    private void Update()
    {
        if (gripAction.GetStateDown(handType))
        {
            Vector3 spawnPosition = transform.position + transform.forward;
            Quaternion spawnRotation = Quaternion.identity;
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
        }
    }
}