using System;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{

    [SerializeField]
    public List<Enemy> enemies;

    [SerializeField]
    public List<Item> items;

    [SerializeField]
    private List<Road> roads;

    [SerializeField]
    public GameObject highlightObject;

    private static List<GameObject> objects = new();

    public static bool CheckEnemy(Enemy enemy)
    {
        var instance = Character.instance;
        return instance.arena.enemies.Contains(enemy);
    }

    public static bool CheckItem(Item item)
    {
        var instance = Character.instance;
        return instance.arena.items.Contains(item);
    }

    public void setHighlight(bool value)
    {
        var i = 0;
        while (enemies.Count > i) {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
                continue;
            }
            enemies[i].highlight.SetActive(value);
            i++;
        }
        i = 0;
        while (items.Count > i)
        {
            if (items[i] == null)
            {
                items.RemoveAt(i);
                continue;
            }
            items[i].highlight.SetActive(value);
            i++;
        }
        foreach (var item in roads)
        {
            item.highlight.SetActive(value);
        }
    }
}
