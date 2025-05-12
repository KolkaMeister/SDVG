using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DbConnector
{
    private static string FilePath => Path.Combine(Application.persistentDataPath, "tasks.json");

    public static void SaveTasks(List<TaskData> tasks)
    {
        TaskDataList wrapper = new TaskDataList { tasks = tasks };
        Debug.Log("Tasks In Wrapper:" + wrapper.tasks);
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(FilePath, json);
        Debug.Log("json after save:" + json);
        Debug.Log("Tasks saved to: " + FilePath);
    }

    public static List<TaskData> LoadTasks()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            Debug.Log(json);
            TaskDataList wrapper = JsonUtility.FromJson<TaskDataList>(json);
            Debug.Log(wrapper);
            if (wrapper.tasks != null)
            {
                return wrapper.tasks;
            }else
            {
                return new List<TaskData> { };
            }
        }
        else
        {
            Debug.LogWarning("No tasks file found at: " + FilePath);
            return new List<TaskData>();
        }
    }
}
[System.Serializable]
public class TaskDataList
{
    public List<TaskData> tasks;
}