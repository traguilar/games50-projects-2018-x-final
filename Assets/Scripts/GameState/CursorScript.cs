using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // IDEA : MAYBE Make not a cursor but a gameobject, to make him rotate
    public Texture2D imageLeft;
    public Texture2D imageRight;
    private bool isLeft = true;
    private float screenWidth;
    private float screenHeight;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(imageLeft, Vector2.zero, CursorMode.Auto);
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        imageLeft = FlipTextureHorizontally(imageLeft);
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 mousePosition = Input.mousePosition;
        if (mousePosition.x < screenWidth / 2)
        {
            if (!isLeft)
            {
                Cursor.SetCursor(imageLeft, Vector2.zero, CursorMode.Auto);
                isLeft = true;
            }
        }
        else
        {
            if (isLeft)
            {
                Cursor.SetCursor(imageRight, Vector2.zero, CursorMode.Auto);
                isLeft = false;
            }
        }
    }

    public Texture2D FlipTextureHorizontally(Texture2D original)
    {
        // Créer une nouvelle texture avec les mêmes dimensions que l'originale
        Texture2D flipped = new Texture2D(original.width, original.height);

        // Copier les pixels de la texture originale dans la nouvelle texture en inversant les colonnes
        for (int y = 0; y < original.height; y++)
        {
            for (int x = 0; x < original.width; x++)
            {
                // Copier les pixels de la colonne x de la texture originale dans la colonne inversée de la nouvelle texture
                flipped.SetPixel(x, y, original.GetPixel(original.width - 1 - x, y));
            }
        }

        // Appliquer les changements de pixels à la nouvelle texture
        flipped.Apply();

        return flipped;
    }
}
