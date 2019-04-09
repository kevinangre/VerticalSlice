using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject MM_Image;
    public GameObject Control_Image;    
    public GameObject backbttn;
    public GameObject startbttn;
    private bool inMM = true;
   


    private void Update()
    {
        if(inMM == true)
        {
            EventSystem.current.firstSelectedGameObject = startbttn;
        }else
            EventSystem.current.firstSelectedGameObject = backbttn;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {

        Control_Image.SetActive(false);       
        MM_Image.SetActive(true);
        inMM = true;
        EventSystem.current.SetSelectedGameObject(startbttn);
        

    }
    public void Controls()
    {
        
        MM_Image.SetActive(false);     
        Control_Image.SetActive(true);
        inMM = false;
        EventSystem.current.SetSelectedGameObject(backbttn);

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
