using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.IO;

public class MenuHandler : MonoBehaviour
{
    public GameObject LevelMenu;


    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
            LevelsClose();
    }

    public void Start(){
        LevelMenu.SetActive(false);

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
