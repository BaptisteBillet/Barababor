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

    void OnDestroy()
    {
		CameraEventManager.onEvent -= Effect;
    }


    // iTween.ShakePosition(gameObject, new Vector3(1, 1, 0), 1);
    void Effect(EventManagerType emt)
    {
       
        switch (emt)
        {
            case  EventManagerType.FISHEYEBUMP:
                StartCoroutine(fisheyemanager());
                break;
        }

    }


	IEnumerator fisheyemanager()
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
