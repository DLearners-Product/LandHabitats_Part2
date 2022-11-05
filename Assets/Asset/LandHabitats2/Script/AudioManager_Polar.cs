using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Polar : MonoBehaviour
{
    private static AudioManager_Polar _instance;
    public static AudioManager_Polar instance { get { return _instance; } }
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    


    private void Awake()
    {
        if (_instance)
            Destroy(this.gameObject);

        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    public void Pause()
    {
        EffectsSource.Pause();
    }

    public void Replay()
    {
        EffectsSource.time = 0;
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }


}



