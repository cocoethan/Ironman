using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Unibeam : MonoBehaviour
{
    public GameObject laserPrefab;
    private SteamVR_Input_Sources leftGrip;
    private SteamVR_Input_Sources rightGrip;
    private SteamVR_Action_Boolean gripAction;
    public AudioClip fireSound;
    private AudioSource audioSource;

    private void Awake()
    {
        leftGrip = SteamVR_Input_Sources.LeftHand;
        rightGrip = SteamVR_Input_Sources.RightHand;

        gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireSound;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gripAction.GetStateDown(leftGrip) && gripAction.GetStateDown(rightGrip))
        {		// * May need to say && !right if the lasers fire with the unibeam
            Vector3 spawnPosition = transform.position + transform.forward;			// likely will be wonky
            spawnPosition.y -= 0.2f;
            Quaternion spawnRotation = Quaternion.identity;
            audioSource.Play();									// may need to be 0 ^
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
            //* DEDUCT AN AMOUNT FROM ENERGY BAR, ENSURE ENOUGH ENERGY REMAINS *//
        }
    }
}
