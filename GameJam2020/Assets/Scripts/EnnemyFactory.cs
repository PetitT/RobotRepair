using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject electricEnnemy, physicalEnnemy;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float difficultyTimerBoost;
    [SerializeField] private float ennemySpeed;
    [SerializeField] private float ennemySpeedBoost;

    private float remainingTime;

    private void Start()
    {
        DIfficultyIncrease.instance.onDifficultyIncrease += DifficultyIncreaseHandler;
    }

    private void DifficultyIncreaseHandler()
    {
        timeBetweenSpawns -= difficultyTimerBoost;
        ennemySpeed += ennemySpeedBoost;
    }

    private void Update()
    {
        remainingTime += Time.deltaTime;
        if(remainingTime >= timeBetweenSpawns)
        {
            InstantiateEnnemy();
            remainingTime = 0;
        }
    }

    private void InstantiateEnnemy()
    {
        GameObject newEnnemy;
        int random = UnityEngine.Random.Range(0, 2);
        if(random == 0)
        {
            newEnnemy = Instantiate(electricEnnemy);
        }
        else
        {
            newEnnemy = Instantiate(physicalEnnemy);
        }
        newEnnemy.GetComponent<LinearMovement>().speed = ennemySpeed;
        newEnnemy.transform.position = spawnPos.position;
    }
}
