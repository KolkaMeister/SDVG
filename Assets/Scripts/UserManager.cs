using UnityEngine;
using System;
using System.IO;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance { get; private set; }

    public UserData CurrentUser { get; private set; }

    private NotificationSender _notificationSender;

    private string savePath => Path.Combine(Application.persistentDataPath, "user_data.json");
    // Данные если хочешь используй
    // SettingsManager.Instance.CurrentOptions
    // TimeSpan reminderTime
    // int rewardPoints
    // int bonusPoints
    // _notificationSender.ScheduleNotification(string title, string message, DateTime notifyTime)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _notificationSender = FindObjectOfType<NotificationSender>();
            if (_notificationSender == null)
            {
                Debug.LogError("NotificationSender не найден в сцене. Уведомления не будут работать.");
            }

            LoadUserData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {

    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(CurrentUser, true);
        File.WriteAllText(savePath, json);
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            CurrentUser = JsonUtility.FromJson<UserData>(json);
        }
        else
        {
            CurrentUser = new UserData()
            {
                UserName = "Пользователь",
                points = 0 
            };
            SaveUserData();
            Debug.Log("Создан новый файл user_data.json с начальными значениями.");
        }
    }

}
