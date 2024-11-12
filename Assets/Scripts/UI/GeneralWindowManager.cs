using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralWindowManager : MonoBehaviour
{
    [SerializeField] private GameObject _pan1;
    [SerializeField] private GameObject _pan2;
    [SerializeField] private GameObject _pan3;
    [SerializeField] private Button _but1;
    [SerializeField] private Button _but2;
    [SerializeField] private Button _but3;



    private void Start()
    {
        _pan1.SetActive(true);
        Link();
    }
    private void Link()
    {
        _but1.onClick.AddListener(() => {
            DisableAll();
            _pan1.SetActive(true) ;
        }
        );
        _but2.onClick.AddListener(() => {
            DisableAll();
            _pan2.SetActive(true);
        }
        );
        _but3.onClick.AddListener(() => {
            DisableAll();
            _pan3.SetActive(true);
        }
        );
    }
    private void DisableAll()
    {
        _pan1.SetActive(false);
        _pan2.SetActive(false);
        _pan3.SetActive(false);
    }
}
