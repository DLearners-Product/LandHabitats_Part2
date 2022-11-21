using System.Collections;
using TMPro;
using UnityEngine;

namespace DesertHabitat
{
    public class DesertMapController : MonoBehaviour
    {
        //images
        [SerializeField] private GameObject northAmericaRegion;
        [SerializeField] private GameObject southAmericaRegion;
        [SerializeField] private GameObject africaRegion;
        [SerializeField] private GameObject asiaRegion;
        [SerializeField] private GameObject australiaRegion;

        //audio
        [SerializeField] private AudioClip titleClip;
        [SerializeField] private AudioClip northAmericaClip;
        [SerializeField] private AudioClip southAmericaClip;
        [SerializeField] private AudioClip africaClip;
        [SerializeField] private AudioClip asiaClip;
        [SerializeField] private AudioClip australiaClip;


        void Start()
        {
            Invoke("PlayTitleClip", 1f);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                string ans = ClickSelect()?.name;
                //if clicked on something that has a meaningful gameobject
                if (ans != null)
                {
                    if (ans == "NorthAmerica")
                    {
                        AudioManager.Instance.Play(northAmericaClip);
                        northAmericaRegion.SetActive(true);
                    }
                    else if (ans == "SouthAmerica")
                    {
                        AudioManager.Instance.Play(southAmericaClip);
                        southAmericaRegion.SetActive(true);
                    }
                    else if (ans == "Africa")
                    {
                        AudioManager.Instance.Play(africaClip);
                        africaRegion.SetActive(true);
                    }
                    else if (ans == "Asia")
                    {
                        AudioManager.Instance.Play(asiaClip);
                        asiaRegion.SetActive(true);
                    }
                    else if (ans == "Australia")
                    {
                        AudioManager.Instance.Play(australiaClip);
                        australiaRegion.SetActive(true);
                    }
                }
                //if clicked on something that has no meaningful gameobject
                else
                {
                    //do nothing
                }
            }
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

        public void PlayTitleClip()
        {
            AudioManager.Instance.Play(titleClip);
        }

    }
}