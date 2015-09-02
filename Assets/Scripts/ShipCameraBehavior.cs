using UnityEngine;
using System.Collections;

public class ShipCameraBehavior : MonoBehaviour {

    //The camera
    public Camera m_Camera;

    //The angle distance of the camera mouvement
    public float m_CameraDisplacementValue;

    public float m_CameraRotationValue;

    // The vector of lerp displacement
    Vector3 m_CameraIdlePosition;
    Vector3 m_CameraRightPosition;
    Vector3 m_CameraLeftPosition;

    //The ref of velocity
    Vector3 m_CameraVelocity = Vector3.zero;

    //The Smooth value
    public float m_SmoothCameraLerp = 0.3f;

    public void Start()
    {
        //Take the value of the idle and define the value of the vectors
        m_CameraIdlePosition = m_Camera.transform.localPosition;
        m_CameraRightPosition = m_Camera.transform.localPosition;
        m_CameraLeftPosition = m_Camera.transform.localPosition;

        //Positions of the Camera
        m_CameraLeftPosition = new Vector3(-m_CameraDisplacementValue, m_CameraIdlePosition.y, m_CameraIdlePosition.z);
        m_CameraRightPosition = new Vector3(m_CameraDisplacementValue, m_CameraIdlePosition.y, m_CameraIdlePosition.z);
    }

    public void MoveCameraToLeft()
    {
        m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, m_CameraLeftPosition, ref m_CameraVelocity, m_SmoothCameraLerp);
    }

    public void MoveCameraToRight()
    {
        m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, m_CameraRightPosition, ref m_CameraVelocity, m_SmoothCameraLerp);
    }

    public void MoveCameraToIdle()
    {
        m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, m_CameraIdlePosition, ref m_CameraVelocity, m_SmoothCameraLerp);
    }

}
