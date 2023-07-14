using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGroundSpwaner : MonoBehaviour
{

    public GameObject GroundFirePrefab;
    private float spawnRateMin = 1f;
    private float spawnRateMax = 3f;
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
            GameObject groundFire = Instantiate(GroundFirePrefab, transform.position, transform.rotation);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
