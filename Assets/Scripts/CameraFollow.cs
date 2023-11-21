using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;

    [SerializeField] private int _lookSpeedMouse;
    private Vector2 _rotation;
    private float _distanceFromTarget = 1.5f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _lookSpeedMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSpeedMouse * Time.deltaTime;

        _rotation.y += mouseX;
        _rotation.x -= mouseY;
        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);
        
        transform.localEulerAngles = new Vector3(_rotation.x, _rotation.y, 0);
        Vector3 newPosition = new Vector3(targetObject.position.x, targetObject.position.y + 1.2f, targetObject.position.z);
        transform.position = newPosition - transform.forward * _distanceFromTarget;
    }
}
