using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : baseController
{

    Rigidbody myBody;
    [SerializeField]
    Transform bulletStartPoint;
    [SerializeField]
    GameObject bulletPref;
    [SerializeField]
    ParticleSystem shootFX;
    [SerializeField]
    float bulletSpeed = 100f;
    public int numBullets = 5;
    UIManager uIManager;
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (uIManager != null)
        {
            uIManager.UpdateBulletCount(numBullets);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ChangeRotation();
        Shooting();
    }
    void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        myBody.MovePosition(myBody.position + speed * Time.deltaTime);
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            MoveFast();
            if ((Input.GetKeyUp(KeyCode.A)) || Input.GetKeyUp(KeyCode.D))
            {
                MoveStraight();
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveSlow();
            if ((Input.GetKeyUp(KeyCode.A)) || Input.GetKeyUp(KeyCode.D))
            {
                MoveStraight();
            }
        }
        else if((Input.GetKeyUp(KeyCode.A))|| (Input.GetKeyUp(KeyCode.D)))
        {
            MoveStraight();
            
        }

        else if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
        {
            MoveNormal();
            
        }

    }

    void ChangeRotation()
    {
        if (speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle,0f), Time.deltaTime*rotationSpeed);
        }
        else if (speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }

    }

    public void Shooting()
    {
        if (Input.GetMouseButtonDown(0) && numBullets>0 && uIManager.isAlive)
        {
            shootFX.Play();
            GameObject bullet = Instantiate(bulletPref, bulletStartPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().MoveBullet(bulletSpeed);
            numBullets--;
            uIManager.UpdateBulletCount(numBullets);

        }
    }
}
