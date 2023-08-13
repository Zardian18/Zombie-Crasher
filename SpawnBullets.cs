using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    [SerializeField]
    Transform[] lanes;
    PlayerController player;
    [SerializeField]
    GameObject collectibleBulletPrefab;
    float xPos;
    [SerializeField]
    float collectibleSpawnTime = 15f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        StartCoroutine(SpawnBulletsCollectible());
    }

    IEnumerator SpawnBulletsCollectible()
    {
        SpawnPosition();
        Instantiate(collectibleBulletPrefab, new Vector3(xPos, 1f, player.transform.position.z + 100f), Quaternion.identity);
        yield return new WaitForSeconds(collectibleSpawnTime);
        StartCoroutine(SpawnBulletsCollectible());

    }

    void SpawnPosition()
    {
        int randomLane = Random.Range(0, 3);
        xPos = lanes[randomLane].position.x;
    }

    
}
