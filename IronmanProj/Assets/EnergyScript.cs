using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class EnergyScript : MonoBehaviour
{
    private const float MAX_ENERGY = 100f;
    public float energy = MAX_ENERGY;
    private Image energyBar;
    float deductAmount;
    private SteamVR_Input_Sources leftGrip;
    private SteamVR_Input_Sources rightGrip;
    private SteamVR_Action_Boolean gripAction;


    // Start is called before the first frame update
    void Start()
    {
        energyBar = GetComponent<Image>();
        energyBar.fillAmount = energy / MAX_ENERGY;

        leftGrip = SteamVR_Input_Sources.LeftHand;
        rightGrip = SteamVR_Input_Sources.RightHand;
        gripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    }

    // Update is called once per frame
    void Update()
    {

        if (gripAction.GetStateDown(leftGrip) && gripAction.GetStateDown(rightGrip))
        {
            deductAmount = energyBar.fillAmount - 0.6f;
            energyBar.fillAmount = deductAmount;
        }
        else if (gripAction.GetStateDown(leftGrip) || gripAction.GetStateDown(rightGrip))
        {
            deductAmount = energyBar.fillAmount - 0.1f;
            energyBar.fillAmount = deductAmount;
        }

        deductAmount = energyBar.fillAmount + 0.001f;
        energyBar.fillAmount = deductAmount;
    }
}