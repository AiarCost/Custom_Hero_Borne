using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayScript : MonoBehaviour
{

    AudioSource AudioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();

    }

    public void AudioPlay()
    {
        AudioPlayer.Play();
    }
}
