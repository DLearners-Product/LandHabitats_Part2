using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacteristicsController_Tundra : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI[] contentTexts;
    [SerializeField] private AudioClip[] contentAudios;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject nextSlide;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button Replaybutton;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button backTextButton;
    [SerializeField] private Button nextSlideHomeButton;
    int i;
    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
        i = 0;
        AudioManager.Instance.Play(contentAudios[i]);

    }



    public void OnClickNextTextButton()
    {
        i++;
        contentTexts[i - 1].gameObject.SetActive(false);
        contentTexts[i].gameObject.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void OnClickBackTextButton()
    {
        i--;
        contentTexts[i + 1].gameObject.SetActive(false);
        contentTexts[i].gameObject.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void EnableDisableTextNavButtons()
    {
        if (i == contentTexts.Length - 1)
        {
            nextTextButton.gameObject.SetActive(false);
            backTextButton.gameObject.SetActive(true);
        }
        else if (i == 0)
        {
            nextTextButton.gameObject.SetActive(true);
            backTextButton.gameObject.SetActive(false);
        }

        //if any audio is playing, stop it
        AudioManager.Instance.EffectsSource.Stop();
    }


    public void NextButtonClick()
    {
        this.gameObject.SetActive(false);
        this.homeButton.gameObject.SetActive(false);
        nextSlideHomeButton.gameObject.SetActive(true);
        nextSlide.SetActive(true);

    }

    public void PlayPause()
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
            AudioManager.Instance.Play(contentAudios[i]);
        }

    }


    public void Replay()
    {
        AudioManager.Instance.Replay();
    }


}
