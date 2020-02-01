using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnim : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private void OnDisable()
    {
        Pool.instance.GetItemFromPool(explosion, transform.position);
    }
}
