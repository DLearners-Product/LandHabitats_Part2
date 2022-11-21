using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GrasslandsHabitat
{
    public class GrasslandActivityController : MonoBehaviour
    {
        //audio
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip titleClip;
        [SerializeField] private AudioClip desc1Clip;
        [SerializeField] private AudioClip desc2Clip;
        [SerializeField] private AudioClip correctAnswerClip;
        [SerializeField] private AudioClip victoryClip;
        [SerializeField] private AudioClip victoryMessage;
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
        private int closeCount;          //for detecting the last close button and to wait and open the win screen

        // Start is called before the first frame update
        void Start()
        {
            i = 0;
            closeCount = 0;
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
                string ans = ClickSelect()?.name;
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

            if (closeCount == 4)
            {
                closeCount = 0;
                Invoke("ShowWinScreen", 2f);
                Invoke("WinMessage", 4f);
            }
        }

        public void ShowInfoWindow(int i, string ans)
        {
            infoWindow.SetActive(true);
            iconPlaceHolder.sprite = animalsIcon[i];
            textPlaceHolder.text = animalsText[i];
            answer.text = ans;

            //AudioManager.Instance.Play(correctAnswerClip);
            audioSource.clip = correctAnswerClip;
            audioSource.Play();


        }

        public void WinMessage()
        {
            audioSource.clip = victoryMessage;
            audioSource.Play();
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
            closeCount++;
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

        public void ShowWinScreen()
        {
            //AudioManager.Instance.Play(victoryClip);


            //yield return new WaitForSeconds(3f);
            //open
            winScreen.SetActive(true);
            audioSource.Stop();
            audioSource.clip = victoryClip;
            audioSource.Play();

            //close
            Close();
        }

        public void Close()
        {
            zoomRect.SetActive(false);
            infoWindow.SetActive(false);
            playScreen.SetActive(false);
            foundAnimalsPanel.SetActive(false);
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }

        public void PlayTitleClip()
        {
            //AudioManager.Instance.Play(titleClip);

            audioSource.clip = titleClip;
            audioSource.Play();
        }

        public void PlayDesc1Clip()
        {
            audioSource.clip = desc1Clip;
            audioSource.Play();
        }

        public void PlayDesc2Clip()
        {
            audioSource.clip = desc2Clip;
            audioSource.Play();
        }

        public void PlayAnimalSound()
        {
            audioSource.clip = animalSounds[i];
            audioSource.Play();
        }

        void OnDestroy()
        {
            AudioManager.Instance.StopMusic();
        }
    }
}