using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoreValue.ToString();
        if (scoreValue >= 50)
        {
            EnemySpawnerControll.waveSpeed = 3f;
        }
        if (scoreValue >= 100)
        {
            EnemySpawnerControll.waveSpeed = 2f;
        }
        if (scoreValue >= 150)
        {
            EnemySpawnerControll.waveSpeed = 1f;
        }
        if (scoreValue >= 200)
        {
            EnemySpawnerControll.waveSpeed = 0.9f;
        }
    }
}
