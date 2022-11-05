using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickableTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI changableText;
    [SerializeField] private GameObject questionText;
    [SerializeField] private TextMeshProUGUI nonChangeText;
    [SerializeField] private AudioClip nonChangeClip;
    [SerializeField] private AudioClip changeClip;
    [SerializeField] private Button backButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject previousSlide;
    [SerializeField] private GameObject nextSlide;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject habitatSlide;
    [SerializeField] private Button mainHomeButton;
    [SerializeField] private Button nextSlideHomeButton;
    private bool firstclip = true;
    private bool isPlaying = true;

    private void Start()
    {
        isPlaying = true;
        firstclip = true;
        questionText.SetActive(true);
        changableText.gameObject.SetActive(false);
        nonChangeText.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(true);

        Invoke("Textswitch", 5f);

    }

    public void OnTextClick()
    {
        firstclip = false;
        nonChangeText.gameObject.SetActive(false);
        changableText.gameObject.SetActive(true);
        AudioManager.Instance.Play(changeClip);
    }

    public void Textswitch()
    {
      
        firstclip = true;
        questionText.SetActive(false);
        nonChangeText.gameObject.SetActive(true);
        AudioManager.Instance.Play(nonChangeClip);

    }

    public void NextButtonClick()
    {
        this.gameObject.SetActive(false);
        this.homeButton.gameObject.SetActive(false);
        nextSlideHomeButton.gameObject.SetActive(true);
        nextSlide.SetActive(true);
    }

    public void BackButtonClick()
    {
        this.gameObject.SetActive(false);
        this.homeButton.gameObject.SetActive(false);
        mainHomeButton.gameObject.SetActive(true);
        previousSlide.SetActive(true);
    }

    public void HomeButtonClick()
    {
        this.gameObject.SetActive(false);
        habitatSlide.SetActive(true);

    }

    public void PlayPauseDesc1()
    {
        if (firstclip)
        {

            if (isPlaying)
            {
                isPlaying = false;
                pauseButton.gameObject.GetComponent<Image>().sprite = playSprite;
                AudioManager.Instance.Pause();
            }

            else
            {
                isPlaying = true;
                pauseButton.gameObject.GetComponent<Image>().sprite = pauseSprite;
                AudioManager.Instance.Play(nonChangeClip);
            }
        }

    }

    public void PlayPauseDesc2()
    {
        if (!firstclip)
        {
            if (isPlaying)
            {
                isPlaying = false;
                pauseButton.gameObject.GetComponent<Image>().sprite = playSprite;
                AudioManager.Instance.Pause();
            }

            else
            {
                isPlaying = true;
                pauseButton.gameObject.GetComponent<Image>().sprite = pauseSprite;
                AudioManager.Instance.Play(changeClip);
            }

        }
    }

    public void Replay()
    {
        AudioManager.Instance.Replay();
    }

}
