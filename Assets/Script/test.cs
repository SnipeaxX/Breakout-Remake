using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Texture2D texture;

    private float pixelPosY;
    private float pixelPosX;
    private Vector2 pixelsCoordinate;
    public Vector2 pixelWorldPos;


    [SerializeField] private float bleuLine;
    [SerializeField] private float greenLine;
    [SerializeField] private float yellowLine;
    [SerializeField] private float orangeLine;
    [SerializeField] private float orangeRedLine;
    [SerializeField] private float redLine;
    private void Awake()
    {
        texture = new Texture2D(100, 100);
    }

    void Update()
    {

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        for (int i = 0; i < texture.width * texture.height; i++)
        {
            pixelPosY = Mathf.Floor(i / texture.width);
            pixelPosX = i - pixelPosY * texture.width;
            pixelsCoordinate = new Vector2(pixelPosX, pixelPosY);

            texture.SetPixel((int)pixelPosX, (int)pixelPosY, Color.red);

            Vector2 spritePos = renderer.worldToLocalMatrix.MultiplyPoint3x4(pixelsCoordinate);
            Rect textureRect = renderer.sprite.textureRect;
            float pixelsPerUnit = renderer.sprite.pixelsPerUnit;
            float halfRealTexWidth = texture.width * 0.5f;
            float halfRealTexHeight = texture.height * 0.5f;

            float texPosX = (renderer.transform.position.x / pixelsPerUnit + renderer.sprite.rect.x + renderer.sprite.pivot.x);
            float texPosY = (renderer.transform.position.y / pixelsPerUnit + renderer.sprite.rect.y + renderer.sprite.pivot.y);

            if (texPosY >= bleuLine)
            {
                texture.SetPixel((int)pixelPosX, (int)pixelPosY, Color.blue);
            }

        }
        texture.Apply();
    }
}
