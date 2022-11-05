using UnityEngine;
using UnityEngine.UI;

namespace GrasslandsHabitat
{
    public class GrasslandsHabitatController : MonoBehaviour
    {
        //
        [SerializeField] private GameObject grasslandsMain;
        [SerializeField] private GameObject characteristics;
        [SerializeField] private GameObject map;
        [SerializeField] private GameObject typesOfAnimals;

        //button
        [SerializeField] private Button homeButton;

        //animator
        [SerializeField] private Animator grasslandsAnimator;

        //Audio
        [SerializeField] private AudioClip nowLetsLookAtClip;
        [SerializeField] private AudioClip grasslandsClip;

        public void Start()
        {
            Invoke("PlayLetsLookAt", 1f);
            Invoke("PlayGrasslands", 3f);
        }

        public void ShowGrasslandsMain()
        {
            grasslandsMain.SetActive(true);
            characteristics.SetActive(false);
            map.SetActive(false);
            typesOfAnimals.SetActive(false);

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();

            homeButton.gameObject.SetActive(false);
        }

        public void ShowCharacteristics()
        {
            grasslandsMain.SetActive(false);
            characteristics.SetActive(true);
            map.SetActive(false);
            typesOfAnimals.SetActive(false);
            homeButton.gameObject.SetActive(true);

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();
        }

        public void ShowMap()
        {
            grasslandsMain.SetActive(false);
            characteristics.SetActive(false);
            map.SetActive(true);
            typesOfAnimals.SetActive(false);
            homeButton.gameObject.SetActive(true);

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();
        }

        public void ShowTypesOfAnimals()
        {
            grasslandsMain.SetActive(false);
            characteristics.SetActive(false);
            map.SetActive(false);
            typesOfAnimals.SetActive(true);
            homeButton.gameObject.SetActive(true);

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();
        }

        public void PlayLetsLookAt()
        {
            AudioManager.Instance.Play(nowLetsLookAtClip);
            grasslandsAnimator.SetTrigger("Play");
        }

        public void PlayGrasslands()
        {
            AudioManager.Instance.Play(grasslandsClip);
        }

    }
}