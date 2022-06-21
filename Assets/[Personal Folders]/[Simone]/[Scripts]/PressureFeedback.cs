using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PressureFeedback : MonoBehaviour
{
    [SerializeField] private Slider pressureSlider;
    [SerializeField] private Material corsetMaterial;
    [SerializeField] private Image pressureCalloutImage;
    [SerializeField] private TextMeshProUGUI pressureValueText, pressureText;
    
    // Update is called once per frame
    void Update()
    {
        //var lerpedColour = Color.Lerp(Color.white, Color.red, pressureSlider.value);
        //corsetMaterial.color = lerpedColour;
        pressureValueText.text = pressureSlider.value.ToString("0.00 ") + "kg/cm2";
        switch (pressureSlider.value)
        {
            case < 0.4f:
                pressureText.text = "LOW PRESSURE";
                pressureCalloutImage.color = Color.yellow;
                corsetMaterial.color = Color.yellow;
                break;
            case >= 0.4f and <= 0.6f:
                pressureText.text = "STRAPS PRESSURE CORRECT";
                pressureCalloutImage.color = Color.green;
                corsetMaterial.color = Color.green;
                break;
            case > 0.6f:
                pressureText.text = "STRAPS PRESSURE HIGH!";
                pressureCalloutImage.color = Color.red;
                corsetMaterial.color = Color.red;
                break;
        }
    }
}
