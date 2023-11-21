using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.clip = s.clip;
        }
    }

    /*public void ToggleSound()
    {
        isSoundOn = !isSoundOn; // Inverte o estado do som

        if (isSoundOn)
        {
            musicSource.volume = 1f; // Define o volume para máximo (som ligado)
            sfxSource.volume = 1f; // Define o volume para máximo (som ligado)
        }
        else
        {
            musicSource.volume = 0f; // Define o volume para zero (som desligado)
            sfxSource.volume = 0f; // Define o volume para zero (som desligado)
        }
    }*/
}
