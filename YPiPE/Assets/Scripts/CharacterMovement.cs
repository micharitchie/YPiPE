using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public Transform player;//reference to player character     public Transform touchParticles;//reference to particles     //public Transform seeButton;     //public Transform doorButton;     //public Transform speakButton;     public GameObject directionHint;     public GameObject mc;//reference to player as game object     public float speed = 5f;//speed of character movement     public Footsteps FSREf;     //public AudioSource footsteps;      private bool touchStart;//checks to see if player is dragging     private bool conversing;//I added this to keep the player from moving while talking, it's not being used rn     private bool roryFlipped;//this keeps the character from flipping constantly     private bool timerStart;     private bool hintShow;     private Vector2 pointA;//start of screen press     private Vector2 pointB;//where player drags to     private Vector2 playerStart;//stores where the player's 2D position at the start of screen press     private Vector2 playerEnd;//stores player's 2D position during the drag     private Vector2 playerOffset;//player end - player start     private Camera cam;//reference to main camera     private Animator anim;//allows me to update state machine     private float countdownTimer;//Counts down to remind the player to drag     private GameObject myHint;     private AudioSource tapSounds;     //private SpriteRenderer currentSprite;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;         anim = mc.GetComponent<Animator>();         tapSounds = GetComponent<AudioSource>();         //currentSprite = mc.GetComponent<SpriteRenderer>();         conversing = false;         countdownTimer = .2f; 
    }

    // Update is called once per frame
    void Update()
    {
        //I set up a mouse input section for testing off the phone, it's not really working though         #region Mouse Inputs         if (Input.GetMouseButtonDown(0))
        {             pointA = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));             playerStart = new Vector2(player.position.x, player.position.y);         }         if (Input.GetMouseButton(0))
        {             touchStart = true;             pointB = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));             playerEnd = new Vector2(player.position.x, player.position.y);          }
        #endregion         //This section stores the location of where the user starts to press on the screen, and where they drag to
        #region Touch Inputs         if (Input.touches.Length > 0)         {
            if (Input.touches[0].phase == TouchPhase.Began)             {
                int tapTrack = Random.Range(1, 5);
                //turns screen press location to world location and assigns it to a starting point for touch
                pointA = cam.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, cam.transform.position.z));
                playerStart = new Vector2(player.position.x, player.position.y);                 if (!conversing)
                {
                    //particle effect, location dictated by touch
                    Instantiate(touchParticles, pointA, transform.rotation);
                    tapSounds.clip = Resources.Load<AudioClip>("Tap0" + tapTrack);
                    tapSounds.Play();
                    timerStart = true;
                }
            }             if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
            {                 touchStart = true;                 pointB = cam.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, cam.transform.position.z));                 playerEnd = new Vector2(player.position.x, player.position.y);                 //seeButton.position = cam.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 100f));
                //doorButton.position = cam.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 100f));             }
            /*if (Input.touches[0].phase == TouchPhase.Ended)
            {
                seeButton.position = cam.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 100f));
                speakButton.position = doorButton.position = cam.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x, Input.touches[0].position.y, 100f));
            }*/
        }
        #endregion 
        else
        {             touchStart = false;             timerStart = false;             anim.SetBool("IsRunning", false);//changes to idle animation             anim.SetInteger("RunSelector", 0);             //footsteps.Stop();         }         playerOffset = playerEnd - playerStart;         if (timerStart)
        {
            countdownTimer -= Time.deltaTime;
        } else
        {
            countdownTimer = .6f;
            if (myHint != null)
            {
                Destroy(myHint.gameObject);
                hintShow = false;
            }
            
        }         if (countdownTimer <= 0)
        {
            if (!hintShow)
            {
                myHint = Instantiate(directionHint, pointA, transform.rotation);
                hintShow = true;
            }
            
        }      }      private void FixedUpdate()     {         if (!conversing)//will only work if you aren't talking         {             if (touchStart)//will only work if player is dragging on screen             {
                //this actually moves the character, offsets make sure you dont' start from 0
                Vector2 offset = pointB - pointA - playerOffset;                 Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);                 moveCharacter(direction);                 if (direction != Vector2.zero)                 {                     anim.SetBool("IsRunning", true);//changes to running animation
                    //this checks to see if the player needs to be flipped, is there a better way to do this?
                    if (direction.x > 0)                     {                         if (roryFlipped)
                        {
                            player.localScale = new Vector3(player.localScale.x * -1, player.localScale.y, player.localScale.z);
                            roryFlipped = false;
                            FSREf.particlesFlipped = false;
                        }
                    }                     else if (direction.x < 0)                     {
                        if (!roryFlipped)
                        {
                            player.localScale = new Vector3(player.localScale.x * -1, player.localScale.y, player.localScale.z);
                            roryFlipped = true;
                            FSREf.particlesFlipped = true;
                        }
                                             }                     timerStart = false;                     /*if (!footsteps.isPlaying)                     {                         footsteps.Play();                     }*/
                }                 else                 {                     anim.SetBool("IsRunning", false);//changes to idle animation                     //footsteps.Stop();                 }              }         }     }      private void moveCharacter(Vector2 direction)
    {
        //the final movement calculation
        player.Translate(direction * speed * Time.deltaTime);     }      public void toggleCharacterMove()//fungus was calling this function when I was using it     {         conversing = !conversing;     }      public void RunSelect()
    {
        int runNumber = Random.Range(1, 6);
        anim.SetInteger("RunSelector",runNumber);
        //Debug.Log(runNumber);
    }      public void FlipRory()
    {
        player.localScale = new Vector3(player.localScale.x * -1, player.localScale.y, player.localScale.z);
        roryFlipped = !roryFlipped;
    } } 
