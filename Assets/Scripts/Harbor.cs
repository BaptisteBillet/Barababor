using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Harbor : MonoBehaviour {

    //Members
    public bool m_IsHarborBlue;

    public Vector3[] m_SpawnList = new Vector3[5];

    public const int m_ValueOfHeal=5;
    public const float m_TimeOfHeal = 0.20f;

    Renderer m_ParentMaterial;
    public Material m_Blue;
    public Material m_Purple;

    public int m_TresorsNumbers;


    // Use this for initialization
    void Start () {

        //Graphismes
        m_ParentMaterial = transform.parent.GetComponent<Renderer>();
        if(m_IsHarborBlue)
        {
            m_ParentMaterial.material = m_Blue;
        }
        else
        {
            m_ParentMaterial.material = m_Purple;
        }
	}
}
