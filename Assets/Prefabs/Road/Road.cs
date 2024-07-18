using System;
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
    private Road? previousRoad = null;

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
        Debug.Log(Road.roads.Contains(previousRoad));
        if (previousRoad != null && !Road.roads.Contains(previousRoad)) {
            return;
        }
        var instance = Character.instance;
        instance.comparisonPowerEvent.Invoke(power.Value);
        instance.powerBarEvent.Invoke(instance.power.Value);
        if (instance.power.Value != 0)
        {
            if (previousRoad != null)
                Road.roads.Add(previousRoad);
            else
                Road.roads.Add(this);
            power.Value = 0;
            instance.moveEvent.Invoke(points);
        }
    }
}
