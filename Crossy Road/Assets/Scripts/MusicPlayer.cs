using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        int num = FindObjectsOfType<MusicPlayer>().Length;
        if (num > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
        Debug.Log(audioSource.mute);
    }
}
