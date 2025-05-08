using System;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class NotificationSender : MonoBehaviour
{

    private void Start()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "default",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Основной канал для уведомлений",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void ScheduleNotification(string title, string message, DateTime notifyTime)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = message,
            FireTime = notifyTime
        };

        AndroidNotificationCenter.SendNotification(notification, "default");
    }
}
