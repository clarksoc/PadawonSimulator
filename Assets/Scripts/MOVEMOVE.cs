using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOVEMOVE : MonoBehaviour
{

    public float speed = 0.1f;
    private Transform target;
    private GameObject player;
    GameObject life;
    public int playerLife;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        target = mainCamera.transform;
        life = GameObject.FindGameObjectWithTag("LifeTotal");
        player = GameObject.FindGameObjectWithTag("Death");
        
        Debug.Log("Starting Health: " + playerLife);
    }

    // Update is called once per frame
    void Update()
    {
        playerLife = int.Parse(life.GetComponent<Text>().text);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        Vector3 targetPosNoY = new Vector3(target.position.x, 0.0f, target.position.z);
        transform.LookAt(targetPosNoY);
/*        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            Debug.Log("Damn shorty you got hit");
            gotHit();
            Destroy(gameObject);
        }*/
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.collider.tag == "MainCamera")
        {
            Debug.Log("Damn shorty you got hit");
            gotHit();
        }
    }

    private void gotHit()
    {
        if(playerLife > 0)
        {
            Destroy(gameObject);
            playerLife--;
            Debug.Log("Life Total: " + playerLife);
            life.GetComponent<Text>().text = playerLife.ToString();
        }
        else
        {
            //Todo: GameOver
        }
    }
}
