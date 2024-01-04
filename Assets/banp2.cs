using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class banp2 : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab c?a gameobject vi?n ??n
    public float bulletSpeed = 10f; // T?c ?? di chuy?n c?a vi?n ??n
    public int damageAmount = 10; // S? ?i?m m?u tr? ?i khi b?n tr?ng ??i th?
    private Vector3 playerDirection = Vector3.left;
    public TextMeshProUGUI dam;
    public float fireRate = 1f; // Kho?ng th?i gian gi?a c?c l?n b?n
    private float nextFire = 0.0f; // Th?i ?i?m ???c ph?p b?n ti?p theo
    private Animator animator;
    public int damageIncreaseAmount = 5;
    public AudioSource bansound;
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "magnum")
        {

            Destroy(collision.gameObject);
            damageAmount += damageIncreaseAmount;

        }


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {


            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;


                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);


                StartCoroutine(DanBan(bullet, playerDirection));

            }


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerDirection = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerDirection = Vector3.right;
        }
        dam.text = "Damage per bullet:" + damageAmount.ToString();
    }
    IEnumerator DanBan(GameObject obj, Vector3 direction)
    {
        bansound.Play();
       
        
        while (obj != null && obj.transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f)).x && obj.transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x)
        {

            obj.transform.Translate(direction * bulletSpeed * Time.deltaTime);
            yield return null;

        }


        if (obj != null)
        {
            Destroy(obj);
        }
    }


}
