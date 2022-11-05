using UnityEngine;
using UnityEngine.UI;

public class NavigationPolar : MonoBehaviour
{
    [SerializeField] private GameObject polarHabitat;
    [SerializeField] private GameObject lattitude;
    [SerializeField] private GameObject charactersitics;
    [SerializeField] private GameObject animalType;
    [SerializeField] private Button homeButton;
    


    private void Start()
    {
        polarHabitat.SetActive(true);
        homeButton.gameObject.SetActive(false);
    }
    public void DisplayHabitat()
    {
        polarHabitat.SetActive(true);
        lattitude.SetActive(false);
        charactersitics.SetActive(false);
        animalType.SetActive(false);
        homeButton.gameObject.SetActive(false);
        
    }
    public void DisplayLattitude()
    {
        polarHabitat.SetActive(false);
        lattitude.SetActive(true);
        charactersitics.SetActive(false);
        animalType.SetActive(false);
        homeButton.gameObject.SetActive(true);
    }

    public void DisplayCharacteristics()
    {
        polarHabitat.SetActive(false);
        lattitude.SetActive(false);
        charactersitics.SetActive(true);
        animalType.SetActive(false);
        homeButton.gameObject.SetActive(true);
        
    }
    public void DisplayAnimalType()
    {
        polarHabitat.SetActive(false);
        lattitude.SetActive(false);
        charactersitics.SetActive(false);
        animalType.SetActive(true);
        homeButton.gameObject.SetActive(true);
        
        

    }
    
}
