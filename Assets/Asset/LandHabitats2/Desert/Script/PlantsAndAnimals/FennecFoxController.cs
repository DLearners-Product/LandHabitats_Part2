using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FennecFoxController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;

    //TextMeshProUGUI
    [SerializeField] private TextMeshProUGUI[] texts;

    //audio
    [SerializeField] private AudioClip[] fennecFoxClips;

    //button
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button backTextButton;

    private int i = 0;
    private bool isPlaying = true;

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
            AudioManager.Instance.Play(fennecFoxClips[i]);

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
        if (i == 3)
        {
            nextTextButton.gameObject.SetActive(false);
            backTextButton.gameObject.SetActive(true);
        }
        else if (i == 2)
        {
            nextTextButton.gameObject.SetActive(true);
            backTextButton.gameObject.SetActive(true);
        }
        else if (i == 1)
        {
            nextTextButton.gameObject.SetActive(true);
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
