using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    //public int nuberofhearts;
    public Image[] hearts;
    //public Sprite full;
    //public Sprite empty;
    public Text lose;
    GameObject ranking;
    GameObject player;
    void Start()

    {
        lose.text = "";

        player = GameObject.FindWithTag("player");
        
        //ranking = GameObject.FindWithTag("ranking"); //Está a null
        //GameObject[] goArray = SceneManager.GetSceneByName("Assets/Scenes/Ranking.unity").GetRootGameObjects();
        //if (goArray.Length > 0)
        //{

        //    if (goArray.FindGameObjectWithTag("ranking") != null)
        //    {
        //        ranking = GameObject.FindWithTag("ranking");
        //    }
        //}
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i<health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health<1)
        {
            lose.text = "PERDEU";
            // Adicionar ao ranking
            
            Debug.Log("Score" + player.GetComponent<Score>().score);
            Debug.Log("Valor"+player.GetComponent<Ranking>());
            PlayerPrefs.SetInt("Lastscore", player.GetComponent<Score>().score);
       
        }
    }

    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }


}
