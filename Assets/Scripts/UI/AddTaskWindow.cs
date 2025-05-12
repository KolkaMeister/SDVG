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
        Close();
    }
}
