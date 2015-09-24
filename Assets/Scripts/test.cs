using UnityEngine;
using System.Collections;

/// <summary>
/// The famous and unique Test class
/// </summary>
public class test : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Debug.Log(TriDataBase.instance.m_BowDico["Proue"].m_Name);	
        //Debug.Log(TriDataBase.instance.ReturnInfo(TriDataBase.Dico.BowDico, "Proue").m_Name);
	}

}
