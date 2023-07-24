using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Sound{ Jump, Point, Dead }

public class PlayerControl : MonoBehaviour
{
    private float speed = 10f;
    private float jumpForce = 7f;
    public int playerLife = 3;

    private bool isGround = false;
    private bool isWalking = false;
    private bool isDead = false;
    private bool haveLife = false;
    private int life = 3;


    private int meterCount = 0;
    private Vector3 previousPosition;

    public Rigidbody2D rigidBody;
    public Animator cAnimator;
    public Animator lAnimator;
    public AudioSource audioSource;
    public AudioClip[] clip;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        previousPosition = rigidBody.position;
        Move();
        Jump();
        UserPositionCheck();

        Debug.LogFormat("플레이어 위치 : {0}", transform.position);
    }

    private void PlaySound(Sound sound)
    {
        audioSource.clip = clip[(int)sound];
        audioSource.Play();
    }

    private void Move()
    {
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
        else if (transform.position.x >= 500f)
        {
            GameManger.instance.isGameOver = true;
            GameManger.instance.GameClear();
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
                PlaySound(Sound.Jump);
            }
        }
    }

    private void UserPositionCheck()
    {
        Vector3 currentPosition = rigidBody.position;
        float distance = Mathf.Abs(currentPosition.x - previousPosition.x);

        if (distance >= 50f)
        {
            meterCount++;
            previousPosition = currentPosition;
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
            transform.Translate(50 * meterCount - 10f, -2f, 0f);
            playerLife--;
            if (playerLife != 0)
            {
                haveLife = true;
                PlaySound(Sound.Dead);
                GameManger.instance.ReGame();
                lAnimator.SetBool("haveLife", haveLife);
                cAnimator.SetBool("haveLife", haveLife);

            }
            if (playerLife == 0)
            {
                GameManger.instance.isGameOver = true;
                gameObject.SetActive(false);
                GameManger.instance.GameOver();

            }
        }
        if (collision.collider.tag == "Money")
        {
            GameManger.instance.AddScore(200);
            PlaySound(Sound.Point);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            GameManger.instance.AddScore(100);
            PlaySound(Sound.Point);

        }
        if (collision.tag == "Fire")
        {
            GameManger.instance.AddScore(100);
            PlaySound(Sound.Point);

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
