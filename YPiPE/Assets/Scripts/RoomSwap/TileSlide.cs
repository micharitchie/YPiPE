using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlide : MonoBehaviour
{

    public GameObject[] arrayRow1;
    public GameObject[] arrayRow2;

    private GameObject[,] multiArray;
    private GameObject selectedObject;
    private GameObject swipeObject;
    private bool enableSwap;
    private Vector2 startTouch;
    private Vector2 direction;
    private Vector2 endTouch;
    private Vector2 clickTilePos;
    private Vector2 swipeTilePos;
    private CharacterMovement CMScript;
    private CameraInteractions CIScript;
    private float swipeAngle;
    private SlideableTile selectedScript;
    private SlideableTile swipeScript;

    // Start is called before the first frame update
    void Start()
    {
        enableSwap = false;
        CMScript = GameObject.Find("VirtualRory").GetComponent<CharacterMovement>();
        CIScript = Camera.main.GetComponent<CameraInteractions>();
        multiArray = new GameObject[2, arrayRow1.Length];
        for (int i = 0; i < arrayRow1.Length; i++)
        {
            multiArray[0, i] = arrayRow1[i];
            multiArray[1, i] = arrayRow2[i];
            //Debug.Log(multiArray[0, i]);
        }
        //Debug.Log(multiArray[0, 0]);
        //StartSwap();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSwap)
        {
            if (Input.touches.Length > 0)
            {
                //Vector3 cameraStart = Camera.main.transform.position;
                //Vector3 cameraEnd = new Vector3;
                //Camera.main.transform.position = Vector3.Lerp()
                Touch touch = Input.GetTouch(0);
                RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Camera.main.transform.forward);
                //if (rayHit.collider.name == this.name)


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
                                //Debug.Log(selectedObject + " is positioned at " + clickTilePos);
                            }

                        }
                        break;

                    case TouchPhase.Moved:
                        direction = Camera.main.ScreenToWorldPoint(touch.position);
                        swipeAngle = Mathf.Atan2(direction.y - startTouch.y, direction.x - startTouch.x) * 180 / Mathf.PI;
                        //Debug.Log(swipeAngle);

                        //MovePieces();

                        break;

                    case TouchPhase.Ended:
                        endTouch = Camera.main.ScreenToWorldPoint(touch.position);
                        MovePieces();
                        //clickTile = false;
                        break;
                }

            }
        }
    }

    void MovePieces()
    {
        if(swipeAngle > -45 && swipeAngle <= 45 && selectedScript.collumn < arrayRow1.Length-1)
        {
            //right swipe
            swipeObject = multiArray[selectedScript.row, selectedScript.collumn + 1];
            //swipeTilePos = swipeObject.transform.position;
            swipeScript = swipeObject.GetComponent<SlideableTile>();
            selectedScript.endPos = swipeObject.transform.position;
            swipeScript.endPos = clickTilePos;
            multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
            multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
            selectedScript.collumn++;
            swipeScript.collumn--;
            //Debug.Log(multiArray[selectedScript.row,selectedScript.collumn+1]);
            //transform.position = Vector2.Lerp(transform.position, tempPos, 1);
        } else if (swipeAngle > 45 && swipeAngle <= 135 && selectedScript.row > 0)
        {
            //up swipe
            swipeObject = multiArray[selectedScript.row - 1, selectedScript.collumn];
            //swipeTilePos = swipeObject.transform.position;
            swipeScript = swipeObject.GetComponent<SlideableTile>();
            selectedScript.endPos = swipeObject.transform.position;
            swipeScript.endPos = clickTilePos;
            multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
            multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
            selectedScript.row--;
            swipeScript.row++;
            //Debug.Log(multiArray[selectedScript.row-1,selectedScript.collumn]);
        } else if ((swipeAngle > 135 || swipeAngle <= -135) && selectedScript.collumn > 0)
        {
            //left swipe
            swipeObject = multiArray[selectedScript.row, selectedScript.collumn - 1];
            //swipeTilePos = swipeObject.transform.position;
            swipeScript = swipeObject.GetComponent<SlideableTile>();
            selectedScript.endPos = swipeObject.transform.position;
            swipeScript.endPos = clickTilePos;
            multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
            multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
            selectedScript.collumn--;
            swipeScript.collumn++;
            //Debug.Log(multiArray[selectedScript.row, selectedScript.collumn-1]);
        } else if (swipeAngle < -45 && swipeAngle >= -135 && selectedScript.row < 1)
        {
            //down swipe
            swipeObject = multiArray[selectedScript.row + 1, selectedScript.collumn];
            //swipeTilePos = swipeObject.transform.position;
            swipeScript = swipeObject.GetComponent<SlideableTile>();
            selectedScript.endPos = swipeObject.transform.position;
            swipeScript.endPos = clickTilePos;
            multiArray[selectedScript.row, selectedScript.collumn] = swipeObject;
            multiArray[swipeScript.row, swipeScript.collumn] = selectedObject;
            selectedScript.row++;
            swipeScript.row--;
            //Debug.Log(multiArray[selectedScript.row+1,selectedScript.collumn]);
        }
    }

    public void toggleSwap()
    {
        CMScript.toggleCharacterMove();
        CIScript.toggleZoom();
        enableSwap = !enableSwap;
    }
}
