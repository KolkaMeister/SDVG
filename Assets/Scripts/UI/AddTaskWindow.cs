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
        Close();
    }
}
