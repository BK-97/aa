using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anacember : MonoBehaviour
{
    public GameObject KucukCember;
    GameObject OyunYonetici;
    void Start()
    {
        OyunYonetici = GameObject.FindGameObjectWithTag("gamemanagertag");
        
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            kucukCemberOlustur();
        }
    }
    void kucukCemberOlustur()
    {
        Instantiate(KucukCember, transform.position, transform.rotation);
        OyunYonetici.GetComponent<oyunYoneticisi>().KucukCemberlerdeTextGosterme();
    }
}
