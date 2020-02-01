using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIfficultyIncrease : MonoBehaviour
{
    [SerializeField] private float timeBeforeDifficultyIncrease;
    public static DIfficultyIncrease instance;
    public event Action onDifficultyIncrease;

    private float remainingTimeBeforeDifficultyIncrease;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        remainingTimeBeforeDifficultyIncrease = timeBeforeDifficultyIncrease;
    }

    private void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        remainingTimeBeforeDifficultyIncrease -= Time.deltaTime;
        if(remainingTimeBeforeDifficultyIncrease <= 0)
        {
            remainingTimeBeforeDifficultyIncrease = timeBeforeDifficultyIncrease;
            onDifficultyIncrease.Invoke();
        }
    }
}
