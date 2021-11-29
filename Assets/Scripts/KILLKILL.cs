using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLKILL : MonoBehaviour
{
    public SpawnPadawan SpawnPadawan;
    public int lifeTotal;
    AudioSource deathSounds;
    // Start is called before the first frame update
    void Start()
    {
        lifeTotal = 10;
        deathSounds = GetComponent<AudioSource>();
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
            Destroy(collision.collider.gameObject, 3);
            Destroy(collision.collider.gameObject.GetComponent<MOVEMOVE>());
            Destroy(collision.collider.gameObject.GetComponent<STANDSTAND>());
            GetComponent<SpawnPadawan>().childrenCounter--;
        }
    }

}
