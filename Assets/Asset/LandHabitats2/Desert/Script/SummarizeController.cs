using UnityEngine;
using UnityEngine.UI;

namespace DesertHabitat
{
    public class SummarizeController : MonoBehaviour
    {
        //audio
        [SerializeField] private AudioClip titleClip;

        //button
        [SerializeField] private Button nextButton;
        [SerializeField] private Button backButton;

        [SerializeField] private GameObject[] screens;

        private int i = 0;

        void Start()
        {
            Invoke("PlayTitleClip", 1f);
        }

        public void PlayTitleClip()
        {
            AudioManager.Instance.Play(titleClip);
        }

        public void OnClickNextButton()
        {
            i++;

            screens[i - 1].SetActive(false);
            screens[i].SetActive(true);

            EnableDisableNavButtons();
        }

        public void OnClickBackButton()
        {
            i--;

            screens[i + 1].SetActive(false);
            screens[i].SetActive(true);

            EnableDisableNavButtons();
        }

        public void EnableDisableNavButtons()
        {
            if (i == 0)
            {
                backButton.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
            }
            else if (i == 1)
            {
                backButton.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(true);
            }
            else if (i == 2)
            {
                backButton.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(false);
            }
        }

    }
}