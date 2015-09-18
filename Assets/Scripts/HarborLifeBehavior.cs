using UnityEngine;
using System.Collections;

public class HarborLifeBehavior : MonoBehaviour {

    public Harbor m_Harbor;

    public void TakeDamage(int damages)
    {
        m_Harbor.m_HarborLife -= damages;
        if(m_Harbor.m_HarborLife<0)
        {
            m_Harbor.m_HarborLife = 0;
        }
        m_Harbor.ActualizeUIHarbor();
        
    }


}
