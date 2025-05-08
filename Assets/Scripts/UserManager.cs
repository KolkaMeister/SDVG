using UnityEngine;
using System;
using System.IO;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance { get; private set; }

    public UserData CurrentUser { get; private set; }

    private NotificationSender _notificationSender;

    private string savePath => Path.Combine(Application.persistentDataPath, "user_data.json");

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
        EndTaskIfExpired();
    }

    public void StartTask()
    {
        if (SettingsManager.Instance == null || SettingsManager.Instance.CurrentOptions == null)
        {
            Debug.LogWarning("SettingsManager или CurrentOptions недоступны. Задача не может быть запущена.");
            return;
        }

        TimeSpan duration = SettingsManager.Instance.CurrentOptions.taskEndTime;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.Add(duration);

        CurrentUser.currentTaskStartTime = startTime;
        CurrentUser.currentTaskEndTime = endTime;

        SaveUserData();

        Debug.Log($"Задача началась: {startTime:HH:mm} — {endTime:HH:mm}");

        // Запланировать уведомление
        if (_notificationSender != null)
        {
            _notificationSender.ScheduleNotification("Задача завершена", "Время задачи вышло", endTime);
        }
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
            CurrentUser = new UserData();
            SaveUserData();
            Debug.Log("Создан новый файл user_data.json с начальными значениями.");
        }
    }

    public void EndTaskIfExpired()
    {
        if (CurrentUser.currentTaskEndTime.HasValue && DateTime.Now >= CurrentUser.currentTaskEndTime.Value)
        {
            Debug.Log("Задача завершена — срок истёк");

            CurrentUser.currentTaskStartTime = null;
            CurrentUser.currentTaskEndTime = null;

            SaveUserData();
        }
    }
    public void EndTask()
    {
        if (!CurrentUser.IsTaskActive)
            return;

        //Debug.Log($"Задача завершена досрочно. Пользователь: {CurrentUser.userName}");

        // Можно здесь добавить логику штрафов или потери очков, если нужно

        // Также можно сбросить таймер или очистить текущие данные
    }

}
