using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorpionController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;

    //text
    [SerializeField] private TextMeshProUGUI[] scorpionTexts;

    //audio
    [SerializeField] private AudioClip[] scorpionClips;

    //button
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button backTextButton;


    private int i = 0;
    private bool isPlaying = true;

    /*    public void OnClickBackButton()
        {
            scorpionPage.SetActive(false);
            detailedPage.SetActive(false);
            backButton.gameObject.SetActive(false);
            mainPage.SetActive(true);
        }*/

    void Update()
    {
        if (!AudioManager.Instance.EffectsSource.isPlaying)
        {
            playPauseButton.GetComponent<Image>().sprite = playButtonSprite;
            isPlaying = true;
        }
    }

    public void OnClickPlayPauseButton()
    {
        if (isPlaying)
        {
            //play
            isPlaying = false;
            playPauseButton.gameObject.GetComponent<Image>().sprite = pauseButtonSprite;
            AudioManager.Instance.Play(scorpionClips[i]);

        }
        else
        {
            //pause
            isPlaying = true;
            playPauseButton.gameObject.GetComponent<Image>().sprite = playButtonSprite;
            AudioManager.Instance.Pause();
        }

    }

    public void OnClickRestartButton()
    {
        AudioManager.Instance.Restart();
    }

    public void OnClickNextTextButton()
    {
        i = 1;
        scorpionTexts[i - 1].gameObject.SetActive(false);
        scorpionTexts[i].gameObject.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void OnClickBackTextButton()
    {
        i = 0;
        scorpionTexts[i + 1].gameObject.SetActive(false);
        scorpionTexts[i].gameObject.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void EnableDisableTextNavButtons()
    {
        if (i == 1)
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
}