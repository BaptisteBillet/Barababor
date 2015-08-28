using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Harbor : MonoBehaviour {

    //Members
    public bool m_IsHarborBlue;

    public Vector3[] m_SpawnList = new Vector3[5];

    public const int m_ValueOfHeal=5;
    public const float m_TimeOfHeal = 0.20f;

	// Use this for initialization
	void Start () {
	
	}
	
    IEnumerator Heal()
    {
        while(true)//is in contact
        {
            State HarborHeal = new State();
            HarborHeal.m_State = Ship.EState.REPAIR;
            //HarborHeal.m_Ship = this;
            HarborHeal.m_Time = m_TimeOfHeal;
            HarborHeal.m_Value = m_ValueOfHeal;
            //AddState()

            yield return new WaitForSeconds(m_TimeOfHeal);
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
