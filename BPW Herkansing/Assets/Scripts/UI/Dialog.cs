using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences; //Amount of sentences
    private int index;

    public float typingSpeed; //speed the letters spawn

    public GameObject continueButton;

    public bool Continue;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (Continue) //Hit space to continue to next sentence
        {
            if (Input.GetKeyDown("space"))
            {
                NextSentence();
            }
        }

        if (textDisplay.text == sentences[index])
        {
            Continue = true;
        }
    }
    IEnumerator Type() //Typing animation
    {

      foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        Continue = false; //Making sure the player can't spam click the continue button

        if(index < sentences.Length - 1)
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
