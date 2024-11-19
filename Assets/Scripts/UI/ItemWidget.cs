using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemWidget<T> : MonoBehaviour
{
    protected T _data;


    public virtual void Set(T data)
    {
        _data = data;
    }
}
