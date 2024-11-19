using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TaskItemData
{
    public readonly int id;
    public readonly string name;
    public readonly string description;
    
    public TaskItemData(int id, string name, string description)
    {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}
