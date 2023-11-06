using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;

    [SerializeField] private int _lookSpeedMouse;
    private Vector2 _rotation;
    private float _distanceFromTarget = 3.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _lookSpeedMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSpeedMouse * Time.deltaTime;

        _rotation.y += mouseX;
        _rotation.x -= mouseY;
        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);

        _distanceFromTarget -= Input.mouseScrollDelta.y;

        transform.localEulerAngles = new Vector3(_rotation.x, _rotation.y, 0);

        Vector3 newPosition = new Vector3(targetObject.position.x, targetObject.position.y + 1.2f, targetObject.position.z);

        transform.position = newPosition - transform.forward * _distanceFromTarget;
    }
}
