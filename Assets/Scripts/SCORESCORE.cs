using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCORESCORE : MonoBehaviour
{

    GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("TotalScore");
        score.GetComponent<Text>().text = PlayerStats.Kills.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
