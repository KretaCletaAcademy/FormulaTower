using UnityEngine;

public class Item : MonoBehaviour
{
    private AtomicVariable<int> power;
    public AtomicEvent<int> powerBarEvent;
    
    public GameObject powerBarPrefab;

    public string powerBarText;

    private PowerBarMechanics barMechanics;

    [SerializeField]
    public GameObject highlight;

    private void Awake()
    {
        highlight.SetActive(false);
        power = new AtomicVariable<int>(EvaluteMechanics.Eval(powerBarText));
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
        if (!Arena.CheckItem(this)) return;
        var character = Character.instance;
        character.power.Value += power.Value;
        Destroy(highlight);
        Destroy(this.gameObject);
    }
}
