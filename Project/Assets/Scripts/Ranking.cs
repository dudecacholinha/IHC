using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    // Start is called before the first frame update
    private void Awake()
    {
        //PlayerPrefs.DeleteKey("highscoreTable");


        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(10000, "CMK");
        // Supostamente para tirar
        //highscoreEntryList = new List<HighScoreEntry>()
        //{
        //    new HighScoreEntry{score = 5212312, name = "TO"},
        //    new HighScoreEntry{score = 31233, name = "DU"}
        //};



        // Para carregar do json

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(1000000, "CMK");
            AddHighscoreEntry(897621, "JOE");
            AddHighscoreEntry(872931, "DAV");
            AddHighscoreEntry(785123, "CAT");
            AddHighscoreEntry(542024, "MAX");
            AddHighscoreEntry(68245, "AAA");

        }
            // Dar sort aqui!

            // Codigo do sort
            Debug.Log(PlayerPrefs.GetInt("Lastscore"));

        highscoreEntryTransformList = new List<Transform>();
        AddHighscoreEntry(PlayerPrefs.GetInt("Lastscore"), "teste");
        SortScores(highscores);
        Debug.Log(highscores.highscoreEntryList.Count);
        foreach (HighScoreEntry highscoreEntry in highscores.highscoreEntryList) 
        {
            if (highscores.highscoreEntryList.Count == 5) // Para só ter 5 entradas
            {
                break;
            }
            CreatedHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        //// Para guardar o ranking
        //Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        //string json = JsonUtility.ToJson(highscores);
        //PlayerPrefs.SetString("highscoreTable", json);
        //PlayerPrefs.Save();
        ////Debug.Log(PlayerPrefs.GetString("highscoreTable"));  

    }

    private void CreatedHighscoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 20f;
        Transform entryTrasform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTrasform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTrasform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        entryTrasform.Find("posText").GetComponent<Text>().text = rank.ToString();

        int score = highScoreEntry.score;
        entryTrasform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTrasform.Find("nameText").GetComponent<Text>().text = name;
        transformList.Add(entryTrasform);

    }
    public void AddHighscoreEntry(int score, string name) {
        

        // Create HighscoreEntry
        HighScoreEntry highscoreEntry = new HighScoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to Highscore
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }
   
    // Para ordenar a lista de scores
    private void SortScores(Highscores highscores)
    {
        highscores.highscoreEntryList.Sort(SortByScore);
    }
    // Compare
    static int SortByScore(HighScoreEntry p1, HighScoreEntry p2)
    {
        return p2.score.CompareTo(p1.score);
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
