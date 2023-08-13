using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseController : MonoBehaviour
{
    //[SerializeField]
    public Vector3 speed;
    [Header("Motion")]
    public float xSpeed;
    public float zSpeed;
    public float acceleration;
    public float decceleration;
    [SerializeField]
    protected float rotationSpeed;
    [SerializeField]
    protected float maxAngle;

    [Header("Audio")]
    public float lowSoundVolume;
    public float normalSoundVolume;
    public float highSoundVolume;
    public AudioClip engineOn, engineOff;
    private AudioSource aud;

    private bool isSlow;
    private bool isFast;


    void Awake()
    {
        aud = GetComponent<AudioSource>();
        if (aud != null)
        {
            aud.clip = engineOff;
            //aud.PlayOneShot(engineOff);
        }
        speed = new Vector3(0f, 0f, zSpeed);
    }

    protected void MoveLeft()
    {
        speed = new Vector3(-xSpeed, 0, speed.z);
    }
    protected void MoveRight()
    {
        speed = new Vector3(xSpeed, 0, speed.z);
    }
    protected void MoveStraight()
    {
        speed = new Vector3(0, 0, speed.z);
    }

    protected void MoveNormal()
    {
        if (isSlow)
        {
            isSlow = false;
            isFast = false;
            aud.Stop();
            aud.clip = engineOn;
            aud.volume = normalSoundVolume;
            aud.Play();
        }
        speed = new Vector3(speed.x, 0f, zSpeed);
    }

    protected void MoveSlow()
    {
        if (!isSlow)
        {
            isSlow = true;
            aud.Stop();
            aud.clip = engineOff;
            aud.volume = highSoundVolume;
            aud.Play();
        }
        speed = new Vector3(speed.x, 0f, decceleration);
    }

    protected void MoveFast()
    {
        if (!isFast)
        {
            isFast = true;
            aud.Stop();
            aud.clip = engineOn;
            aud.volume = highSoundVolume*1.5f;
            aud.Play();
        }
        speed = new Vector3(speed.x, 0f, acceleration);
        
        

    }

    public void PauseAudio(bool state)
    {
        if (state)
        {
            aud.Pause();
        }
        else
        {
            aud.UnPause();
        }
    }
}
