using System.Collections;

using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace DesertHabitat
{
    public class CharacteristicsController : MonoBehaviour
    {
        //audio
        [SerializeField] private AudioClip clipTitle;

        //gameobject
        [SerializeField] private GameObject screens;
        [SerializeField] private GameObject bottomElements;

        //button
        [SerializeField] private Button btnNext;
        [SerializeField] private Button btnBack;

        private int i = 0;
        private bool nextButtonClicked = false;
        private bool backButtonClicked = false;

        private Vector3 screenStartPos;
        private Vector3 screenEndPos;
        private Vector3 screenNextOffset = new Vector3(-17.55f, 0f, 0f);
        private Vector3 screenBackOffset = new Vector3(17.55f, 0f, 0f);
        private float timer = 0;
        private Vector3 mountainStartPos;
        private Vector3 mountainEndPos;
        private Vector3 mountainNextOffset = new Vector3(-4.5f, 0f, 0f);
        private Vector3 mountainBackOffset = new Vector3(4.5f, 0f, 0f);


        public void Start()
        {
            screenStartPos = screens.transform.position;
            screenEndPos = screens.transform.position + screenNextOffset;

            mountainStartPos = bottomElements.transform.position;
            mountainEndPos = bottomElements.transform.position + mountainNextOffset;

            Invoke("PlayTitleClip", 1f);
        }

        void Update()
        {
            if (nextButtonClicked)
            {
                //onNextButtonClicked
                screens.transform.position = Vector3.Lerp(screenStartPos, screenEndPos, timer);
                bottomElements.transform.position = Vector3.Lerp(mountainStartPos, mountainEndPos, timer);
                timer += Time.deltaTime;

                if (screenStartPos == screenEndPos)
                {
                    screenStartPos = screenEndPos;
                    nextButtonClicked = false;

                    mountainStartPos = mountainEndPos;
                }
            }

            if (backButtonClicked)
            {
                //onNextButtonClicked
                screens.transform.position = Vector3.Lerp(screenStartPos, screenEndPos, timer);
                bottomElements.transform.position = Vector3.Lerp(mountainStartPos, mountainEndPos, timer);
                timer += Time.deltaTime;

                if (screenStartPos == screenEndPos)
                {
                    screenStartPos = screenEndPos;
                    backButtonClicked = false;

                    mountainStartPos = mountainEndPos;
                }
            }
        }

        public void PlayTitleClip()
        {
            AudioManager.Instance.Play(clipTitle);
        }

        public void OnClickNextButton()
        {
            i++;
            nextButtonClicked = true;
            timer = 0;

            screenStartPos = screens.transform.position;
            screenEndPos = screens.transform.position + screenNextOffset;

            mountainStartPos = bottomElements.transform.position;
            mountainEndPos = bottomElements.transform.position + mountainNextOffset;

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();

            EnableDisableNavButtons();
        }

        public void OnClickBackButton()
        {
            i--;
            backButtonClicked = true;
            timer = 0;

            screenStartPos = screens.transform.position;
            screenEndPos = screens.transform.position + screenBackOffset;

            mountainStartPos = bottomElements.transform.position;
            mountainEndPos = bottomElements.transform.position + mountainBackOffset;

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();

            EnableDisableNavButtons();
        }

        void EnableDisableNavButtons()
        {
            if (i == 0)
            {
                btnBack.gameObject.SetActive(false);
                btnNext.gameObject.SetActive(true);
            }
            else if (i == 1)
            {
                btnBack.gameObject.SetActive(true);
                btnNext.gameObject.SetActive(true);
            }
            else if (i == 2)
            {
                btnBack.gameObject.SetActive(true);
                btnNext.gameObject.SetActive(false);
            }
        }

    }
}