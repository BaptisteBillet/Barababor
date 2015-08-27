using UnityEngine;
using System.Collections;

public class TimeOfPlay : MonoBehaviour {

    #region Singleton
    static private TimeOfPlay s_Instance;
    static public TimeOfPlay instance
    {
        get
        {
            return s_Instance;
        }
    }

    void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        //DontDestroyOnLoad(this);
    }
    #endregion

    public int seconds;
    public int minutes;
    public int hours;

    // Use this for initialization
    void Start ()
    {
        seconds = 0;
        minutes = 0;
        hours = 0;

        StartCoroutine(Clock());
	}
	
	IEnumerator Clock()
    {
        yield return new WaitForSeconds(1f);
        seconds++;
        if(seconds>59)
        {
            seconds = 0;

            minutes++;
            if(minutes>59)
            {
                minutes = 0;
                hours++;
            }

        }
    }

}
