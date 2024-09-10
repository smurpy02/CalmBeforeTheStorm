using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Instance,
    Continuous
}

public class DoDamage : MonoBehaviour
{
    public float damage;
    public DamageType type;

    float damageAmount
    {
        get
        {
            switch (type)
            {
                case DamageType.Instance:
                    return damage;
                case DamageType.Continuous:
                    return damage * Time.deltaTime;
            }

            return 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        DamageDestructable(other.GetComponent<Destructable>());
    }

    void OnTriggerStay(Collider other)
    {
        DamageDestructable(other.GetComponent<Destructable>());
    }

    void DamageDestructable(Destructable destructable)
    {
        if (destructable != null)
        {
            destructable.Damage(damageAmount);

            if (type == DamageType.Instance) Destroy(gameObject);
        }
    }
}
