using UnityEngine;
using UnityEngine.UI;

public class NavigationTundra : MonoBehaviour
{
    [SerializeField] private GameObject tundraHabitat;
    [SerializeField] private GameObject distributions;
    [SerializeField] private GameObject charactersitics;
    [SerializeField] private GameObject animalType;
    [SerializeField] private Button homeButton;



    private void Start()
    {
        tundraHabitat.SetActive(true);
        homeButton.gameObject.SetActive(false);
    }
    public void DisplayHabitat()
    {
        tundraHabitat.SetActive(true);
        distributions.SetActive(false);
        charactersitics.SetActive(false);
        animalType.SetActive(false);
        homeButton.gameObject.SetActive(false);

    }
    public void DisplayDist()
    {
        tundraHabitat.SetActive(false);
        distributions.SetActive(true);
        charactersitics.SetActive(false);
        animalType.SetActive(false);
        homeButton.gameObject.SetActive(true);
    }

    public void DisplayCharacteristics()
    {
        tundraHabitat.SetActive(false);
        distributions.SetActive(false);
        charactersitics.SetActive(true);
        animalType.SetActive(false);
        homeButton.gameObject.SetActive(true);

    }
    public void DisplayAnimalType()
    {
        tundraHabitat.SetActive(false);
        distributions.SetActive(false);
        charactersitics.SetActive(false);
        animalType.SetActive(true);
        homeButton.gameObject.SetActive(true);



    }

}
