using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesertHabitat
{
    public class DesertActivityController : MonoBehaviour
    {
        //audio
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip titleClip;
        [SerializeField] private AudioClip hintClip;
        [SerializeField] private AudioClip correctAnswerClip;
        [SerializeField] private AudioClip wrongAnswerClip;
        [SerializeField] private AudioClip victoryClip;
        [SerializeField] private AudioClip desertAmbienceClip;
        [SerializeField] private AudioClip foundAllCorrectlyVO;
        [SerializeField] private AudioClip[] foundVO;

        //sprites
        [SerializeField] private GameObject[] clouds;

        //screen
        [SerializeField] private GameObject screen;
        [SerializeField] private GameObject welcomeScreen;
        [SerializeField] private GameObject playScreen;
        [SerializeField] private GameObject winScreen;

        //answer
        [SerializeField] private GameObject answerWindow;
        [SerializeField] private TextMeshProUGUI answer;

        //button
        [SerializeField] private Button nextButton;
        [SerializeField] private Button backButton;

        private Vector3 screenPos;
        private float maxLeftView;
        private float maxRightView;
        private int answerCount;
        private Dictionary<string, int> animals;
        private int i;


        // Start is called before the first frame update
        void Start()
        {
            screenPos = screen.transform.position;
            answerCount = 0;
            maxLeftView = 9f;
            maxRightView = -9f;
            animals = new Dictionary<string, int>();

            AudioManager.Instance.PlayMusic(desertAmbienceClip);
            Invoke("PlayTitleClip", 1f);
            Invoke("PlayHintClip", 5f);
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
                    //if answer already found
                    if (animals.ContainsKey(ans))
                    {
                        //display already found
                        answerWindow.SetActive(true);
                        answer.text = "Already found!";
                        //AudioManager.Instance.Play(wrongAnswerClip);

                        audioSource.clip = wrongAnswerClip;
                        audioSource.Play();

                        Invoke("DisableAnswerWindow", 2.5f);
                    }
                    //if answer not already found
                    else
                    {

                        if (ans == "Cactus")
                        {
                            i = 0;
                            ShowAnswerWindow(ans, i);
                        }
                        else if (ans == "Desert Tree")
                        {
                            i = 1;
                            ShowAnswerWindow(ans, i);
                        }
                        else if (ans == "Camel")
                        {
                            i = 2;
                            ShowAnswerWindow(ans, i);
                        }
                        else if (ans == "Eagle")
                        {
                            i = 3;
                            ShowAnswerWindow(ans, i);
                        }
                        else if (ans == "Snake")
                        {
                            i = 4;
                            ShowAnswerWindow(ans, i);
                        }
                        else if (ans == "Kangaroo")
                        {
                            i = 5;
                            ShowAnswerWindow(ans, i);
                        }
                        //if answer found does not belongs to desert
                        else
                        {
                            answerWindow.SetActive(true);
                            answer.text = "Not a desert plant/animal";
                            //AudioManager.Instance.Play(wrongAnswerClip);

                            audioSource.clip = wrongAnswerClip;
                            audioSource.Play();

                            Invoke("DisableAnswerWindow", 2.5f);
                        }
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

            if (answerCount == 4)
            {
                answerCount = 0;
                StartCoroutine(PlayFoundAllCorrectlyClip());
                Invoke("ShowWinScreen", 7f);
            }
        }

        public void ShowAnswerWindow(string ans, int i)
        {
            animals.Add(ans, 1);
            answerCount++;
            answerWindow.SetActive(true);
            answer.text = ans;
            //AudioManager.Instance.Play(foundVO[i]);

            audioSource.clip = foundVO[i];
            audioSource.Play();

            Invoke("DisableAnswerWindow", 2.5f);
        }

        public void DisableAnswerWindow()
        {
            answerWindow.SetActive(false);
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
            screenPos.x += dir.x * 5f * Time.deltaTime;
            screen.transform.position = screenPos;
        }

        public void OnClickNextButton()
        {
            playScreen.SetActive(true);
            welcomeScreen.SetActive(false);
            nextButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(true);
        }

        public void OnClickBackButton()
        {
            welcomeScreen.SetActive(true);
            playScreen.SetActive(false);
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
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
            audioSource.Stop();
            audioSource.clip = victoryClip;
            audioSource.Play();

            playScreen.SetActive(false);
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            winScreen.SetActive(true);
        }

        public void PlayTitleClip()
        {
            //AudioManager.Instance.Play(titleClip);

            audioSource.clip = titleClip;
            audioSource.Play();
        }

        public void PlayHintClip()
        {
            //AudioManager.Instance.Play(hintClip);

            audioSource.clip = hintClip;
            audioSource.Play();
        }

        IEnumerator PlayFoundAllCorrectlyClip()
        {
            yield return new WaitForSeconds(2f);

            audioSource.clip = foundAllCorrectlyVO;
            audioSource.Play();
        }

        void OnDestroy()
        {
            AudioManager.Instance.StopMusic();
        }
    }
}