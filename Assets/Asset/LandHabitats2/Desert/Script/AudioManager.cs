using UnityEngine;

public class AudioManager : MonoSingletonGeneric<AudioManager>
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    protected override void Awake()
    {
        base.Awake();
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

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void Restart()
    {
        EffectsSource.time = 0;
    }

    public void Replay()
    {
        EffectsSource.time = 0;
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }

    public void StopVoice()
    {
        EffectsSource.Stop();
    }

}
