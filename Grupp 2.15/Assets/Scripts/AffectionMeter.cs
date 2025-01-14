using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionMeter : MonoBehaviour
{
    public int minAffection = 0;
    public int maxAffection = 100;
    public int Affection;
    public int increaseAffectionAmount;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        Affection = minAffection;
        fill.color = gradient.Evaluate(1f);
    }
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.D))
        {
            DecreaseAffection();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            IncreaseAffection();
        }
        */
    }

    public void IncreaseAffection()
    {
        Affection += increaseAffectionAmount;
        slider.value = Affection;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (Affection > maxAffection)
        {
            Affection = maxAffection;
        }
    }
    public void DecreaseAffection()
    {
        Affection -= increaseAffectionAmount;
        slider.value = Affection;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (Affection < minAffection)
        {
            Affection = minAffection;
        }
    }
}
