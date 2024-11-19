using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class CircularAvatar : MonoBehaviour
{
    public Image avatarUI; // UI-элемент для отображения результата
    private Texture2D circularTexture;

    public void LoadAndSetAvatar()
    {
        // Открытие файлового проводника
        string filePath = EditorUtility.OpenFilePanel("Select an Image", "", "png,jpg,jpeg");

        if (!string.IsNullOrEmpty(filePath))
        {
            // Загрузка текстуры из файла
            byte[] fileData = System.IO.File.ReadAllBytes(filePath);
            Texture2D loadedTexture = new Texture2D(2, 2);
            if (loadedTexture.LoadImage(fileData))
            {
                // Установить текстуру как аватар
                SetCircularAvatar(loadedTexture);
            }
            else
            {
                Debug.LogError("Failed to load image.");
            }
        }
    }

    // Метод обрезки в круг
    private void SetCircularAvatar(Texture2D sourceTexture)
    {
        int width = sourceTexture.width;
        int height = sourceTexture.height;

        // Создаем текстуру для круга
        Texture2D circularTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);

        Vector2 center = new Vector2(width / 2, height / 2);
        float radius = Mathf.Min(width, height) / 1.9f; // Радиус увеличен в 2 раза

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float distance = Vector2.Distance(new Vector2(x, y), center);
                if (distance <= radius)
                {
                    circularTexture.SetPixel(x, y, sourceTexture.GetPixel(x, y));
                }
                else
                {
                    circularTexture.SetPixel(x, y, new Color(0, 0, 0, 0)); // Прозрачность за кругом
                }
            }
        }

        circularTexture.Apply();

        // Преобразуем в Sprite
        Sprite circularSprite = Sprite.Create(
            circularTexture,
            new Rect(0, 0, circularTexture.width, circularTexture.height),
            new Vector2(0.5f, 0.5f)
        );

        // Устанавливаем в Image
        avatarUI.sprite = circularSprite;
    }

    // Очистка памяти (вызывается при удалении объекта)
    private void OnDestroy()
    {
        if (circularTexture != null)
        {
            Destroy(circularTexture);
        }
    }

    
}
