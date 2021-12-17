using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetActivator : MonoBehaviour
{
    public SpriteRenderer sphere;

    private void Start()
    {
        //sphere.color = new Color()
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sphere.color = new Color(1, 0, 0, 1);
            IsSavedScene.instance.gateSave3 = true;
        }
    }
}
