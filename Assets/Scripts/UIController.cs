using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public List<CustomButton> ButtonList = new List<CustomButton>();
    public List<CustomSquare> SquareList = new List<CustomSquare>();
    public List<JokeCategory> Joke = new List<JokeCategory>();
    public Button SubmitButton;
    public Button DeleteButton;
    public GameObject InputPanel;
    public ProgressBar ProgressBar;
    public DialogueSystem dialogueBox;

    void Start()
    {
        ButtonList[0].button.onClick.AddListener(delegate{Add(ButtonList[0].jokeCategory);});
        ButtonList[1].button.onClick.AddListener(delegate{Add(ButtonList[1].jokeCategory);});
        ButtonList[2].button.onClick.AddListener(delegate{Add(ButtonList[2].jokeCategory);});
        ButtonList[3].button.onClick.AddListener(delegate{Add(ButtonList[3].jokeCategory);});
        SubmitButton.onClick.AddListener(delegate{Submit();});
        DeleteButton.onClick.AddListener(delegate{Delete();});
        ProgressBar.value = 0;
    }

    public void Add(JokeCategory jokeCategory)
    {
        int index = Joke.Count;
        if(index < 3)
        {
            Joke.Add(jokeCategory);
            SquareList[index].ChangeColor(jokeCategory);
        }
    }

    public void Delete()
    {
        int index = Joke.Count - 1;
        if(index >= 0)
        {
            SquareList[index].ChangeColor(JokeCategory.None);
            Joke.RemoveAt(index);
        }
    }

    public void DeleteAll()
    {
        int ToDelete = Joke.Count;
        for (int i = 0; i < ToDelete; i++)
        {
            Delete();
        }
    }

    public List<JokeCategory> Submit()
    {
        int index = Joke.Count;
        if(index == 3)
        {
            GameManager gameManager = (GameManager)GameManager.instance;
            gameManager.OnSubmit(Joke);
            DeleteAll();
        
            return Joke;
        }
        return null;
    }
    public void SetActiveInputPanel(bool value)
    {
        InputPanel.SetActive(value);
    }
    public void ToggleInputPanel() 
    {
        InputPanel.SetActive(!InputPanel.activeSelf);
    }

    public void SetActiveDialogueBox(bool value)
    {
        dialogueBox.ToggleBox();
    }

    public void ToggleDialogueBox()
    {
        dialogueBox.ToggleBox();
    }

    public void StartDialogue(List<string> dialogues)
    {
        dialogueBox.ToggleBox();
        dialogueBox.dialogues = dialogues;
        dialogueBox.ShowNextDialogue();
    }

    public void OnClickNextText()
    {
        dialogueBox.ShowNextDialogue();
    }

}
