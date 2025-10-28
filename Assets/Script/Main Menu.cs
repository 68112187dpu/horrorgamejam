using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Call this function from your button
    public void LoadScene(string Gameplay)
    {
        SceneManager.LoadScene(Gameplay);
    }
}
