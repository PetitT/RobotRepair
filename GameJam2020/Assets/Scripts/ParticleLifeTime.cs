using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private float remainingLifeTime;

    private void OnEnable()
    {
        remainingLifeTime = lifeTime;
    }

    private void Update()
    {
        remainingLifeTime -= Time.deltaTime;
        if (remainingLifeTime <= 0)
            gameObject.SetActive(false);
    }
}
