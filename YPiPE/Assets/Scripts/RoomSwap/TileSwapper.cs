using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSwapper : MonoBehaviour
{
    public GameObject finishButton;
    public GameObject startButton;

    private Transform firstSelected;
    //private Transform secondSelected;
    private Vector3 tempPosition;
    private CharacterMovement CMScript;
    private bool enableSwap;

    // Start is called before the first frame update
    void Start()
    {
        CMScript = GameObject.Find("VirtualRory").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSwap) {
            if (Input.touches.Length > 0)
		{
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    Vector2 raycast = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    RaycastHit2D raycastHit = Physics2D.Raycast(raycast, Input.GetTouch(0).position);

                    if (raycastHit.collider.tag == "Swappable Tile")
                    {
                        if (firstSelected == null)
                        {
                            firstSelected = raycastHit.collider.gameObject.transform;
                            firstSelected.localScale *= 1.3f;
                            firstSelected.GetChild(0).gameObject.SetActive(true);
                            //Debug.Log(firstSelected.GetChild(0).name);
                        }
                        else
                        {
                            if (firstSelected == raycastHit.collider.gameObject.transform)
                            {
                                firstSelected.localScale = Vector3.one;
                                firstSelected.GetChild(0).gameObject.SetActive(false);
                                firstSelected = null;
                            }
                            else
                            {
                                //Debug.Log("second selection");
                                firstSelected.localScale = Vector3.one;
                                firstSelected.GetChild(0).gameObject.SetActive(false);
                                tempPosition = raycastHit.collider.gameObject.transform.position;
                                raycastHit.collider.gameObject.transform.position = firstSelected.position;
                                firstSelected.position = tempPosition;
                                firstSelected = null;
                            }

                        }
                    }


                }
            }
		}

	}

public void FinishSwap()
    {
        if (firstSelected != null)
        {
            firstSelected.localScale = Vector3.one;
            firstSelected.GetChild(0).gameObject.SetActive(false);
            firstSelected = null;
        }
        CMScript.toggleCharacterMove();
        enableSwap = false;
        startButton.SetActive(true);
    }

    public void StartSwap()
    {
        enableSwap = true;
        CMScript.toggleCharacterMove();
        finishButton.SetActive(true);
    }
}
