using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    GameObject score;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.name == "blade")
        {
            Debug.Log("I was SLAPPED");
        }
        if(collision.gameObject.tag == "Death")
        {
            Debug.Log("Twas but a flesh wound");
            count++;
            score.GetComponent<Text>().text = count.ToString();
            
        }
    }
}