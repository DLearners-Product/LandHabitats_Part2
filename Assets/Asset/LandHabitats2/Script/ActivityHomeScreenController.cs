using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityHomeScreenController : MonoBehaviour
{
    [SerializeField] private GameObject polarActivity;
    [SerializeField] private Button nextButton;
    [SerializeField] private AudioClip activityInstructionAudio;
    public GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        AudioManager.Instance.Play(activityInstructionAudio);
        playerCamera.SetActive(false);
    }

   public void OnNextButtonclick()
    {
        this.gameObject.SetActive(false);
        polarActivity.SetActive(true);
        playerCamera.SetActive(true);

    }
}
