using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AtomicVariable<int> power;
    public AtomicVariable<bool> isDead;

    public AtomicEvent<bool> deathEvent;
    public AtomicEvent<int> powerBarEvent;
    public AtomicEvent<int> powerComprasionEvent;

    [SerializeField]
    public string powerBarText;

    public List<Transform> points = new List<Transform>();

    public GameObject powerBarPrefab;

    private DeathMechanics deathMechanics;
    private PowerBarMechanics powerBarMechanics;
    private PowerСomparisonMechaincs powerСomparisonMechaincs;

    private void Awake()
    {
        isDead = new AtomicVariable<bool>(false);
        power = new AtomicVariable<int>(EvaluteMechanics.Eval(powerBarText));
        deathMechanics = new DeathMechanics(power, isDead, deathEvent);
        powerBarMechanics = new PowerBarMechanics(power, powerBarEvent, powerBarPrefab, transform.position, powerBarText);
        powerСomparisonMechaincs = new PowerСomparisonMechaincs(power, powerComprasionEvent);
    }

    private void OnEnable()
    {
        powerСomparisonMechaincs.OnEnable();
        deathMechanics.OnEnable();
        powerBarMechanics.OnEnable();
    }

    private void OnDisable()
    {
        powerСomparisonMechaincs.OnDisable();
        deathMechanics.OnDisable();
        powerBarMechanics.OnDisable();
    }

    private void OnMouseDown()
    {
        var instance = Character.instance;
        instance.comparisonPowerEvent.Invoke(power.Value);
        instance.powerBarEvent.Invoke(instance.power.Value);
        if (instance.power.Value != 0)
        {
            power.Value = 0;
            instance.moveEvent.Invoke(points);
            Destroy(gameObject);
        }
    }
}