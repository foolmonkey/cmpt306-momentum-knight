using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip coinpickupSound, playerhitSound, playerattackSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerhitSound = Resources.Load<AudioClip>("playerhit");
        coinpickupSound = Resources.Load<AudioClip>("coinpickup");
        playerattackSound = Resources.Load<AudioClip>("playerattack");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerhit":
                audioSrc.PlayOneShot(playerhitSound);
                break;
            case "coinpickup":
                audioSrc.PlayOneShot(coinpickupSound);
                break;
            case "playerattack":
                audioSrc.PlayOneShot(playerattackSound);
                break;
        }
    }
}
