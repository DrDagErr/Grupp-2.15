using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public TextMeshProUGUI BestRizzText;
    public TextMeshProUGUI GoodRizzText;
    public TextMeshProUGUI BadRizzText;
    public TextMeshProUGUI WorstRizzText;
    string BestRizzReaction;
    string GoodRizzReaction;
    string BadRizzReaction;
    string WorstRizzReaction;
    int SaveEventPos;
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
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 1;
    }
    IEnumerator Question1()
    {
        //Event1
        nextButton.SetActive(false);
        textToSpeak = "Oh you are? I remember the first time i attendant miss Erika's class it was quite challenging at first. Are you familiar with the Callan-Symanzik equation?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        BestRizzText.text = "Callans equation from 1970 that lets you know the mass of a proton? Why yes, I am more than familiar with it.";
        BestRizzReaction = "Oh wow your pretty smart.";
        GoodRizzText.text = "No I haven't heard of that one, care to tell me what it is about?";
        GoodRizzReaction = "Oh its the best, you get to calculet the mass of a proton, its so fun!";
        BadRizzText.text = "Is that the equation that estimates the mass of a proton, yeah i have heard about it but didn't really care for it";
        BadRizzReaction = "Why not? its so much fun!";
        WorstRizzText.text = "Heh no, why would i care about that?";
        WorstRizzReaction = "Because it is coming on the exam we have tomorrow, i would start studying.";
        nextButton.SetActive(true);
        SaveEventPos = eventPos;
        eventPos = 2;

    }

    IEnumerator Awnsers()
    {
        //EventTwo
        mainTextObject.SetActive(false);
        nextButton.SetActive(false);
        yield return new WaitForSeconds(1);
        affecGO.SetActive(true);
        RizzButtons.SetActive(true);
        eventPos = SaveEventPos += 1;
    }
    IEnumerator Question2()
    {
        nextButton.SetActive(false);
        affecGO.SetActive(false);
        textToSpeak = "Well never mind that, we have to work in groups of two. Wanna team up? ";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        BestRizzText.text = "What a great idea, I would love to.";
        BestRizzReaction = "Fantastic, this will be great!";
        GoodRizzText.text = "Sure but go a bit easy on me i haven't had the opportunity to warm up.";
        GoodRizzReaction = "Well it's not a competition, let's just try and help each other.";
        BadRizzText.text = "Ok but dont espect me to slow down for you.";
        BadRizzReaction = "Well it's not a competition, let's just try and help each other.";
        WorstRizzText.text = "Fine, I guess you can work with me, but you'll have to do all the work.";
        WorstRizzReaction = "Emm... ok, i'll teach you along the way.";
        nextButton.SetActive(true);
        SaveEventPos = eventPos -= 1;
        eventPos = 2;

    }
    IEnumerator Question3()
    {
        nextButton.SetActive(false);
        affecGO.SetActive(false);
        textToSpeak = "So, about this assignment... How do you think we should split the work?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        BestRizzText.text = "How about we work together on everything? That way, we can both learn and help each other out.";
        BestRizzReaction = "That sounds like a great idea! Two heads are better than one, right?";

        GoodRizzText.text = "I could handle the research, and you could focus on putting it all together. We’d make a great team!";
        GoodRizzReaction = "That’s a solid plan! I like how you’re thinking ahead.";

        BadRizzText.text = "I’ll take the easy parts, and you can do the hard stuff. You seem like you’d ace it.";
        BadRizzReaction = "Um… I guess I can handle it, but it’d be nice to have some help on the harder parts.";

        WorstRizzText.text = "I’ll just do my part quickly so I can relax, and you can finish the rest.";
        WorstRizzReaction = "Wait… that’s not very fair. This is supposed to be a team effort!";

        nextButton.SetActive(true);
        SaveEventPos = eventPos -= 1;
        eventPos = 2;

    }
    IEnumerator Question4()
    {
        // Set up Question 4
        nextButton.SetActive(false);
        affecGO.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        // Dialogue setup
        textToSpeak = "We did such a great job on this assignment! You were amazing to work with. I really enjoyed it.";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;

        // Wait until the text finishes displaying
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        // Set up the flirtation options
        BestRizzText.text = "Well, I guess we make a perfect team. Maybe we should pair up more often? Maybe over some coffe?";
        BestRizzReaction = "Are... you asking me on a date?";

        GoodRizzText.text = "Thanks! I couldn't have done it without you. Maybe we should celebrate sometime?";
        GoodRizzReaction = "Are... you asking me on a date?";

        BadRizzText.text = "Uh... so, I mean, if you’re not busy... and like, I don’t know, if you want... maybe we could go do something sometime? Or not. No pressure or anything.";
        BadRizzReaction = "Are... you asking me on a date?";

        WorstRizzText.text = "I see the way you were looking at me while we worked, you wanna go on a date with me don't you?";
        WorstRizzReaction = "Emmmm.....";

        nextButton.SetActive(true); // Enable the "Next" button for the next interaction
        SaveEventPos = eventPos -= 1;
        eventPos = 2; // Update event position
    }

    IEnumerator Date()
    {
        if (affectionMeter.Affection == 100)
        {
            yield return new WaitForSeconds(1.5f);
            nextButton.SetActive(false);
            affecGO.SetActive(false);

            textToSpeak = "Really?! Oh wow, yes! That sounds amazing! I promise I won’t bore you with quantum field theory talk. Or maybe... just a little?!";
            speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
            currentTextLength = textToSpeak.Length;
            TextCreater.runTextPrint = true;

            // Wait until the text finishes displaying
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => textLength == currentTextLength);
            yield return new WaitForSeconds(0.5f);
            eventPos = 7;
            nextButton.SetActive(true);
        }
        if (affectionMeter.Affection >= 50 && affectionMeter.Affection <= 99)
        {
            yield return new WaitForSeconds(1.5f);
            nextButton.SetActive(false);
            affecGO.SetActive(false);

            textToSpeak = "That's so sweet of you to ask! I had a great time too, but I think we’re better off as friends. I really value what we have.";
            speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
            currentTextLength = textToSpeak.Length;
            TextCreater.runTextPrint = true;

            // Wait until the text finishes displaying
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => textLength == currentTextLength);
            yield return new WaitForSeconds(0.5f);
            eventPos = 7;
            nextButton.SetActive(true);
        }
        if (affectionMeter.Affection < 50)
        {
            yield return new WaitForSeconds(1.5f);
            nextButton.SetActive(false);
            affecGO.SetActive(false);

            textToSpeak = "Thanks for asking, but I’m not interested. I hope you understand.";
            speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
            currentTextLength = textToSpeak.Length;
            TextCreater.runTextPrint = true;

            // Wait until the text finishes displaying
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => textLength == currentTextLength);
            yield return new WaitForSeconds(0.5f);
            eventPos = 7;
            nextButton.SetActive(true);
        }
        


    }
    IEnumerator BestRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = BestRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = SaveEventPos += 1;

        nextButton.SetActive(true);
    }
    IEnumerator GoodRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = GoodRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = SaveEventPos += 1;

        nextButton.SetActive(true);
    }
    IEnumerator BadRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = BadRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = SaveEventPos += 1;

        nextButton.SetActive(true);
    }
    IEnumerator WorstRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = WorstRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = SaveEventPos += 1;

        nextButton.SetActive(true);
    }
    public void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(Question1());
        }
        if (eventPos == 2)
        {
            StartCoroutine(Awnsers());
        }
        if (eventPos == 3)
        {
            StartCoroutine(Question2());
        }
        if (eventPos == 4)
        {
            StartCoroutine(Question3());
        }
        if (eventPos == 5)
        {
            StartCoroutine(Question4());
        }
        if (eventPos == 6)
        {
            StartCoroutine(Date());
        }
        if (eventPos == 7)
        {
            SceneManager.LoadScene("Menu");
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

