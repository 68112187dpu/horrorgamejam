using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject cam;
    private Vector3 campos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 campos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        campos = cam.transform.position;
        if (gameObject.CompareTag("Finish"))
        {
            cam.transform.position = new Vector3(0, 0, -10);
           
        }
        if (gameObject.CompareTag("QTE"))
        {
            SceneManager.LoadScene("Gameplay");
        }
        
        if (gameObject.CompareTag("QTE2"))
        {
            cam.transform.position = new Vector3(30, 0, -10);

        }
        if (gameObject.CompareTag("LeftRight"))
        {
            cam.transform.position = new Vector3(campos.x+30, 0, -10);
     
        }
        if (gameObject.CompareTag("RightLeft"))
        {
            cam.transform.position = new Vector3(campos.x - 30, 0, -10);
           
        }
    }
}
