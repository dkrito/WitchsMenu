using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioContainer[] sounds;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        PlaySound(SoundName.Ambient);
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(SoundName name)
    {
        if (audioSource == null) return;
        for (int i = 0; i < sounds.Length; ++i)
        {
            if (name == sounds[i].name)
            {
                audioSource.clip = sounds[i].clip;
                audioSource.Play();
            }
        }
    }

    public void PlayOneShot(SoundName name)
    {
        if (audioSource == null) return;
        for (int i = 0; i < sounds.Length; ++i)
        {
            if (name == sounds[i].name)
            {
                audioSource.PlayOneShot(sounds[i].clip, 1);
            }
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        PlaySound(SoundName.Ambient);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        PlayOneShot(SoundName.Swoosh);
    //    }
    //}
}
