using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupExample : MonoBehaviour
{
    public void OnPickup(int id)
    {
        GetComponent<UnityEngine.UI.Text>().text = $"Picked: true, ID: {id.ToString()}";
    }
}
