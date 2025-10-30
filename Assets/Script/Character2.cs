using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character2 : MonoBehaviour
{
    public void scenechanger(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
