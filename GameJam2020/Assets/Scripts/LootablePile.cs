﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootablePile : MonoBehaviour
{
    public InteractableObject item;
    [SerializeField] private SpriteRenderer aura;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        aura.enabled = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
            aura.enabled = false;

    }

}
