using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{

    public Text endScore;
    // Start is called before the first frame update
    void Start()
    {
        endScore.GetComponent<Text>();
        endScore.text = GameManager.scoreValue.ToString();
    }

}
