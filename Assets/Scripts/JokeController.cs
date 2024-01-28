using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public struct JokeItem
{
    public string text;
    public AudioClip clip;
}

public class JokeController : MonoBehaviour
{
    Dictionary<JokeCategory,List<string>> introJokesDictionary = new Dictionary<JokeCategory, List<string>>();
    Dictionary<JokeCategory,List<string>> middleJokesDictionary = new Dictionary<JokeCategory, List<string>>();
    Dictionary<JokeCategory,List<string>> finalJokesDictionary = new Dictionary<JokeCategory, List<string>>();

    string introAudiosFolderPath = "Voces/Inicios";
    string middleAudiosFolderPath = "Voces/Situación";
    string finalAudiosFolderPath = "Voces/Finales";

    public string GetFullJoke(JokeCategory introCategory, JokeCategory middleCategory, JokeCategory finalCategory) 
    {
        string result = "";
        result = GetJokeSectionByIndex(1, introCategory)+ " " + GetJokeSectionByIndex(2, middleCategory) + " " + GetJokeSectionByIndex(3, finalCategory); 
        return result;
    }
    public List<JokeItem> GetJokeList(List<JokeCategory> categories)
    {
        List<JokeItem> result = new List<JokeItem>();
        for (int i = 0; i < categories.Count; i++)
        {
            result.Add(GetJokeSectionByIndex(i+1, categories[i]));
        }

        return result;
    }

    public JokeItem GetJokeSectionByIndex(int index, JokeCategory category) 
    {
        AudioManager audioManager = ((GameManager)GameManager.instance).audioManager;
        Dictionary<JokeCategory, List<string>> dictionary;
        Dictionary<JokeCategory, List<AudioClip>> audioDictionary;
        JokeItem result = new JokeItem();

        switch (index) 
        {
            case 1:
                dictionary = introJokesDictionary;
                audioDictionary = audioManager.introAudiosDictionary;
                break;
            case 2:
                dictionary = middleJokesDictionary;
                audioDictionary = audioManager.middleAudiosDictionary;
                break;
            case 3:
                dictionary = finalJokesDictionary;
                audioDictionary = audioManager.finalAudiosDictionary;
                break;
            default:
                return result;
        };

        int randomElement = Random.Range(0,dictionary[category].Count);
        result.text = dictionary[category][randomElement];
        result.clip = audioDictionary[category][randomElement];

        return result;
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

        AudioManager audioManager = ((GameManager)GameManager.instance).audioManager;

        audioManager.introAudiosDictionary.Add(JokeCategory.NEGROS, new List<AudioClip>());
        audioManager.introAudiosDictionary.Add(JokeCategory.VERDES, new List<AudioClip>());
        audioManager.introAudiosDictionary.Add(JokeCategory.INFORMATICOS, new List<AudioClip>());
        audioManager.introAudiosDictionary.Add(JokeCategory.BLANCOS, new List<AudioClip>());

        audioManager.middleAudiosDictionary.Add(JokeCategory.NEGROS, new List<AudioClip>());
        audioManager.middleAudiosDictionary.Add(JokeCategory.VERDES, new List<AudioClip>());
        audioManager.middleAudiosDictionary.Add(JokeCategory.INFORMATICOS, new List<AudioClip>());
        audioManager.middleAudiosDictionary.Add(JokeCategory.BLANCOS, new List<AudioClip>());

        audioManager.finalAudiosDictionary.Add(JokeCategory.NEGROS, new List<AudioClip>());
        audioManager.finalAudiosDictionary.Add(JokeCategory.VERDES, new List<AudioClip>());
        audioManager.finalAudiosDictionary.Add(JokeCategory.INFORMATICOS, new List<AudioClip>());
        audioManager.finalAudiosDictionary.Add(JokeCategory.BLANCOS, new List<AudioClip>());


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
                audioManager.introAudiosDictionary[enumResult].Add(introClip);

                path = middleAudiosFolderPath + "/" + i.ToString("00");
                AudioClip middleClip = (Resources.Load(path) as AudioClip);
                audioManager.middleAudiosDictionary[enumResult].Add(middleClip);

                path = finalAudiosFolderPath + "/" + i.ToString("00");
                AudioClip finalClip = (Resources.Load(path) as AudioClip);
                audioManager.finalAudiosDictionary[enumResult].Add(finalClip);
            }
        }
    }
}
