using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneStartupPEClass : MonoBehaviour
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
    int saveEventPos;
    public AffectionMeter affectionMeter;

    public TextMeshProUGUI bestRizzText;
    public TextMeshProUGUI goodRizzText;
    public TextMeshProUGUI badRizzText;
    public TextMeshProUGUI worstRizzText;
    
    string bestRizzReaction;
    string goodRizzReaction;
    string badRizzReaction;
    string worstRizzReaction;
    void Update()
    {
        textLength = TextCreater.charCount;
    }

    void Start()
    {
        StartCoroutine(Introduction1());

    }

    IEnumerator Introduction1()
    {
        //event0
        yield return new WaitForSeconds(waitSeconds);
        character.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);
        mainTextObject.SetActive(true);
        textToSpeak = "Hi there, i haven't seen you before, my name is Alex";
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
    IEnumerator Introduction2()
    {
        //Event1
        nextButton.SetActive(false);
        textToSpeak = "Oohhh, you are new, nice to meet you!";
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
    IEnumerator Question1()
    {
        nextButton.SetActive(false);
        textToSpeak = "What do you like to do during your free time?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "I like doing active activities such as going on hikes and such";
        goodRizzText.text = "I usually like going out with friends and doing stuff to stay active";
        badRizzText.text = "I like to ocasionally go out on a run but mostly take it easy at home";
        worstRizzText.text = "I love playing games with my friends";

        bestRizzReaction = "Nice! You’re my kind of person. No time for laziness!";
        goodRizzReaction = "That’s decent! As long as you don’t slack off.";
        badRizzReaction = "Ugh, that’s weak. You should do more, its good for you.";
        worstRizzReaction = "Wow, no wonder you’re so slow. You don't do much fun huh";

        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;

    }

   
    IEnumerator Question2()
    {
        nextButton.SetActive(false);
        textToSpeak = "Alright if we were stuck in a zombie apocalypse, what’s your first move?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "Find weapons and fight back, thats for sure.";
        goodRizzText.text = "Run fast and keep moving so they can't keep up.";
        badRizzText.text = "Find a good place for shelter and only go out to find necesities such as food and water.";
        worstRizzText.text = "Lie down and accept my fate. I know i couldn't fight against the zombies.";

        bestRizzReaction = "Yes! You’d be on the front lines with me. Let’s go!";
        goodRizzReaction = "Smart move. Just make sure they don't catch you!";
        badRizzReaction = "Might be safe, but have some fun instead, boring.";
        worstRizzReaction = "Seriously? I can’t believe you just said that. Pathetic.";

        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;
    }
    IEnumerator Question3()
    {
        nextButton.SetActive(false);
        textToSpeak = "What’s your idea of a perfect day?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "Go hiking to the top of a hill and paragliding down from it for sure. Gives me both training and excitment!";
        goodRizzText.text = "Going out and playing some sports with friends and just having a fun time.";
        badRizzText.text = "Go out clubbing with friends, for sure.";
        worstRizzText.text = "Just relaxing at home with a good movie and some sweets.";

        bestRizzReaction = "That’s what I’m talking about! Active days are the best days!";
        goodRizzReaction = "Solid! You know how to balance things. Both training and friends.";
        badRizzReaction = "Might be safe, but have some fun instead, boring.";
        worstRizzReaction = "Relaxing? Sounds… boring. You’re missing out!";

        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;
    }
    IEnumerator Question4()
    {
        nextButton.SetActive(false);
        textToSpeak = "Okay, this one’s important—how do you handle failure?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "Learn from it, get better, and try again.";
        goodRizzText.text = "I get frustrated, but I always try again.";
        badRizzText.text = "I get upset and take a break before trying again.";
        worstRizzText.text = "I just give up. No point in trying if it’s too hard.";

        bestRizzReaction = "Exactly! You get knocked down, you get back up. That’s how it’s done!";
        goodRizzReaction = "Frustration’s fine, but don’t let it stop you. Keep pushing!";
        badRizzReaction = "Breaks are for quitters. Push through it next time!";
        worstRizzReaction = "Giving up? Wow. That explains a lot…";

        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;
    }
    IEnumerator Question5()
    {
        nextButton.SetActive(false);
        textToSpeak = "Final one—what’s something you’d never give up on??";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "My goals. I’ll keep fighting for what I want.";
        goodRizzText.text = "My friends. They always have my back.";
        badRizzText.text = "My comfort. Life’s too short to be uncomfortable.";
        worstRizzText.text = "I don't really have anything im that passionate about.";

        bestRizzReaction = "Respect. That’s the mindset of a winner.";
        goodRizzReaction = "Friends are important, sure. But don’t forget your own goals aswell!";
        badRizzReaction = "Comfort? Pfft, that’s just an excuse to be lazy.";
        worstRizzReaction = "Wow. That’s just sad.";

        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;
    }

    IEnumerator AnswerButtons()
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
        textToSpeak = bestRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }
    
    IEnumerator GoodRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = goodRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }
    
    IEnumerator BadRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = badRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }
    IEnumerator WorstRizzEvent()
    {
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = worstRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitUntil(() => textLength == currentTextLength);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }
    
    public void NextButton()
    {
        if (eventPos == 0)
        {
            StartCoroutine(AnswerButtons());
        }
        if (eventPos == 1)
        {
            StartCoroutine(Introduction2());
        }
        if (eventPos == 2)
        {
            StartCoroutine(Question1());
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
            StartCoroutine(Question5());
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
