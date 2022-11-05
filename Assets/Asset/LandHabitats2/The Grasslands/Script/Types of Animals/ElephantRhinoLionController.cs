using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ElephantRhinoLionController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;

    //audio
    [SerializeField] private AudioClip[] camelClips;

    //text
    [SerializeField] private TextMeshProUGUI[] texts;

    //button
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextTextButton;
    [SerializeField] private Button backTextButton;

    private int i = 0;
    private bool isPlaying = true;

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
        texts[i - 1].gameObject.SetActive(false);
        texts[i].gameObject.SetActive(true);
        EnableDisableTextNavButtons();
    }

    public void OnClickBackTextButton()
    {
        i = 0;
        texts[i + 1].gameObject.SetActive(false);
        texts[i].gameObject.SetActive(true);
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
