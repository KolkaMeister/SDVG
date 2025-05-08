using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class TimePickerUI : MonoBehaviour
{
    public TMP_Dropdown hourDropdown;
    public TMP_Dropdown minuteDropdown;

    public string SelectedTime => $"{hourDropdown.options[hourDropdown.value].text}:{minuteDropdown.options[minuteDropdown.value].text}";

    void Start()
    {
        PopulateHourDropdown();
        PopulateMinuteDropdown();

        // Установка текущего времени из настроек
        SetTimeFromSettings();

        // Подписка на изменения
        hourDropdown.onValueChanged.AddListener(_ => UpdateReminderTime());
        minuteDropdown.onValueChanged.AddListener(_ => UpdateReminderTime());
    }

    void PopulateHourDropdown()
    {
        List<string> hours = new List<string>();
        for (int i = 0; i < 24; i++)
        {
            hours.Add(i.ToString("D2")); // 00, 01, ...
        }
        hourDropdown.ClearOptions();
        hourDropdown.AddOptions(hours);
    }

    void PopulateMinuteDropdown()
    {
        List<string> minutes = new List<string>();
        for (int i = 0; i < 60; i += 5) // шаг 5 минут
        {
            minutes.Add(i.ToString("D2"));
        }
        minuteDropdown.ClearOptions();
        minuteDropdown.AddOptions(minutes);
    }

    public string GetTimeString()
    {
        return SelectedTime; // например "08:15"
    }

    public void SetTime(string time)
    {
        var parts = time.Split(':');
        if (parts.Length == 2 &&
            int.TryParse(parts[0], out int h) &&
            int.TryParse(parts[1], out int m))
        {
            hourDropdown.value = Mathf.Clamp(h, 0, 23);
            minuteDropdown.value = Mathf.Clamp(m / 5, 0, 11); // шаг 5 мин
        }
    }

    public void SetTimeFromSettings()
    {
        var time = SettingsManager.Instance.CurrentOptions.reminderTime;
        hourDropdown.value = time.Hours;
        minuteDropdown.value = time.Minutes / 5;
    }

    public void UpdateReminderTime()
    {
        int hour = hourDropdown.value;
        int minute = minuteDropdown.value * 5;
        SettingsManager.Instance.CurrentOptions.reminderTime = new TimeSpan(hour, minute, 0);
        Debug.Log(SettingsManager.Instance.CurrentOptions.reminderTime.Hours.ToString() + ":" + SettingsManager.Instance.CurrentOptions.reminderTime.Minutes.ToString());
        SettingsManager.Instance.SaveSettings();
    }
}
