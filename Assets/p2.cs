using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isfacingright = true;
    public bool isground = true;
    public float speed;
    public float jumpForce = 20f; // L?c nh?y
    private float trai_phai;
    private Rigidbody2D rb;
    private Animator animator;
    public float speedIncreaseAmount = 3f;

    private bool isSpeedIncreasing = false;
    public float speedIncreaseTime = 3f;
    public AudioSource jumpsound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            trai_phai = 1;
            rb.velocity = new Vector2(-speed, rb.velocity.y); // đi sang trái
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            trai_phai = -1;
            rb.velocity = new Vector2(speed, rb.velocity.y); // đi sang phải
        }
        else
        {

            trai_phai = 0;
            rb.velocity = new Vector2(0, rb.velocity.y); // không di chuyển nếu không có phím nào được ấn
        }

        flip();
        

        if (Input.GetKeyDown(KeyCode.UpArrow) && isground) // N?u ng??i ch?i nh?n n?t Space v? ?ang ch?m ground
        {
            jumpsound.Play();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isground = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isground = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isground = true;
        }
        if (collision.gameObject.tag == "boost")
        {
            if (!isSpeedIncreasing)
            {
                Destroy(collision.gameObject);
                StartCoroutine(IncreaseSpeedCoroutine());
            }
        }


    }
    IEnumerator IncreaseSpeedCoroutine()
    {

        isSpeedIncreasing = true;

        // Tăng giá trị biến speedp
        speed += speedIncreaseAmount;


        yield return new WaitForSeconds(speedIncreaseTime);


        speed -= speedIncreaseAmount;


        isSpeedIncreasing = false;
    }
    void flip()
    {
        if (isfacingright && trai_phai < 0 || !isfacingright && trai_phai > 0)
        {
            isfacingright = !isfacingright;
            Vector3 xoay = transform.localScale;
            xoay.x = xoay.x * -1;
            transform.localScale = xoay;
        }
    }

}
