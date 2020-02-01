using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticLaser : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ppv;
    [SerializeField] private float intensity;
    [SerializeField] private float duration;
    [SerializeField] private Laser_Shooter laser;

    private float currentintensity = 0;
    private ChromaticAberration chromaticAberration;

    private void Start()
    {
        ppv.profile.TryGetSettings(out chromaticAberration);
        laser.onShoot += OnShootHandler;
    }

    private void OnShootHandler()
    {
        StartCoroutine(ChromaticAberrate());
    }

    private IEnumerator ChromaticAberrate()
    {
        while (chromaticAberration.intensity.value < intensity)
        {
            chromaticAberration.intensity.value += Time.deltaTime;
            yield return null;
        }
        while (chromaticAberration.intensity.value > 0)
        {           
          //  currentintensity -= Time.deltaTime * intensity;
            chromaticAberration.intensity.value -= Time.deltaTime;
            yield return null;
            chromaticAberration.intensity.value = 0;
        }
    }
}
