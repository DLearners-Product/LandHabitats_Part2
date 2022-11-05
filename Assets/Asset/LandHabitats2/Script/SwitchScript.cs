using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SwitchScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] animalTexts;
    [SerializeField] private Image animalImage;
    [SerializeField] private Sprite[] images;
    [SerializeField] private AudioClip[] animalClips;
    [SerializeField] private AudioClip subTextCLip;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject nextSlide;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button nextSlideHomebutton;
    private int i;
     

    private void Start()
    {
        i = 0;
       AudioManager.Instance.Play(subTextCLip);
       StartCoroutine(SwitchText());
        homeButton.gameObject.SetActive(true);
      
    }
    IEnumerator SwitchText()
    {
        while (true)
        {
            yield return new WaitForSeconds(subTextCLip.length +1 );
            if(i< animalTexts.Length - 1)
            {
                i++;
                animalTexts[i - 1].gameObject.SetActive(false);
                animalTexts[i].gameObject.SetActive(true);
                animalImage.sprite = images[i];
               AudioManager.Instance.Play(animalClips[i]);
            }
            else
            {
                if (i >= animalTexts.Length) i = 0;
            }
          

        }
        
    }

    public void NextButtonClick()
    {
        this.gameObject.SetActive(false);
        this.homeButton.gameObject.SetActive(false);
        nextSlideHomebutton.gameObject.SetActive(true);
        nextSlide.SetActive(true);
    }

    
}
