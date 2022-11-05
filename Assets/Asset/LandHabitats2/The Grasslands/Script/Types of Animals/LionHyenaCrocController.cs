using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LionHyenaCrocController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;

    //audio
    [SerializeField] private AudioClip clip;

    //button
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button restartButton;

    private int i = 0;
    private bool isPlaying = true;


    public void OnClickPlayPauseButton()
    {
        if (isPlaying)
        {
            //play
            isPlaying = false;
            playPauseButton.gameObject.GetComponent<Image>().sprite = pauseButtonSprite;
            AudioManager.Instance.Play(clip);
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
