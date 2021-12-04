using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOVEMOVE : MonoBehaviour
{

    public float speed = 0.5f;
    private Transform target;
    private GameObject player;
    GameObject life;
    public int playerLife;
    public GameObject mainCamera;
    GameObject spawner;
    AudioSource audioSource;
    Animator animator;
    private float distToPlayer = 1.25f;
    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        target = mainCamera.transform;
        life = GameObject.FindGameObjectWithTag("LifeTotal");
        player = GameObject.FindGameObjectWithTag("Death");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        audioSource = mainCamera.GetComponent<AudioSource>();
        Debug.Log(audioSource);
        Debug.Log("Starting Health: " + playerLife);
        animator = GetComponent<Animator>();
        //animator.SetBool("MOVEMOVE", true);
        animator.Play("Unarmed Walk Forward");
    }

    // Update is called once per frame
    void Update()
    {
        playerLife = int.Parse(life.GetComponent<Text>().text);
        float step = speed * Time.deltaTime;
        Vector3 targetVector = new Vector3(target.position.x, 0, target.position.z);

        if(Vector3.Distance(new Vector3(transform.position.x, 0.0f, transform.position.z), target.position) > distToPlayer)
        {
            animator.SetBool("inRange", false);
            transform.position = Vector3.MoveTowards(transform.position, targetVector, step);
        }


        Vector3 targetPosNoY = new Vector3(target.position.x, -1.0f, target.position.z);

        transform.LookAt(targetPosNoY);
        if (Vector3.Distance(new Vector3(transform.position.x, 0.0f, transform.position.z), target.position) <= distToPlayer)
        {
            Debug.Log("Damn shorty you got hit");
            animator.SetBool("inRange", true);
            if (!hit) gotHit();
            
        }
    }

/*    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.collider.tag == "MainCamera")
        {
            Debug.Log("Damn shorty you got hit");
            gotHit();
            audioSource.Play();
        }
    }*/

    private void gotHit()
    {
        if(playerLife > 0)
        {
            //Destroy(gameObject);
            StartCoroutine(DelayHit());
            Debug.Log("Life Total: " + playerLife);
            //spawner.GetComponent<SpawnPadawan>().childrenCounter--;
        }
        else
        {
            //Todo: GameOver
        }
    }

    IEnumerator DelayHit()
    {
        //Wait for the specified delay time before continuing.
        hit = true;
        yield return new WaitForSecondsRealtime(2);
        OtherHit();
        //Do the action after the delay time has finished.
    }

    void OtherHit() { 
        audioSource.Play();
        playerLife--;
        life.GetComponent<Text>().text = playerLife.ToString();
        hit = false;
    }
}
