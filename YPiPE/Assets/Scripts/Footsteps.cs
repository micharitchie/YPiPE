using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public Transform dustLocation;
    public bool particlesFlipped;

    private float distance = 1.5f;
    private AudioSource footstepPlayer;
    private AudioClip footstepSound;
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

    void MaterialCheck()
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
            Debug.Log(footstepParticles.transform.eulerAngles);
            
        } else
        {
            particleRotation = footstepParticles.transform.rotation;
            Debug.Log(footstepParticles.transform.eulerAngles);
        }

        if (hit.collider)
        {
            if (hit.collider.tag == "Material: Dirt")
            {
                //Debug.Log("you're standing on dirt");
                footstepPlayer.clip = Resources.Load<AudioClip>("footstep_test01");
                footstepPlayer.Play();
                footstepParticles = Resources.Load<GameObject>("SandParticles");
                Instantiate(footstepParticles, dustLocation.transform.position, particleRotation);
            } else if (hit.collider.tag == "Material: Grass")
            {
                footstepPlayer.clip = Resources.Load<AudioClip>("footstep_test02");
                footstepParticles = Resources.Load<GameObject>("GrassParticles");
                Instantiate(footstepParticles, dustLocation.transform.position, particleRotation);
                footstepPlayer.Play();
            } else
            {
                Debug.Log("I don't know what the fuck you're standing on");
            }
        }

    }
}
