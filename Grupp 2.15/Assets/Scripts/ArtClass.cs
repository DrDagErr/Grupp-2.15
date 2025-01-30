using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class ArtClass : MonoBehaviour
{
    public GameObject character;
    public GameObject speakText;
    public Sprite[] characterOutfits;
    [SerializeField] public Image uiCharacterImage;
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
        if (Input.GetMouseButtonDown(0))
        {
            Click.Play();
        }
    }

    void Start()
    {
        StartCoroutine(Introduction1());

    }
    void SetRectTransform(float x, float y, float z, Transform button)
    {
        RectTransform rectTransform = (RectTransform)button.transform;
        Vector3 position = new Vector3(x, y, z);
        rectTransform.anchoredPosition = position;

    }

    IEnumerator Introduction1()
    {
        //event0
        yield return new WaitForSeconds(waitSeconds);
        character.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);
        mainTextObject.SetActive(true);
        textToSpeak = "Hi there, i haven't seen you here before. I suppose your new to this class, my name is Lily";
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
        textToSpeak = "Welcome to this class, nice to meet you!";
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
        // Dialog setup
        nextButton.SetActive(false);
        textToSpeak = "So, what kind of stuff do you do for fun?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;


        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "I love exploring new places or trying something creative.";
        goodRizzText.text = "I’m into relaxing—like reading, gaming, or just hanging out.";
        badRizzText.text = "Honestly? Mostly binge-watching shows. It’s kind of my thing.";
        worstRizzText.text = "Not much. I just sort of go with the flow.";

        bestRizzReaction = "That’s awesome. Creativity keeps things exciting, don’t you think?";
        goodRizzReaction = "Not bad. Everyone needs a little downtime now and then.";
        badRizzReaction = "Eh, that’s okay, but don’t you ever feel like doing something a little more... meaningful?";
        worstRizzReaction = "Wow, living the dream, huh? Sounds... thrilling.”";

        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;

    }


    IEnumerator Question2()
    {
        nextButton.SetActive(false);
        textToSpeak = "What’s something you’ve always wanted to try but haven’t yet?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "Traveling somewhere totally different, like a vibrant city or a peaceful countryside.";
        goodRizzText.text = "Taking a pottery class or learning a new skill—like cooking or photography.";
        badRizzText.text = "Something like skydiving, I guess? I mean, it sounds wild.";
        worstRizzText.text = "I don’t know. Never really thought about it.";

        bestRizzReaction = "That’s such a cool idea. I bet you’d come back inspired!";
        goodRizzReaction = "That’s a solid plan. It’s fun to surprise yourself with new abilities.";
        badRizzReaction = "Huh, risky, but interesting. You might be more adventurous than I thought.";
        worstRizzReaction = "Nothing? That’s kind of... uninspiring.";


        SetRectTransform(126, 350, 0, BestRizzButton.transform);
        SetRectTransform(126, -400, 0, GoodRizzButton.transform);
        SetRectTransform(126, 100, 0, WorstRizzButton.transform);
        SetRectTransform(126, -150, 0, BadRizzButton.transform);

        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;
    }

    IEnumerator Question3()
    {
        nextButton.SetActive(false);
        textToSpeak = "What’s your favorite way to express yourself?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;

        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "Through words—writing or even just having deep conversations.";
        goodRizzText.text = "Music or movement. I feel like emotions just flow out that way.";
        badRizzText.text = "I’m not really the expressive type. I just keep things to myself.";
        worstRizzText.text = "I don’t know. I’m not really into that whole self-expression thing.";

        bestRizzReaction = "That’s beautiful. Words can really bring emotions to life.";
        goodRizzReaction = "That’s so raw and honest. I love that.";
        badRizzReaction = "That’s a little sad. Don’t you ever want to share what’s inside?";
        worstRizzReaction = "Wow. That’s... one way to live, I guess.";

        SetRectTransform(126, -150, 0, BestRizzButton.transform);
        SetRectTransform(126, 350, 0, GoodRizzButton.transform);
        SetRectTransform(126, -400, 0, BadRizzButton.transform);
        SetRectTransform(126, 100, 0, WorstRizzButton.transform);
        nextButton.SetActive(true);
        saveEventPos = eventPos;
        eventPos = 0;

    }
    IEnumerator Question4()
    {
        nextButton.SetActive(false);
        textToSpeak = "If you could create something that would last forever, what would it be?";
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        bestRizzText.text = "A memory, like spending time together somewhere meaningful, maybe painting or sketching outdoors.";
        goodRizzText.text = "A moment—something like an evening with someone, maybe at a gallery or somewhere inspiring.";
        badRizzText.text = "Something simple, like a date at a café or watching the stars. I think the company matters more than the place.";
        worstRizzText.text = "I don’t really know, I’m not good at creating stuff. Maybe just dinner or something?";

        bestRizzReaction = "Wait, are you suggesting we go sketching together? That’s... actually a great idea";
        goodRizzReaction = "Oh, are you saying you want to create that moment with me? That sounds nice.";
        badRizzReaction = "A café date? Hmm... not exactly groundbreaking, but I guess it would be something.";
        worstRizzReaction = "Dinner? That’s kind of uninspiring.";

        SetRectTransform(126, 350, 0, BestRizzButton.transform);
        SetRectTransform(126, -400, 0, GoodRizzButton.transform);
        SetRectTransform(126, 100, 0, BadRizzButton.transform);
        SetRectTransform(126, -150, 0, WorstRizzButton.transform);
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
        uiCharacterImage.sprite = characterOutfits[0];
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = bestRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }
    IEnumerator GoodRizzEvent()
    {
        uiCharacterImage.sprite = characterOutfits[0];
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = goodRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }

    IEnumerator BadRizzEvent()
    {
        uiCharacterImage.sprite = characterOutfits[1];
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = badRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }
    IEnumerator WorstRizzEvent()
    {
        uiCharacterImage.sprite = characterOutfits[1];
        RizzButtons.SetActive(false);
        mainTextObject.SetActive(true);
        textToSpeak = worstRizzReaction;
        speakText.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreater.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        eventPos = saveEventPos += 1;

        nextButton.SetActive(true);
    }
    IEnumerator Date()
    {
        if (affectionMeter.Affection == 100)
        {
            yield return new WaitForSeconds(1.5f);
            nextButton.SetActive(false);
            affecGO.SetActive(false);
            uiCharacterImage.sprite = characterOutfits[0];

            textToSpeak = "I like that, lets go this saturday!";
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
            uiCharacterImage.sprite = characterOutfits[1];

            textToSpeak = "That's so sweet of you to ask! I had a great time too, but I think we’re better off as friends.";
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
            uiCharacterImage.sprite = characterOutfits[1];

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
