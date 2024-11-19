using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddTaskWindow : ModalWindow
{
    [SerializeField] private TMP_InputField _taskTitle;
    [SerializeField] private TMP_InputField _taskDescription;
    public void Add()
    {
        var t = new TaskItemData(0, _taskTitle.text, _taskDescription.text);
        PlayerData.TaskM.Add(t);
        Close();
    }
}
