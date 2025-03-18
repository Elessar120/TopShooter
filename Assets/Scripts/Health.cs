using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ItakeDamage
{
    float ItakeDamage.Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void TakeDamage(float amount)
    {
        throw new System.NotImplementedException();
    }
}
