using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskItemWidget : ItemWidget<TaskData>
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _taskTime;
    [SerializeField] private TaskDescriptionWindow _descriptionWindow;
    public override void Set(TaskData data)
    {
        base.Set(data);
        _title.text = _data._name;
        _taskTime.text = data._startTime.ToString() + ":00 - " + data._endTime.ToString() + ":00";
    }

    public void OpenTaskEditWindow()
    {
        var i =Instantiate<TaskDescriptionWindow>(_descriptionWindow, transform.parent.parent.parent);
       // i.SetData(_data);
    }
}
