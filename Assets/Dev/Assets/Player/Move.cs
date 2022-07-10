using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float yRotation;
    private float xRotation;
    private Rigidbody body;
    public GameObject mainCamera;
    public float MoveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.freezeRotation = true;

    }

    void FixedUpdate()
    {
        
        //Rotate Player
        var moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        body.AddForce(moveDirection * MoveSpeed, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
        //cursor.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);

        //Rotate mainCamera
        yRotation += Input.GetAxisRaw("Mouse X") * 5;
        xRotation -= Input.GetAxisRaw("Mouse Y") * 5;

        xRotation = Mathf.Clamp(xRotation, -90F, 90F);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
