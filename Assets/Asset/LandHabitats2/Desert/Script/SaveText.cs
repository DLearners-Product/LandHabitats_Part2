using UnityEngine;
using TMPro;

public class SaveText : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI inputText;
    [SerializeField] private string key;

    private void Start()
    {

        RestoreData();
    }


    public void OnEnable()
    {
        RestoreData();
    }

    public void OnDisable()
    {
        SaveData();
    }

    public void OnDestroy()
    {
        SaveData();
    }

    public void SaveData()
    {
        if (inputText.text.Length > 0)
        {
            PlayerPrefs.SetString(key, inputText.text);
        }
    }

    public void RestoreData()
    {
        inputField.text = PlayerPrefs.GetString(key);
    }
}