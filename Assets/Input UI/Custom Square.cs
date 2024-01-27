using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CustomSquare : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void changeColor(JokeCategory jokeCategory)
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        switch (jokeCategory)
        {
            case JokeCategory.NEGROS:
                image1.SetActive(true);
            break;
            case JokeCategory.BLANCOS:
                image2.SetActive(true);
            break;
            case JokeCategory.VERDES:
                image3.SetActive(true);
            break;
            case JokeCategory.INFORMATICOS:
                image4.SetActive(true);
            break;
        }   
    }
}
