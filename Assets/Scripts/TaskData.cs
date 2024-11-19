using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskData 
{
    public readonly int _id;
    public string _name;
    public string _text;
    //public int Id => _id;
    //public string Name => _name;
    //public string Text => _text;
    public TaskData(int id, string name, string text)
    {
        _id = id;
        _name = name;
        _text = text;
    }

}
