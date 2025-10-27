using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject player;
    bool RightCross = false;
    bool LeftCross = false;
    bool firstcross=false;
    public GameObject Guide;
    public TextMeshPro textMeshPro;
    public static bool passed_3;

    // Start is called before the first frame update
    void Start()
    {
        passed_3 = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerWorldPosition = transform.position;
        float xPosition = playerWorldPosition.x;
        // Player Position Check

        if (NewBehaviourScript.Traveling != true)
        { 
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f);
            rb.velocity = movement * speed;
        }
        else 
            rb.velocity = Vector3.zero;
        //Player movement
        if (LeftCross == true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector2(xPosition+3f, -3.43f);
            firstcross= true;
        }
        if (RightCross == true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector2(xPosition-3f, -3.43f);
        }
        //Cross Logic
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("QTE"))
        {

            LeftCross = true;
            if (firstcross == false)
            {
                Guide.SetActive(true);
                textMeshPro.text = "E";
            }
            //not text after first cross
        }
        if (collision.gameObject.CompareTag("QTE2"))
        {

            RightCross = true;
        }
        if (collision.gameObject.CompareTag("Text"))
        {
            Guide.SetActive(false);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("QTE"))
        {

            LeftCross = false;
            Guide.SetActive(false);
        }
        if (collision.gameObject.CompareTag("QTE2"))
        {
            RightCross = false;
        }
       
    }
}
