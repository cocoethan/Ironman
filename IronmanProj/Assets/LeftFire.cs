using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class LeftFire : MonoBehaviour
{
    public GameObject laserPrefab;
    private SteamVR_Input_Sources leftGrip;
    private SteamVR_Input_Sources rightGrip;
    private SteamVR_Action_Boolean gripAction;
    public AudioClip fireSound;
    private AudioSource audioSource;
    private Image energyBar;
    float deductAmount;

    private void Awake()
    {
        leftGrip = SteamVR_Input_Sources.LeftHand;
        rightGrip = SteamVR_Input_Sources.RightHand;
        gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireSound;
        energyBar = GetComponent<Image>();
    }

    private void Update()
    {
        if (gripAction.GetStateDown(leftGrip) && !gripAction.GetStateDown(rightGrip))
        {		
            Vector3 spawnPosition = transform.position + transform.forward * 0.1f;
            spawnPosition.x -= 0.17f;
            spawnPosition.y -= 0.08f;
            Quaternion spawnRotation = Quaternion.identity;
            audioSource.Play();									
            GameObject cylinder = Instantiate(laserPrefab, spawnPosition, spawnRotation);
            deductAmount = energyBar.fillAmount - 0.5f;
            energyBar.fillAmount = deductAmount;
            //* DEDUCT AN AMOUNT FROM ENERGY BAR, ENSURE ENOUGH ENERGY REMAINS *//
        }

    }
}