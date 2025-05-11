using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class PetCharacteristic : MonoBehaviour
{
    private PetInfo petInfo;
    [SerializeField]
    private string Name;
    [SerializeField]
    private TMP_Text characteristicText;
    [SerializeField]
    private UnityEngine.UI.Button characteristicButton;
    [SerializeField]
    private float maxCharacteristic = 100f;
    [SerializeField]
    private float characteristic;
    [SerializeField]
    private float characteristicDown;
    [SerializeField]
    private float characteristicUp;
    [SerializeField]
    private float timeDelta;
    private float timeStart;
    void Start()
    {
        petInfo = GetComponent<PetInfo>();
        characteristic = GetCharacteristic();
        characteristicText.text = characteristic.ToString();
        characteristicButton.onClick.AddListener(ButtonCharacteristic);
        timeStart = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart + timeDelta <= Time.time)
        {
            timeStart = Time.time;
            if (characteristic != 0)
            {
                characteristic -= characteristicDown;
                if (characteristic < 0){ characteristic = 0; }
                UpdateCharacteristic();
                characteristicText.text = characteristic.ToString();
            }
        }
        
    }

    public float GetCharacteristic()
    {
        switch (Name)
        {
            case "play":
                return petInfo.play;
            case "eat":
                return petInfo.eat;
            case "wash":
                return petInfo.wash;
            case "drink":
                return petInfo.drink;
            default:
                return -3;
        }
    }

    public void UpdateCharacteristic()
    {
        switch (Name)
        {
            case "play":
                petInfo.play=characteristic;
                break;
            case "eat":
                petInfo.eat= characteristic;
                break;
            case "wash":
                petInfo.wash = characteristic;
                break;
            case "drink":
                petInfo.drink = characteristic;
                break;
            default:
                break;
        }
    }

    public void ButtonCharacteristic()
    {

        Debug.Log(characteristic);
        if (characteristic < maxCharacteristic)
        {
            characteristic += characteristicUp;
            if (characteristic > maxCharacteristic)
            {
                characteristic = maxCharacteristic;
            }
            UpdateCharacteristic();
            characteristicText.text = characteristic.ToString();
        }
    }

}
