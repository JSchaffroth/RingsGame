using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject ring;
    public GameObject heart;
    public GameObject gas;
    public GameObject shield;
    public GameObject meteor;


    float randX;  //left or right side
    float randY;    //vertical distance relative to the spawner objects

    Vector3 whereToSpawn;

    public float spawnRate;
    float nextSpawn;

    int type;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 10f;
        nextSpawn = 5f;
        randX = Random.Range(0f, 17.5f);
        randY = Random.Range(0f, 3.3f);
        whereToSpawn = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z);
        Instantiate(ring, whereToSpawn, transform.rotation);
        this.transform.position.Set(-9f, 0.02f, 111f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnRate < 2f)
        {
            spawnRate = 2f;
        }
        spawnRate = 5;
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(0f, 17.5f);     //spawns on the left or the right
            randY = Random.Range(0f, 3.3f);//spawns in a range of Y values

            type = Random.Range(0, 10);

            if (type < 5)       //5 in 10 chance to spawn ring
            {
                whereToSpawn = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z);
                Instantiate(ring, whereToSpawn, transform.rotation);
            }

            else if (type < 8)  //3 in 10 chance to spawn heart
            {
                whereToSpawn = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z+100);
                Instantiate(heart, whereToSpawn, Quaternion.Euler(-90, 0, 0));
            }
            
            else if (type < 10)//1 in 5 chance to spawn meteor
            {
                whereToSpawn = new Vector3(transform.position.x + randX, 8 + randY, 0);
                Instantiate(meteor, whereToSpawn, transform.rotation);
            }
            else if (type < 7)  //1 in 6 chance to spawn gas
            {
                whereToSpawn = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z);
                //Instantiate(gas, whereToSpawn, Quaternion.Euler(0, 90, 180));
            }
            else if (type < 11) //1 in 6 chance to spawn shield
            {
                whereToSpawn = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z);
                //Instantiate(shield, whereToSpawn, Quaternion.Euler(0, 0, 180));
            }
        }
    }
}
