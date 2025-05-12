using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskData 
{
    public readonly int _id;
    public string _name;
    public string _text;
    public string _date;
    public int _startTime;
    public int _endTime;
    //public int Id => _id;
    //public string Name => _name;
    //public string Text => _text;
    public TaskData(int id, string name, string text, string date, int startTime, int endTime)
    {
        _id = id;
        _name = name;
        _text = text;
        _date = date;
        _startTime = startTime;
        _endTime = endTime;
    }

}
