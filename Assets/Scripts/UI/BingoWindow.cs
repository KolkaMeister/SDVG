using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BingoWindow : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private TaskItemWidget _widgetPrefab;
    [SerializeField] private AddTaskWindow _addTaskWindowPrefab;
    private DataGroup<TaskItemWidget, TaskData> _dataGroup ;

    public static string chosenDate;
    private void Awake()
    {
        _dataGroup = new DataGroup<TaskItemWidget, TaskData>(_container, _widgetPrefab);
        chosenDate = DateTime.Now.ToString("dd.MM.yyyy");
        TaskManager.TasksChanged += UpdateBingo;
        UpdateBingo();
    }
    public void UpdateBingo()
    {
        var v = TaskManager.GetTasks();
        var sorted = v.Where(task => task._date.Equals(chosenDate));
       // foreach (var task in v) { l.Add(new TaskItemData(task._id, task._name, task._text)); }
        _dataGroup.SetData(sorted.ToArray());
        
    }
    public void OpenAddBingoWindow()
    {
        Instantiate<AddTaskWindow>(_addTaskWindowPrefab,transform.parent);
    }
}
