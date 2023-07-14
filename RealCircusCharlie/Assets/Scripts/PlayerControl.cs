using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 10f;
    private float jumpForce = 7f;
    public int playerLife = 3;

    private bool isGround = false;
    private bool isWalking = false;
    private bool isDead = false;


    public Rigidbody2D rigidBody;
    public Animator cAnimator;
    public Animator lAnimator;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        Debug.LogFormat("플레이어 위치 : {0}",transform.position);
    }

    private void Move()
    {
        //if (BackgroundLoop.instance == null) { return; }

        //int MoveCount = BackgroundLoop.instance.screenMoveCount;
        if (transform.position.x >= -10f)
        {

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                isWalking = true;
                lAnimator.SetBool("isWalking", isWalking);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                isWalking = true;
                lAnimator.SetBool("isWalking", isWalking);
            }
            else
            {
                isWalking = false;
                lAnimator.SetBool("isWalking", isWalking);
            }
        }
        else
        {
            Vector3 newPosition = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }

        
        #region LEGACY
        //float xInput = Input.GetAxis("Horizontal");
        //float xSpeed = xInput * speed;
        //Vector2 newVec = new Vector2(xSpeed, 0f);
        //rigidBody.velocity = newVec;
        //isWalking = true;
        //lAnimator.SetBool("isWalking", isWalking);
        #endregion
    }






    #region LEGACY
    //private void Jump()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        if (jumpCount == 0)
    //        {
    //            jumpCount++;
    //            rigidBody.AddForce(new Vector2(0f, jumpForce));
    //        }
    //    }
    //}
    #endregion

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGround)
            {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                lAnimator.SetTrigger("Jump"); // 점프 트리거를 활성화하여 점프 애니메이션을 재생합니다.
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            lAnimator.SetBool("isGround", isGround);
        }
        if (collision.collider.tag == "Fire")
        {
            isDead = true;
            lAnimator.SetBool("isDead", isDead);
            cAnimator.SetBool("isDead", isDead);
            playerLife--;
            if (playerLife != 0)
            { 
                // 게임 재시작 로직    
            }
            if (playerLife == 0)
            { 
                // 게임 종료 로직   
            }
        }
        if (collision.collider.tag == "Money")
        {
            GameManger.instance.AddScore(200);   
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            GameManger.instance.AddScore(100);
        }
        if (collision.tag == "Fire")
        {
            GameManger.instance.AddScore(200);    
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            lAnimator.SetBool("isGround", isGround);
   
        }
    }
}
