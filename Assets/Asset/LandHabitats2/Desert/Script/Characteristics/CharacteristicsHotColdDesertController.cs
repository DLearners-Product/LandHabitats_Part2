using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacteristicsHotColdDesertController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite playButtonSprite;
    [SerializeField] private Sprite pauseButtonSprite;

    //Audio
    [SerializeField] private AudioClip desc1Clip;

    //Button
    [SerializeField] private Button playPauseButton;

    private bool isDesc1Playing = true;
    private float currentClipPos = 0;


    public void PlayPauseDesc1()
    {
        if (isDesc1Playing)
        {
            //play
            isDesc1Playing = false;
            playPauseButton.gameObject.GetComponent<Image>().sprite = pauseButtonSprite;
            AudioManager.Instance.Play(desc1Clip);
        }
        else
        {
            //pause
            isDesc1Playing = true;
            playPauseButton.gameObject.GetComponent<Image>().sprite = playButtonSprite;
            AudioManager.Instance.Pause();
        }
    }

    public void RestartDesc1()
    {
        AudioManager.Instance.Restart();
    }

}
