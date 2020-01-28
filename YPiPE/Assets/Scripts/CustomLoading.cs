using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CustomLoading : MonoBehaviour
{

	private SaveMenu mySaveMenu;

    // Start is called before the first frame update
    void Start()
    {
        mySaveMenu = FindObjectOfType<SaveMenu>();  
    }

    public void LoadSave()
    {
        if (mySaveMenu != null)
        {
            mySaveMenu.Load();
        }
    }

    public void RestartGame()
    {
        if (mySaveMenu != null)
        {
            mySaveMenu.Restart();
        }
    }
}
