using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public AtomicVariable<int> power;
    public AtomicVariable<bool> isDead;

    public AtomicEvent<int> comparisonPowerEvent;
    public AtomicEvent<bool> deathEvent;
    public AtomicEvent<int> powerBarEvent;

    public GameObject powerBarPrefab;

    private PowerСomparisonMechaincs comparisonPower;
    private DeathMechanics deathMechanics;
    private PowerBarMechanics barMechanics;

    public static Character instance { get; private set; }

    private void Awake()
    {
        comparisonPower = new PowerСomparisonMechaincs(power, comparisonPowerEvent);
        deathMechanics = new DeathMechanics(power, isDead, deathEvent);
        barMechanics = new PowerBarMechanics(power, powerBarEvent, powerBarPrefab, transform.position);
    }

    private void OnEnable()
    {
        barMechanics.OnEnable();
        comparisonPower.OnEnable();
        deathMechanics.OnEnable();
        instance = this;
    }

    private void OnDisable()
    {
        barMechanics.OnDisable();
        comparisonPower.OnDisable();
        deathMechanics.OnDisable();
        instance = null;
    }
}