using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnBricksManager : MonoBehaviour
{
    [SerializeField] private GameObject bricks;

    public List<GameObject> level = new List<GameObject>();

    [HideInInspector] public int levelCount;

    public Color[] colors;

    void Start()
    {
        levelCount = 0;
        SpawnBricks();
    }

    private void Update()
    {
        if (level.Count == 0)
        {
            SpawnBricks();
        }
    }

    public void SpawnBricks()
    {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                GameObject brick = Instantiate(bricks);
                brick.transform.position = new Vector3(x * 1.5f, 4.5f - y * 0.75f, 0) + new Vector3(-14.25f, 0, 0);
                brick.GetComponent<SpriteRenderer>().color = colors[y];

                level.Add(brick);

                if (y <= 1)
                {
                    brick.GetComponent<BrickPoint>().point = 7;
                }
                if (y == 2 || y == 3)
                {
                    brick.GetComponent<BrickPoint>().point = 4;
                }
                if (y == 4 || y == 5)
                {
                    brick.GetComponent<BrickPoint>().point = 1;
                }
            }
        }

        levelCount += 1;
    }
}
