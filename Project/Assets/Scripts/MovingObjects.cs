using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{

    public GameObject new_block;
    public Transform target;
    public float spawnTime = 0.0f;
    //public float spawnDelay;
    private float minTime=0.0f;
    private float maxTime=5.0f;

    //Velocidade
    public float speed = 1.0f;  

    private int chooseObj;


    // Start is called before the first frame update
    void Start()
    {   
         // Position the cube at the origin.
        //transform.position = new Vector3(2.0f, 0.5f, 2.0f);

        //InvokeRepeating("SpawnBlock", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update(){
        //Dar spawn e mover ao longo de um vector que se dirige para os botões
        //this.spawnTime -= Time.deltaTime;
        /*if (this.spawnTime <= 0){
            chooseObj = Random.Range(1,5);
            SpawnBlock();
        }*/
        
        moveAlong();

    }


    public void SpawnBlock()
    {   
        switch (chooseObj){
            case 1:
                Instantiate(new_block, transform.position = new Vector3(-3.75f, 0.5f, 0f), transform.rotation);
                moveAlong();
                break;
            case 2:
                Instantiate(new_block, transform.position = new Vector3(-2.0f, 0.5f, 0f), transform.rotation);
                moveAlong();
                break;
            case 3:
                Instantiate(new_block, transform.position = new Vector3(0f, 0.5f, 0f), transform.rotation);
                moveAlong();
                break;
            case 4:
                Instantiate(new_block, transform.position = new Vector3(2f, 0.5f, 0f), transform.rotation);
                moveAlong();
                break;
            case 5:
                Instantiate(new_block, transform.position = new Vector3(3.95f, 0.5f, 0f), transform.rotation);
                moveAlong();
                break;

        }

        //Apenas para testar o spawn random
        //Instantiate(new_block, transform.position = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f)), transform.rotation);
    }

    public void moveAlong(){
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position+ new Vector3(0,0,-10), step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            //Destroi o objecto
            Destroy(new_block);
        }
    }


    public void RandomObj(){
        this.spawnTime = Random.Range(this.minTime, this.maxTime);
    }


}
