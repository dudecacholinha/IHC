using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botoes : MonoBehaviour
{
    private Rigidbody rb;
    AudioSource audioData;

    private int collision=0;
    private Collider aux = null;
    private bool clicking = false;
    GameObject player;

    public int score=0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
    }
    private void OnMouseDown()
    {

        rb.position = new Vector3(rb.position[0], rb.position[1] - (float)0.5, rb.position[2]);
        //Debug.Log(collision);
        if (collision == 1)
        {
            //Debug.Log(aux.gameObject.tag);
            GameObject player = GameObject.FindWithTag("player");
            switch (aux.gameObject.tag)
            {

                case "nota":
                    audioData = GetComponent<AudioSource>();
                    audioData.Play(0);
                    collision = 0;
                    player.GetComponent<Score>().score += 10;
                    break;
                case "carro":
                    Debug.Log("wowowo");
                    clicking = true;
                    audioData = GetComponent<AudioSource>();
                    audioData.Play(0);
                    collision = 0;
                    player.GetComponent<Score>().score += 10;
                    break;
                case "creeper":
                    Debug.Log("creeper");
                    //GameObject player = GameObject.FindWithTag("player");
                    player.GetComponent<Health>().health--;
                    collision = 0;
                    player.GetComponent<Score>().score+=10;
                    break;
                default:
                    //Destroy(aux.gameObject);
                    break;
            }
            Destroy(aux.gameObject);

        }
        else
        {
            player.GetComponent<Health>().health--;
        }

    }
    private void OnMouseUp()
    {
        rb.position = new Vector3(rb.position[0], rb.position[1] + (float)0.5, rb.position[2]);
        clicking = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("ground"))
        {
            collision = 1;
            aux = other;
            if (clicking == true)
            {
                //other.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Destroy(other.gameObject);

            }

        }
        

    }


    private void OnTriggerExit(Collider other)
    {
            if (clicking==false&& (other.gameObject.CompareTag("carro") || other.gameObject.CompareTag("traseira")))
            {
                Destroy(other.gameObject.transform.parent.gameObject);
                collision = 0;
                aux = null;
                if (other.gameObject.CompareTag("carro"))
                    {
                        player.GetComponent<Health>().health--;
                    }
                

            }
            else
            {
                if (!other.gameObject.CompareTag("creeper"))
                {
                    player.GetComponent<Health>().health--;
                }
                Destroy(other.gameObject);
                
                //ter cuidado com esta condiçao
                if (other.gameObject.transform.parent!=null)
                {
                    Destroy(other.gameObject.transform.parent.gameObject);
                }
                
                aux = null;
            }
            

            

    }
}
