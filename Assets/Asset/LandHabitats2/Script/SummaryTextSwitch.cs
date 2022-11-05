using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SummaryTextSwitch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] descTexts;
    [SerializeField] private AudioClip[] descAudios;
    [SerializeField] private Button nextButton;
    private int i;
    void Start()
    {
        i = 0;
        AudioManager.Instance.Play(descAudios[i]);
    }

    public void OnButtonClick()
    {
        i++;
        descTexts[i].gameObject.SetActive(true);
        AudioManager.Instance.Play(descAudios[i]);

        if(i== descTexts.Length-1)
        {
            nextButton.gameObject.SetActive(false);
        }
    }

    
}
