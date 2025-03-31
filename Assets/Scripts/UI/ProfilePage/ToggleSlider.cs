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
        _toggle.onValueChanged.AddListener(UpdateSprite);
        UpdateSprite(_toggle.isOn); // Устанавливаем начальный спрайт
    }

    private void UpdateSprite(bool isOn)
    {
        _handleImage.sprite = isOn ? _onSprite : _offSprite;
    }
}
