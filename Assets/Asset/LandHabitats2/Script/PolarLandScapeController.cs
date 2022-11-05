using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PolarLandScapeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI desc_text_1;
    [SerializeField] private TextMeshProUGUI desc_text_2;
    [SerializeField] private AudioClip titleAudio;
    [SerializeField] private AudioClip descClip_1;
    [SerializeField] private AudioClip descClip_2;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button BackButton;
    [SerializeField] private GameObject previousSlide;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button previousTextButton;
    [SerializeField] private  GameObject habitatSlide;
    [SerializeField] private Button mainHomebutton;
    private bool firstclip = true;
    private bool isPlaying = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayTitle();
        Invoke("PlayDesc1", 2f);
        Invoke("PlayDesc2", 10f);
        homeButton.gameObject.SetActive(true);
    }

    private void PlayTitle()
    {
        AudioManager.Instance.Play(titleAudio);

    }
    private void PlayDesc1()
    {
        firstclip = true;
        desc_text_1.gameObject.SetActive(true);
        AudioManager.Instance.Play(descClip_1);
       
    }

    private void PlayDesc2()
    {
        firstclip = false;
        desc_text_1.gameObject.SetActive(false);
        desc_text_2.gameObject.SetActive(true);
        AudioManager.Instance.Play(descClip_2);
    }


    public void PlayPauseDesc1()
    {
        if (firstclip)
        {

            if (isPlaying)
            {
                isPlaying = false;
                pauseButton.gameObject.GetComponent<Image>().sprite = playSprite;
                AudioManager.Instance.Pause();
            }

            else
            {
                isPlaying = true;
                pauseButton.gameObject.GetComponent<Image>().sprite = pauseSprite;
                AudioManager.Instance.Play(descClip_1);
            }
        }

    }

    public void PlayPauseDesc2()
    {
        if (!firstclip)
        {
            if (isPlaying)
            {
                isPlaying = false;
                pauseButton.gameObject.GetComponent<Image>().sprite = playSprite;
                AudioManager.Instance.Pause();
            }

            else
            {
                isPlaying = true;
                pauseButton.gameObject.GetComponent<Image>().sprite = pauseSprite;
                AudioManager.Instance.Play(descClip_2);
            }

        }
    }

    public void BackButtonClick()
    {
        this.gameObject.SetActive(false);
        previousSlide.SetActive(true);
        mainHomebutton.gameObject.SetActive(true);
        this.homeButton.gameObject.SetActive(false);
        AudioManager.Instance.Pause();
    }

    public void HomeButtonClick()
    {
        this.gameObject.SetActive(false);
        habitatSlide.SetActive(true);
        
    }

    public void Replay()
    {
        AudioManager.Instance.Replay();
    }
    public void TextMoveforward()
    {
        desc_text_1.gameObject.SetActive(false);
        desc_text_2.gameObject.SetActive(true);
        AudioManager.Instance.Play(descClip_2);
        nextTextButton.gameObject.SetActive(false);
        previousTextButton.gameObject.SetActive(true);
    }
    public void TextMoveback()
    {
        desc_text_2.gameObject.SetActive(false);
        desc_text_1.gameObject.SetActive(true);
        AudioManager.Instance.Play(descClip_1);
        previousTextButton.gameObject.SetActive(false);
        nextTextButton.gameObject.SetActive(true);
    }
}
