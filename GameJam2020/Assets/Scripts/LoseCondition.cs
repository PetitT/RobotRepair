using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{

    [SerializeField]
    private float timeBeforeDefeat = 3.0F;
    [SerializeField]
    private GameObject deathScreen;

    public event Action Lost;

    private Death death;

    private void Awake()
    {
        this.death = GetComponent<Death>();
    }

    private void OnEnable()
    {
        this.death.Died += Death_Died;
    }

    private void OnDisable()
    {
        this.death.Died -= Death_Died;
    }

    private void Death_Died()
    {
        StartCoroutine(TimerCoroutine());
        deathScreen.SetActive(true);
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(timeBeforeDefeat);
        Lost?.Invoke();
    }

}
