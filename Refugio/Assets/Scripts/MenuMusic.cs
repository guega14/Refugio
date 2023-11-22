using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMusic : MonoBehaviour
{
    private bool isPlaying = true;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;

    [SerializeField] private Image mute;

    public void OnOffMusic()
    {
        isPlaying = !isPlaying;
        musicSource.enabled = isPlaying;

        if (isPlaying)
        {
            mute.sprite = musicOn;
        }
        else
        {
            mute.sprite = musicOff;
        }
    }
}