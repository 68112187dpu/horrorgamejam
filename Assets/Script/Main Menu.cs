using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public GameObject Extra;
    void Start()
    {
        Extra.SetActive(false);
    }
    // Call this function from your button
    public void LoadScene()
    {
        SceneManager.LoadScene("Gameplay");
    }




    private GameObject panel;

    void Start2()
    {
        // หา Panel ด้วย Tag
        panel = GameObject.FindGameObjectWithTag("NG");

        // ปิด Panel ตอนเริ่มเกม
        if (panel != null)
            panel.SetActive(false);
    }

    // ฟังก์ชันเรียกเมื่อกดปุ่ม
    public void OnButtonClick()
    {
        if (panel != null)
            panel.SetActive(true);
    }
}