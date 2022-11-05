using UnityEngine;
using UnityEngine.UI;

namespace GrasslandsHabitat
{
    public class TypesOfAnimalsController : MonoBehaviour
    {
        //button
        [SerializeField] private Button backButton;

        //
        [SerializeField] private GameObject mainPage;
        [SerializeField] private GameObject detailedPage;

        [SerializeField] private GameObject lionCheetahDetailed;
        [SerializeField] private GameObject bisonWildHorseDetailed;
        [SerializeField] private GameObject lionHyenaCrocDetailed;
        [SerializeField] private GameObject kangarooOstrichDetailed;
        [SerializeField] private GameObject elephantRhinoDetailed;

        public void OnClickLionCheetahButton()
        {
            ShowDetailedPage(lionCheetahDetailed);
        }

        public void OnClickBisonWildHorseButton()
        {
            ShowDetailedPage(bisonWildHorseDetailed);
        }
        public void OnClickLionHyenaCrocButton()
        {
            ShowDetailedPage(lionHyenaCrocDetailed);
        }

        public void OnClickKangarooOstrich()
        {
            ShowDetailedPage(kangarooOstrichDetailed);
        }


        public void OnClickElephantRhinoButton()
        {
            ShowDetailedPage(elephantRhinoDetailed);
        }

        public void ShowDetailedPage(GameObject screen)
        {
            mainPage.SetActive(false);
            detailedPage.SetActive(true);
            screen.SetActive(true);
            backButton.gameObject.SetActive(true);
        }

        public void OnClickBackButton()
        {
            detailedPage.SetActive(false);
            lionCheetahDetailed.SetActive(false);
            bisonWildHorseDetailed.SetActive(false);
            lionHyenaCrocDetailed.SetActive(false);
            kangarooOstrichDetailed.SetActive(false);
            elephantRhinoDetailed.SetActive(false);
            backButton.gameObject.SetActive(false);

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();

            mainPage.SetActive(true);
        }
    }
}