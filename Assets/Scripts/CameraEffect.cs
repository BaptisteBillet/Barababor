using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class CameraEffect : MonoBehaviour
{
    #region Members
    private Fisheye fisheye;
    private Camera m_Camera;
    #endregion

    float gap = 0.02f;

    // Use this for initialization
    void Start()
    {
		
		CameraEventManager.onEvent += Effect;

        CameraEventManager.ActualizeFOV += FOVEffect;

        m_Camera = GetComponent<Camera>();

        fisheye = GetComponent<Fisheye>();
 



        fisheye.enabled = false;
        fisheye.strengthX = 0;
        fisheye.strengthY = 0;

        


    }

    /// <summary>
    /// Called when [destroy].
    /// </summary>
    void OnDestroy()
    {
        CameraEventManager.onEvent -= Effect;
        CameraEventManager.ActualizeFOV -= FOVEffect;
    }


    // iTween.ShakePosition(gameObject, new Vector3(1, 1, 0), 1);

    /// <summary>
    /// Effects the specified emt.
    /// </summary>
    /// <param name="emt">The emt.</param>
    void Effect(EventManagerType emt)
    {
       
        switch (emt)
        {
            case  EventManagerType.FISHEYEBUMP:
                StartCoroutine(StartToFisheye());
                break;

            case EventManagerType.DASH:
                StartCoroutine(Dash());
                break;
        }

    }

    void FOVEffect(ShipMoveBehavior m_Ship)
    {

            float objective;
            if (m_Ship.m_IsMoving && !m_Ship.m_Down)
            {
                objective = 65;
            }
            else
            {
                objective = 60;
            }
            
            objective += ((m_Ship.m_Ship.m_CSpeed - 100) * 0.025f);
        //StartCoroutine(ChangeFOV(objective));
        ChangeFOV(objective);


    }

    void ChangeFOV(float goal)
    {
        if (goal > m_Camera.fieldOfView)
        {
                m_Camera.fieldOfView += gap;
        }
        else
        { 
                m_Camera.fieldOfView -= gap;
        }

    }

    /*
    IEnumerator ChangeFOV(float goal)
    {
        float gap = 0.001f;

        if (goal > m_Camera.fieldOfView)
        {
            while(m_Camera.fieldOfView< goal)
            {
                m_Camera.fieldOfView += gap;
                yield return new WaitForSeconds(0.001f);
            }
        }
        else
        {
            while (m_Camera.fieldOfView> goal)
            {
                m_Camera.fieldOfView -= gap;
                yield return new WaitForSeconds(0.001f);
            }

        }

    }
    */

    /// <summary>
    /// Starts to fisheye.
    /// </summary>
    /// <returns></returns>
    IEnumerator StartToFisheye()
    {

        fisheye.enabled = true;
        /*
        yield return new WaitForSeconds(0.3f);

        fisheye.enabled = false;
        */
        float fade=0;
        while(fade<0.3f)
        {
            fade += 0.07f;
            fisheye.strengthX = fade;
            fisheye.strengthY = fade;
            yield return new WaitForSeconds(0.0001f);
        }

        while (fade > 0.0f)
        {
            fade -= 0.07f;
            fisheye.strengthX = fade;
            fisheye.strengthY = fade;
            yield return new WaitForSeconds(0.0001f);
        }
        fisheye.enabled = false;
        fisheye.strengthX = 0;
        fisheye.strengthY = 0;
        yield return null;
         
    }

    IEnumerator Dash()
    {

        fisheye.enabled = false;
        fisheye.strengthX = 0;
        fisheye.strengthY = 0;

        fisheye.enabled = true;
        float fade = 0;

        while (fade < 0.5f)
        {
            fade += 0.005f;
            fisheye.strengthX = -1 * fade;
            //fisheye.strengthY = fade;
            yield return new WaitForSeconds(0.0001f);
        }

        while (fade > 0.0f)
        {
            fade -= 0.07f;
            fisheye.strengthX = -1 *fade;
            //fisheye.strengthY = fade;
            yield return new WaitForSeconds(0.0001f);
        }


    }

}
