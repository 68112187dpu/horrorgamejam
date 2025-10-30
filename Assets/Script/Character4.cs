using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character4 : MonoBehaviour
{
    // Start is called before the first frame update
    public void scenechanger(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


}
