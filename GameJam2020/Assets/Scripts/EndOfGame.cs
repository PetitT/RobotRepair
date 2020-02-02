using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{

    private LoseCondition loseCondition;

    private void Awake()
    {
        this.loseCondition = GetComponent<LoseCondition>();          
    }

    private void OnEnable()
    {
        this.loseCondition.Lost += LoseCondition_Lost;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("LaunchMenu");
    }


    private void LoseCondition_Lost()
    {
        // Tout ce qui se passe lors de la défaite
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
