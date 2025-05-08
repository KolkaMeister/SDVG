using UnityEngine;
using TMPro;

public class UserNameEditor : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TMP_InputField userNameInput;
    public GameObject userNamePanel;

    public void OnChangeUserNameClicked()
    {
        userNameInput.text = SettingsManager.Instance.CurrentOptions.userName;
        userNamePanel.SetActive(true);
        userNameInput.ActivateInputField();
    }

    public void OnUserNameConfirmed()
    {
        string newName = userNameInput.text;
        userNameText.text = newName;

        // Сохраняем
        SettingsManager.Instance.CurrentOptions.userName = newName;
        SettingsManager.Instance.SaveSettings();

        userNamePanel.SetActive(false);
    }
}