using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    private float gameTime;

    public float GameTime { get => gameTime; }

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;

    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }
}
