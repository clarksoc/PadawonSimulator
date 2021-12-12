using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KILLKILL : MonoBehaviour
{
    public SpawnPadawan SpawnPadawan;
    public int lifeTotal;
    AudioSource deathSounds;
    GameObject spawner;
    GameObject score;


    // Start is called before the first frame update
    void Start()
    {
        lifeTotal = 10;
        deathSounds = GetComponent<AudioSource>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.collider.tag == "InnocentPadawon")
        {
            deathSounds.Play();
            spawner.GetComponent<SpawnPadawan>().childrenCounter--;
            Destroy(collision.collider.gameObject, 3);
            Destroy(collision.collider.gameObject.GetComponent<MOVEMOVE>());
            Destroy(collision.collider.gameObject.GetComponent<STANDSTAND>());
            Destroy(collision.collider.gameObject.GetComponent<Rigidbody>());
        }
    }

}
