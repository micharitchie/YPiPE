using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public Transform dustLocation;

    private float distance = 1.5f;
    private AudioSource footstepPlayer;
    private AudioClip footstepSound;

    // Start is called before the first frame update
    void Start()
    {
        footstepPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MaterialCheck();
        //Debug.DrawRay(transform.position, Vector2.down * distance, Color.magenta);
    }

    void MaterialCheck()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, distance, 1 << 31);

        if (hit.collider)
        {
            if (hit.collider.tag == "Material: Dirt")
            {
                //Debug.Log("you're standing on dirt");
                footstepPlayer.clip = Resources.Load<AudioClip>("footstep_test01");
                footstepPlayer.Play();
                Instantiate(Resources.Load<Transform>("SandParticles"), dustLocation.transform.position, transform.rotation);
            } else if (hit.collider.tag == "Material: Grass")
            {
                footstepPlayer.clip = Resources.Load<AudioClip>("footstep_test02");
                footstepPlayer.Play();
            } else
            {
                Debug.Log("I don't know what the fuck you're standing on");
            }
        }

    }
}
