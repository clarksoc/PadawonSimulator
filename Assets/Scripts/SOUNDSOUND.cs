using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUNDSOUND : MonoBehaviour
{
    public Rigidbody rigidBody;
    AudioSource audioSource;
    public float speed = 0.1f;
    public int startingPitch = 1;

    public Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        //Debug.Log(audioSource.pitch.ToString() + "\n");

        oldPosition = rigidBody.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigidBody.velocity;

        //Debug.Log((this.rigidBody.velocity.magnitude).ToString() + "\n");
        //Debug.Log((Vector3.Distance(oldPosition, this.rigidBody.position)).ToString() + "\n");
        //Debug.Log(audioSource.volume.ToString() + "\n");

        speed = Vector3.Distance(oldPosition, this.rigidBody.position);
        oldPosition = rigidBody.position;

        /*
        if (this.rigidBody.velocity.magnitude < 1)
        {
            audioSource.pitch = 3;
        } 
        else
        {
            audioSource.pitch = 2 - (1 / (this.rigidBody.velocity.magnitude));
        }
        */

        if (speed > 0.5)
        {
            audioSource.pitch = 2;
            audioSource.volume = 0.755F;
        }
        else
        {
            audioSource.pitch = 1 + (2 * speed);
            audioSource.volume = 0.255F + speed;
        }

        //Debug.Log(audioSource.pitch.ToString() + "\n");

        //audioSource.pitch = ((Time.deltaTime * startingPitch) / 5);

    }


}