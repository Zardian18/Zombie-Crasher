using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] skins;
    int skinId;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        skinId=PlayerPrefs.GetInt("SkinId", 0);
        for(int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(false);
        }
        if (skinId > skins.Length)
        {
            skinId = 0;
        }
        else if (skinId < 0)
        {
            skinId = skins.Length;
        }
        skins[skinId].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Next()
    {
        

         if (skinId < skins.Length-1)
         {
             skins[skinId].SetActive(false);
             skinId++;
             skins[skinId].SetActive(true);
         }
         else
         {
             skins[skinId].SetActive(false);
             skinId = 0;
             skins[skinId].SetActive(true);
         }
         PlayerPrefs.SetInt("SkinId", skinId);
        
    }
    public void Previous()
    {
        if (skinId >=0)
        {
            skins[skinId].SetActive(false);
            skinId--;
            skins[skinId].SetActive(true);
        }
        else
        {
            skins[skinId].SetActive(false);
            skinId = skins.Length-1;
            skins[skinId].SetActive(true);
        }
        PlayerPrefs.SetInt("SkinId", skinId);
    }

    public void PickTank()
    {
        PlayerPrefs.SetInt("SkinId", skinId);
        SceneManager.LoadScene(0);
    }
}
