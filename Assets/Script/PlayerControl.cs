using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    public bool movable = true;
    float Crossing = 5f;
    bool crossingleft = false;
    bool crossingright = false;
    public GameObject Logblock;
    public static bool firstwarp = false;

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
            speed = 5;
        }
        else if (NewBehaviourScript.Final==true)
        {
            speed= 3;
        }
        else
        {
            speed = 20;
        }

        if (NewBehaviourScript.Traveling != true)
        {
            if (movable == true)
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
            }
            //moveHorizontal=0
            //rb.velocity = Vector3.zero;
            //Player movement
        if (LeftCross == true && Input.GetKeyDown(KeyCode.E)&&crossingright!=true)
            {
                Logblock.SetActive(false);
                movable = false;
                crossingleft = true;
                firstcross = true; 
            }
        if (RightCross == true && Input.GetKeyDown(KeyCode.E) && crossingleft != true)
            {
                Logblock.SetActive(false);
                crossingright = true;
                movable = false;
                player.transform.Translate(Vector2.left * Crossing * Time.deltaTime);
            }
            //Cross Logic
        }
        if (crossingleft == true&&LeftCross == true)
        {
            player.transform.Translate(Vector2.right * Crossing * Time.deltaTime);
        }
        if (crossingright == true&& RightCross == true)
        {
            player.transform.Translate(Vector2.left * Crossing * Time.deltaTime);
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
        if (collision.gameObject.CompareTag("WarpText"))
        {
            if (firstwarp != true)
            {
                Guide.SetActive(true);
                textMeshPro.text = "E";
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("QTE"))
        {
            
            
            Guide.SetActive(false);
        }
        if (collision.gameObject.CompareTag("QTE2"))
        {
            
            
        }
        if (collision.gameObject.CompareTag("LeftRight"))
        {
            LeftCross = false;
            Logblock.SetActive(true);
            crossingleft = false;
            movable = true;
            
        }
        if (collision.gameObject.CompareTag("RightLeft"))
        {
            RightCross = false;
            Logblock.SetActive(true);
            crossingright = false;
            movable = true;
        }
        if (collision.gameObject.CompareTag("WarpText"))
        {
            Guide.SetActive(false);
        }

    }
}
