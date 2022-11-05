using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LandscapeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText_1;
    [SerializeField] private TextMeshProUGUI descText_2;
    [SerializeField] private Image aurora_1;
    [SerializeField] private Image aurora_2;
    [SerializeField] private AudioClip tileAudio;
    [SerializeField] private AudioClip desc1Audio;
    [SerializeField] private AudioClip desc2Audio;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button BackButton;
    [SerializeField] private GameObject previousSlide;
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject habitatSlide;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button previousTextButton;
    [SerializeField] private Button mainHomeButton;
    private bool firstclip = true;
    private bool secondclip = true;
    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        aurora_1.gameObject.SetActive(true);
        descText_1.gameObject.SetActive(true);
        PlayTitleClip();
        Invoke("PlayDescAudio1", 10f);
        Invoke("ChangeFunct", 20f);
       
        
    }

   private void PlayTitleClip()
    {
        firstclip = true;
        AudioManager.Instance.Play(tileAudio);
    }
   private void PlayDescAudio1()
    {
        firstclip = false;
        secondclip = true;
        AudioManager.Instance.Play(desc1Audio);
    }

    private void ChangeFunct()
    {
        firstclip = false;
        secondclip = false;
        aurora_1.gameObject.SetActive(false);
        aurora_2.gameObject.SetActive(true);
        descText_1.gameObject.SetActive(false);
        descText_2.gameObject.SetActive(true);
        AudioManager.Instance.Play(desc2Audio);
    }

    public void PlayPauseTitleClip()
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
                AudioManager.Instance.Play(tileAudio);
            }
        }

    }

    public void PlayPauseDesc1()
    {
        if (!firstclip && secondclip)
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
                AudioManager.Instance.Play(desc1Audio);
            }

        }
    }

    public void PlayPauseDesc2()
    {
        if(!firstclip && !secondclip)
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
                AudioManager.Instance.Play(desc2Audio);
            }
        }
    }

    public void BackButtonClick()
    {
        this.gameObject.SetActive(false);
        this.homeButton.gameObject.SetActive(false);
        mainHomeButton.gameObject.SetActive(true);
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
        descText_1.gameObject.SetActive(false);
        descText_2.gameObject.SetActive(true);
        nextTextButton.gameObject.SetActive(false);
        previousTextButton.gameObject.SetActive(true);
        AudioManager.Instance.Play(desc1Audio);
    }
    public void TextMoveback()
    {
        descText_2.gameObject.SetActive(false);
        descText_1.gameObject.SetActive(true);
        AudioManager.Instance.Play(desc2Audio);
        previousTextButton.gameObject.SetActive(false);
        nextTextButton.gameObject.SetActive(true);
    }
}
