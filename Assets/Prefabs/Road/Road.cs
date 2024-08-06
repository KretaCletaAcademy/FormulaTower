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

    [SerializeField]
    public GameObject highlight;

    private void Awake()
    {
        highlight.SetActive(false);
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

    public void ReverseDirection()
    {
        (fromArena, toArena) = (toArena, fromArena);
        points.Reverse();
    }

    public bool PlayerCanMove()
    {
        var instance = Character.instance;
        return instance.power.Value - power.Value > 0;
    }

    private void OnMouseDown()
    {
        var instance = Character.instance;

        if (instance.arena != fromArena && instance.arena != toArena) {
            return;
        }
        if (instance.arena == toArena)
        {
            ReverseDirection();
        }
        
        if (PlayerCanMove())
        {
            instance.power.Value -= power.Value;
            if (instance.arena != null) instance.arena.setHighlight(false);
            instance.moveEvent.Invoke(points);
            instance.arena = toArena;
            instance.arena.setHighlight(true);
        } else
        {
            highlight.SetActive(false);
        }
    }
}
