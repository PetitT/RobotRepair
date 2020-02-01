using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    #region Trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            Pool.instance.GetItemFromPool(explosion, transform.position);
            gameObject.SetActive(false);

        }

    }

    #endregion

}
