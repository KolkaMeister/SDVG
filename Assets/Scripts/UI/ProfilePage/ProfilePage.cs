using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePage : MonoBehaviour
{
    [SerializeField] private FAQPage _openFAQPage;
    public void OpenFAQPage()
    {
        if (_openFAQPage == null)
        {
            Debug.LogError("FAQPage не назначен в инспекторе!");
            return;
        }
        var newFAQPage = Instantiate(_openFAQPage, transform.parent);
        newFAQPage.gameObject.SetActive(true);
    }

}
