using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float damage = 10f;
    [SerializeField]
    GameObject explosionPref;
    UIManager uIManager;
    [SerializeField]
    int scoreValue=50;

    private void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionPref, transform.position, Quaternion.identity);
            //deal damage
            collision.gameObject.GetComponent<PlayerHealth>().DealDamage(damage);
            uIManager.UpdateScore(scoreValue);
            Destroy(explosion, 3f);
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            GameObject explosion = Instantiate(explosionPref, transform.position, Quaternion.identity);
            uIManager.UpdateScore(scoreValue);
            Destroy(explosion, 3f);
            Destroy(gameObject);
            
        }
    }

}
