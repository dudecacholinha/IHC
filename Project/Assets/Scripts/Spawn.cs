using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnee;
    public GameObject  crepper;
    public Transform target;
    public bool stopSpawn;
    public float sapwnTime;
    public float spawnDelay;
    public float creeper_chance;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(spawnee.GetComponent<MovingObjects>().target);
        Debug.Log(target);
        spawnee.GetComponent<MovingObjects>().target = target;
        crepper.GetComponent<MovingObjects>().target = target;
        InvokeRepeating("spawnObject", sapwnTime, spawnDelay);
    }

    public void spawnObject(){
        //Debug.Log(transform.rotation.w);
        //Quaternion teste = new Quaternion(spawnee.transform.rotation.x, spawnee.transform.rotation.y, spawnee.transform.rotation.z, spawnee.transform.rotation.w);

        if (Random.Range(0.0f, 1.0f)>creeper_chance)
        {
            //Debug.Log(spawnee.GetComponent<MovingObjects>().target);
            spawnee.GetComponent<MovingObjects>().target = target;
            Instantiate(spawnee, transform.position, spawnee.transform.rotation);
        }
        else
        {
            //meter o alvo do crepper aqui
            //Debug.Log(crepper.GetComponent<MovingObjects>().target);
            crepper.GetComponent<MovingObjects>().target = target;
            Instantiate(crepper, transform.position,  crepper.transform.rotation);
        }
        


    }

}
