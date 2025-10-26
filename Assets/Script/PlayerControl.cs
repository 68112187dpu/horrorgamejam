using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerWorldPosition = transform.position;
        float xPosition = playerWorldPosition.x;
        // Player Position Check

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        rb.velocity = movement * speed;
        //Player movement
        if (xPosition > -2.0 && LeftCross == true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector2(3.42f, -3.43f);
            firstcross= true;
        }
        if (xPosition < 3.5 && RightCross == true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector2(-0.11f, -3.43f);
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
