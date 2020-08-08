using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogPuzzles : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences; //Amount of sentences
    private int index;

    public float typingSpeed; //Typing animation speed

    public bool Continue;

    public float restartDelay = 1f;

    bool gameHasEnded = false;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(Continue) //Hit space to continue
        {
            if(Input.GetKeyDown("space"))
            {
                NextSentence();
            }
        }
        
        if (textDisplay.text == sentences[index])
        {
            Continue = true;
        }


    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() //Stop button spamming
    {
        Continue = false;

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }

}


