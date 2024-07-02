public sealed class DeathMechanics
{
    private readonly AtomicVariable<int> hitPoints;
    private readonly AtomicVariable<bool> isDead;
    private readonly AtomicEvent<bool> deathEvent;

    public DeathMechanics(
        AtomicVariable<int> hitPoints,
        AtomicVariable<bool> isDead,
        AtomicEvent<bool> deathEvent
    )
    {
        this.hitPoints = hitPoints;
        this.isDead = isDead;
        this.deathEvent = deathEvent;
    }

    public void OnEnable()
    {
        this.hitPoints.Subscribe(this.OnHitPointsChanged);
    }

    public void OnDisable()
    {
        this.hitPoints.Unsubscribe(this.OnHitPointsChanged);
    }

    private void OnHitPointsChanged(int hitPoints)
    {
        if (hitPoints <= 0)
        {
            this.deathEvent.Invoke(true);
            this.isDead.Value = true;
        }
    }
}