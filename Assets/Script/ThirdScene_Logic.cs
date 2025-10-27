using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    
    public GameObject gm_quest;
    
    bool quest_check = false;
    bool bag_zone = false;
    bool bag=false;
    bool gm_zone;
    public GameObject bag_object;
    public GameObject show_bag;
    public GameObject grandma;
    public GameObject happy_gm;
    public GameObject Trash;
    bool vil_tem = false;
    bool vil_gra = false;
    public GameObject player;
    public static bool Temple = false;
    public static bool Village = true;
    public static bool Grave = false;

    // Start is called before the first frame update
    void Start()
    {
        show_bag.SetActive(false);
        happy_gm.SetActive(false);
        gm_quest.SetActive(false);
    }
    void bag_show()
    {
        show_bag.SetActive(true);
        bag = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        if ( quest_check==true&&bag_zone==true && Input.GetKeyDown(KeyCode.E))
        {
            bag_show();
            bag_object.SetActive(false);
        }
        //get the bag
        if (gm_zone==true&&bag==true&&quest_check==true && Input.GetKeyDown(KeyCode.E))
        {
            show_bag.SetActive(false);
            bag=false;
            grandma.SetActive(false);
            happy_gm.SetActive(true);
            Trash.SetActive(false);
        }
        //finish quest bag
        if (vil_tem == true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector2(-28f, -3.43f);
        }
        //warp Logic

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Quest"))
        {
            gm_quest.SetActive(true);
            quest_check = true;
            gm_zone = true;
        }
        if (collision.gameObject.CompareTag("Bag"))
        {
            bag_zone=true;
        }
        if (collision.gameObject.CompareTag("Vil_Tem"))
        {
            vil_tem = true;
            Temple=true;
            Village=false;
        }
        if (collision.gameObject.CompareTag("Vil_Gra"))
        {
            vil_gra = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Quest"))
        {
            gm_quest.SetActive(false);
            gm_zone = false;
        }
        if (collision.gameObject.CompareTag("Bag"))
        {
            bag_zone = false;
        }
        if (collision.gameObject.CompareTag("Vil_Tem"))
        {
            vil_tem = false;
        }
        if (collision.gameObject.CompareTag("Vil_Gra"))
        {
            vil_gra = false;
        }


    }
    // Zone check
}
    
   
