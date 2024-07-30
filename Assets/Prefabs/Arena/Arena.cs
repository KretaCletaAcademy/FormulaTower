using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{

    [SerializeField]
    public List<Enemy> enemies;

    [SerializeField]
    public List<Item> items;

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

    public void EnableHighlight()
    {
        foreach (var enemy in enemies) {
            var obj = Instantiate(highlightObject);
            obj.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y / 2);
            objects.Add(obj);
        }
        foreach (var enemy in items)
        {
            var obj = Instantiate(highlightObject);
            obj.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y / 2);
            objects.Add(obj);
        }
    }

    public void DisableHighlight()
    {
        while (objects.Count != 0) {
            Destroy(objects[0]);
            objects.RemoveAt(0);
        }
    }
}
