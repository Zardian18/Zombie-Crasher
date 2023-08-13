using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    float health;
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //gameover
            uIManager.isAlive = false;
        }
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        uIManager.UpdateHealth(health);
    }
}
