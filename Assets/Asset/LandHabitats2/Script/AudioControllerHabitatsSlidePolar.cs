using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerHabitatsSlidePolar : MonoBehaviour
{
    
    [SerializeField] private AudioClip introVoiceOverClip;
    [SerializeField] private AudioClip nowLetsLookatClip;
    [SerializeField] private AudioClip voiceOverClip;

   
    // Start is called before the first frame update
   private void Start()
    {



        PlayIntroAudio();

        Invoke("PlayLetsLookatAudio", 5f);

        Invoke("PlayVoiceOver", 7f);
      
    }

   private void PlayIntroAudio()
    {
        AudioManager.Instance.Play(introVoiceOverClip);
    }

    private void PlayLetsLookatAudio()
    {
        AudioManager.Instance.Play(nowLetsLookatClip);
    }

   private void PlayVoiceOver()
    {
        AudioManager.Instance.Play(voiceOverClip);
    }


}
