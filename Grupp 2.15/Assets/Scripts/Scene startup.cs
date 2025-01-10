using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartup : MonoBehaviour
{
    public GameObject character;
    public GameObject textBox;

    [SerializeField] float waitSeconds;

    void Start()
    {
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(waitSeconds);
        //fadeScreenIn.SetActive(false);
        character.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);
        // this is where our text function will go in future tutorial
        textBox.SetActive(true);

        yield return new WaitForSeconds(waitSeconds);
       
    }
}

