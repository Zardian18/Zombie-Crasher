using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Rigidbody myBody;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    GameObject bloodFXPref;
    AudioSource aud;
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    float damage=10f;
    UIManager uIManager;
    [SerializeField]
    int scoreValue = 10;
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        if (aud != null)
        {
            aud.clip = clip;
        }
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        myBody.velocity = new Vector3(0f, 0f, -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            GameObject fx = Instantiate(bloodFXPref, transform.position, Quaternion.identity);
            Destroy(fx, 3f);
            collision.gameObject.GetComponent<PlayerHealth>().DealDamage(damage);
            uIManager.UpdateScore(scoreValue);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);
        }

        else if(collision.gameObject.tag == "Bullet")
        {
            GameObject fx = Instantiate(bloodFXPref, transform.position, Quaternion.identity);
            Destroy(fx, 3f);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            uIManager.UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
