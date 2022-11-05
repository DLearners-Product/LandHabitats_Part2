using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ClickSwitch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI changeText;
    [SerializeField] private AudioClip lattitudesClip;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button previousTextButton;

    private bool isPlaying =  true;

    private void Start() 
    {
        isPlaying = true;
        descText.gameObject.SetActive(true);
        AudioManager.Instance.Play(lattitudesClip);
    }
    public void OnNextTextButtonClick()
    {
        descText.gameObject.SetActive(false);
        changeText.gameObject.SetActive(true);
        nextTextButton.gameObject.SetActive(false);
        previousTextButton.gameObject.SetActive(true);
    }
    public void TextBackButtonClick()
    {
        descText.gameObject.SetActive(true);
        changeText.gameObject.SetActive(false);
        nextTextButton.gameObject.SetActive(true);
        previousTextButton.gameObject.SetActive(false);
    }

    public void PlayPause()
    {
        if(isPlaying)
        {
            isPlaying = false;
            pauseButton.gameObject.GetComponent<Image>().sprite = playSprite;
            AudioManager.Instance.Pause();
        }
        else
        {
            isPlaying = true;
            pauseButton.gameObject.GetComponent<Image>().sprite = pauseSprite;
            AudioManager.Instance.Play(lattitudesClip);
        }
    }

    public void Replay()
    {
        AudioManager.Instance.Replay();
    }
}
