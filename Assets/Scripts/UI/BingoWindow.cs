using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoWindow : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private TaskItemWidget _widgetPrefab;
    [SerializeField] private AddTaskWindow _addTaskWindowPrefab;
    private DataGroup<TaskItemWidget,TaskItemData> _dataGroup ;

    private void Start()
    {
        _dataGroup = new DataGroup<TaskItemWidget, TaskItemData>(_container, _widgetPrefab);
        PlayerData.TaskM.TasksChanged += UpdateBingo;
    }
    private void UpdateBingo()
    {
        var v = PlayerData.TaskM.GetTasks();
        var l = new List<TaskItemData>();
        foreach (var task in v) { l.Add(new TaskItemData(task._id, task._name, task._text)); }
        _dataGroup.SetData(l.ToArray());
    }
    public void OpenAddBingoWindow()
    {
        Instantiate<AddTaskWindow>(_addTaskWindowPrefab,transform.parent);
    }
}
