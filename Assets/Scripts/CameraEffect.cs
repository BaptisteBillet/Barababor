using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class CameraEffect : MonoBehaviour
{
    #region Members
    private Fisheye fisheye;
    #endregion


    // Use this for initialization
    void Start()
    {
		
		CameraEventManager.onEvent += Effect;

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
        }

    }



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


}
