using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;

    private void Update()
    {
        float currentTime = Timer.instance.GameTime;
        text.text = Convert.ToInt32(currentTime).ToString();
    }
}
