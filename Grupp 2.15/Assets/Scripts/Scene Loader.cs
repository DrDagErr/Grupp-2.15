using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void LoadMathClass()
    {
        SceneManager.LoadScene("Math Class");
    }
    public void LoadArtClass()
    {
        SceneManager.LoadScene("Art Class"); 
    }
    public void LoadPEClass()
    {
        SceneManager.LoadScene("PE Class");
    }
}
