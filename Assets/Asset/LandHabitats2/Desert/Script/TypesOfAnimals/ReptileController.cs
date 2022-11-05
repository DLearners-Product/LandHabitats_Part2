﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReptileController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;

    //audio
    [SerializeField] private AudioClip[] reptileClips;

    //button
    [SerializeField] private Button playPauseButton;
    //[SerializeField] private Button backButton;

    //
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject detailedPage;
    [SerializeField] private GameObject reptile;

    private int i = 0;
    private bool isPlaying = true;

    /*    public void OnClickBackButton()
        {
            reptile.SetActive(false);
            detailedPage.SetActive(false);
            backButton.gameObject.SetActive(false);
            mainPage.SetActive(true);
        }*/

    public void OnClickPlayPauseButton()
    {
        if (isPlaying)
        {
            //play
            isPlaying = false;
            playPauseButton.gameObject.GetComponent<Image>().sprite = pauseButtonSprite;
            AudioManager.Instance.Play(reptileClips[i]);
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

}

