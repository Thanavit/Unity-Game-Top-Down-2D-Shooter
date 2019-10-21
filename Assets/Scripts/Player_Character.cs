using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Character : MonoBehaviour
{
    //player movement var(s)
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 moveVelocity;

    //player aim var(s)
    Vector2 mousePos;
    public Camera cam;
    public GameObject crossHairs;

    //player stats var(s)
    public float playerHealth;
    public float playerMaxHealth;
    public Image playerHealthBar;

    private shake shakeEffect;


    private void Start()
    {
        Cursor.visible = false;
        shakeEffect = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        moveVelocity.x = Input.GetAxisRaw("Horizontal");
        moveVelocity.y = Input.GetAxisRaw("Vertical");

        //get mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //player movement
        rb.MovePosition(rb.position + moveVelocity * moveSpeed * Time.fixedDeltaTime);

        //make character facing mouse location
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        crossHairs.transform.position = mousePos;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet")
        {
            shakeEffect.CamShake();
            playerHealth -= 5;
            playerHealthBar.fillAmount = playerHealth / 100f;
            if (playerHealth <= 0)
            {
                Destroy(gameObject);               
                SceneManager.LoadScene("End");
                Cursor.visible = true;
            }
        }
    }

    public void addHealth(float health)
    {
        playerHealth += health;
        playerHealthBar.fillAmount = playerHealth / 100f;
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }
}
