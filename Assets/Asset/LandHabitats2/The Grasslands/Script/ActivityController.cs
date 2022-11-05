using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GrasslandsHabitat
{
    public class ActivityController : MonoBehaviour
    {
        //audio
        [SerializeField] private AudioClip titleClip;
        [SerializeField] private AudioClip desc1Clip;
        [SerializeField] private AudioClip desc2Clip;
        [SerializeField] private AudioClip correctAnswerClip;
        [SerializeField] private AudioClip victoryClip;
        [SerializeField] private AudioClip grasslandsAmbienceClip;
        [SerializeField] private GameObject zoomRect;
        [SerializeField] private AudioClip[] animalSounds;

        //sprites
        [SerializeField] private GameObject[] clouds;

        //image
        [SerializeField] private GameObject[] animalsFoundImages;

        //screen
        [SerializeField] private GameObject screen;
        [SerializeField] private GameObject welcomeScreen;
        [SerializeField] private GameObject playScreen;
        [SerializeField] private GameObject winScreen;
        [SerializeField] private GameObject foundAnimalsPanel;

        //answer
        [SerializeField] private GameObject infoWindow;
        [SerializeField] private TextMeshProUGUI answer;
        [SerializeField] private Sprite[] animalsIcon;
        [SerializeField] private string[] animalsText;
        [SerializeField] private Image iconPlaceHolder;
        [SerializeField] private TextMeshProUGUI textPlaceHolder;

        //button
        [SerializeField] private Button nextButton;
        [SerializeField] private Button backButton;
        [SerializeField] private Button closeButton;

        private Vector3 screenPos;
        private float maxLeftView;
        private float maxRightView;
        private float maxtopView;
        private float maxbottomView;
        private int answerCount;
        private Dictionary<string, int> animalsFound;
        private int i;

        // Start is called before the first frame update
        void Start()
        {
            i = 0;
            screenPos = screen.transform.position;
            maxLeftView = 9f;
            maxRightView = -9f;
            maxtopView = 4.5f;
            maxbottomView = -4.5f;
            animalsFound = new Dictionary<string, int>();

            AudioManager.Instance.PlayMusic(grasslandsAmbienceClip);
            Invoke("PlayTitleClip", 1f);
            Invoke("PlayDesc1Clip", 5f);
            Invoke("PlayDesc2Clip", 10f);
        }

        // Update is called once per frame
        void Update()
        {
            CloudsMovement();

            if (Input.GetMouseButtonDown(0))
            {
                string ans = ClickSelect().name;
                //if clicked on something that has a meaningful gameobject
                if (ans != null)
                {
                    if (ans == "Eagle")
                    {
                        i = 0;
                        ShowInfoWindow(i, ans);
                    }
                    else if (ans == "Elephant")
                    {
                        i = 1;
                        ShowInfoWindow(i, ans);
                    }
                    else if (ans == "Kangaroo")
                    {
                        i = 2;
                        ShowInfoWindow(i, ans);
                    }
                    else if (ans == "Zebra")
                    {
                        i = 3;
                        ShowInfoWindow(i, ans);
                    }
                    else
                    {
                        //do nothing
                    }

                    if (!animalsFound.ContainsKey(ans))
                    {
                        animalsFound.Add(ans, 1);
                        animalsFoundImages[i].SetActive(true);
                        answerCount++;
                    }
                }
                //if clicked on something that has no meaningful gameobject
                else
                {
                    //do nothing
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow) && screen.transform.position.x < maxLeftView)
            {
                MoveScreen(Vector3.right);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && screen.transform.position.x > maxRightView)
            {
                MoveScreen(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.DownArrow) && screen.transform.position.y < maxtopView)
            {
                MoveScreen(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.UpArrow) && screen.transform.position.y > maxbottomView)
            {
                MoveScreen(Vector3.down);
            }

            if (answerCount == 4)
            {
                StartCoroutine(ShowWinScreen());
            }
        }

        public void ShowInfoWindow(int i, string ans)
        {
            infoWindow.SetActive(true);
            iconPlaceHolder.sprite = animalsIcon[i];
            textPlaceHolder.text = animalsText[i];
            answer.text = ans;
            AudioManager.Instance.Play(correctAnswerClip);
        }

        IEnumerator DisableAnswerWindow()
        {
            yield return new WaitForSeconds(1f);

            infoWindow.SetActive(false);
            answer.text = "";
        }


        GameObject ClickSelect()
        {
            //Converting $$anonymous$$ouse Pos to 2D (vector2) World Pos
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                return hit.transform.gameObject;
            }
            else
            {
                return null;
            }
        }

        public void MoveScreen(Vector3 dir)
        {
            //screenPos.x += dir.x * 5f * Time.deltaTime;   //only to navigate in x axis
            screenPos += dir * 5f * Time.deltaTime;
            screen.transform.position = screenPos;
        }

        public void OnClickNextButton()
        {
            playScreen.SetActive(true);
            foundAnimalsPanel.SetActive(true);
            welcomeScreen.SetActive(false);
            nextButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(true);
            zoomRect.SetActive(true);
        }

        public void OnClickBackButton()
        {
            welcomeScreen.SetActive(true);
            playScreen.SetActive(false);
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
            zoomRect.SetActive(false);
        }

        public void OnClickCloseButton()
        {
            infoWindow.SetActive(false);
        }

        public void CloudsMovement()
        {
            clouds[0].transform.Translate((transform.position + Vector3.right) * 0.25f * Time.deltaTime);
            clouds[1].transform.Translate((transform.position + Vector3.left) * 0.75f * Time.deltaTime);
            clouds[2].transform.Translate((transform.position + Vector3.right) * 0.15f * Time.deltaTime);
            clouds[3].transform.Translate((transform.position + Vector3.left) * 0.5f * Time.deltaTime);
            clouds[4].transform.Translate((transform.position + Vector3.right) * 0.25f * Time.deltaTime);
            clouds[5].transform.Translate((transform.position + Vector3.left) * 0.75f * Time.deltaTime);
            clouds[6].transform.Translate((transform.position + Vector3.right) * 0.15f * Time.deltaTime);
        }

        IEnumerator ShowWinScreen()
        {
            AudioManager.Instance.Play(victoryClip);

            yield return new WaitForSeconds(3f);
            //open
            winScreen.SetActive(true);

            //close
            zoomRect.SetActive(false);
            playScreen.SetActive(false);
            foundAnimalsPanel.SetActive(false);
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }

        public void PlayTitleClip()
        {
            AudioManager.Instance.Play(titleClip);
        }

        public void PlayDesc1Clip()
        {
            AudioManager.Instance.Play(desc1Clip);
        }

        public void PlayDesc2Clip()
        {
            AudioManager.Instance.Play(desc2Clip);
        }

        public void PlayAnimalSound()
        {
            AudioManager.Instance.Play(animalSounds[i]);
        }

        void OnDestroy()
        {
            AudioManager.Instance.StopMusic();
        }
    }
}