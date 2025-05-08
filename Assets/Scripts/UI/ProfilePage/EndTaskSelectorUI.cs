using TMPro;
using UnityEngine;
using System;
using System.Collections.Generic;

public class EndTaskSelectorUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown endTaskDropdown;

    private readonly List<TimeSpan> predefinedTimes = new List<TimeSpan>
    {
        TimeSpan.FromMinutes(30),
        TimeSpan.FromHours(1),
        TimeSpan.FromHours(2),
        TimeSpan.FromHours(5)
    };

    private void Start()
    {
        if (endTaskDropdown == null)
        {
            Debug.LogWarning("Dropdown не назначен!");
            return;
        }

        endTaskDropdown.ClearOptions();
        endTaskDropdown.AddOptions(new List<string>
        {
            "За 30 минут",
            "За 1 час",
            "За 2 часа",
            "За 5 часов"
        });

        // Установить значение из настроек
        SetDropdownFromSettings();

        // Обработка изменения выбора
        endTaskDropdown.onValueChanged.AddListener(_ => UpdateEndTaskTime());
    }

    public TimeSpan GetSelectedTimeSpan()
    {
        int index = endTaskDropdown.value;
        if (index >= 0 && index < predefinedTimes.Count)
            return predefinedTimes[index];

        return TimeSpan.FromHours(1); // fallback
    }

    public int GetSelectedIndex()
    {
        return endTaskDropdown.value;
    }

    private void SetDropdownFromSettings()
    {
        TimeSpan saved = SettingsManager.Instance.CurrentOptions.taskEndTime;
        int index = predefinedTimes.FindIndex(t => t == saved);
        if (index < 0) index = 1; // По умолчанию "За 1 час"
        endTaskDropdown.value = index;
    }

    private void UpdateEndTaskTime()
    {
        TimeSpan selected = GetSelectedTimeSpan();
        SettingsManager.Instance.CurrentOptions.taskEndTime = selected;
        SettingsManager.Instance.SaveSettings();
    }
}
