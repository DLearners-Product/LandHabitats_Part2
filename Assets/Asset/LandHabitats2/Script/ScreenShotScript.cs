using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotScript : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoframe;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;
    
    
    public LayerMask animalLayer;

    private BoxCollider2D col;

    private int i;

    [SerializeField] private AudioClip[] voAudio;
   

   

    Texture2D screenShot;
    
    private bool viewPhoto;

   
    // Start is called before the first frame update
    void Start()
    {
      screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        col = GetComponent<BoxCollider2D>();
        i = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!viewPhoto)
            {
                StartCoroutine(CapturePhoto());
            }
            else
            {
                RemovePhoto();
            }
        }
    }
    public void TakePicture()
    {
       
    }
    IEnumerator CapturePhoto()
    {
        //CameraUI to false
        viewPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenShot.ReadPixels(regionToRead, 0,0, false);

        Vector2 rayPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f );

        if (hit)
        {
           yield  return hit.transform.gameObject;
            if (hit.collider.name == "PolarBear")
            {
                AudioManager.Instance.Play(voAudio[0]);
            }

            else if (hit.collider.name == "Orca")
            {
                AudioManager.Instance.Play(voAudio[1]);
            }

            else if (hit.collider.name == "Penguin")
            {
                AudioManager.Instance.Play(voAudio[2]);
            }
        }
        else
        {
          yield  return null;

        }
        screenShot.Apply();
        ShowPhoto();
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenShot, new Rect(0.0f, 0.0f, screenShot.width, screenShot.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoframe.SetActive(true);
        StartCoroutine(CameraFlashEffect());
    }

    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

    void RemovePhoto()
    {
        viewPhoto = false;
        photoframe.SetActive(false);
        //CameraUI to true
    }


}   
