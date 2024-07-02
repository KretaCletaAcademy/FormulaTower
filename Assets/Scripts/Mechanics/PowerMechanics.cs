public sealed class PowerСomparisonMechaincs
{
    private readonly AtomicEvent<int> comparisonPowerEvent;
    private readonly AtomicVariable<int> power;

    public PowerСomparisonMechaincs(AtomicVariable<int> power, AtomicEvent<int> comparisonPowerEvent)
    {
        this.power = power;
        this.comparisonPowerEvent = comparisonPowerEvent;
    }

    public void OnEnable()
    {
        comparisonPowerEvent.Subscribe(СomparisonDamage);
    }

    public void OnDisable()
    {
        comparisonPowerEvent.Unsubscribe(СomparisonDamage);
    }

    private void СomparisonDamage(int powerComp)
    {
        if (power.Value > powerComp)
        {
            power.Value += powerComp;
        }
        else
        {
            power.Value = 0;
        }
    }
}