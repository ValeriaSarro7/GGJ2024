using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateController
{ 
    public CrowdController crowdController;
    public InputController inputController;
    public JokeController jokeController;
    public UIController uiController;

    void Start()
    {
        jokeController.ReadCSV();
        string joke = jokeController.GetFullJoke((JokeCategory)Random.Range(0,3), (JokeCategory)Random.Range(0, 3), (JokeCategory)Random.Range(0, 3));
        print(joke);
        List<JokeCategory> bestJoke = crowdController.GetBestJoke();
        Debug.LogWarning(bestJoke[0] + " - "+ bestJoke[1] + " - " + bestJoke[2]);
    }

    void Update()
    {
    }
}
