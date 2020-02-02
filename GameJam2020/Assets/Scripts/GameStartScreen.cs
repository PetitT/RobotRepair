using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScreen : MonoBehaviour
{
    public GameObject startscreen;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Time.timeScale = 1f;
            startscreen.SetActive(false);
            Destroy(this);
        }
    }
}
