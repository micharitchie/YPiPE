using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TileSlide : MonoBehaviour
{

    public string puzzleSolution;
    public Flowchart outFlow;
    public string fungusBool;
    public string storageObjectName;
    public GameObject[] arrayRow1;
    public GameObject[] arrayRow2;
    public GameObject[] arrayRow3;
    public GameObject[,] multiArray;

    private GameObject selectedObject;
    private GameObject swipeObject;
    private GameObject storageObject;
    private GameObject[,] startingObjects;
    private Vector2[,] startingPositions;
    private bool enableSwap;
    private Vector2 startTouch;
    private Vector2 direction;
    private Vector2 endTouch;
    private Vector2 clickTilePos;
    //private Vector2 swipeTilePos;
    private float distance;
    //private CharacterMovement CMScript;
    private RoryPartSwap RPSScript;
    private float swipeAngle;
    private SlideableTile selectedScript;
    private SlideableTile swipeScript;
    private StoreOrientation storeScript;

    // Start is called before the first frame update


    private void Awake()
    {
        //creating a 2D array from 3 separate arrays
        multiArray = new GameObject[3, arrayRow1.Length];
        for (int i = 0; i < arrayRow1.Length; i++)
        {
            multiArray[0, i] = arrayRow1[i];
            multiArray[1, i] = arrayRow2[i];
            multiArray[2, i] = arrayRow3[i];
        }
        //if (!string.IsNullOrEmpty(storageObjectName))
        //{
        //    storeScript.tileGrid = this.gameObject;
        //}

        }
    void Start()
    {
        enableSwap = false;
        RPSScript = GameObject.Find("VirtualRory").GetComponent<RoryPartSwap>();
        //Finds the empty object with the StoreOrientation script if one exists
        //not sure why I don't just make the script public
        if (!string.IsNullOrEmpty(storageObjectName))
        {
            storageObject = GameObject.Find(storageObjectName);
            storeScript = storageObject.GetComponent<StoreOrientation>();

        }
        
        //storing tile info for reset button
        startingPositions = new Vector2[multiArray.GetLength(0),multiArray.GetLength(1)];
        startingObjects = new GameObject[multiArray.GetLength(0), multiArray.GetLength(1)];
        for (var i = 0; i < multiArray.GetLength(0); i++)
        {
            for (var j = 0; j < multiArray.GetLength(1); j++)
            {
                startingPositions[i, j] = multiArray[i, j].transform.position;
                startingObjects[i, j] = multiArray[i, j];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSwap)
        {
            if (Input.touches.Length > 0)
            {
                
                Touch touch = Input.GetTouch(0);
                RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Camera.main.transform.forward);
                //Debug.Log(rayHit.collider.gameObject);
                
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startTouch = Camera.main.ScreenToWorldPoint(touch.position);
                        if (rayHit.collider != null)
                        {
                            if (rayHit.collider.tag == "Swappable Tile")
                            {
                                clickTilePos = rayHit.collider.gameObject.transform.position;
                                selectedObject = rayHit.collider.gameObject;
                                selectedScript = selectedObject.GetComponent<SlideableTile>();
                            } else
                            {
                                selectedObject = null;
                                selectedScript = null;
                            }

                        } else
                        {
                            selectedObject = null;
                            selectedScript = null;
                        }
                        break;

                    case TouchPhase.Moved:
                        direction = Camera.main.ScreenToWorldPoint(touch.position);
                        swipeAngle = Mathf.Atan2(direction.y - startTouch.y, direction.x - startTouch.x) * 180 / Mathf.PI;
                        break;

                    case TouchPhase.Ended:
                        endTouch = Camera.main.ScreenToWorldPoint(touch.position);
                        distance = Vector2.Distance(startTouch, endTouch);
                        //Debug.Log(distance);
                        if (distance >= 2)
                        {
                            if (!SlideableTile.slideIncomplete)
                            {
                                MovePieces();
                            } else
                            {
                                SpriteRenderer[] tileSprites = selectedObject.transform.GetComponentsInChildren<SpriteRenderer>();
                                for (int i = 0; i < tileSprites.Length; i++)
                                {
                                    tileSprites[i].sortingOrder -= 1000;
                                }
                                selectedObject.transform.localScale = Vector2.one;
                            }
                            
                        }
                        break;
                }

            }
        }
    }

    void MovePieces()
    {
        if (selectedObject)
        {
            SpriteRenderer[] tileSprites = selectedObject.transform.GetComponentsInChildren<SpriteRenderer>();
            Vector2 tileScale = new Vector2(1.5f, 1.5f);
            for (int i = 0; i < tileSprites.Length; i++)
            {
                tileSprites[i].sortingOrder += 1000;
            }
            selectedObject.transform.localScale = Vector2.Lerp(Vector2.one, tileScale, .3f);
            if (swipeAngle > -45 && swipeAngle <= 45 && selectedScript.collumn < arrayRow1.Length - 1)
            {
                //right swipe
                swipeObject = multiArray[selectedScript.row, selectedScript.collumn + 1];
                swipeScript = swipeObject.GetComponent<SlideableTile>();
                selectedScript.endPos = swipeObject.transform.position;
                swipeScript.endPos = clickTilePos;
                multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
                multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
                selectedScript.collumn++;
                swipeScript.collumn--;
            }
            else if (swipeAngle > 45 && swipeAngle <= 135 && selectedScript.row > 0)
            {
                //up swipe
                swipeObject = multiArray[selectedScript.row - 1, selectedScript.collumn];
                swipeScript = swipeObject.GetComponent<SlideableTile>();
                selectedScript.endPos = swipeObject.transform.position;
                swipeScript.endPos = clickTilePos;
                multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
                multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
                selectedScript.row--;
                swipeScript.row++;
            }
            else if ((swipeAngle > 135 || swipeAngle <= -135) && selectedScript.collumn > 0)
            {
                //left swipe
                swipeObject = multiArray[selectedScript.row, selectedScript.collumn - 1];
                swipeScript = swipeObject.GetComponent<SlideableTile>();
                selectedScript.endPos = swipeObject.transform.position;
                swipeScript.endPos = clickTilePos;
                multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
                multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
                selectedScript.collumn--;
                swipeScript.collumn++;
            }
            else if (swipeAngle < -45 && swipeAngle >= -135 && selectedScript.row < 2)
            {
                //down swipe
                swipeObject = multiArray[selectedScript.row + 1, selectedScript.collumn];
                swipeScript = swipeObject.GetComponent<SlideableTile>();
                selectedScript.endPos = swipeObject.transform.position;
                swipeScript.endPos = clickTilePos;
                multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
                multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
                selectedScript.row++;
                swipeScript.row--;
            }
        }
    }

    //allows you to manually swap 2 tiles via parameters
    public void ManualSwap(GameObject pieceOne, GameObject pieceTwo)
    {
        int tempRow;
        int tempCol;
        clickTilePos = pieceOne.transform.position;
        selectedScript = pieceOne.GetComponent<SlideableTile>();
        swipeScript = pieceTwo.GetComponent<SlideableTile>();
        tempRow = selectedScript.row;
        tempCol = selectedScript.collumn;
        selectedScript.endPos = pieceTwo.transform.position;
        swipeScript.endPos = clickTilePos;
        multiArray[selectedScript.row, selectedScript.collumn] = pieceTwo;
        multiArray[swipeScript.row, swipeScript.collumn] = pieceOne;
        selectedScript.row = swipeScript.row;
        selectedScript.collumn = swipeScript.collumn;
        swipeScript.row = tempRow;
        swipeScript.collumn = tempCol;
    }

    public void toggleSwap()
    {
        RPSScript.ChangeVisibility(enableSwap);
        enableSwap = !enableSwap;
        for (var i = 0; i < multiArray.GetLength(0); i++)
        {
            for (var j = 0; j < multiArray.GetLength(1); j++)
            {
                GameObject tileGlow = multiArray[i, j].transform.Find("GlowTiles").gameObject;
                tileGlow.SetActive(enableSwap);
            }
        }
    }

    public void CheckPuzzle()
    {
        string s = "";
        for (var i = 0; i < multiArray.GetLength(0); i++)
        {
            for (var j = 0; j < multiArray.GetLength(1); j++)
            {
                s = s + multiArray[i, j].name;
            }
        }
        //Debug.Log(s + " / " + puzzleSolution);
        Debug.Log(s);
        if (s == puzzleSolution)
        {
            outFlow.SetBooleanVariable(fungusBool, true);
            //Debug.Log("success");
        }
        //assigns finished orientation as starting orientation 
        for (var i = 0; i < multiArray.GetLength(0); i++)
        {
            for (var j = 0; j < multiArray.GetLength(1); j++)
            {
                startingObjects[i, j] = multiArray[i, j];
                startingPositions[i, j] = multiArray[i, j].transform.position;
                //if there is a storage object, orientation is also stored there
                if (!string.IsNullOrEmpty(storageObjectName))
                {
                    storeScript.objectName[i, j] = multiArray[i,j].name;
                    storeScript.objectPosition[i, j] = multiArray[i, j].transform.position;
                    storeScript.orientationStored = true;
                    //Debug.Log(i + "" + j + " " + storeScript.objectName[i, j]);
                    //Debug.Log(i + "" + j + " " + storeScript.objectName[i, j] + storeScript.objectPosition[i, j]);
                }
            }
        }
    }

    public void ResetPuzzle()
    {
        SlideableTile tempScript;
        for (var i = 0; i < startingObjects.GetLength(0); i++)
        {
            for (var j = 0; j < startingObjects.GetLength(1); j++)
            {
                multiArray[i, j] = startingObjects[i, j];
                tempScript = multiArray[i, j].GetComponent<SlideableTile>();
                tempScript.endPos = startingPositions[i,j];
                tempScript.row = i;
                tempScript.collumn = j;
            }
        }
    }

    public void RememberOrientation()
    {
        storeScript.RememberOrientation();  
    }
}
