using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
    private const float MAX_ENERGY = 100f;
    public float energy = MAX_ENERGY;
    private Image energyBar;
    // Start is called before the first frame update
    void Start()
    {
        energyBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.fillAmount = energy / MAX_ENERGY;
    }
}