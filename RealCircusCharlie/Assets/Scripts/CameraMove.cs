using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - player.transform.position.x;

        //Vector3 newVector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > -8.21f)
        { 
            Vector3 targetPosition = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
            transform.position = targetPosition;           
        }
    }
}
