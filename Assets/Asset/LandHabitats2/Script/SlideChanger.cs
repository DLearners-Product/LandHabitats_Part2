using UnityEngine;
using UnityEngine.UI;

public class SlideChanger : MonoBehaviour
{
    [SerializeField]private GameObject[] slides;
    [SerializeField] private GameObject polarSlide;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject general;

    private int i;

    private void Start()
    {
        i = 0;

    }

  public void Switcher(int switchcount)
    {
        i = switchcount;
        ShowSlide();
    }

    void ShowSlide()
    {
        for(int j=0; j<slides.Length; j++)
        {
            slides[j].SetActive(false);
        }
        slides[i].SetActive(true);

        if (i == slides.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            /*nextButton.transform.parent.gameObject.SetActive(true);*/
            backButton.transform.parent.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
        }
        else if (i > 0)
        {
            nextButton.transform.parent.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
        }
        else if(i == 0)
        {
            nextButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(false);
            homeButton.gameObject.SetActive(false);
        }
      
    }

    public void SlideSwitchNext()
    {
        if (i < slides.Length - 1)
        {
            //increasing slides with i
            i++;
            ShowSlide();
           
        }
           
          

      
    }
    public void SlideSwitchBack()
    {
        if (i > 0)
        {
            //decreasing slides with i
            i--;
            ShowSlide();
           
        }
          

    }




}
