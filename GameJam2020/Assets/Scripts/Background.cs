using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField]
    private float speedIncrease = 0.1F;

    [SerializeField]
    private Transform spawnPoint;

    private DIfficultyIncrease difficulty;

    private LinearMovement linearMovement;   

    private void Awake()
    {
        //this.difficulty = FindObjectOfType<DIfficultyIncrease>();
        this.linearMovement = GetComponent<LinearMovement>();
    }

    //private void OnEnable()
    //{
    //    this.difficulty.onDifficultyIncrease += Difficulty_onDifficultyIncrease; 
    //}

    //private void OnDisable()
    //{
    //    this.difficulty.onDifficultyIncrease -= Difficulty_onDifficultyIncrease;
    //}

    //private void Difficulty_onDifficultyIncrease()
    //{
    //    this.linearMovement.speed += speedIncrease;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Endpoint Background"))
            this.transform.position = this.spawnPoint.transform.position;

        Debug.Log("Collided");
    }

}
