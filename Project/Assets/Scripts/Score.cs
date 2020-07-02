using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    // Use this for initialization
    public Text scorevalue;
    void Start()
    {
        score=0;
        scorevalue.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        scorevalue.text = score.ToString(); // está NULL
    }
}
