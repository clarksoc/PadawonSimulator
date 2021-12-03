using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    GameObject score;
    public int count;
    AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        count = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "InnocentPadawon")
        {
            animator = collision.gameObject.GetComponent<Animator>();
            Debug.Log("Twas but a flesh wound");
            audioSource.Play();
            count++;
            score.GetComponent<Text>().text = count.ToString();
            //animator.SetBool("isDead", true);
            animator.Play("Dying");
            collision.gameObject.tag = "EnlightenedPadawon";
            
        }
    }
}
