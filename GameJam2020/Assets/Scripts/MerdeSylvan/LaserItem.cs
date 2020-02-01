using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserItem : MonoBehaviour
{

    #region Variables
    public float lifeTime;
    public float speed;

    #endregion


    #region Updates

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            gameObject.SetActive(false);
    }

    #endregion
    #region OnCollision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {

            gameObject.SetActive(false);

        }

    }

    #endregion

}
