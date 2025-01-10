using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01Events : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charVelma;
    public GameObject textBox;

    void Start()
    {
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        yield return new WaitForSeconds(2);
        //fadeScreenIn.SetActive(false);
        charVelma.SetActive(true);

        yield return new WaitForSeconds(2);
        // this is where our text function will go in future tutorial
        textBox.SetActive(true);

        yield return new WaitForSeconds(2);
       
    }
}

