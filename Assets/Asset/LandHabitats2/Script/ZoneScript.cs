using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private GameObject tropicZoomed;
    [SerializeField] private GameObject polarZoomed;
    [SerializeField] private GameObject temperateZoomed;

   public void TropicClick ()
    {
        blackPanel.SetActive(true);
        tropicZoomed.SetActive(true);
    }

    public void TemperateClick()
    {
        blackPanel.SetActive(true);
        temperateZoomed.SetActive(true);

    }

    public void PolarClick()
    {
        blackPanel.SetActive(true);
        polarZoomed.SetActive(true);
    }

    public void PanelClick()
    {
        
        tropicZoomed.SetActive(false);
        temperateZoomed.SetActive(false);
        polarZoomed.SetActive(false);
        blackPanel.SetActive(false);
    }
}
