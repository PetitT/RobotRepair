using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    // Utilité : Toutes les animations, sons, ect, s'activeront quand l'event Died se déclenchera

    public event Action Died;

    // Cette classe sert juste d'exmple 
    // Elle devra s'abonner au "Damage Manager" et Invoke l'event quand les dégâts atteindront leur maximum

    private void Awake()
    {
        // Référence au "Damage Manager"
    }

    private void OnEnable()
    {
        // S'abonne à l'event
    }

    private void OnDisable()
    {
        // Se désabonne à l'event
    }

    // L'event devra être Invoke quand "Damange Manager"

}
