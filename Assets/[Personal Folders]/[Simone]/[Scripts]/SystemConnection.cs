using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemConnection : MonoBehaviour
{
    [SerializeField] private Toggle systemConnection;
    [SerializeField] private TextMeshProUGUI bluetoothConnectionText, sensorConnectionText;
    [SerializeField] private Image bluetoothBackground,sensorBackground;
    
    // Update is called once per frame
    void Update()
    {
        if (systemConnection.isOn)
        {
            bluetoothConnectionText.text = "BLUETOOTH ON";
            bluetoothBackground.color = Color.green;
            sensorConnectionText.text = "SENSOR ACTIVE";
            sensorBackground.color = Color.green;
        }
        else
        {
            bluetoothConnectionText.text = "BLUETOOTH OFF";
            bluetoothBackground.color = Color.red;
            sensorConnectionText.text = "SENSOR INACTIVE";
            sensorBackground.color = Color.red;
        }
    }
}
