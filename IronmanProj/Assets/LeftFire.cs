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
        {		
            Vector3 spawnPosition = transform.position + transform.forward * 0.1f;
            spawnPosition.x -= 0.17f;
            spawnPosition.y -= 0.08f;
            Quaternion spawnRotation = Quaternion.identity;
            audioSource.Play();									
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
            //* DEDUCT AN AMOUNT FROM ENERGY BAR, ENSURE ENOUGH ENERGY REMAINS *//
        }

    }
}