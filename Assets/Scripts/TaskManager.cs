using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskManager
{
    private static List<TaskData> _tasks;

    public static Action TasksChanged;
    static TaskManager()
    {
        _tasks = DbConnector.LoadTasks();
    }
    
    public static TaskData[] GetTasks() { return _tasks.ToArray(); }

    //public static void EditTask(int id,TaskItemData d)
    //{
    //   var task = _tasks.Find(t => t._id == id);
    //   task._name = d.name;
    //    task._text = d.description;
    //   TasksChanged?.Invoke();
    //}

    //public static void DeleteTask(int id)
    //{
    //   var task = _tasks.Find(t => t._id == id);
    //    _tasks.Remove(task);
    //    TasksChanged?.Invoke();
    //}
    public static void Add(TaskItemData d)
    {
        Debug.Log("created");
        Debug.Log(_tasks);
        _tasks.Add(new TaskData(0,d.name,d.description,d.date,d.startTime,d.endTime));
        DbConnector.SaveTasks(_tasks);
        TasksChanged?.Invoke();
    }

}
