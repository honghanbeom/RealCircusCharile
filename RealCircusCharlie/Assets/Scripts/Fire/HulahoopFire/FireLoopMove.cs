using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLoopMove : MonoBehaviour
{
    private float loopSpeed = 3f;
    private float destroyTime = 10f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(-loopSpeed*Time.deltaTime,0f,0f);
        Destroy(gameObject, destroyTime);
    }
}
