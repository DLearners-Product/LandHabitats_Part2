using UnityEngine;
using UnityEngine.UI;

namespace DesertHabitat
{
    public class DesertHabitatController : MonoBehaviour
    {
        [SerializeField] private GameObject desertMain;
        [SerializeField] private GameObject characteristics;
        [SerializeField] private GameObject map;
        [SerializeField] private GameObject typesOfAnimals;
        [SerializeField] private Button homeButton;
        [SerializeField] private Animator desertAnimator;

        //Audio
        [SerializeField] private AudioClip nowLetsLookAtClip;
        [SerializeField] private AudioClip desertClip;

        public void Start()
        {
            Invoke("PlayLetsLookAt", 1f);
            Invoke("PlayDesert", 3f);
        }

        //home button
        public void ShowDesertMain()
        {
            desertMain.SetActive(true);
            characteristics.SetActive(false);
            map.SetActive(false);
            typesOfAnimals.SetActive(false);

            /*            //if any audio is playing, stop it
                        AudioManager.Instance.EffectsSource.Stop();*/

            homeButton.gameObject.SetActive(false);

            AudioManager.Instance.StopVoice();
        }

        public void ShowCharacteristics()
        {
            AudioManager.Instance.EffectsSource.Stop();
            desertMain.SetActive(false);
            characteristics.SetActive(true);
            map.SetActive(false);
            typesOfAnimals.SetActive(false);
            homeButton.gameObject.SetActive(true);
        }


        public void ShowMap()
        {
            AudioManager.Instance.EffectsSource.Stop();
            desertMain.SetActive(false);
            characteristics.SetActive(false);
            map.SetActive(true);
            typesOfAnimals.SetActive(false);
            homeButton.gameObject.SetActive(true);
        }

        public void ShowTypesOfAnimals()
        {
            AudioManager.Instance.EffectsSource.Stop();
            desertMain.SetActive(false);
            characteristics.SetActive(false);
            map.SetActive(false);
            typesOfAnimals.SetActive(true);
            homeButton.gameObject.SetActive(true);
        }

        public void PlayLetsLookAt()
        {
            AudioManager.Instance.Play(nowLetsLookAtClip);
            desertAnimator.SetTrigger("Play");
        }

        public void PlayDesert()
        {
            AudioManager.Instance.Play(desertClip);
        }

    }
}