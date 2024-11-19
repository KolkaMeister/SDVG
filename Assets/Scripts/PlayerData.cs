using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public static class PlayerData 
{
    public static TaskManager TaskM;
    static PlayerData()
    {
        TaskM = new TaskManager(new TaskData[0]);
    }
}
