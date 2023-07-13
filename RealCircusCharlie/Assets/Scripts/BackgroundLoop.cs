//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.WSA;

//public class BackgroundLoop : MonoBehaviour
//{
//    public GameObject player;
//    private float offset;
//    private float width;
//    private void Awake()
//    {
//        BoxCollider2D background = GetComponent<BoxCollider2D>();
//        width = background.size.x;
//    }

//    private void Start()
//    {
//        offset = Mathf.Abs(width - player.transform.position.x);
//    }

//    private void Update()
//    {
//        if (offset <= 20)
//        {
//            Reposition();
//        }
//    }

//    private void Reposition()
//    {
//        Vector2 newPosition = new Vector2(width, 0f);
//        transform.position = newPosition;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    private float width;
    public PlayerControl playerControl;

    // Start is called before the first frame update
    void Awake()
    {
        //GameObject.Find("offset").GetComponent<CameraMove>();
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x <= -width )
        //{
        //    Reposition();
        //}
        Debug.Log(string.Format("플레이어 포지션 {0},", playerControl.gameObject.transform.position.x));
        if( playerControl.gameObject.transform.position.x > this.transform.position.x + 9f)
        {
            
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 3, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}

