using UnityEngine;
using UnityEngine.UI;

public class LionCheetahController : MonoBehaviour
{
    //sprite
    [SerializeField] private Sprite playButtonSprite;
    [SerializeField] private Sprite pauseButtonSprite;

    //audio
    [SerializeField] private AudioClip clipDesc;

    //button
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Button restartButton;

    private bool isDescPlaying = false;


    public void PlayPauseDesc()
    {
        if (isDescPlaying)
        {
            //play
            isDescPlaying = false;
            playPauseButton.gameObject.GetComponent<Image>().sprite = pauseButtonSprite;
            AudioManager.Instance.Play(clipDesc);
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
}
