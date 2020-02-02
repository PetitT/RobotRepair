using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    public float speed;

    private void Start()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    private void Update()
    {

        if (transform.localPosition.y >= maxY)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        else if (transform.localPosition.y <= minY)
            transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

}
