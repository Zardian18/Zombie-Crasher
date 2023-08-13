using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBullet : MonoBehaviour
{
    PlayerController player;
    [SerializeField]
    AudioClip clip;
    AudioSource aud;
    UIManager uIManager;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        aud = GetComponent<AudioSource>();
        if (aud != null)
        {
            aud.clip = clip;
        }
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            player.numBullets++;
            uIManager.UpdateBulletCount(player.numBullets);
            Destroy(gameObject);
        }
    }
}
