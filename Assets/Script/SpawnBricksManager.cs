using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnBricksManager : MonoBehaviour
{
    [Header("SpawnBrick")]
    [SerializeField] private int raw;
    [SerializeField] private int column;
    [SerializeField] private GameObject bricks;
    public Color[] colors;

    public List<GameObject> level = new List<GameObject>();

    private int startingLevelCount = 0;
    [HideInInspector] public int currentLevelCount;
    private int maxLevelCount = 3;

    [SerializeField] private UnityEvent levelCount;

    private SpawnBallManager spawnBall;

    private void Awake()
    {
        spawnBall = GetComponent<SpawnBallManager>();
    }

    void Start()
    {
        currentLevelCount = startingLevelCount;
        SpawnBricks();
    }

    private void Update()
    {
        if (level.Count == 0)
        {
            Destroy(spawnBall.ball);
            SpawnBricks();
            spawnBall.SpawnBall();
        }
    }

    public void SpawnBricks()
    {
        for (int y = 0; y < raw; y++)
        {
            for (int x = 0; x < column; x++)
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

        ModifyLevelCount(1);
        levelCount.Invoke();
    }

    private void ModifyLevelCount(int value)
    {
        currentLevelCount = Mathf.Clamp(currentLevelCount + value, 0, maxLevelCount);
    }
}
