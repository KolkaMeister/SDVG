using System;

[System.Serializable]
public class UserOptions
{
    public string userName;
    public TimeSpan reminderTime;
    public TimeSpan taskEndTime;
    public bool taskStartEnabled;
    public int rewardPoints;
    public int bonusPoints;
}