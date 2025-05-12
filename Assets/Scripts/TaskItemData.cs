using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public struct TaskItemData
{
    private static int counter;
    public  int id;
    public  string name;
    public string description;
    public string date;
    public int startTime;
    public int endTime;

    
    public TaskItemData(int id, string name, string description, string date, int startTime, int endTime)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.date = date;
        this.startTime = startTime;
        this.endTime = endTime;
    }
}
