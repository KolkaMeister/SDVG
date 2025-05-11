using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Pet
{
    public string name;
    public int level;
    public int progress;
    public float play;
    public float eat;
    public float drink;
    public float wash;
}

public class PetInfo : MonoBehaviour
{
    [SerializeField]
    internal string name_pet;
    [SerializeField]
    internal int level;
    [SerializeField]
    internal int progress;
    [SerializeField]
    internal float play;
    [SerializeField]
    internal float eat;
    [SerializeField]
    internal float drink;
    [SerializeField]
    internal float wash;
    [SerializeField]
    internal string path;
    private Pet petData;

    void Awake()
    {
        path = Application.dataPath + "/Data/pet.json";

        if (File.Exists(path))
        {
            string jsonContent = File.ReadAllText(path);
            petData = JsonUtility.FromJson<Pet>(jsonContent);
            name_pet = petData.name;
            level = petData.level;
            progress = petData.progress;
            play = petData.play;
            eat = petData.eat;
            drink = petData.drink;
            wash = petData.wash;
            Debug.Log(play+"23");
        }
        else
        {
            Debug.LogError("Pet JSON file not found at: " + path);
        }
    }

    void OnApplicationQuit()
    {
        Debug.Log("Данные сохраненны");
        SaveData();
    }

    private void SaveData()
    {
        petData.name = name_pet;
        petData.level = level;
        petData.progress = progress;
        petData.play = play;
        petData.eat = eat;
        petData.drink = drink;
        petData.wash = wash;
        string json = JsonUtility.ToJson(petData, true);
        File.WriteAllText(path, json);

        Debug.Log($"Data saved to: {path}");
    }

}
