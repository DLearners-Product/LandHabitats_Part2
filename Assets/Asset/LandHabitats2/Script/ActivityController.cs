using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActivityController : MonoBehaviour
{
    GameObject gameScreen;
    [SerializeField] private GameObject playScreen;
    private Vector3 screenPos;
    private float maxLeftView;
    private float maxRightView;
    private float maxtopView;
    private float maxbottomView;

    

    // Start is called before the first frame update
    void Start()
    {
        screenPos = playScreen.transform.position;
        maxLeftView = 50f;
        maxRightView = -50f;
        maxtopView = 12f;
        maxbottomView = -6f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && playScreen.transform.position.x < maxLeftView)
        {
            MoveScreen(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && playScreen.transform.position.x > maxRightView)
        {
            MoveScreen(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && playScreen.transform.position.y < maxtopView)
        {
            MoveScreen(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && playScreen.transform.position.y > maxbottomView)
        {
            MoveScreen(Vector3.down);
        }

        
    }

    public void MoveScreen(Vector3 dir)
    {
        //screenPos.x += dir.x * 5f * Time.deltaTime;   //only to navigate in x axis
        screenPos += dir * 5f * Time.deltaTime;
        playScreen.transform.position = screenPos;
    }


}
