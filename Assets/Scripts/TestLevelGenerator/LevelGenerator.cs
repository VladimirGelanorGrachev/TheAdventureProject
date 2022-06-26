using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D _map;

    public ColorToPrefab[] colorMapping;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < _map.width; x++)
        {
            for(int y = 0; y < _map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = _map.GetPixel(x, y);

        if(pixelColor.a ==0)
        {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMapping)
        {
            if (colorMapping._color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping._prefab, position, Quaternion.identity, transform);
            }
        }
    }
    
}
