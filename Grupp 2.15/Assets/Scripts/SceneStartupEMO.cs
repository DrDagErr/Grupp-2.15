using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneStartupEMO : MonoBehaviour
{

    public GameObject character;
    public GameObject speakText;
    public AudioSource Click;

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

        if (Input.GetMouseButtonDown(0))
        {
            Click.Play(); 
        }
    }

    void Start()
    {
        StartCoroutine(EventStarter());
    }
    void SetRectTransform(float x, float y, float z, Transform button)
    {
        RectTransform rectTransform = (RectTransform)button.transform;
        Vector3 position = new Vector3(x, y, z);
        rectTransform.anchoredPosition = position;
    }

    IEnumerator EventStarter()
    {
        //event0
        yield return new WaitForSeconds(waitSeconds);
        character.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);
        mainTextObject.SetActive(true);
        textToSpeak = "Oh. You’re actually here. Didn’t think you’d show up. Most people bail when I invite them out here.";
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
        textToSpeak = "So… what do you even do for fun? I usually just sit here and listen to music. Life’s kind of... whatever.";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        BestRizzText.text = "I’ve been getting into music too. Got any bands you’d recommend? Maybe we can trade playlists?";
        BestRizzReaction = "You’re into music? That’s... actually cool. I might have something for you.";
        

        GoodRizzText.text = "Honestly, I just like chilling out. I’m not into anything crazy.";
        GoodRizzReaction = "Yeah, I get that. It’s not like there’s much worth getting excited over anyway.";

        BadRizzText.text = "I don’t really have hobbies. I just do whatever passes the time.";
        BadRizzReaction = "That’s… kind of sad. Even I have *some* passions.";

        WorstRizzText.text = "Nothing, really. Why even bother with stuff? Life is just a void.";
        WorstRizzReaction = "Wow. That’s bleak, even for me. You okay?";



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
        textToSpeak = "By the way, did you bring anything to eat? I didn’t. I was kind of hoping you’d take care of that.";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        BestRizzText.text = "Yeah, I brought snacks! Want to share? I made sure to get something vegan just in case.";
        BestRizzReaction = "Vegan snacks? Hah, thoughtful. Guess I’ll let you live today.";

        GoodRizzText.text = "I didn’t know what you’d like, so I grabbed some chips and drinks. Hope that’s okay.";
        GoodRizzReaction = "Not bad. At least you didn’t forget completely.";

        BadRizzText.text = "Nah, I figured you’d just grab something if you wanted it.";
        BadRizzReaction = "Wow. Really banking on me, huh?";

        WorstRizzText.text = "Why would I bring food? This isn’t some fancy picnic.";
        WorstRizzReaction = "Yeah, okay. So, I’ll just starve, I guess.";

        SetRectTransform(-26.2f, 432, 0, BestRizzButton.transform);
        SetRectTransform(-26.2f, 160, 0, BadRizzButton.transform);
        SetRectTransform(-26.2f, -120, 0, GoodRizzButton.transform);
        SetRectTransform(-26.2f, -372, 0, WorstRizzButton.transform);

        nextButton.SetActive(true);
        SaveEventPos = eventPos -= 1;
        eventPos = 2;

    }
    IEnumerator Question3()
    {
        nextButton.SetActive(false);
        affecGO.SetActive(false);
        textToSpeak = "So, do you ever think about, like… what happens after this? Not life, but, like, this moment. What’s the point?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        BestRizzText.text = "I guess the point is to enjoy moments like this. Even if everything’s fleeting, this is still nice.";
        BestRizzReaction = "Huh. That’s... surprisingly deep. I didn’t expect that from you.";

        GoodRizzText.text = "I think the point is just to make the best of what we’ve got. No need to overthink it.";
        GoodRizzReaction = "Yeah, maybe. Keeping it simple isn’t so bad.";

        BadRizzText.text = "I don’t really think about stuff like that. It’s too exhausting.";
        BadRizzReaction = "Hmm. I guess that tracks.";

        WorstRizzText.text = "Honestly? Who cares. Nothing we do matters anyway.";
        WorstRizzReaction = "Jeez, you’re even gloomier than me. Maybe tone it down a bit.";

        SetRectTransform(-26.2f, -120, 0, BestRizzButton.transform);
        SetRectTransform(-26.2f, -372, 0, BadRizzButton.transform);
        SetRectTransform(-26.2f, 432, 0, GoodRizzButton.transform);
        SetRectTransform(-26.2f, 160, 0, WorstRizzButton.transform);

        nextButton.SetActive(true);
        SaveEventPos = eventPos -= 1;
        eventPos = 2;

    }
    IEnumerator Question4()
    {

        nextButton.SetActive(false);
        affecGO.SetActive(false);
        mainTextObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        mainTextObject.SetActive(true);


        textToSpeak = "This wasn’t terrible. You’re actually kind of tolerable. Maybe we could do this again… or not. Whatever.";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;


        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);


        BestRizzText.text = "I’m glad you think so. How about we make it official and go on a real date?";
        BestRizzReaction = "Emmm...";

        GoodRizzText.text = "This was nice. Want to try an actual date sometime? Could be fun.";
        GoodRizzReaction = "Emmm...";

        BadRizzText.text = "If you ever get bored, maybe we could do something more... like a date?";
        BadRizzReaction = "Emmm...";

        WorstRizzText.text = "Whatever. Since you didn’t completely annoy me, want to try a date or something?";
        WorstRizzReaction = "Emmm...";

        SetRectTransform(-26.2f, -372, 0, GoodRizzButton.transform);
        SetRectTransform(-26.2f, -120, 0, WorstRizzButton.transform);
        SetRectTransform(-26.2f, 160, 0, BestRizzButton.transform);
        SetRectTransform(-26.2f, 432, 0, BadRizzButton.transform);

        nextButton.SetActive(true);
        SaveEventPos = eventPos -= 1;
        eventPos = 2;
    }

    IEnumerator Date()
    {
        if (affectionMeter.Affection == 100)
        {
            mainTextObject.SetActive(false);
            nextButton.SetActive(false);
            yield return new WaitForSeconds(2f);
            mainTextObject.SetActive(true);
            affecGO.SetActive(false);

            textToSpeak = "Wait... are you seriously asking me out? Like, for real? That’s... actually kinda cool. I’d love to.";
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
            mainTextObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            mainTextObject.SetActive(true);
            nextButton.SetActive(false);
            affecGO.SetActive(false);

            textToSpeak = "That’s sweet, but… I think we’re better off just staying friends. Don’t take it the wrong way, okay?";
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
            mainTextObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            mainTextObject.SetActive(true);
            nextButton.SetActive(false);
            affecGO.SetActive(false);

            textToSpeak = "A date? Seriously? I don’t know where you got that idea, but no. Not happening. Maybe work on yourself first.";
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

