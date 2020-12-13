using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class oyunYoneticisi : MonoBehaviour
{
    GameObject donenCember;
    GameObject AnaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kacTaneKucukCemberOlsun;
    bool kontrol = true;
    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name)) ;
        

        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        AnaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;
        
        if(kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
        }
        else if(kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun-1) + "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
    }
    public void KucukCemberlerdeTextGosterme()
        //çubukları atma yerindeki dairede kaç tane kaldığını göstermek için
    {   
        
        kacTaneKucukCemberOlsun--;
        if (kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
        if (kacTaneKucukCemberOlsun==0)
        {
            StartCoroutine(NextLevel());
            //atılması gereken çubuk sayısı 0 a indiğinde yeni levele geçmek için
        }
    }
    IEnumerator NextLevel()
    {
        donenCember.GetComponent<Dondurme>().enabled = false; //hedef dairenin dönüşü durur
        AnaCember.GetComponent<anacember>().enabled = false;  //çubuk atılan AnaCember durur
        yield return new WaitForSeconds(1);   //son atılan çubuk hedefe varsın diye yarım saniye beklet
        if(kontrol==true)
        {
            animator.SetTrigger("yeniLevel");   //yeni level animasyonu etkinleştir
            yield return new WaitForSeconds(1.5f);  //animasyon bitmesi için bekle
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);  //yeni sahneye geç
        }
        
       // yield return new WaitForSeconds(0.5f);
    }
    public void OyunBitti()
    {
        StartCoroutine(CagrilanMetot());
        Debug.Log("bitti");
    }
    // Update is called once per frame
    IEnumerator CagrilanMetot()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<anacember>().enabled = false;
        animator.SetTrigger("Endgame");
        kontrol = false;
        yield return new WaitForSeconds(1);  //1 saniye beklet
      
        SceneManager.LoadScene("AnaMenu");
    }
}
