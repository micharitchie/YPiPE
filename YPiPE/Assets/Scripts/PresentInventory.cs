using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentInventory : MonoBehaviour
{
    public static List<Button> presentList = new List<Button>();
    public static List<string> presentTextList = new List<string>();

    void Awake()
    {
        /*DontDestroyOnLoad(gameObject);
        if (presentList.Count == 0) { 
        presentTextList = new List<string>();
        presentList = new List<Button>();
        } else
        {*/
            for (int i = 0; i < presentList.Count; i++)
            {
                Instantiate(presentList[i], gameObject.transform.Find("Inventory").Find("PresentContainer" + i).transform);
                gameObject.transform.Find("Inventory").Find("PresentContainer" + i).GetComponentInChildren<Text>().text = presentTextList[i];
            }
        //}

    }


    public void AddPresent(string newText)
    {
        
        presentList.Add(Resources.Load<Button>(newText));
        presentTextList.Add(newText);
        for (int i = 0; i < presentList.Count; i++)
        {
            Instantiate(presentList[i], gameObject.transform.Find("Inventory").Find("PresentContainer" + i).transform);
            gameObject.transform.Find("Inventory").Find("PresentContainer" + i).GetComponentInChildren<Text>().text = presentTextList[i];
        }
    }

    
}
