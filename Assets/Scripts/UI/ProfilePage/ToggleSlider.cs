using UnityEngine;
using UnityEngine.UI;

public class ToggleSlider : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _handleImage;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private void Start()
    {
        // Установка значения из сохранённых настроек
        if (SettingsManager.Instance != null)
        {
            _toggle.isOn = SettingsManager.Instance.CurrentOptions.taskStartEnabled;
        }

        _toggle.onValueChanged.AddListener(OnToggleChanged);
        UpdateSprite(_toggle.isOn);
    }

    private void OnToggleChanged(bool isOn)
    {
        UpdateSprite(isOn);

        // Обновляем настройку
        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.CurrentOptions.taskStartEnabled = isOn;
            SettingsManager.Instance.SaveSettings();
        }

        // Запускаем/останавливаем задачу
        if (UserManager.Instance != null)
        {
            if (isOn)
                UserManager.Instance.StartTask();
            else
                UserManager.Instance.EndTask();
        }
    }

    private void UpdateSprite(bool isOn)
    {
        _handleImage.sprite = isOn ? _onSprite : _offSprite;
    }
}
