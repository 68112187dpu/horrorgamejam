using System.Collections;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject player;
    public GameObject Dialogue;
    public TextMeshProUGUI Text;
    bool RightCross= false;
    bool LeftCross = false;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerWorldPosition = transform.position;
        float xPosition = playerWorldPosition.x;
        //เชคตำแหน่ง Player

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f);
        rb.velocity = movement * speed;
        //สำหรับ Player ขยับได้


        if (xPosition>-2.0&&LeftCross==true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector2(3.42f, -3.43f);
        }
        if (xPosition<3.5&&RightCross==true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector2(-0.11f, -3.43f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Text"))
        {
            Dialogue.SetActive(false);
        }
        if (collision.gameObject.CompareTag("QTE"))
        {
            Dialogue.SetActive(true);
            Text.text = "Press E to Cross";
            LeftCross =true;
        }
        if (collision.gameObject.CompareTag("QTE2"))
        {
            Dialogue.SetActive(true);
            Text.text = "Press E to Cross";
            RightCross = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("QTE"))
        {
            Dialogue.SetActive(false);
            LeftCross = false;
        }
        if (collision.gameObject.CompareTag("QTE2"))
        {
            Dialogue.SetActive(false);
            RightCross = false;
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("QTE") && Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (player.transform.position.x > -2.0 && crossed2 == false)
    //        {
    //            //StartCoroutine (waitcross());
    //            player.transform.position = new Vector2(3.42f, -3.43f);
    //            crossed2 = true;
    //        }
                
                
    //    }
    //    if (collision.gameObject.CompareTag("QTE2") && Input.GetKeyDown(KeyCode.E))
    //    {
    //         if (player.transform.position.x > 3.43 && crossed2 == true)
    //        {
    //            player.transform.position = new Vector2(-0.11f, -3.43f);
    //            crossed2 = false;
    //        }
    //    }
    //}
   IEnumerator waitcross()
    {
        yield return new WaitForSeconds(2);
    }

}
