using DesertHabitat;
using UnityEngine;
using UnityEngine.UI;

public class CamelController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;

    //audio
    [SerializeField] private AudioClip[] camelClips;

    //button
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button backTextButton;

    //
    [SerializeField] private GameObject camel0;
    [SerializeField] private GameObject camel1;

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
            AudioManager.Instance.Play(camelClips[i]);
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
        camel0.SetActive(false);
        camel1.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void OnClickBackTextButton()
    {
        i = 0;
        camel0.SetActive(true);
        camel1.SetActive(false);
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
