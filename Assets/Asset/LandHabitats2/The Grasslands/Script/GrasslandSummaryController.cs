using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace GrasslandsHabitat
{
    public class GrasslandSummaryController : MonoBehaviour
    {
        //button
        [SerializeField] private Button nextButton;
        [SerializeField] private Button backButton;

        [SerializeField] private GameObject[] containers;
        [SerializeField] private AudioClip titleClip;
        [SerializeField] private AudioClip[] clips;

        private int i;

        void Start()
        {
            i = 0;
            Invoke("PlayTitleClip", 1f);
        }

        public void PlayTitleClip()
        {
            AudioManager.Instance.Play(titleClip);
            Invoke("PlayFirstDesc", 3f);
        }

        public void PlayFirstDesc()
        {
            AudioManager.Instance.Play(clips[0]);
        }

        public void OnClickNextButton()
        {
            i++;
            containers[i].gameObject.SetActive(true);
            containers[i - 1].gameObject.SetActive(false);
            AudioManager.Instance.Play(clips[i]);
            EnableDisableButtons();
        }

        public void OnClickBackButton()
        {
            i--;
            containers[i].gameObject.SetActive(true);
            containers[i + 1].gameObject.SetActive(false);
            AudioManager.Instance.Play(clips[i]);
            EnableDisableButtons();
        }

        public void EnableDisableButtons()
        {
            if (i == 0)
                backButton.gameObject.SetActive(false);
            else
                backButton.gameObject.SetActive(true);

            if (i == containers.Length - 1)
                nextButton.gameObject.SetActive(false);
            else
                nextButton.gameObject.SetActive(true);
        }
    }
}