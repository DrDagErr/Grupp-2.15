using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectionMeter : MonoBehaviour
{
    public int minAffection = 0;
    public int maxAffection = 100;
    public float Affection;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        slider.value = Affection; 
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

    public void IncreaseAffection(float increaseAffection)
    {
        Affection += increaseAffection;
        slider.value = Affection;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (Affection > maxAffection)
        {
            Affection = maxAffection;
        }
    }
    public void DecreaseAffection(float decreaseAffection)
    {
        Affection -= decreaseAffection;
        slider.value = Affection;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (Affection < minAffection)
        {
            Affection = minAffection;
        }
    }
}
