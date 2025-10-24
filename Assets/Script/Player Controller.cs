using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject player;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerWorldPosition = transform.position;
        float moveHorizontal = Input.GetAxis("Horizontal");

        float xPosition = playerWorldPosition.x;
        Vector2 movement = new Vector2(moveHorizontal,0f);

     
        rb.velocity = movement * speed;
        if (xPosition >-7.0)
            Text.SetActive(false);
    }
}
