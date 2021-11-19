using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLKILL : MonoBehaviour
{
    public SpawnPadawan SpawnPadawan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //spawnPadawan.childrenCounter--;
        //Debug.Log(spawnPadawan.childrenCounter);
        Destroy(collision.collider.gameObject, 3);
        GetComponent<SpawnPadawan>().childrenCounter--;
        //SpawnPadawan.childrenCounter--;
    }

}
