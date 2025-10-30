using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDeklogic : MonoBehaviour
{
    public GameObject GhostDekback;
    public GameObject GhostDekIdle;
    public GameObject GhostDekJump;
    public static bool dekjump=false;
    public bool firstdekjum=false;
    // Start is called before the first frame update
    void Start()
    {
        GhostDekback.SetActive(true);
        GhostDekIdle.SetActive(false);
        GhostDekJump.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&firstdekjum==false)
        {
            dekjump = true;
            firstdekjum = true;
            GhostDekIdle.SetActive(true);
            GhostDekback.SetActive(false) ;
            GhostDekJump.SetActive(true);
            StartCoroutine(Jump());
        }
    }
    IEnumerator Jump()
    {
        dekjump=false;
        yield return new WaitForSeconds(1f);
        GhostDekJump.SetActive(false);
    }

}
