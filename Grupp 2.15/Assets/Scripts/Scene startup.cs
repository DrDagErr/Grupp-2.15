using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SceneStartup : MonoBehaviour
{
    
    public GameObject character;
    public GameObject speakText;

    [SerializeField] float waitSeconds;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject RizzButtons;
    [SerializeField] GameObject BestRizzButton;
    [SerializeField] GameObject GoodRizzButton;
    [SerializeField] GameObject BadRizzButton;
    [SerializeField] GameObject WorstRizzButton;
    [SerializeField] GameObject affecGO;
    [SerializeField] int eventPos = 0;
    public AffectionMeter affectionMeter;
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
        character.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);
        mainTextObject.SetActive(true);
        textToSpeak = "Hi. My name is Velma, I haven't seen you in this class before. Are you new here?";
        speakText.GetComponent <TMPro.TMP_Text>().text = textToSpeak;
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
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 2; 
    }

    IEnumerator EventTwo()
    {
        //EventTwo
        mainTextObject.SetActive(false);
        nextButton.SetActive(false);
        yield return new WaitForSeconds(1);
        affecGO.SetActive(true); 
        RizzButtons.SetActive(true);
    }
    IEnumerator BestRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = "Wow best Rizz.";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = 3; 
        
        nextButton.SetActive(true);
    }
    IEnumerator EventThree()
    {
        yield return new WaitForSeconds(1); 
    }
    IEnumerator GoodRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = "ok good Rizz.";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = 3;

        nextButton.SetActive(true);
    }
    IEnumerator BadRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = "emm... bad Rizz.";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = 3;

        nextButton.SetActive(true);
    }
    IEnumerator WorstRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = "Ew worst Rizz";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = 3;

        nextButton.SetActive(true);
    }
    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne()); 
        }
        if(eventPos == 2)
        {
            StartCoroutine(EventTwo()); 
        }
        if(eventPos == 3)
        {
            StartCoroutine(EventThree()); 
        }
    }
    public void bestRizzButton()
    {
        StartCoroutine(BestRizzEvent());
        affectionMeter.IncreaseAffection(25);
    }
    public void goodRizzButton()
    {
        StartCoroutine(GoodRizzEvent());
        affectionMeter.IncreaseAffection(12.5f);
    }
    public void badRizzButton()
    {
        StartCoroutine(BadRizzEvent());
        affectionMeter.IncreaseAffection(-12.5f);

    }
    public void worstRizzButton()
    {
        StartCoroutine(WorstRizzEvent());
        affectionMeter.IncreaseAffection(-25);

    }


}

