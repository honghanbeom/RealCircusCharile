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
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    //public static BackgroundLoop instance;

    private float width;
    public PlayerControl playerControl;
    //public int screenMoveCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        //GameObject.Find("offset").GetComponent<CameraMove>();
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;

        // 초기화
        //instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x <= -width )
        //{
        //    Reposition();
        //}
        //Debug.Log(string.Format("플레이어 포지션 {0},", playerControl.gameObject.transform.position.x));
        if( playerControl.gameObject.transform.position.x > this.transform.position.x + 20f)
        {
            //Debug.LogFormat("이동할 때 포지션 : {0}",transform.position);
            Reposition();
            //screenMoveCount++;
        }

        else if (playerControl.gameObject.transform.position.x < this.transform.position.x - 37f)
        {
            //Debug.LogFormat("이동할 때 포지션 : {0}",transform.position);
            BackReposition();
            //screenMoveCount++;
        }

    }

    private void Reposition()
    {
        Vector3 offset = new Vector3(width * 7.5f, 0f, 0f);
        transform.position = (Vector3)transform.position + offset;
    }

    private void BackReposition()
    {
        Vector3 offset = new Vector3(-width * 7.5f, 0f, 0f);
        transform.position = (Vector3)transform.position + offset;
    }
}

