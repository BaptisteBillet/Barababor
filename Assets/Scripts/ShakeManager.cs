using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShakeManager : MonoBehaviour {
    #region Singleton
    static private ShakeManager s_Instance;
    static public ShakeManager instance
    {
        get
        {
            return s_Instance;
        }
    }

    void Awake()
    {
        mainCamera = Camera.main;
        if (s_Instance == null)
            s_Instance = this;
        //DontDestroyOnLoad(this);
    }
    #endregion

    #region members
    private float shakeAmt;
    public Camera mainCamera;

    private bool shake_up;
    private bool shake_left;

    public Image douleur;

    public Image flash;

    Color alphachange;
    Color alphachange_flash;

    int alerte = 20;
    #endregion

    public void ShakeCamera(float second=10, int horizontalForce=1, int verticalForce=1)
    {
        iTween.ShakeRotation(gameObject, new Vector3(horizontalForce, verticalForce, 0), second);
        //iTween.ShakePosition(gameObject, new Vector3(horizontalForce, verticalForce, 0), second);
    }

    public void LetsShake(bool rouge,float relative = 100, bool _shake_up = true, bool _shake_left = true)
    {
        
        /*
        shake_up=_shake_up;
        shake_left=_shake_left;
        
        if(rouge==true)
        {
            StartCoroutine(douleurflashonce());
        }

        shakeAmt = relative * .0025f;
        
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);
        */

    }

    public void LetsShakeLife(Ship ship, float relative = 20)
    {
        StartCoroutine(LetsShakeLifeCoroutine(ship,relative));
        
        StartCoroutine(douleurflash(ship));
    }

    IEnumerator douleurflashonce()
    {
        alphachange_flash = flash.color;
        alphachange_flash.a = 0f;
        flash.color = alphachange_flash;
        flash.enabled = true;

        alphachange_flash.a = 1f;
        flash.color = alphachange_flash;

        while (alphachange_flash.a > 0.0f)
        {
            alphachange_flash.a -= 0.01f;
            flash.color = alphachange_flash;
            yield return new WaitForSeconds(0.01f);
        }
        flash.enabled = false;
    }

    IEnumerator douleurflash (Ship ship)
    {
        alphachange = douleur.color;
        alphachange.a = 0f;
        douleur.color = alphachange;
        douleur.enabled = true;


        while (douleur.color.a < 0.8f)
        {
            alphachange.a += 0.01f;
            douleur.color = alphachange;
            yield return new WaitForSeconds(0.01f);
        }
        
        while (((ship.m_CHealthPoint*100)/ship.m_CHealthPointBase) < alerte)
        {
            while (douleur.color.a > 0.2f)
            {
                alphachange.a -= 0.01f;
                douleur.color = alphachange;
                yield return new WaitForSeconds(0.01f);

            }
            while (douleur.color.a < 0.8f)
            {
                alphachange.a += 0.01f;
                douleur.color = alphachange;
                yield return new WaitForSeconds(0.01f);
            }

        }

        while (douleur.color.a > 0)
        {
            alphachange.a -= 0.01f;
            douleur.color = alphachange;
            yield return new WaitForSeconds(0.01f);
        }

        douleur.enabled = false;

    }

    IEnumerator LetsShakeLifeCoroutine(Ship ship, float relative = 20)
    {
        shake_up = true;
        shake_left = true;

        shakeAmt = relative * .0025f;

        while ((ship.m_CHealthPoint * 100 / ship.m_CHealthPointBase) <= alerte)
        {

            InvokeRepeating("CameraShake", 0, .01f);
            Invoke("StopShaking", 0.3f);
            yield return new WaitForSeconds(2);
        }

        //ship.alertelaunched = false;
    }

    void CameraShake()
    {

        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            if(shake_up)
            {
                pp.y += quakeAmt;
            }
            if(shake_left)
            {
                pp.x += quakeAmt;
            }
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
		mainCamera.transform.position = new Vector3(0, 0, -10);
    }

}
