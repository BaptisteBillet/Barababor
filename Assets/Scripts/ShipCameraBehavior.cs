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

    Vector3 m_CameraClairvoyantPosition;

    //The ref of velocity
    Vector3 m_CameraVelocity = Vector3.zero;

    //The Smooth value
    public float m_SmoothCameraLerp = 0.3f;

    public bool IsClairvoyant;
    public bool IsDazzled;

    Ship m_Ship;

    public void Start()
    {

        m_Ship = GetComponent<Ship>();

        //Take the value of the idle and define the value of the vectors
        m_CameraIdlePosition = m_Camera.transform.localPosition;
        m_CameraRightPosition = m_Camera.transform.localPosition;
        m_CameraLeftPosition = m_Camera.transform.localPosition;

        //Positions of the Camera
        m_CameraLeftPosition = new Vector3(-m_CameraDisplacementValue, m_CameraIdlePosition.y, m_CameraIdlePosition.z);
        m_CameraRightPosition = new Vector3(m_CameraDisplacementValue, m_CameraIdlePosition.y, m_CameraIdlePosition.z);
        m_CameraClairvoyantPosition = new Vector3(m_Camera.transform.localPosition.x, 18f, -26f);
    }

    public void MoveCamera(string direction)
    {
        switch(direction)
        {
            case "idle":
                MoveCameraToIdle();
                break;
            case "left":
                MoveCameraToLeft();
                break;
            case "right":
                MoveCameraToRight();
                break;
            case "clairvoyant":
                if (IsDazzled == true)
                {
                    IsDazzled = false;
                    UIManager.instance.ActualizeDazzled(IsDazzled);
                }
                else
                {
                    if (IsClairvoyant == false)
                    {
                        IsClairvoyant = true;
                        StopAllCoroutines();
                        BecomeClairvoyant();
                    }
                    else
                    {
                        IsClairvoyant = false;
                        StopAllCoroutines();
                        StopToBeClairvoyant();
                    }
                }
                break;
            case "dazzled":
                if (IsClairvoyant == true)
                {
                    StopToBeClairvoyant();
                    IsClairvoyant = false;
                }
                else
                {
                    if (IsDazzled == false)
                    {
                        IsDazzled = true;
                        UIManager.instance.ActualizeDazzled(IsDazzled);
                    }
                    else
                    {
                        IsDazzled = false;
                        UIManager.instance.ActualizeDazzled(IsDazzled);
                    }
                }
                break;
        }
    }

    void MoveCameraToLeft()
    {
        m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, new Vector3(m_CameraLeftPosition.x, m_Camera.transform.localPosition.y, m_Camera.transform.localPosition.z), ref m_CameraVelocity, m_SmoothCameraLerp);
    }

    void MoveCameraToRight()
    {
        m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, new Vector3(m_CameraRightPosition.x, m_Camera.transform.localPosition.y, m_Camera.transform.localPosition.z), ref m_CameraVelocity, m_SmoothCameraLerp);
    }

    void MoveCameraToIdle()
    {
        m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, new Vector3(m_CameraIdlePosition.x, m_Camera.transform.localPosition.y, m_Camera.transform.localPosition.z), ref m_CameraVelocity, m_SmoothCameraLerp);
    }

    #region State
    void BecomeClairvoyant()
    {
        StartCoroutine(CBecomeClairvoyant());
    }

    IEnumerator CBecomeClairvoyant()
    {
        while (m_Camera.transform.localPosition.y != m_CameraClairvoyantPosition.y || m_Camera.transform.localPosition.z != m_CameraClairvoyantPosition.z)
        {
            yield return new WaitForSeconds(0.0001f);
            m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, new Vector3(m_Camera.transform.localPosition.x, m_CameraClairvoyantPosition.y, m_CameraClairvoyantPosition.z), ref m_CameraVelocity, m_SmoothCameraLerp);
        }
    }

    void StopToBeClairvoyant()
    {
        StartCoroutine(CStopToBeClairvoyant());
    }

    IEnumerator CStopToBeClairvoyant()
    {
        while (m_Camera.transform.localPosition.y != m_CameraClairvoyantPosition.y || m_Camera.transform.localPosition.z != m_CameraClairvoyantPosition.z)
        {
            yield return new WaitForSeconds(0.0001f);
            m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, new Vector3(m_Camera.transform.localPosition.x, m_CameraIdlePosition.y, m_CameraIdlePosition.z), ref m_CameraVelocity, m_SmoothCameraLerp);
        }
    }

    #endregion

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            MoveCamera("clairvoyant");
        }

    }
}





// m_Camera.transform.localPosition = Vector3.SmoothDamp(m_Camera.transform.localPosition, m_CameraLeftPosition, ref m_CameraVelocity, m_SmoothCameraLerp);