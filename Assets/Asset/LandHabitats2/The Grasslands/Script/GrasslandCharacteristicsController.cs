using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GrasslandsHabitat
{
    public class GrasslandCharacteristicsController : MonoBehaviour
    {

        //sprite
        [SerializeField] private Sprite playButtonSprite;
        [SerializeField] private Sprite pauseButtonSprite;

        //audio
        [SerializeField] private AudioClip clipDesc;

        //button
        [SerializeField] private Button playPauseButton;
        [SerializeField] private Button restartButton;

        private bool isDescPlaying = true;


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
}