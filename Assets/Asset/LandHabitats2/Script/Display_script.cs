using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Display_script : MonoBehaviour
{
    
    [SerializeField] private Image penguinImage;
    [SerializeField] private TextMeshProUGUI initialText;
    [SerializeField] private TextMeshProUGUI delayText;
    [SerializeField] private AudioClip initialClip;
    [SerializeField] private AudioClip delayClip;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button Replaybutton;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject previousSlide;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button previousTextButton;
    [SerializeField] private GameObject habitatSlide;
    [SerializeField] private Button previousSlideHomebutton;
    private bool isPlaying = true;
    private bool firstclip = true;
    
    private void Start()
    {
        firstclip = true;
        initialText.gameObject.SetActive(true);
       Invoke("DelayFunct", initialClip.length + 3);
        AudioManager.Instance.Play(initialClip);
        previousTextButton.gameObject.SetActive(false);
        nextTextButton.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(true);
    }

    public void DelayFunct()
    {
        firstclip = false;
        initialText.gameObject.SetActive(false);
        delayText.gameObject.SetActive(true);
        penguinImage.gameObject.SetActive(true);
        AudioManager.Instance.Play(delayClip);
        previousTextButton.gameObject.SetActive(true);
    }

    public void PlayPauseInitialClip()
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
                AudioManager.Instance.Play(initialClip);
            }
        }



    }

    public void PlayPauseDelayClip()
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
                AudioManager.Instance.Play(delayClip);
            }

        }

    }

    public void BackButtonClick()
    {
        this.gameObject.SetActive(false);
        this.homeButton.gameObject.SetActive(false);
        previousSlideHomebutton.gameObject.SetActive(true);
        previousSlide.SetActive(true);
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
        initialText.gameObject.SetActive(false);
        delayText.gameObject.SetActive(true);
        AudioManager.Instance.Play(delayClip);
        nextTextButton.gameObject.SetActive(false);
        previousTextButton.gameObject.SetActive(true);
    }
    public void TextMoveback()
    {
        delayText.gameObject.SetActive(false);
        initialText.gameObject.SetActive(true);
        AudioManager.Instance.Play(initialClip);
        previousTextButton.gameObject.SetActive(false);
        nextTextButton.gameObject.SetActive(true);
    }


}
