using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public Transform dustLocation;
    public bool particlesFlipped;

    private float distance = 1.5f;
    private AudioSource footstepPlayer;
    //private AudioClip footstepSound;
    private GameObject footstepParticles;
    private Quaternion particleRotation;

    // Start is called before the first frame update
    void Start()
    {
        footstepPlayer = GetComponent<AudioSource>();
        footstepParticles = Resources.Load<GameObject>("SandParticles");
        if (footstepParticles != null)
        {
            particleRotation = footstepParticles.transform.rotation;
        }
    }

    public void MaterialCheck()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, distance, 1 << 31);

        if (particlesFlipped)
        {
            float x = footstepParticles.transform.eulerAngles.x;
            float y = footstepParticles.transform.eulerAngles.y;
            float z = 180f;
            Vector3 newRot = new Vector3(x, y, z);
            particleRotation = Quaternion.Euler(newRot);
            //Debug.Log(footstepParticles.transform.eulerAngles);
            
        } else
        {
            particleRotation = footstepParticles.transform.rotation;
            //Debug.Log(footstepParticles.transform.eulerAngles);
        }
        //may want to move Play and Instantiate outside of conditionals
        if (hit.collider)
        {
            if (hit.collider.tag == "Material: Dirt")
            {
                int sandTrack = Random.Range(1, 5);
                //Debug.Log("sandStep0" + sandTrack);
                footstepPlayer.clip = Resources.Load<AudioClip>("sandStep0" + sandTrack);
                //footstepPlayer.Play();
                footstepParticles = Resources.Load<GameObject>("SandParticles");
                //Instantiate(footstepParticles, dustLocation.transform.position, particleRotation);
            } else if (hit.collider.tag == "Material: Grass")
            {
                int grassTrack = Random.Range(1, 5);
                footstepPlayer.clip = Resources.Load<AudioClip>("grassSteps0" + grassTrack);
                footstepParticles = Resources.Load<GameObject>("GrassParticles");
                //Instantiate(footstepParticles, dustLocation.transform.position, particleRotation);
                //footstepPlayer.Play();
            } else if (hit.collider.tag == "Material: Gravel")
            {
                int gravelTrack = Random.Range(1, 5);
                footstepPlayer.clip = Resources.Load<AudioClip>("gravelStep0" + gravelTrack);
                //footstepPlayer.Play();
                footstepParticles = Resources.Load<GameObject>("GravelParticles");
                //Instantiate(footstepParticles, dustLocation.transform.position, particleRotation);
            } else if (hit.collider.tag == "Material: Hardfloor")
            {
                int hardfloorTrack = Random.Range(1, 5);
                footstepPlayer.clip = Resources.Load<AudioClip>("hardfloorStep0" + hardfloorTrack);
                //footstepPlayer.Play();
                footstepParticles = Resources.Load<GameObject>("HardfloorParticles");
                //Instantiate(footstepParticles, dustLocation.transform.position, particleRotation);
            } else
            {
                //Debug.Log("I don't know what the fuck you're standing on");
            }
            footstepPlayer.Play();
            Instantiate(footstepParticles, dustLocation.transform.position, particleRotation);
        }

    }
}
