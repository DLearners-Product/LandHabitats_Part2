
using UnityEngine;
using UnityEngine.UI;

namespace DesertHabitat
{
    public class TypesOfAnimalsController : MonoBehaviour
    {
        //button
        [SerializeField] private Button backButton;
        [SerializeField] private Button detailedBackButton;

        //GO
        [SerializeField] private GameObject mainPage;
        [SerializeField] private GameObject detailedPage;
        [SerializeField] private GameObject plant;
        [SerializeField] private GameObject camel0;
        [SerializeField] private GameObject camel1;

        [SerializeField] private GameObject plantDetailed;
        [SerializeField] private GameObject camelDetailed;
        [SerializeField] private GameObject reptileDetailed;
        [SerializeField] private GameObject fennecFoxDetailed;
        [SerializeField] private GameObject scorpionDetailed;

        [SerializeField] private GameObject plantHead;

        [SerializeField] private GameObject animalHead;
        [SerializeField] private GameObject animalBody;

        public void OnClickPlantButton()
        {
            ShowDetailedPage(plantDetailed);
        }

        public void OnClickCamelButton()
        {
            ShowDetailedPage(camelDetailed);
            camel0.SetActive(true);
        }

        public void OnClickReptilesButton()
        {
            ShowDetailedPage(reptileDetailed);
        }
        public void OnClickFennecFoxButton()
        {
            ShowDetailedPage(fennecFoxDetailed);
        }
        public void OnClickScorpionButton()
        {
            ShowDetailedPage(scorpionDetailed);
        }

        public void ShowDetailedPage(GameObject screen)
        {
            mainPage.SetActive(false);
            detailedPage.SetActive(true);
            screen.SetActive(true);
            //backButton.gameObject.SetActive(true);
            detailedBackButton.gameObject.SetActive(true);
        }


        //returns from plant or animal head to types of animals main screen
        public void OnClickBackButton()
        {
            animalBody.SetActive(false);
            detailedPage.SetActive(false);
            camelDetailed.SetActive(false);
            reptileDetailed.SetActive(false);
            fennecFoxDetailed.SetActive(false);
            scorpionDetailed.SetActive(false);
            backButton.gameObject.SetActive(false);

            plantHead.SetActive(true);
            animalHead.SetActive(true);

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();

            mainPage.SetActive(true);
        }

        public void OnClickPlantHead()
        {
            ShowDetailedPage(plantDetailed);
        }

        public void OnClickAnimalHead()
        {
            animalHead.SetActive(false);
            plantHead.SetActive(false);
            plant.SetActive(false);
            mainPage.SetActive(true);
            animalBody.SetActive(true);
        }

        public void OnClickDetailedBackButton()
        {
            detailedPage.SetActive(false);
            plantDetailed.SetActive(false);
            camelDetailed.SetActive(false);
            reptileDetailed.SetActive(false);
            fennecFoxDetailed.SetActive(false);
            scorpionDetailed.SetActive(false);
            mainPage.SetActive(true);
            AudioManager.Instance.EffectsSource.Stop();
        }
    }
}