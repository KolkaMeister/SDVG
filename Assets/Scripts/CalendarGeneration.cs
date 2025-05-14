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
using UnityEditor.PackageManager;

public class CalendarGeneration : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private UnityEngine.UI.Button buttonDate;
    [SerializeField]
    private UnityEngine.UI.Image imageBackground;
    [SerializeField]
    private UnityEngine.UI.Button leftButton;
    [SerializeField]
    private UnityEngine.UI.Button rightButton;
    [SerializeField]
    private UnityEngine.UI.Image nowImage;
    private List<int> calendarDays;
    private List<UnityEngine.UI.Button> buttons;
    private DateTime dateTime;
    private bool hideButton;
    private BingoWindow bingoWindow;
    void Start()
    {
        bingoWindow = GetComponent<BingoWindow>();
        dateTime = DateTime.Today;
        hideButton = true;
        GenerateData();
        HideCalendar();
        buttonDate.onClick.AddListener(() => HideCalendar());
        leftButton.onClick.AddListener(() => LeftClick());
        rightButton.onClick.AddListener(() => RightClick());
        buttons = new List<UnityEngine.UI.Button>(canvas.GetComponentsInChildren<UnityEngine.UI.Button>());
        GenerateButtons();
    }
    void Update()
    {
        
    }

    void HideCalendar()
    {
        Debug.Log(1);
        if (hideButton)
        {
            hideButton = false;
            canvas.gameObject.SetActive(hideButton);
        }
        else
        {
            hideButton = true;
            canvas.gameObject.SetActive(hideButton);
        }
    }

    void GenerateButtons()
    {
        RectTransform rectTransform = imageBackground.GetComponent<RectTransform>();
        float newHeight = rectTransform.rect.height;
        float y = 0;
        if ((calendarDays.Count() + 1) / 7 == 6 && newHeight != 960)
        {
            newHeight = 960;
            if (rectTransform.rect.height == 836)
            {
                y -= 62;
            }
            else
            {
                y -= 126f;
            }
        }
        else if ((calendarDays.Count() + 1) / 7 == 5 && newHeight != 836)
        {
            newHeight = 836;
            if (rectTransform.rect.height == 960)
            {
                y += 62;
            }
            else
            {
                y -= 64f;
            }
        }
        else if ((calendarDays.Count() + 1) / 7 == 4 && (newHeight != 707))
        {
            newHeight = 707;
            if (rectTransform.rect.height == 960)
            {
                y += 126f;
            }
            else
            {
                y += 64f;
            }
        }
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, newHeight);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x,
                rectTransform.anchoredPosition.y + y
            );
        for (int i = 0; i < buttons.Count(); i++)
        {
            TMP_Text dateText = buttonDate.GetComponentInChildren<TMP_Text>();
            dateText.text = dateTime.ToString("ddd, dd.MM.yyyy", new CultureInfo("ru-RU")) + " ã.";
            UnityEngine.UI.Button button = buttons[i];
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            if (i < calendarDays.Count())
            {
                buttonText.text = calendarDays[i].ToString();
                button.gameObject.SetActive(true);
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnClick(button));
                if (i < 7 && calendarDays[i] > 20 || i > 20 && calendarDays[i] < 7)
                {
                    Color transparentColor = buttonText.color;
                    transparentColor.a = 0.65f;
                    buttonText.color = transparentColor;
                    //buttonText.color = new Color(0.5f, 0.8f, 0.2f, 1f);
                }
                else
                {
                    Color transparentColor = buttonText.color;
                    transparentColor.a = 1f;
                    buttonText.color = transparentColor;
                    if (calendarDays[i] == dateTime.Day)
                    {
                        RectTransform buttonRect = button.GetComponent<RectTransform>();
                        RectTransform imageRect = nowImage.GetComponent<RectTransform>();
                        imageRect.position = buttonRect.position;
                    }
                }
            }
            else
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    void LeftClick()
    {
        Debug.Log("LeftClick");
        if (dateTime.Month == 1)
        {
            dateTime = new DateTime(dateTime.Year - 1, 12, DateTime.DaysInMonth(dateTime.Year - 1, 12));
        }
        else if (dateTime.Day == 1) {
            dateTime = new DateTime(dateTime.Year, dateTime.Month - 1, DateTime.DaysInMonth(dateTime.Year, dateTime.Month - 1));
        }
        else
        {
            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day - 1);
        }
        GenerateData();
        GenerateButtons();
    }

    void RightClick()
    {
        Debug.Log("RightClick");
        if (dateTime.Month == 12)
        {
            dateTime = new DateTime(dateTime.Year + 1, 1, 1);
        }
        else if (dateTime.Day == DateTime.DaysInMonth(dateTime.Year, dateTime.Month))
        {
            dateTime = new DateTime(dateTime.Year, dateTime.Month + 1, 1);
        }
        else
        {
            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1);
        }
        GenerateData();
        GenerateButtons();
    }

    void OnClick(UnityEngine.UI.Button buttonObject)
    {
        name = buttonObject.name;
        string dayText = buttonObject.GetComponentInChildren<TMP_Text>().text;
        int.TryParse(dayText, out int day);
        int.TryParse(name, out int i);
        if (i < 7 && day > 22)
        {
            if (dateTime.Month == 1)
            {
                dateTime = new DateTime(dateTime.Year - 1, 12, day);
            }
            else
            {
                dateTime = new DateTime(dateTime.Year, dateTime.Month - 1, day);
            }
        }
        if (i > 20 && day < 7)
        {
            if (dateTime.Month == 12)
            {
                dateTime = new DateTime(dateTime.Year + 1, 12, day);
            }
            else
            {
                dateTime = new DateTime(dateTime.Year, dateTime.Month + 1, day);
            }
        }
        else
        {
            dateTime = new DateTime(dateTime.Year, dateTime.Month, day);
        }
        GenerateData();
        GenerateButtons();
    }


    void GenerateData()
    {
        BingoWindow.chosenDate = dateTime.ToString("dd.MM.yyyy");
        bingoWindow.UpdateBingo();
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
