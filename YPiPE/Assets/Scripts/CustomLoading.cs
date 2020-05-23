using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;


public class CustomLoading : MonoBehaviour
{

	//private SaveMenu mySaveMenu;
    private Flowchart myGV;

    // Start is called before the first frame update
    void Start()
    {
        //mySaveMenu = FindObjectOfType<SaveMenu>();
        //myGV = GameObject.Find("GlobalVariables").GetComponent<Flowchart>();
    }

    /*public void LoadSave()
    {
        if (mySaveMenu != null)
        {
            mySaveMenu.Load();
        }
    }*/

    public void RestartGame()
    {
        /*if (mySaveMenu != null)
        {
            myGV.Reset(true, true);
            mySaveMenu.Restart();
        } */
        myGV = GameObject.Find("GlobalVariables").GetComponent<Flowchart>();
        myGV.Reset(true, true);
        SceneManager.LoadScene("IntroWorld");

    }
}
