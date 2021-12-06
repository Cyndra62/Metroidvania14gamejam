using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public static CameraControler instance;
    //public Transform target;
    //public GameObject player;
    public float minHeight, maxHeight, minWidth, maxWidth;
    private Vector2 lastPos;

    private void Awake()
    {
        instance = this;
        FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {
        lastPos = transform.position;
        //target.transform.position = player.transform.position;
        
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(FindObjectOfType<PlayerMovement>().transform.position.x, minWidth, maxWidth), Mathf.Clamp(FindObjectOfType<PlayerMovement>().transform.position.y, minHeight, maxHeight), transform.position.z);
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
    }
}
