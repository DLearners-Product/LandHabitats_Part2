using UnityEngine;
using UnityEngine.UI;

public class AnimalSlideChangerTundra : MonoBehaviour
{
    [SerializeField] private GameObject[] slides;
    [SerializeField] private Button backButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private AudioClip[] descClips;
    
    private int i;

    private void Start()
    {
        i = 0;
        slides[i].SetActive(true);
        AudioManager.Instance.Play(descClips[i]);
    }
    public void SlideSwitchNext()
    {
      //increasing slides with i
        i++;
        //disabling the previous slide and enabling the current slide
            slides[i - 1].SetActive(false);
            slides[i].SetActive(true);
        
        if(i == 1)
        {
            AudioManager.Instance.Play(descClips[i]);
            Invoke("PlayFoxAudio", descClips[i].length+1f);
           
        }
        else if(i == 2)
        {
            AudioManager.Instance.Play(descClips[i+1]);
        }

        if(i == slides.Length-1)
        {
            nextButton.gameObject.SetActive(false);
        }

         
    }

    public void SlideSwitchBack()
    {
        //increasing slides with i
        i--;
        //disabling the previous slide and enabling the current slide
        slides[i+1].SetActive(false);
        slides[i].SetActive(true);

        if (i == 0)
        {
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }

    }
    private void PlayFoxAudio()
    {
        AudioManager.Instance.Play(descClips[i + 1]);
    }
    




}
