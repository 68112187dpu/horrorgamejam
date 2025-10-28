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
    public GameObject player;
    public static bool Temple = false;
    public static bool Village = false;
    public static bool Grave = false;
    public static bool Final = false;
    public static bool House = false;
    public static bool Village_2 = false;
    public static bool Entrace = true;
    bool vil_tem = false;
    bool tem_vil = false;
    bool ent_tem = false;
    bool tem_ent = false;
    bool vil_hou = false;
    bool hou_vil = false; 
    bool hou_vil2=false;
    bool vil2_hou = false;
    bool vil2_gra = false;
    bool gra_vil2= false;
    bool gra_fin = false;
    bool fin_gra = false;
    public GameObject LoadScene;
    public static bool Traveling=false;
    public GameObject Light;
    public GameObject Flashlight;
    public static bool slow=false;

    // Start is called before the first frame update
    void Start()
    {
        Traveling = false;
        Entrace = true;
        show_bag.SetActive(false);
        happy_gm.SetActive(false);
        gm_quest.SetActive(false);
        LoadScene.SetActive(false);
    }
    void bag_show()
    {
        show_bag.SetActive(true);
        bag = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Grave == true)
        {
            Light.SetActive(false);
            Flashlight.SetActive(true);
        }
        else
        {
            Light.SetActive(true);
            Flashlight.SetActive(false);
        }
        if ( quest_check==true&&bag_zone==true && Input.GetKeyDown(KeyCode.E))
        {
            bag_show();
            bag_object.SetActive(false);
            slow=true;
        }
        //get the bag
        if (gm_zone==true&&bag==true&&quest_check==true && Input.GetKeyDown(KeyCode.E))
        {
            show_bag.SetActive(false);
            bag=false;
            grandma.SetActive(false);
            happy_gm.SetActive(true);
            slow=false;
        }
        //finish quest bag
        if (vil_tem == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(-28f, -6.32f);
            Temple = true;
            Village = false;
            StartCoroutine(Loading());
        }
        if (tem_vil == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(-10f, -6.32f);
            Temple = false;
            Village = true;
            StartCoroutine(Loading());
        }
        if (ent_tem == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(-75, -6.32f);
            Temple = true;
            Entrace = false;
            StartCoroutine(Loading());
        }
        if (tem_ent == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(-96, -6.32f);
            Temple = false;
            Entrace = true;
            StartCoroutine(Loading());
        }
        if (vil_hou == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(42, -6.32f);
            Village = false;
            House = true;
            StartCoroutine(Loading());
        }
        if (hou_vil == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(24, -6.32f);
            House = false;
            Village = true;
            StartCoroutine(Loading());
        }
        if (hou_vil2 == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(84, -6.32f);
            House = false;
            Village_2 = true;
            StartCoroutine(Loading());
        }
        if (vil2_hou == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(67, -6.32f);
            House = true;
            Village_2 = false;
            StartCoroutine(Loading());
        }
        if (vil2_gra == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(133, -6.32f);
            Village_2 = false;
            Grave = true;
            StartCoroutine(Loading());
        }
        if (gra_vil2 == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(117, -6.32f);
            Village_2 = true;
            Grave = false;
            StartCoroutine(Loading());
        }
        if (gra_fin == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(206, -6.32f);
            Final = true;
            Grave = false;
            StartCoroutine(Loading());
        }
        if (fin_gra == true && Input.GetKeyDown(KeyCode.E))
        {
            Traveling = true;
            LoadScene.SetActive(true);
            player.transform.position = new Vector2(182, -6.32f);
            Final = false;
            Grave = true;
            StartCoroutine(Loading());
        }
        //first_=false last=true
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
           
        }
        if (collision.gameObject.CompareTag("Tem_Vil"))
        {
            tem_vil = true;
        }

        if (collision.gameObject.CompareTag("Ent_Tem"))
        {
            ent_tem = true;
        }
        if (collision.gameObject.CompareTag("Tem_Ent"))
        {
            tem_ent = true;
        }
        if (collision.gameObject.CompareTag("Vil_Hou"))
        {
            vil_hou = true;
        }
        if (collision.gameObject.CompareTag("Hou_Vil"))
        {
            hou_vil = true;
        }
        if (collision.gameObject.CompareTag("Hou_Vil2"))
        {
            hou_vil2 = true;
        }
        if (collision.gameObject.CompareTag("Vil2_Hou"))
        {
            vil2_hou = true;
        }
        if (collision.gameObject.CompareTag("Vil2_Gra"))
        {
            vil2_gra = true;
        }
        if (collision.gameObject.CompareTag("Gra_Vil2"))
        {
            gra_vil2 = true;
        }
        if (collision.gameObject.CompareTag("Gra_Fin"))
        {
            gra_fin = true;
        }
        if (collision.gameObject.CompareTag("Fin_Gra"))
        {
            fin_gra = true;
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
        if (collision.gameObject.CompareTag("Tem_Vil"))
        {
            tem_vil = false;
        }
        if (collision.gameObject.CompareTag("Ent_Tem"))
        {
            ent_tem = false;
        }
        if (collision.gameObject.CompareTag("Tem_Ent"))
        {
            tem_ent = false;
        }
        if (collision.gameObject.CompareTag("Vil_Hou"))
        {
            vil_hou = false;
        }
        if (collision.gameObject.CompareTag("Hou_Vil"))
        {
            hou_vil = false;
        }
        if (collision.gameObject.CompareTag("Hou_Vil2"))
        {
            hou_vil2 = false;
        }
        if (collision.gameObject.CompareTag("Vil2_Hou"))
        {
            vil2_hou = false;
        }
        if (collision.gameObject.CompareTag("Vil2_Gra"))
        {
            vil2_gra = false;
        }
        if (collision.gameObject.CompareTag("Gra_Vil2"))
        {
            gra_vil2 = false;
        }
        if (collision.gameObject.CompareTag("Gra_Fin"))
        {
            gra_fin = false;
        }
        if (collision.gameObject.CompareTag("Fin_Gra"))
        {
            fin_gra = false;
        }

    }
    // Zone check
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
        
        LoadScene.SetActive(false);
        Traveling=false;
    }
    //Warp wait
}
    
   
