using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    private Vector3 positionTarget;
    private Vector3 camFollowVelocity = Vector3.zero;
    private Vector3 camVectorPos;

    public LayerMask collideLayer;

    public Transform transformTarget;
    public Transform camPivot;
    public Transform camTransform;
    public float speedFollow = 0.2f;

    public float angleLook;
    public float anglePivot;
    public float camSpeedLook = 2;
    public float camSpeedRotation = 2;
    public float camRadiusCollision = 2;

    public float minPiv = -35;
    public float maxPiv = 35;
    public float camCollOffset = 0.2f;
    public float minCollOffset = 0.2f;

    private Vector3 rotation;
    private Vector3 direction;
    private Quaternion rotateTarget;

    private float posTarget;
    private float positionDefault;
    private float distance;

    private void Awake()
    {
        transformTarget = GameObject.Find("LowPolyMan").GetComponent<PlayerManager>().transform;
        inputManager = FindObjectOfType<InputManager>();
        camTransform = Camera.main.transform;
        positionDefault = camTransform.localPosition.z;
    }

    public void AllCamMovement()
    {
        PlayerFollow();
        CamRotation();
        CamCollision();
    }

    private void PlayerFollow()
    {
        positionTarget = Vector3.SmoothDamp(transform.position, transformTarget.position, ref camFollowVelocity, speedFollow);

        transform.position = positionTarget;
    }

    private void CamRotation()
    {
        angleLook = angleLook + (inputManager.XCamInput * camSpeedLook);
        anglePivot = anglePivot - (inputManager.YCamInput * camSpeedRotation);
        anglePivot = Mathf.Clamp(anglePivot, minPiv, maxPiv);

        rotation = Vector3.zero;
        rotation.y = angleLook;

        rotateTarget = Quaternion.Euler(rotation);
        transform.rotation = rotateTarget;

        rotation = Vector3.zero;
        rotation.x = anglePivot;
        rotateTarget = Quaternion.Euler(rotation);

        camPivot.localRotation = rotateTarget;
    }

    private void CamCollision()
    {
        posTarget = positionDefault;

        RaycastHit hit;
        direction = camTransform.position - camPivot.position;
        direction.Normalize();

        if (Physics.SphereCast
            (camPivot.transform.position, camRadiusCollision, direction, out hit, Mathf.Abs(posTarget), collideLayer))
        {
            distance = Vector3.Distance(camPivot.position, hit.point);
            posTarget =+ (distance - camCollOffset);
        }

        if (Mathf.Abs(posTarget) < minCollOffset)
        {
            posTarget = posTarget - minCollOffset;
        }

        camVectorPos.z = Mathf.Lerp(camTransform.localPosition.z, posTarget, 0.2f);
        camTransform.localPosition = camVectorPos;
    }
}
