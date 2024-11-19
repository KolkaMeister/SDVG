using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemWidget<T> : MonoBehaviour
{
    private T _data;


    public void Set(T data)
    {
        _data = data;
    }
}
