using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    List<JokeCategory> bestJoke = new List<JokeCategory>();

    private void Awake()
    {
        GenerateBestJoke();
    }

    public List<JokeCategory> GetBestJoke()
    {
        return bestJoke;
    }

    private void GenerateBestJoke() 
    {
        int RandomIndex = Random.Range(0, 4);
        bestJoke.Add((JokeCategory)RandomIndex);
        RandomIndex = Random.Range(0, 4);
        bestJoke.Add((JokeCategory)RandomIndex);
        RandomIndex = Random.Range(0, 4);
        bestJoke.Add((JokeCategory)RandomIndex);
    }

    void EvaluateJoke() 
    {
    }

}
