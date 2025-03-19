using System;

public interface ItakeDamage
{
    public Action OnDeath { get; set; }
    public void TakeDamage(float amount);
}
