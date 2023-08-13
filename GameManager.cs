using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField]
    GameObject[] obstacle;
    [SerializeField]
    GameObject[] zombie;
    [SerializeField]
    Transform[] lanes;
    [SerializeField]
    float minSpawnTime = 3f, maxSpawnTime = 10f;
    float halfGroundSize = 100f;
    baseController player;
    [SerializeField]
    float probablityPercent = 70f;
    float awakeTime = 0f;
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != null)
        {
            Destroy(gameObject);
        }
        awakeTime = Time.time;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<baseController>();
        StartCoroutine("GenerateObstacles");
    }

    
    void Update()
    {
        
        if (maxSpawnTime <= minSpawnTime)
        {
            maxSpawnTime = minSpawnTime+.5f;
        }
        else
        {
            maxSpawnTime -= (Time.time - awakeTime) / 100f;
        }
    }

    IEnumerator GenerateObstacles()
    {
        float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
        CreateObstacle(player.transform.position.z + halfGroundSize);
        yield return new WaitForSeconds(randomTime);
        StartCoroutine("GenerateObstacles");

    }

    void CreateObstacle(float zPos)
    {
        int probablity = Random.Range(0, 10);
        if (probablity * 10 < probablityPercent)
        {
            int obstacleLane = Random.Range(0, lanes.Length);

            AddObstacle(new Vector3(lanes[obstacleLane].transform.position.x,0f,zPos), Random.Range(0,obstacle.Length));
            int zombieLane=0;
            if (obstacleLane == 0)
            {
                zombieLane = Random.Range(0, 2) == 0 ? 1 : 2;
            }
            else if (obstacleLane == 1)
            {
                zombieLane = Random.Range(0, 2) == 1 ? 2 : 0;
            }
            else if (obstacleLane == 2)
            {
                zombieLane = Random.Range(0, 2) == 2 ? 1 : 0;
            }

            AddZombies(new Vector3(lanes[zombieLane].transform.position.x, 0f, zPos));
        }
    }

    void AddObstacle(Vector3 pos, int type)
    {
        bool mirrorObject = Random.Range(0, 1) == 1;
        Quaternion angle;
        angle = Quaternion.Euler(0, mirrorObject ? 0f : 180f, 0);
        

        GameObject obst=Instantiate(obstacle[type], pos, angle);
        Destroy(obst.gameObject, 20f);
        
    }

    void AddZombies(Vector3 pos)
    {
        int count = Random.Range(0, 3) + 1;
        for(int i = 0; i < count; i++)
        {
            Vector3 shift = new Vector3(Random.Range(-0.5f, 0.5f), 0f, Random.Range(1f, 10f)*i);
            GameObject zoms=Instantiate(zombie[Random.Range(0, zombie.Length)], pos + shift * i, Quaternion.identity);
            Destroy(zoms.gameObject, 20f);
        }
    }
}
