using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem.XR;
using Unity.VisualScripting;

public class GameManager : StateController
{
    public int maxTries = 10;
    public int currentTries = 10;

    public AudioManager audioManager;
    public CrowdController crowdController;
    public InputController inputController;
    public JokeController jokeController;
    public UIController uiController;

    public CinemachineVirtualCamera scenarioCamera;
    public CinemachineVirtualCamera jokeCamera;
    public CinemachineBrain cinemachineBrain;
    List<JokeCategory> bestJoke = null;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    void Start()
    {
        jokeController.ReadCSV();
        bestJoke = crowdController.GetBestJoke();
        string joke = jokeController.GetFullJoke(bestJoke[0], bestJoke[1], bestJoke[2]);
        //print(joke);
        uiController.UpdateTries(currentTries);
        scenarioCamera.enabled = true;
        jokeCamera.enabled = false;

        //Debug.LogWarning("GANADOR "+bestJoke[0] + " - "+ bestJoke[1] + " - " + bestJoke[2]);
    }
    public void OnSubmit(List<JokeCategory> jokeInput)
    {
        int result = 0;
        //Debug.LogWarning(jokeInput);
        for (int i = 0; i < bestJoke.Count; i++)
        {
            if (jokeInput[i] == bestJoke[i])
            {
                result += 2;
            }
            else if (bestJoke.Contains(jokeInput[i]))
            {
                result += 1;
            }
        }

        if (currentTries < 0)
        {
            uiController.SetActiveGameOverScreen(true);
        }

        currentTries--;
        uiController.UpdateTries(currentTries);


        uiController.StartDialogue(jokeController.GetJokeList(jokeInput));
        uiController.ProgressBar.value = result;

        //Debug.LogWarning("RESULT _" + result.ToString());
    }

    public void ResetGame()
    {
        scenarioCamera.enabled = true;
        jokeCamera.enabled = false;
        currentTries = maxTries;
        uiController.UpdateTries(currentTries);
    }

    public void SetActiveJokeCamera(bool value)
    {
        scenarioCamera.enabled = !value;
        jokeCamera.enabled = value;
    }

    public void SetActiveInputPanel(bool value) 
    {
        uiController.SetActiveInputPanel(value);
    }
    public void ToggleCamera() 
    {
        scenarioCamera.enabled = !scenarioCamera.enabled;
        jokeCamera.enabled = !jokeCamera.enabled;
    }

}
