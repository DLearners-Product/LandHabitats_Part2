using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerDistributionSlide : MonoBehaviour
{
    
    [SerializeField] private AudioClip introVoiceOverClip;
    [SerializeField] private AudioClip voiceOverClip;
   
    // Start is called before the first frame update
   private void Start()
    {



        PlayIntroAudio();
        Invoke("PlayVoiceOver", 4f);
      
    }

   private void PlayIntroAudio()
    {
        AudioManager.Instance.Play(introVoiceOverClip);
    }

   private void PlayVoiceOver()
    {
        AudioManager.Instance.Play(voiceOverClip);
    }
}
