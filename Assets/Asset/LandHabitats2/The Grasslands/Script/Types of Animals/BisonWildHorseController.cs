using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BisonWildHorseController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite playButtonSprite;
    [SerializeField] private Sprite pauseButtonSprite;

    //audio
    [SerializeField] private AudioClip[] clipDescs;

    //text
    [SerializeField] private TextMeshProUGUI[] texts;

    //button
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button prevArrow;
    [SerializeField] private Button nextArrow;

    private int i = 0;
    private bool isDescPlaying = true;

    public void PlayPauseDesc()
    {
        if (isDescPlaying)
        {
            //play
            isDescPlaying = false;
            playPauseButton.gameObject.GetComponent<Image>().sprite = pauseButtonSprite;
            AudioManager.Instance.Play(clipDescs[i]);
        }
        else
        {
            //pause
            isDescPlaying = true;
            playPauseButton.gameObject.GetComponent<Image>().sprite = playButtonSprite;
            AudioManager.Instance.Pause();
        }
    }

    public void RestartDesc()
    {
        AudioManager.Instance.Restart();
    }

    public void OnClickNextTextButton()
    {
        i++;
        texts[i - 1].gameObject.SetActive(false);
        texts[i].gameObject.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void OnClickBackTextButton()
    {
        i--;
        texts[i + 1].gameObject.SetActive(false);
        texts[i].gameObject.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void EnableDisableTextNavButtons()
    {
        if (i == 2)
        {
            nextArrow.gameObject.SetActive(false);
            prevArrow.gameObject.SetActive(true);
        }
        else if (i == 1)
        {
            nextArrow.gameObject.SetActive(true);
            prevArrow.gameObject.SetActive(true);
        }
        else if (i == 0)
        {
            nextArrow.gameObject.SetActive(true);
            prevArrow.gameObject.SetActive(false);
        }

        //if any audio is playing, stop it
        AudioManager.Instance.EffectsSource.Stop();
    }
}
