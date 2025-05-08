using System;

[System.Serializable]
public class UserData
{
    public int points;

    public DateTime? currentTaskStartTime;
    public DateTime? currentTaskEndTime;

    public bool IsTaskActive => currentTaskEndTime.HasValue && DateTime.Now < currentTaskEndTime.Value;
}
