using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] private TileControll m_tilePrefab;
    [SerializeField] int m_amount;
    [SerializeField] List<TileControll> m_tileList = new List<TileControll>();

    public static TowerManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }


    public TileControll GetTile(Vector2Int coordinate)
    {
        return m_tileList.Find(x => x.coordinate == coordinate);
    }


    [ContextMenu(nameof(Create))]
    public void Create()
    {
        Create(m_amount);
    }

    private void Create(int firstStep)
    {
        m_tileList = new List<TileControll>();

        Vector3 position = Vector3.zero;
        Vector2Int coordinate = Vector2Int.zero;

        for (int y = firstStep, height = 0; y > 0; y--, height++)
        {
            for (int x = 0; x < y; x++)
            {
                var obj = Instantiate(m_tilePrefab, position, Quaternion.identity);
                obj.transform.SetParent(this.transform);
                obj.coordinate = coordinate;

                obj.name = $"Tile =>\t[{coordinate.x}, {coordinate.y}]";
                m_tileList.Add(obj);
                position.x++;
                position.z++;
                coordinate.x += 2;
            }
            position.y++;
            position.z = height + 1;
            position.x = 0;
            coordinate.y++;
            coordinate.x = height + 1;
        }
    }


    [ContextMenu(nameof(DestroyChild))]
    public void DestroyChild()
    {
        var list = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            list.Add(transform.GetChild(i).gameObject);
        }

        foreach (var item in list)
        {
            DestroyImmediate(item);
        }
    }
}
