using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _cloudParticlePrefabs;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       Bird hitBird = collision.collider.GetComponent<Bird>();
        if( hitBird !=null)
        {
            Instantiate(_cloudParticlePrefabs, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy !=null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefabs, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
