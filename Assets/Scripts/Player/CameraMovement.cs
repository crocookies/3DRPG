using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform objectToFollow;
    [SerializeField]
    private float followSpeed;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float clampAngleUp;
    [SerializeField]
    private float clampAngleDown;

    private float rotX;
    private float rotY;

    [SerializeField]
    private Transform realCamera;
    private Vector3 dirNormalized;
    private Vector3 finalDir;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float finalDistance;
    [SerializeField]
    private float smoothness;

    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            GameManager.Instance.cursorOn = true;

        if (Input.GetKeyUp(KeyCode.LeftAlt))
            GameManager.Instance.cursorOn = false;

        if (GameManager.Instance.cursorOn)
        {
            GameManager.Instance.CursorOn();
            return;
        }
        else
        {
            GameManager.Instance.CursorOff();
        }
        */

        rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngleUp, clampAngleDown);
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
        transform.rotation = rot;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position, followSpeed * Time.deltaTime);

        finalDir = transform.TransformPoint(dirNormalized * maxDistance);

        RaycastHit hit;

        if (Physics.Linecast(transform.position, finalDir, out hit))
        {
            if (!hit.collider.CompareTag("Player"))
                finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
            else
                finalDistance = maxDistance;
        }
        else
        {
            finalDistance = maxDistance;
        }

        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smoothness);
    }
}
