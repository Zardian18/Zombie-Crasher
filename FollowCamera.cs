using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Vector3 offsetPos;
    UIManager uIManager;
    [SerializeField]
    Transform initialCamera;
    [SerializeField]
    Vector3 initialOffset;
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        //StartCoroutine(Startgame());
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        
    }

    void FollowPlayer()
    {
        transform.position = playerTransform.position + offsetPos;
    }
    IEnumerator Startgame()
    {
        yield return new WaitForSeconds(1f);
        //uIManager.gameStarted = true;
    }
}
