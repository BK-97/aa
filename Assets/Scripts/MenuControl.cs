using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void Play()
    {
        int kayitliLevel = PlayerPrefs.GetInt("kayit");
        if(kayitliLevel==0)
        {
            SceneManager.LoadScene(kayitliLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(kayitliLevel);
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
