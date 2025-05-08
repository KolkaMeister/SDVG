using Unity.Notifications.Android;
using UnityEngine;

public class NotificationSender : MonoBehaviour
{
    private void Start()
    {
        // Регистрируем канал, если его нет
        var channel = new AndroidNotificationChannel()
        {
            Id = "default",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Основной канал для уведомлений",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void ScheduleNotification(string title, string message, System.DateTime notifyTime)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = message;
        notification.FireTime = notifyTime;

        AndroidNotificationCenter.SendNotification(notification, "default");
    }
}
