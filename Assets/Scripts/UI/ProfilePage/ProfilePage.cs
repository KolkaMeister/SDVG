using System;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class ProfilePage : MonoBehaviour
{
    [SerializeField] private FAQPage _openFAQPage;

    [Header("Очки")]
    [SerializeField] private TMP_InputField rewardPointsInput;
    [SerializeField] private TMP_InputField bonusPointsInput;

    private void Start()
    {
        LoadPoints();

        rewardPointsInput.onEndEdit.AddListener(OnRewardPointsChanged);
        bonusPointsInput.onEndEdit.AddListener(OnBonusPointsChanged);
    }

    private void LoadPoints()
    {
        var options = SettingsManager.Instance.CurrentOptions;
        Debug.Log(JsonConvert.SerializeObject(options));
        rewardPointsInput.text = options.rewardPoints.ToString();
        bonusPointsInput.text = options.bonusPoints.ToString();
    }

    private void OnRewardPointsChanged(string value)
    {
        if (int.TryParse(value, out int points))
        {
            if (points > 0 && points <= 100)
            {
                SettingsManager.Instance.CurrentOptions.rewardPoints = points;
                SettingsManager.Instance.SaveSettings();
            }
            else
            {
                Debug.LogWarning("Очки награды должны быть от 1 до 100");
                rewardPointsInput.text = SettingsManager.Instance.CurrentOptions.rewardPoints.ToString();
            }
        }
    }

    private void OnBonusPointsChanged(string value)
    {
        if (int.TryParse(value, out int bonus))
        {
            if (bonus > 0 && bonus <= 20)
            {
                SettingsManager.Instance.CurrentOptions.bonusPoints = bonus;
                SettingsManager.Instance.SaveSettings();
            }
            else
            {
                Debug.LogWarning("Бонусные очки должны быть от 1 до 20");
                bonusPointsInput.text = SettingsManager.Instance.CurrentOptions.bonusPoints.ToString();
            }
        }
    }

    public void OpenFAQPage()
    {
        if (_openFAQPage == null)
        {
            Debug.LogError("FAQPage не назначен в инспекторе!");
            return;
        }

        var newFAQPage = Instantiate(_openFAQPage, transform.parent);
        newFAQPage.gameObject.SetActive(true);
    }
}
