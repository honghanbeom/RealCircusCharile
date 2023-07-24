using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryFire : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
