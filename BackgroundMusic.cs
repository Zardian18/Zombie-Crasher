using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundMusic : MonoBehaviour
{

    [SerializeField]
    AudioClip bgm;
    AudioSource aud;
    UIManager uIManager;
    bool checkUI=true;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        if (aud != null)
        {
            aud.clip = bgm;
            aud.PlayOneShot(bgm);
        }
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!uIManager.isAlive)
        {
            aud.Stop();
        }
    }

    public void ToogleMusic(bool state)
    {
        if (state)
        {
            aud.PlayOneShot(bgm);
        }
        else
        {
            aud.Stop();
        }
    }
}
