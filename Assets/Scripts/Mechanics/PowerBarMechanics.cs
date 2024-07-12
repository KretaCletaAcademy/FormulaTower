using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public sealed class PowerBarMechanics
{
    private readonly AtomicVariable<int> power;
    private readonly AtomicEvent<int> powerEvent;

    public string? powerBarText;
   
    public TextMeshPro powerBar;
    private GameObject powerBarObject;

    public PowerBarMechanics(
        AtomicVariable<int> power,
        AtomicEvent<int> powerEvent,
        GameObject powerBar,
        Vector3 position,
        string? powerBarText=null
    )
    {
        this.power = power;

        powerBarObject = Object.Instantiate(powerBar);
        powerBarObject.transform.position = position;
        
        this.powerEvent = powerEvent;
        this.powerBar = powerBarObject.GetComponent<TextMeshPro>();
        this.powerBarText = powerBarText;
        OnPowerPointsChanged(power.Value);
    }

    public void OnEnable()
    {
        power.Subscribe(OnPowerPointsChanged);
    }

    public void OnDisable()
    {
        power.Unsubscribe(OnPowerPointsChanged);
        Object.Destroy(powerBarObject);
    }

    private void OnPowerPointsChanged(int powerChanges)
    {
        if (powerBarText == null)
        {
            powerBar.text = power.Value.ToString();
        }
        else {
            powerBar.text = powerBarText;
        }
        powerBar.SetAllDirty();
    }

    public void Update(Vector3 position)
    {
        powerBarObject.transform.position = position;
    }
}