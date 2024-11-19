using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGroup<T,D> where T : ItemWidget<D>
{
    private Transform _container;

    private T _itemWidget;

    private D[] _data;
    private List<ItemWidget<D>> _itemWidgets;

    public DataGroup(Transform container, T itemWidget)
    {
        _container = container;
        _itemWidget = itemWidget;
        _itemWidgets = new List<ItemWidget<D>>();
    }

    public void SetData(D[] data)
    {
        _data = data;
        Debug.Log(_itemWidgets);
        Debug.Log(_container);
        Debug.Log(_itemWidget);
        for (var i = _itemWidgets.Count; i < _data.Length; i++) 
        {
            _itemWidgets.Add(Transform.Instantiate<T>(_itemWidget, _container)); 
        } 
        for (var i = 0; i < _data.Length; i++) 
        {
            _itemWidgets[i].gameObject.SetActive(true);
            _itemWidgets[i].Set(data[i]);
        }
        for (var i = _data.Length; i < _itemWidgets.Count; i++) { _itemWidgets[i].gameObject.SetActive(false);}
    }
}
