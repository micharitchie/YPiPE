using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreOrientation : MonoBehaviour
{

    public string[,] objectName;
    public Vector2[,] objectPosition;
    public GameObject tileGrid;
    public string thisName;

    private TileSlide TSScript;

    private void Awake()
    {
        //int numStoreOrientations = FindObjectOfType<StoreOrientation>();
       if (GameObject.Find(thisName) != this.gameObject)
        {
            Destroy(this.gameObject);
            //Debug.Log("new object destroyed");
        } else
        {
            DontDestroyOnLoad(gameObject);
            //Debug.Log("first instance of object created");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TSScript = tileGrid.GetComponent<TileSlide>();
        objectName = new string[TSScript.multiArray.GetLength(0), TSScript.multiArray.GetLength(1)];
        objectPosition = new Vector2[TSScript.multiArray.GetLength(0), TSScript.multiArray.GetLength(1)];
    }
    //Assigns the stored orientation to the level
    public void RememberOrientation()
    {
        SlideableTile tempTileRef;
        for (var i = 0; i < objectName.GetLength(0); i++)
        {
            for (var j = 0; j < objectName.GetLength(1); j++)
            {
                TSScript.multiArray[i, j] = GameObject.Find(objectName[i, j]);
                tempTileRef = TSScript.multiArray[i, j].GetComponent<SlideableTile>();
                tempTileRef.transform.position = tempTileRef.startPos = tempTileRef.endPos = objectPosition[i, j];
                tempTileRef.row = i;
                tempTileRef.collumn = j;
            }
        }
    }
}
