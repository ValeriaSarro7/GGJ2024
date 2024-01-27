using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputUIController : MonoBehaviour
{
    public List<CustomButton> ButtonList = new List<CustomButton>();
    public List<CustomSquare> SquareList = new List<CustomSquare>();
    public List<JokeCategory> Joke = new List<JokeCategory>();
    public Button SubmitButton;
    public Button DeleteButton;

    void Start()
    {
        ButtonList[0].button.onClick.AddListener(delegate{add(ButtonList[0].jokeCategory);});
        ButtonList[1].button.onClick.AddListener(delegate{add(ButtonList[1].jokeCategory);});
        ButtonList[2].button.onClick.AddListener(delegate{add(ButtonList[2].jokeCategory);});
        ButtonList[3].button.onClick.AddListener(delegate{add(ButtonList[3].jokeCategory);});
        SubmitButton.onClick.AddListener(delegate{submit();});
        DeleteButton.onClick.AddListener(delegate{delete();});
    }

    
    void Update()
    {
        
    }

    public void add(JokeCategory jokeCategory)
    {
        int index = Joke.Count;
        if(index < 3)
        {
            Joke.Add(jokeCategory);
            SquareList[index].changeColor(jokeCategory);
            print(jokeCategory.ToString());
        }
    }

    public void delete()
    {
        int index = Joke.Count - 1;
        if(index >= 0)
        {
            SquareList[index].changeColor(JokeCategory.None);
            Joke.RemoveAt(index);
        }
    }

    public List<JokeCategory> submit()
    {
        int index = Joke.Count;
        if(index == 3)
        {
            print(Joke[0] + " " + Joke[1] + " " + Joke[2]);
            return Joke;
        }
        return null;
    }
 }
