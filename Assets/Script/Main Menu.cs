using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public GameObject Extra;
    void Start()
    {
        Extra.SetActive(false);
    }
    // Call this function from your button
    public void LoadScene()
    {
        SceneManager.LoadScene("Gameplay");
    }
    
}
