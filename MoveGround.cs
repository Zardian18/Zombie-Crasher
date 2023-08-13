using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    private float halfLength = 100f;
    [SerializeField]
    Transform otherBlock;
    private Transform player;
    [SerializeField]
    float endOffset = 5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        RelocateGround();
    }

    void RelocateGround()
    {
        if(transform.position.z+ halfLength < player.position.z - endOffset)
        {
            transform.position = otherBlock.position + new Vector3(0f, 0f, halfLength * 2);
        }
    }
}
