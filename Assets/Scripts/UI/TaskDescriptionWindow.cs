using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskDescriptionWindow : ModalWindow
{
    [SerializeField] private Button _editBut;
    [SerializeField] private Button _cancelBut;
    [SerializeField] private Button _confirmBut;
    [SerializeField] private Button _closeBut;
    [SerializeField] private Button _deleteBut;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private TMP_InputField _inputDecription;
    private TaskItemData _data;


    public void SetData(TaskItemData data)
    {
        _data = data;
        _inputName.text= _data.name;
        _inputDecription.text = _data.description;
        _inputName.interactable = false;
        _inputDecription.interactable = false;
    }
    public void UpdateDecsView()
    {

    }
    public void Edit()
    {
        _inputName.interactable = true;
        _inputDecription.interactable = true;
        _editBut.gameObject.SetActive(false);
        _closeBut.gameObject.SetActive(false);
        _deleteBut.gameObject.SetActive(false);
        _confirmBut.gameObject.SetActive(true);
        _cancelBut.gameObject.SetActive(true);
    }
    public void ConfirmEdit()
    {
        PlayerData.TaskM.EditTask(_data.id,new TaskItemData(_data.id,_inputName.text,_inputDecription.text));
        Close();
    }
    public void Delete()
    {
        PlayerData.TaskM.DeleteTask(_data.id);
        Close();
    }
    public void CancelEdit()
    {
        _inputName.text = _data.name;
        _inputDecription.text = _data.description;
        _inputName.interactable = false;
        _inputDecription.interactable = false;
        _editBut.gameObject.SetActive(true);
        _closeBut.gameObject.SetActive(true);
        _deleteBut.gameObject.SetActive(true);
        _confirmBut.gameObject.SetActive(false);
        _cancelBut.gameObject.SetActive(false);
    }
}
