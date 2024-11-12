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

    public void EditTask(int id)
    {
       var task = _tasks.Find(t => t.Id == id);
        
    }

}
