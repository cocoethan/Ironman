using UnityEngine;
using Valve.VR;

public class LeftFire : MonoBehaviour
{
    public GameObject laserPrefab;
    private SteamVR_Input_Sources leftGrip;
    private SteamVR_Action_Boolean gripAction;
    public AudioClip fireSound;
    private AudioSource audioSource;

    private void Awake()
    {
        leftGrip = SteamVR_Input_Sources.LeftHand;
        gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireSound;
    }

    private void Update()
    {
        if (gripAction.GetStateDown(leftGrip))
        {		// * May need to say && !right if the lasers fire with the unibeam
            Vector3 spawnPosition = transform.position + transform.forward * 0.1f;			// likely will be wonky
            Quaternion spawnRotation = Quaternion.identity;
            audioSource.Play();									// may need to be 0 ^
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
            //* DEDUCT AN AMOUNT FROM ENERGY BAR, ENSURE ENOUGH ENERGY REMAINS *//
        }

        //* Add if statement reading if (left trigger?) is pressed, spawn sword bound to Player->SteamVRObjects->LeftHand(If we use left trigger)->ObjectAttachmentPoint *//
        //* Will need to check if the sword should spawn or despawn, i.e. if sword exists despawn on click, if sword does not exist spawn on click *//

    }
}