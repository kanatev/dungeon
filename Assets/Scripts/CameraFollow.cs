using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    [SerializeField] private int _lookSpeedMouse;
    private Vector2 _rotation;
    private float _distanceFromTarget = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        initalOffset = transform.position - targetObject.position;
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

        // работает
        //transform.position = targetObject.position - transform.forward * _distanceFromTarget;


        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //if (h > 0.5f)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        //}
        //if (h < -0.5f)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        //}
        //if (v > 0.5f)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        //}
        //if (v < -0.5f)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
        //}

        //cameraPosition = targetObject.position + initalOffset;
        //transform.position = cameraPosition;
    }
}
