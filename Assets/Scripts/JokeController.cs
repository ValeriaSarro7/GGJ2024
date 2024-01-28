using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JokeController : MonoBehaviour
{
    Dictionary<JokeCategory,List<string>> introJokesDictionary = new Dictionary<JokeCategory, List<string>>();
    Dictionary<JokeCategory,List<string>> middleJokesDictionary = new Dictionary<JokeCategory, List<string>>();
    Dictionary<JokeCategory,List<string>> finalJokesDictionary = new Dictionary<JokeCategory, List<string>>();

    string introAudiosFolderPath = "Voces/Inicios";
    string middleAudiosFolderPath = "Voces/Situación";
    string finalAudiosFolderPath = "Voces/Finales";

    Dictionary<JokeCategory, List<AudioClip>> introAudiosDictionary = new Dictionary<JokeCategory, List<AudioClip>>();
    Dictionary<JokeCategory, List<AudioClip>> middleAudiosDictionary = new Dictionary<JokeCategory, List<AudioClip>>();
    Dictionary<JokeCategory, List<AudioClip>> finalAudiosDictionary = new Dictionary<JokeCategory, List<AudioClip>>();

    public string GetFullJoke(JokeCategory introCategory, JokeCategory middleCategory, JokeCategory finalCategory) 
    {
        string result = "";
        result = GetJokeSectionByIndex(1, introCategory)+ " " + GetJokeSectionByIndex(2, middleCategory) + " " + GetJokeSectionByIndex(3, finalCategory); 
        return result;
    }
    public List<string> GetJokeList(List<JokeCategory> categories)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < categories.Count; i++)
        {
            result.Add(GetJokeSectionByIndex(i+1, categories[i]));
        }

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

        introAudiosDictionary.Add(JokeCategory.NEGROS, new List<AudioClip>());
        introAudiosDictionary.Add(JokeCategory.VERDES, new List<AudioClip>());
        introAudiosDictionary.Add(JokeCategory.INFORMATICOS, new List<AudioClip>());
        introAudiosDictionary.Add(JokeCategory.BLANCOS, new List<AudioClip>());

        middleAudiosDictionary.Add(JokeCategory.NEGROS, new List<AudioClip>());
        middleAudiosDictionary.Add(JokeCategory.VERDES, new List<AudioClip>());
        middleAudiosDictionary.Add(JokeCategory.INFORMATICOS, new List<AudioClip>());
        middleAudiosDictionary.Add(JokeCategory.BLANCOS, new List<AudioClip>());

        finalAudiosDictionary.Add(JokeCategory.NEGROS, new List<AudioClip>());
        finalAudiosDictionary.Add(JokeCategory.VERDES, new List<AudioClip>());
        finalAudiosDictionary.Add(JokeCategory.INFORMATICOS, new List<AudioClip>());
        finalAudiosDictionary.Add(JokeCategory.BLANCOS, new List<AudioClip>());


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

                string path = introAudiosFolderPath + "/" + i.ToString("00");
                AudioClip introClip = (Resources.Load(path) as AudioClip);
                introAudiosDictionary[enumResult].Add(introClip);
                middleAudiosDictionary[enumResult].Add((Resources.Load(middleAudiosFolderPath + "/" + i.ToString("00")) as AudioClip));
                finalAudiosDictionary[enumResult].Add((Resources.Load(finalAudiosFolderPath + "/" + i.ToString("00")) as AudioClip));
            }
        }
    }
}
