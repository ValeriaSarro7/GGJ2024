using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JokeController : MonoBehaviour
{
    public Dictionary<JokeCategory,List<string>> introJokesDictionary = new Dictionary<JokeCategory, List<string>>();
    public Dictionary<JokeCategory,List<string>> middleJokesDictionary = new Dictionary<JokeCategory, List<string>>();
    public Dictionary<JokeCategory,List<string>> finalJokesDictionary = new Dictionary<JokeCategory, List<string>>();

    void Start()
    {
    }

    void Update()
    {
        
    }

    public string GetFullJoke(JokeCategory introCategory, JokeCategory middleCategory, JokeCategory finalCategory) 
    {
        string result = "";
        result = GetJokeSectionByIndex(1, introCategory)+ " " + GetJokeSectionByIndex(2, middleCategory) + " " + GetJokeSectionByIndex(3, finalCategory); 
        return result;
    }

    public string GetJokeSectionByIndex(int index, JokeCategory category) 
    {
        Dictionary<JokeCategory, List<string>> dictionary;

        switch (index) 
        {
            case 1:
                dictionary = introJokesDictionary;
                break;
            case 2:
                dictionary = middleJokesDictionary;
                break;
            case 3:
                dictionary = finalJokesDictionary;
                break;
            default:
                return "";
        };

        int randomElement = Random.Range(0,dictionary[category].Count);
        string jokeResult = dictionary[category][randomElement];
        return jokeResult;
    }

    public void ReadCSV()
    {
        introJokesDictionary.Add(JokeCategory.NEGROS, new List<string>());
        introJokesDictionary.Add(JokeCategory.VERDES, new List<string>());
        introJokesDictionary.Add(JokeCategory.INFORMATICOS, new List<string>());
        introJokesDictionary.Add(JokeCategory.BLANCOS, new List<string>());

        middleJokesDictionary.Add(JokeCategory.NEGROS, new List<string>());
        middleJokesDictionary.Add(JokeCategory.VERDES, new List<string>());
        middleJokesDictionary.Add(JokeCategory.INFORMATICOS, new List<string>());
        middleJokesDictionary.Add(JokeCategory.BLANCOS, new List<string>());

        finalJokesDictionary.Add(JokeCategory.NEGROS, new List<string>());
        finalJokesDictionary.Add(JokeCategory.VERDES, new List<string>());
        finalJokesDictionary.Add(JokeCategory.INFORMATICOS, new List<string>());
        finalJokesDictionary.Add(JokeCategory.BLANCOS, new List<string>());

        var dataset = Resources.Load<TextAsset>("JokesTable3");
        string[] dataLines = dataset.text.Split('\n');

        for (int i = 1; i < dataLines.Length; i++)
        {
            List<string> data = dataLines[i].Split(';').ToList();
            
            if (System.Enum.TryParse<JokeCategory>(data[0], out JokeCategory enumResult))
            {
                introJokesDictionary[enumResult].Add(data[1]);
                middleJokesDictionary[enumResult].Add(data[2]);
                finalJokesDictionary[enumResult].Add(data[3]);
            }
        }
    }
}
