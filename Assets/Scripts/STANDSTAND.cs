using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STANDSTAND : MonoBehaviour
{

    public float speed = 0.25f;
    private Transform target;
    private GameObject player;
    GameObject life;
    public int playerLife;
    public GameObject mainCamera;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        target = mainCamera.transform;
        life = GameObject.FindGameObjectWithTag("LifeTotal");
        player = GameObject.FindGameObjectWithTag("Death");
        Destroy(gameObject.GetComponent<Rigidbody>());

        Debug.Log("Starting Health: " + playerLife);
    }

    // Update is called once per frame
    void Update()
    {
        var forward = Camera.main.transform.forward;
        forward.y = 0.0f;
        //transform.LookAt(target);
        Vector3 targetPosNoY = new Vector3(target.position.x, -1.0f, target.position.z);
        transform.LookAt(targetPosNoY);
    }

}
