using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader1 : MonoBehaviour
{
    public void scenechanger(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}