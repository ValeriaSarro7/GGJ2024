using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem.XR;

public class GameManager : StateController
{
    public CrowdController crowdController;
    public InputController inputController;
    public JokeController jokeController;
    public UIController uiController;

    public CinemachineVirtualCamera scenarioCamera;
    public CinemachineVirtualCamera jokeCamera;
    public CinemachineBrain cinemachineBrain;
    List<JokeCategory> bestJoke = null;

    void Start()
    {
        jokeController.ReadCSV();
        bestJoke = crowdController.GetBestJoke();
        string joke = jokeController.GetFullJoke(bestJoke[0], bestJoke[1], bestJoke[2]);
        print(joke);

        scenarioCamera.enabled = true;
        jokeCamera.enabled = false;

        Debug.LogWarning("GANADOR "+bestJoke[0] + " - "+ bestJoke[1] + " - " + bestJoke[2]);
    }
    public void OnSubmit(List<JokeCategory> jokeInput)
    {
        int result = 0;
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

        ToggleCamera();
        StartCoroutine("ToggleCameraAfterSeconds", 5);
        //WaitForSeconds(5)

        uiController.ProgressBar.value = result;
        Debug.LogWarning("RESULT _" + result.ToString());
    }

    public void ToggleCamera() 
    {
        scenarioCamera.enabled = !scenarioCamera.enabled;
        jokeCamera.enabled = !jokeCamera.enabled;
        uiController.ToggleInputPanel();
    }

    IEnumerator ToggleCameraAfterSeconds(int value) 
    {
        yield return new WaitForSeconds(value);
        ToggleCamera();
    }
}
