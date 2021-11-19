using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPadawan : MonoBehaviour
{
    public GameObject PadawanPrefab;

    public Vector3 center;
    public Vector3 size;
    public float distanceFromPlayer = 2;
    public float spawnTimer = 0f;
    public int childrenCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        PadawanSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
            PadawanSpawner();*/
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 3 && childrenCounter < 10)
        {
            PadawanSpawner();
            spawnTimer = 0;
            childrenCounter++;
        }
    }

    public void PadawanSpawner()
    {
        float x;
        float z;
        bool reroll = false;
        do
        {
            x = Random.Range(-size.x / 2, size.x / 2);
            z = Random.Range(-size.z / 2, size.z / 2);

            if (x > -distanceFromPlayer && x < distanceFromPlayer)
                if (z > -distanceFromPlayer && z < distanceFromPlayer)
                    reroll = true;
                else
                    reroll = false;
            else
                reroll = false;
        } while (reroll);

        Vector3 pos = (transform.localPosition + center) + new Vector3(x, (float)0.1, z);
        Instantiate(PadawanPrefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }
}