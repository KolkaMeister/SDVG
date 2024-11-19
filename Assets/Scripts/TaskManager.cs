using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager
{
    private List<TaskData> _tasks;

    public Action TasksChanged;
    public TaskManager(TaskData[] tasks)
    {
        _tasks = new List<TaskData>(tasks);
    }
    
    public TaskData[] GetTasks() { return _tasks.ToArray(); }

    public void EditTask(int id,TaskItemData d)
    {
       var task = _tasks.Find(t => t._id == id);
       task._name = d.name;
        task._text = d.description;
       TasksChanged?.Invoke();
    }

    public void Add(TaskItemData d)
    {
        Debug.Log("created");
        _tasks.Add(new TaskData(0,d.name,d.description));
        TasksChanged?.Invoke();
    }

}
