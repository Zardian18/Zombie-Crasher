using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    Rigidbody bulletBody;
    [SerializeField]
    float lifeTime = 3f;
    [SerializeField]
    AudioClip clip;
    AudioSource aud;
    
    void Awake()
    {
        bulletBody = GetComponent<Rigidbody>();
        if (bulletBody == null)
        {
            //Debug.Log("No rbd");
        }
        aud = GetComponentInParent<AudioSource>();
        if (aud != null)
        {
            aud.clip = clip;
            aud.Play();
        }
        Destroy(gameObject, lifeTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveBullet(float speed)
    {
        bulletBody.velocity = new Vector3(0, 0, 1) * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
            Destroy(gameObject);
        }
    }
}
