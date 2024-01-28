using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public GameObject boxGameObject;
    public TMP_Text textLabel;
    public List<string> dialogues;
    public Button nextButton;
    public int currentDialogue = -1;
    public float textSpeed = 100f;

    private void Start()
    {
        nextButton.onClick.AddListener(delegate { ShowNextDialogue(); });
    }

    public void SetText(string text)
    {
        StartCoroutine(TypeText(text));
    }

    public void ClearText()
    {
        currentDialogue = -1;
        textLabel.text = "";
    }

    IEnumerator TypeText(string text)
    {
        textLabel.text = "";
        float time = 0;
        int charIndex = 0;

        while (charIndex < text.Length)
        {
            time += Time.deltaTime * textSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, text.Length);

            textLabel.text = text.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = text;
    }

    public void ToggleBox() 
    {
        boxGameObject.SetActive(!boxGameObject.activeSelf);
    }

    public void ShowNextDialogue()
    {
        GameManager gameManager = (GameManager)GameManager.instance;
        
        currentDialogue++;
        if (dialogues.Count > currentDialogue)
        {
            gameManager.SetActiveJokeCamera(true);
            gameManager.SetActiveInputPanel(false);
            SetText(dialogues[currentDialogue]);
        }
        else
        {
            gameManager.SetActiveJokeCamera(false);
            gameManager.SetActiveInputPanel(true);
            boxGameObject.SetActive(true);
            ClearText();
            ToggleBox();
        }
    }
}
