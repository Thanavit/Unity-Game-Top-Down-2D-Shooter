using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    public float HealthPack= 20f;
    private Player_Character PC;

    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Character>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PC.playerHealth < PC.playerMaxHealth) {
                Destroy(gameObject);
                SoundManagerScript.PlaySound("powerUp");
                PC.addHealth(HealthPack);
            }
        }
    }
}
