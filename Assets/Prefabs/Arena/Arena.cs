using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{

    [SerializeField]
    public List<Enemy> enemies;

    [SerializeField]
    public List<Item> items;
    

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
}
