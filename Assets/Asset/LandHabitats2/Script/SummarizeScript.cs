using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummarizeScript : MonoBehaviour
{
    [SerializeField] private GameObject[] slides;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button backButton;
    [SerializeField] private AudioClip summarizeClip;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        slides[i].SetActive(true);
        AudioManager.Instance.Play(summarizeClip);
        backButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
    }

    public void OnclickNextButton()
    {
        i++;
        slides[i - 1].SetActive(false);
        slides[i].SetActive(true);

        if(i == slides.Length -1)
        {
            nextButton.gameObject.SetActive(false);
            backButton.gameObject.SetActive(true);
        }
       
    }

    public void OnclickBackButton()
    {
        i--;
        slides[i + 1].SetActive(false);
        slides[i].SetActive(true);

        if (i == 0)
        {
            backButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
     
    }


}
