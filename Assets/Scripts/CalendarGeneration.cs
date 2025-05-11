using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine.Windows;

public class CalendarGeneration : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private TMP_Text textMeshPro;
    private List<int> calendarDays;
    private List<UnityEngine.UI.Button> buttons;
    private DateTime dateTime;
    void Start()
    {
        dateTime = DateTime.Today;
        GenerateData();
        buttons = new List<UnityEngine.UI.Button>(canvas.GetComponentsInChildren<UnityEngine.UI.Button>());
        GenerateButtons();
    }
    void Update()
    {
        
    }

    void GenerateButtons()
    {
        for (int i = 0; i < buttons.Count(); i++)
        {
            UnityEngine.UI.Button button = buttons[i];
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            if (i < calendarDays.Count())
            {
                buttonText.text = calendarDays[i].ToString();
                button.gameObject.SetActive(true);
                button.onClick.AddListener(() => OnClick(button));
                if (i < 7 && calendarDays[i] > 20 || i > 20 && calendarDays[i] < 7)
                {
                    Color transparentColor = buttonText.color;
                    transparentColor.a = 0.5f;
                    buttonText.color = transparentColor;
                }
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    void OnClick(UnityEngine.UI.Button buttonObject)
    {
        string day = buttonObject.GetComponentInChildren<TMP_Text>().text;
        dateTime.Day = day;

    }


    void GenerateData()
    {
        string date = dateTime.ToString("MMMM") + " " + dateTime.Year.ToString() + " ã.";
        textMeshPro.text = char.ToUpper(date[0]) + date.Substring(1);
        DateTime firstDayOfMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
        int daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
        DateTime firstDayOfPreviousMonth = firstDayOfMonth.AddMonths(-1);
        int daysInPreviousMonth = DateTime.DaysInMonth(firstDayOfPreviousMonth.Year, firstDayOfPreviousMonth.Month);
        int dayOfWeekIndex = ((int)firstDayOfMonth.DayOfWeek - 1 + 7) % 7;
        calendarDays = new List<int>();
        for (int i = daysInPreviousMonth - dayOfWeekIndex + 1; i <= daysInPreviousMonth; i++)
        {
            calendarDays.Add(i);
        }
        for (int i = 1; i <= daysInMonth; i++)
        {
            calendarDays.Add(i);
        }

        int remainingDays = 7 - (calendarDays.Count % 7);
        if (remainingDays < 7)
        {
            for (int i = 1; i <= remainingDays; i++)
            {
                calendarDays.Add(i);
            }
        }
    }
}
