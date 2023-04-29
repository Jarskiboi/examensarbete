using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.IO;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject LevelMenu;
    public Image[] medalObjects;
    public Color on;
    public Color off;

    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
            LevelsClose();
    }

    public void Start(){
        LevelMenu.SetActive(false);


        for (int i = 0; i < 5; i++)
        {
            int ach = PlayerPrefs.GetInt(i+1 + "Medal", 0);
            if(ach == 3)
                medalObjects[i * 3].color = on;
            else
                medalObjects[i * 3].color = off;

            if(ach >= 2)
                medalObjects[i * 3 + 1].color = on;
            else
                medalObjects[i * 3 + 1].color = off;
            
            if(ach >= 1)
                medalObjects[i * 3 + 2].color = on;
            else
                medalObjects[i * 3 + 2].color = off;
        }
        
    }

    public void Exit(){
        Application.Quit();
    }

    public void LevelsOpen(){
        LevelMenu.SetActive(true);

    }

    public void LevelsClose(){
        LevelMenu.SetActive(false);
    }

    public void OpenLevel(int SceneIndex){
        SceneManager.LoadScene(SceneIndex);
    }

    public void RESET(){
        PlayerPrefs.DeleteAll();
    }
}
