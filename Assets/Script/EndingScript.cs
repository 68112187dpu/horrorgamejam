using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Retart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Retart()
    {
        {
            yield return new WaitForSeconds(10f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
