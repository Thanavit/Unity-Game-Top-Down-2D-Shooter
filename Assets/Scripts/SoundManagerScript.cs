using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip FireSound, explosion, healUp;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        FireSound = Resources.Load<AudioClip>("laser");
        explosion = Resources.Load<AudioClip>("Explosion");
        healUp = Resources.Load<AudioClip>("PowerUp");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "laser":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosion);
                break;
            case "powerUp":
                audioSrc.PlayOneShot(healUp);
                break;
        }
    }
}
