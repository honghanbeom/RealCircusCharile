using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLoopSpwaner : MonoBehaviour
{
    public GameObject[] LoopFirePrefab;
    private float spawnRateMin = 4f;
    private float spawnRateMax = 5f;
    private float spawnRate;
    private float timeAfterSpawn;
    private Vector3 lastSpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();   
    }

    void Spawn()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn > spawnRate)
        {
            GameObject groundFire;
            if (Vector3.Distance(transform.position, lastSpawnPosition) >= 4f)
            {
                timeAfterSpawn = 0f;
                int loopRandom = Random.Range(0, 10);
                // 8,9 20% 확률로 머니달린 후프 생성
                if (loopRandom > 7)
                {
                    groundFire = Instantiate(LoopFirePrefab[1], transform.position, transform.rotation);
                }
                // 80% 확률로 일반 루프 생성
                else
                {
                    groundFire = Instantiate(LoopFirePrefab[0], transform.position, transform.rotation);
                }
                lastSpawnPosition = groundFire.transform.position;
            }

        }
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);       
    }
}
