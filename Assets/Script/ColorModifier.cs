using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorModifier : MonoBehaviour
{
    [SerializeField] private List<ColorDef> colorDef;

    private Texture2D texture;

    [SerializeField] private float PPU;
    private void Awake()
    {
        texture = new Texture2D(128, 128);
    }

    void Update()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                Vector2 pixelPos = new Vector2(x, y) / PPU;
                Color result = Color.clear;

                for (int i = 0; i < colorDef.Count; i++)
                {
                    if (pixelPos.y - 0.5f + transform.position.y > colorDef[i].limit)
                    {
                        result = colorDef[i].color;
                    }
                }

                texture.SetPixel(x, y, result == Color.clear ? colorDef[5].color : result);
            }
        }

        texture.Apply();

        renderer.sprite = Sprite.Create(texture, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
    }
}

[System.Serializable]
public class ColorDef
{
    public float limit;
    public Color color;
}
