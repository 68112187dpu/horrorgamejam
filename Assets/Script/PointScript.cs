using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public GameObject pointleft;
    public GameObject pointright;
    public GameObject nextpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextpoint.SetActive(true);
            pointleft.SetActive(true);
            pointright.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}
