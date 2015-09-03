using UnityEngine;
using System.Collections;

public class ColonieFortification : MonoBehaviour {

    Colonie m_Colonie;

    // Use this for initialization
    void Start ()
    {
        m_Colonie = transform.parent.GetComponent<Colonie>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
