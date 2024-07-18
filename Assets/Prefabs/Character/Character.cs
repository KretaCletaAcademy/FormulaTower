using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int powerValue;

    public AtomicVariable<int> power;
    public AtomicVariable<bool> isDead;

    public AtomicEvent<int> comparisonPowerEvent;
    public AtomicEvent<bool> deathEvent;
    public AtomicEvent<int> powerBarEvent;
    public AtomicEvent<List<Transform>> moveEvent;

    public GameObject powerBarPrefab;
    public float speed;

    private PowerСomparisonMechaincs comparisonPower;
    private DeathMechanics deathMechanics;
    private PowerBarMechanics barMechanics;
    private WayPointsMechaincs wayPointsMechanics;

    public static Character instance { get; private set; }

    private void Awake()
    {
        power = new AtomicVariable<int>(powerValue);
        isDead = new AtomicVariable<bool>(false);
        comparisonPower = new PowerСomparisonMechaincs(power, comparisonPowerEvent);
        deathMechanics = new DeathMechanics(power, isDead, deathEvent);
        barMechanics = new PowerBarMechanics(power, powerBarEvent, powerBarPrefab, transform.position);
        wayPointsMechanics = new WayPointsMechaincs(moveEvent, speed);
    }

    private void OnEnable()
    {
        barMechanics.OnEnable();
        comparisonPower.OnEnable();
        deathMechanics.OnEnable();
        wayPointsMechanics.OnEnable();
        instance = this;
    }

    private void OnDisable()
    {
        barMechanics.OnDisable();
        comparisonPower.OnDisable();
        deathMechanics.OnDisable();
        wayPointsMechanics.OnDisable();
        instance = null;
    }

    private void Update()
    {
        wayPointsMechanics.Update();
        barMechanics.Update(transform.position);
    }
}