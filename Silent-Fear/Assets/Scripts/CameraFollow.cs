using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    ///FOLLOWS PLAYER ON X AND Y AXIS,
    ///PLAYER STAYS IN THE MIDDLE OF THE SCREEN

    public GameObject playerObj;
    Camera cam;

    [Range(0f,10f)]
    [SerializeField] float offset = 0f;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        transform.position = transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, -offset);
    }
}
