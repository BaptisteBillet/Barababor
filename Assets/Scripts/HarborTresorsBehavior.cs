using UnityEngine;
using System.Collections;

public class HarborTresorsBehavior : MonoBehaviour {

    public Harbor m_Harbor;
    //TRESOR METHODS

    #region Tresors
    public void AddTresor()
    {
        m_Harbor.m_TresorsHarbor++;
        m_Harbor.ActualizeUIHarbor();
    }

    public bool CanLooseTresor()
    {
        if (m_Harbor.m_TresorsHarbor > 0)
        {
            LooseTresor();
            return true;
        }
        return false;
    }

    void LooseTresor()
    {
        m_Harbor.m_TresorsHarbor--;
        m_Harbor.ActualizeUIHarbor();
    }
    #endregion

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Ship>().m_IsGreen != m_Harbor.m_IsGreen)
            {
                m_Harbor.m_Canon.AddToList(other.gameObject);
            }
        }
        if (other.tag == "Mousse")
        {
            if (other.gameObject.GetComponent<Mousse>().m_IsGreen != m_Harbor.m_IsGreen)
            {
                m_Harbor.m_Canon.AddToList(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
            if (other.tag == "Player")
            {
                if (other.gameObject.GetComponent<Ship>().m_IsGreen != m_Harbor.m_IsGreen)
                {
                    m_Harbor.m_Canon.RemoveFromList(other.gameObject);
                }

            }
            if (other.tag == "Mousse")
            {
                if (other.gameObject.GetComponent<Mousse>().m_IsGreen != m_Harbor.m_IsGreen)
                {
                    m_Harbor.m_Canon.RemoveFromList(other.gameObject);
                }
            }

   }



}
