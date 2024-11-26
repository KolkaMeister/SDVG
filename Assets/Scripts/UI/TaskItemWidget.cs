using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskItemWidget : ItemWidget<TaskItemData>
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TaskDescriptionWindow _descriptionWindow;
    public override void Set(TaskItemData data)
    {
        base.Set(data);
        _title.text = _data.name;
    }

    public void OpenTaskEditWindow()
    {
        var i =Instantiate<TaskDescriptionWindow>(_descriptionWindow, transform.parent.parent.parent);
        i.SetData(_data);
    }
}
