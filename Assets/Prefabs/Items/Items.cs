using UnityEngine;

public class Items : MonoBehaviour
{
    public AtomicVariable<int> power;
    public AtomicEvent<int> powerBarEvent;
    
    public GameObject powerBarPrefab;

    public string powerBarText;

    private PowerBarMechanics barMechanics;

    private void Awake()
    {
        barMechanics = new PowerBarMechanics(power, powerBarEvent, powerBarPrefab, transform.position, powerBarText);
    }

    private void OnEnable()
    {
        barMechanics.OnEnable();
    }

    private void OnDisable()
    {
        barMechanics.OnDisable();
    }

    private void OnMouseDown()
    {
        var character = Character.instance;
        character.power.Value += power.Value;
        Destroy(this.gameObject);
    }
}
