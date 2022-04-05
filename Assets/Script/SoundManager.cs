using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip Hitsound, SlashSound;
    private AudioSource auSour;
    private void Start()
    {
        auSour = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    /// combine
    /// -hit
    /// </summary>
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hit":
                auSour.PlayOneShot(Hitsound);
                break;
            case "slash":
                auSour.PlayOneShot(SlashSound,0.7f);
                break;
         //write hear to add option sound
        }

    }
}
