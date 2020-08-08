using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogPuzzles : MonoBehaviour
{
    //tutorial by Blackthornprod - Cool dialog system
    //Lighting Brackeys Tutorial


    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;

    public float typingSpeed;

    public bool Continue;


    public float restartDelay = 1f;

    bool gameHasEnded = false;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {

        if(Continue)
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

    public void NextSentence()
    {
        Continue = false;
        
        //continueButton.SetActive(false); //Making sure the player can't spam click the continue button

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


