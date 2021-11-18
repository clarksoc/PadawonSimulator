using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUNDSOUND : MonoBehaviour
{
    public Rigidbody rigidBody;
    AudioSource audioSource;
    public float speed = 0.1f;
    public int startingPitch = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Debug.Log(rigidBody);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(rigidBody.velocity.sqrMagnitude);
        Vector3 rbVelocity = rigidBody.velocity;
        if(rigidBody.velocity.sqrMagnitude > speed * speed)
        {
            //rigidBody.velocity = rbVelocity.normalized * speed;
            Debug.Log("GAS GAS GAS");
            audioSource.pitch -= ((Time.deltaTime * startingPitch) / 5);
        }
    }


}
