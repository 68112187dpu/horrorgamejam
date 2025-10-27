using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=20;
    public GameObject player;
    bool RightCross = false;
    bool LeftCross = false;
    bool firstcross=false;
    public GameObject Guide;
    public TextMeshPro textMeshPro;
    public static bool passed_3;
    public float originalScaleX;

    // Start is called before the first frame update
    void Start()
    {
        originalScaleX = Mathf.Abs(transform.localScale.x);
        passed_3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerWorldPosition = transform.position;
        float xPosition = playerWorldPosition.x;
        // Player Position Check
        if (NewBehaviourScript.slow == true)
        {
            speed = 10;
        }
        else
        {
            speed = 20;
        }

        if (NewBehaviourScript.Traveling != true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            //Vector2 movement = new Vector2(moveHorizontal, 0f);
            //rb.velocity = movement * speed;
            if (moveHorizontal > 0)
            {
                player.transform.Translate(Vector2.right * speed * Time.deltaTime);
                // Face right
                transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
            }
            else if (moveHorizontal < 0)
            {

                // Face left by making the X scale negative
                transform.localScale = new Vector3(-originalScaleX, transform.localScale.y, transform.localScale.z);
                player.transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            //moveHorizontal=0
            //rb.velocity = Vector3.zero;
            //Player movement
            if (LeftCross == true && Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = new Vector2(xPosition + 3f, -6.32f);
                firstcross = true;
            }
            if (RightCross == true && Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = new Vector2(xPosition - 3f, -6.32f);
            }
            //Cross Logic
        }
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
