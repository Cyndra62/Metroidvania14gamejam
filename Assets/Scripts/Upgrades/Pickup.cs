using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnPickupEvent : UnityEvent<int> { }

[RequireComponent(typeof(Collider2D))]
public class Pickup : MonoBehaviour
{
    [Tooltip("Layer of the object that can pick this up")]
    public LayerMask canPickup;
    [Tooltip("For example the ID of the upgrade picked up. This will be passed to the OnPickupEvent")]
    public int PickupID = 1;
    [Tooltip("Whether to Destroy(gameObject) on pickup")]
    public bool destroyOnPickup = true;
    public OnPickupEvent OnPickup;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // check layermask
        if (canPickup == (canPickup | (1 << collider.gameObject.layer))) {
            OnPickup.Invoke(PickupID);

            if (destroyOnPickup)
                Destroy(gameObject);
        }

    }
}
