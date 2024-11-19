using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfileWindow : MonoBehaviour
{
    [SerializeField]
    private GameObject UserProfileInfoModalWindow;

    public void OpenUserProfileInfoModalWindow()
    {
        Instantiate(UserProfileInfoModalWindow, transform.parent);
    }
}
