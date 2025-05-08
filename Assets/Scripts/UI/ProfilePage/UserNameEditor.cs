using UnityEngine;
using TMPro;

public class UserNameEditor : MonoBehaviour
{
    public TextMeshProUGUI userNameText;
    public TMP_InputField userNameInput;
    public GameObject userNamePanel;
    private void Start()
    {
        userNameText.text = UserManager.Instance.CurrentUser.UserName;
    }
    public void OnChangeUserNameClicked()
    {
        userNameInput.text = UserManager.Instance.CurrentUser.UserName;
        userNamePanel.SetActive(true);
        userNameInput.ActivateInputField();
    }

    public void OnUserNameConfirmed()
    {
        string newName = userNameInput.text.Trim();

        // Проверка длины имени
        if (newName.Length < 4 || newName.Length > 17)
        {
            Debug.LogWarning("Имя пользователя должно содержать от 4 до 17 символов.");
            return;
        }

        userNameText.text = newName;

        // Сохраняем
        UserManager.Instance.CurrentUser.UserName = newName;
        UserManager.Instance.SaveUserData();

        userNamePanel.SetActive(false);
    }
}