﻿using UnityEngine;
using System.Collections;

/// <summary>
/// This class manage the play time
/// </summary>
public class TimeOfPlay : MonoBehaviour {

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

    /// <summary>
    /// This coroutine manage the time system
    /// </summary>
    /// <returns></returns>
    IEnumerator Clock()
    {
        while(this!=null)
        {
            yield return new WaitForSeconds(1f);
            seconds++;
            if (seconds > 59)
            {
                seconds = 0;

                minutes++;
                if (minutes > 59)
                {
                    minutes = 0;
                    hours++;
                }

            }
            //Actualise regulary the UI Clock
            UIManager.instance.ActualizeUIClock();
        }
       
    }

}
