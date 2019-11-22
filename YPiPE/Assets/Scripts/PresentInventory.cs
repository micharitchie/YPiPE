using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentInventory : MonoBehaviour
{
    private List<Button> presentList;
    private List<string> presentTextList;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        presentTextList = new List<string>();
        presentList = new List<Button>();
        
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
