
using UnityEngine;
using UnityEngine.UI;

namespace DesertHabitat
{
    public class TypesOfAnimalsController : MonoBehaviour
    {
        //button
        [SerializeField] private Button backButton;

        //
        [SerializeField] private GameObject mainPage;
        [SerializeField] private GameObject detailedPage;
        [SerializeField] private GameObject camelHome;
        [SerializeField] private GameObject reptileHome;
        [SerializeField] private GameObject fennecFoxHome;
        [SerializeField] private GameObject scorpionHome;

        [SerializeField] private GameObject camel0;
        [SerializeField] private GameObject camel1;

        [SerializeField] private GameObject camelDetailed;
        [SerializeField] private GameObject reptileDetailed;
        [SerializeField] private GameObject fennecFoxDetailed;
        [SerializeField] private GameObject scorpionDetailed;

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
            backButton.gameObject.SetActive(true);
        }

        public void OnClickBackButton()
        {
            detailedPage.SetActive(false);
            camelDetailed.SetActive(false);
            reptileDetailed.SetActive(false);
            fennecFoxDetailed.SetActive(false);
            scorpionDetailed.SetActive(false);
            backButton.gameObject.SetActive(false);

            //if any audio is playing, stop it
            AudioManager.Instance.EffectsSource.Stop();

            mainPage.SetActive(true);
        }
    }
}