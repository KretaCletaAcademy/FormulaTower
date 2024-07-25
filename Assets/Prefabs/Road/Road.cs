using System.Collections.Generic;
using UnityEngine;

class Road: MonoBehaviour
{
    private static List<Road> roads = new List<Road>();

    public AtomicVariable<int> power;
    private AtomicEvent<int> atomicEvent;

    [SerializeField]
    public string powerBarText;

    [SerializeField]
    private List<Transform> points;

    [SerializeField]
    private Arena fromArena;

    [SerializeField]
    private Arena toArena;

    [SerializeField]
    private GameObject powerBarPrefab;

    private PowerBarMechanics powerBarMechanics;

    private void Awake()
    {
        power = new AtomicVariable<int>(EvaluteMechanics.Eval(powerBarText));
        powerBarMechanics = new PowerBarMechanics(power, atomicEvent, powerBarPrefab, transform.position, powerBarText);
    }

    private void OnEnable()
    {
        powerBarMechanics.OnEnable();
    }

    private void OnDisable()
    {
        powerBarMechanics.OnDisable();
    }

    private void OnMouseDown()
    {
        var instance = Character.instance;
        if (instance.arena != fromArena) {
            return;
        }
        instance.comparisonPowerEvent.Invoke(power.Value);
        instance.powerBarEvent.Invoke(instance.power.Value);
        if (instance.power.Value != 0)
        {
            power.Value = 0;
            instance.moveEvent.Invoke(points);
            instance.arena = toArena;
        }
    }
}
