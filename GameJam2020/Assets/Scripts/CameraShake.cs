using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float shakeAmount;
    [SerializeField] private float decreaseFactor;

    private Vector3 basePos;
    private bool isShaking = false;

    private void Start()
    {
        basePos = cam.transform.position;
    }

    IEnumerator Shake()
    {

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / shakeDuration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= shakeAmount * damper;
            y *= shakeAmount * damper;

            cam.position = new Vector3(x, y, basePos.z);

            yield return null;
        }
    }
}
