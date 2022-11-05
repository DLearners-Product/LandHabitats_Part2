using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesertHabitat
{
    public class SummaryController : MonoBehaviour
    {
        //button
        [SerializeField] private Button nextButton;
        [SerializeField] private Button backButton;

        [SerializeField] private TextMeshProUGUI[] descs;
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
            descs[i].gameObject.SetActive(true);
            AudioManager.Instance.Play(clips[i]);
            EnableDisableButtons();
        }

        public void OnClickBackButton()
        {
            i--;
            descs[i + 1].gameObject.SetActive(false);
            AudioManager.Instance.Play(clips[i]);
            EnableDisableButtons();
        }

        public void EnableDisableButtons()
        {
            if (i == 0)
                backButton.gameObject.SetActive(false);
            else
                backButton.gameObject.SetActive(true);

            if (i == descs.Length - 1)
                nextButton.gameObject.SetActive(false);
            else
                nextButton.gameObject.SetActive(true);
        }
    }
}