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
        
        if(timeAfterSpawn > spawnRate)
        {
            timeAfterSpawn = 0f;
            int loopRandom = Random.Range(0,10);
            // 8,9 20% 확률로 머니달린 후프 생성
            if (loopRandom > 7)
            { 
                GameObject groundFire = Instantiate(LoopFirePrefab[1], transform.position, transform.rotation);
            }
            // 80% 확률로 일반 루프 생성
            else
            {
                GameObject groundFire = Instantiate(LoopFirePrefab[0], transform.position, transform.rotation);
            }
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
