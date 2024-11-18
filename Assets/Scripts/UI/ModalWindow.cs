using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalWindow : MonoBehaviour
{
    


    public virtual void Close()
    {
        Destroy(gameObject);
    }
}
