using TMPro;
using UnityEngine;

public sealed class PowerBarMechanics
{
    private readonly AtomicVariable<int> power;
    private readonly AtomicEvent<int> powerEvent;
   
    public TextMeshPro powerBar;
    private GameObject powerBarObject;

    public PowerBarMechanics(
        AtomicVariable<int> power,
        AtomicEvent<int> powerEvent,
        GameObject powerBar,
        Vector3 position
    )
    {
        this.power = power;

        powerBarObject = Object.Instantiate(powerBar);
        powerBarObject.transform.position = position;
        
        this.powerEvent = powerEvent;
        this.powerBar = powerBarObject.GetComponent<TextMeshPro>();

        OnPowerPointsChanged(power.Value);
    }

    public void OnEnable()
    {
        power.Subscribe(OnPowerPointsChanged);
    }

    public void OnDisable()
    {
        power.Unsubscribe(OnPowerPointsChanged);
    }

    private void OnPowerPointsChanged(int powerChanges)
    {
        powerBar.text = power.Value.ToString();
        powerBar.SetAllDirty();
    }
}