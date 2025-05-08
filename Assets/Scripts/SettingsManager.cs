using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    public UserOptions CurrentOptions { get; private set; }

    private string savePath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // сохраняем при смене сцен

        savePath = Path.Combine(Application.persistentDataPath, "user_settings.json");
        LoadSettings();
    }

    public void LoadSettings()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
                CurrentOptions = JsonConvert.DeserializeObject<UserOptions>(json);
            }
            catch (Exception ex)
            {
                Debug.LogWarning("Ошибка чтения JSON, создаются настройки по умолчанию. " + ex.Message);
                CreateDefaultSettings();
            }
        }
        else
        {
            CreateDefaultSettings();
        }
    }

    private void CreateDefaultSettings()
    {
        CurrentOptions = new UserOptions()
        {
            reminderTime = TimeSpan.FromHours(9),
            rewardPoints = 50,
            bonusPoints = 10
        };

        SaveSettings();
        Debug.Log("Создан файл настроек по умолчанию.");
    }

    public void SaveSettings()
    {
        try
        {
            string json = JsonConvert.SerializeObject(CurrentOptions);
            File.WriteAllText(savePath, json);
            Debug.Log($"Настройки сохранены в: {savePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError("Не удалось сохранить настройки: " + ex.Message);
        }
    }
}
