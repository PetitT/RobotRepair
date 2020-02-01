using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteIntensity : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ppv;
    [SerializeField] private float intensity;
    [SerializeField] private float duration;

    private float currentintensity = 0;
    private Vignette vignette;

    private void Start()
    {
        ppv.profile.TryGetSettings<Vignette>(out vignette);
    }

    private IEnumerator VignetteIntensityChange()
    {
        float timer = 0f;

        while (timer < duration / 2)
        {
            timer += Time.deltaTime;
            currentintensity += Time.deltaTime * intensity;
            vignette.intensity.value = currentintensity;
            yield return null;
        }
        while(timer > duration / 2 && timer < duration)
        {
            timer += Time.deltaTime;
            currentintensity -= Time.deltaTime * intensity;
            vignette.intensity.value = currentintensity;
            yield return null;
        }
    }
}
