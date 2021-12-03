using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPadawan : MonoBehaviour
{
    public GameObject PadawanPrefab;

    public Vector3 center;
    public Vector3 size;
    public float distanceFromPlayer = 2.0f;
    public float spawnTimer = 0f;
    public int childrenCounter = 0;
    public float RandomDist = 2.0f;

    private GameObject spawnedPadawan;

    // Start is called before the first frame update
    void Start()
    {
        //PadawanSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
            PadawanSpawner();*/
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 3 && childrenCounter < 3)
        {

            PadawanSpawner();
            spawnTimer = 0;
            childrenCounter++;
        }
    }

    public void PadawanSpawner()
    {
        float angle = Random.Range(0.0F, 6.28f);
        float randDist = Random.Range(0, RandomDist);
        Vector3 location = new Vector3(Mathf.Sin(angle) * (distanceFromPlayer + randDist), 0.0f, Mathf.Cos(angle) * (distanceFromPlayer + randDist));
        spawnedPadawan = Instantiate(PadawanPrefab, transform.localPosition + location, Quaternion.identity);
        var chance = Random.Range(0, 2);
        if (chance == 0)
        {
            spawnedPadawan.AddComponent<MOVEMOVE>();
        }
        else
        {
            spawnedPadawan.AddComponent<STANDSTAND>();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }
}