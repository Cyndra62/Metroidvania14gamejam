using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamageEvent : UnityEvent<float, float> { }
[System.Serializable]
public class OnHealEvent : UnityEvent<float, float> { }
[System.Serializable]
public class HealthBarHook : UnityEvent<float, float> { }

public enum OnDeathAction {
    Destroy, Callback, DestroyAndCallback
}

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;
    public bool setHealthOnStart = true;
    [SerializeField]
    private float maxHealth = 100f;

    [Space]
    [Header("Events")]
    public OnDeathAction deathAction;
    public UnityEvent onDeath;
    public OnDamageEvent onDamage;
    public OnHealEvent onHeal;
    [Tooltip("Bind this to the healthbar's UpdateBar method.")]
    public HealthBarHook healthBarHook;


    void Start()
    {
        if (setHealthOnStart)
            health = maxHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Damage(10);
        }

        if (Input.GetMouseButtonDown(1))
            Heal(2);
    }

    public void Damage(float amount)
    {
        health -= amount;
        onDamage.Invoke(amount, health);
        healthBarHook.Invoke(health, maxHealth);
        if (health <= 0)
        {
            if (deathAction == OnDeathAction.Callback || deathAction == OnDeathAction.DestroyAndCallback)
                onDeath.Invoke();

            if (deathAction == OnDeathAction.Destroy || deathAction == OnDeathAction.DestroyAndCallback)
                Destroy(gameObject);
        }
    }

    public void Heal(float amount)
    {
        health += amount;
        onHeal.Invoke(amount, health);
        healthBarHook.Invoke(health, maxHealth);
    }
}
