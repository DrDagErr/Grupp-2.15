using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartup : MonoBehaviour
{
    
    public GameObject character;
    public GameObject textBox;

    [SerializeField] float waitSeconds;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0; 

    void Update()
    {
        textLength = TextCreater.charCount;
    }

    void Start()
    {
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        //event0
        yield return new WaitForSeconds(waitSeconds);
        //fadeScreenIn.SetActive(false);
        character.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);
        // this is where our text function will go
        mainTextObject.SetActive(true);
        textToSpeak = "bla bla bla lalall bal";
        textBox.GetComponent <TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true; 
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true); 
        eventPos = 1; 
    }
    IEnumerator EventOne()
    {
        //Event1
        nextButton.SetActive(false);
        textToSpeak = "Hello, my name is Velma";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 2; 
    }
    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne()); 
        }
    }
}

