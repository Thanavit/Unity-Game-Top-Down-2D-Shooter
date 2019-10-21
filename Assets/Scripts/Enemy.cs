using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //movement var(s)
    public float moveSpeed;
    private Transform target;
    public Rigidbody2D rb;

    //stats var(s)
    public float health;
    public Image enemyHealthBar;

    //effects
    public GameObject explosion;
    private shake shakeEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shakeEffect = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<shake>();
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {

        //make Enemy facing player location
        Vector2 lookDir = (Vector2)target.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 20;
            enemyHealthBar.fillAmount = health / 100f;
            if (health <= 0) {
                GameManager.scoreValue += 10;
                shakeEffect.CamShake();
                SoundManagerScript.PlaySound("explosion");
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }


}
