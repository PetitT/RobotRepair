using UnityEngine;
using System.Collections;

public class LinearMovement : MonoBehaviour
{

    [SerializeField]
    public float speed = 1.0F;

    [SerializeField]
    private Vector2 direction;

    private void Update()
    {
        this.transform.position += (Vector3)this.direction * speed * Time.deltaTime;
    }

}
