using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreOrientation : MonoBehaviour
{

    public string[,] objectName;
    public Vector2[,] objectPosition;
    public GameObject tileGrid;
    public string thisName;
    public string tileGridName;

    private TileSlide TSScript;
    //private GameObject tileGrid;

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
        if (GameObject.Find(tileGridName))
        {
            tileGrid = GameObject.Find(tileGridName);
        }
        TSScript = tileGrid.GetComponent<TileSlide>();
        objectName = new string[TSScript.multiArray.GetLength(0), TSScript.multiArray.GetLength(1)];
        objectPosition = new Vector2[TSScript.multiArray.GetLength(0), TSScript.multiArray.GetLength(1)];
    }
    //Assigns the stored orientation to the level
    public void RememberOrientation()
    {
        FindTileGrid();
        SlideableTile tempTileRef;
        
        for (var i = 0; i < objectName.GetLength(0); i++)
        {
            for (var j = 0; j < objectName.GetLength(1); j++)
            {
                //assigns game objects to tile swap array via stored string
                TSScript.multiArray[i, j] = GameObject.Find(objectName[i, j]);
                //assigns tile to temporary reference based on position in array
                tempTileRef = TSScript.multiArray[i, j].GetComponent<SlideableTile>();
                //assigns position, startPos, and endPos of tile referenced via stored position value
                tempTileRef.transform.position = tempTileRef.startPos = tempTileRef.endPos = objectPosition[i, j];
                //assigns row and collumn of tile referenced
                tempTileRef.row = i;
                tempTileRef.collumn = j;
                //Debug.Log(i + " " + j + " " + objectName[i, j]);
                //Debug.Log(objectName[i, j] + "/" + TSScript.multiArray[i, j] + TSScript.multiArray[i, j].transform.position);
            }
        }
    }

    private void FindTileGrid()
    {
        if (GameObject.Find(tileGridName))
        {
            tileGrid = GameObject.Find(tileGridName);
            TSScript = tileGrid.GetComponent<TileSlide>();
            Debug.Log(TSScript);
        }
        //objectName = new string[TSScript.multiArray.GetLength(0), TSScript.multiArray.GetLength(1)];
        //objectPosition = new Vector2[TSScript.multiArray.GetLength(0), TSScript.multiArray.GetLength(1)];
    }
}
