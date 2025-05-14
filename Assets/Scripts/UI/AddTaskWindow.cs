using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTaskWindow : ModalWindow
{
    [SerializeField] private TMP_InputField _taskName;
    [SerializeField] private TMP_InputField _taskDescription;
    [SerializeField] private TMP_InputField _startTime;
    [SerializeField] private TMP_InputField _endTime;
    public void Add()
    {
        var t = new TaskItemData(0, _taskName.text,
            _taskDescription.text,
            BingoWindow.chosenDate,
            int.Parse(_startTime.text),
            int.Parse(_endTime.text));
        TaskManager.Add(t);
        NotificationSender _notificationSender = FindObjectOfType<NotificationSender>();
        var a = BingoWindow.chosenDate.Split(".");
        DateTime dtStart = new DateTime(int.Parse(a[2]), int.Parse(a[1]), int.Parse(a[0]), t.startTime, 0, 0);
        DateTime dtEnd = new DateTime(int.Parse(a[2]), int.Parse(a[1]), int.Parse(a[0]), t.endTime, 0, 0);
        _notificationSender.ScheduleNotification("Задание началось: " + _taskName.text, _taskDescription.text, dtStart);
        _notificationSender.ScheduleNotification("Задание завершилось: " + _taskName.text, _taskDescription.text, dtEnd);
        Close();
    }
}
