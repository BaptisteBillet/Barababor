using UnityEngine;
using System.Collections;

public class ShipTresorBehavior : MonoBehaviour {

    Ship m_Ship;
    [HideInInspector]
    public float m_CooldownHullBreach;
    float m_Timer=0.1f;

    public GameObject m_TresorPrefab;

    public Transform m_EjectPosition;

    bool m_DropingTresor;
    float m_DelayForDroping=0.5f;

    bool m_ChargingTresor;
    float m_DelayForCharging = 0.5f;

    // Use this for initialization
    void Start ()
    {
        m_Ship = GetComponent<Ship>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tresor")
        {
            if (m_Ship.m_CCapacity < m_Ship.m_CCapacityBase)
            {
                AddTresor();
                Destroy(other.transform.parent.gameObject);
            }
        }
    }


    public void AddTresor()
    {
        if (m_Ship.m_CCapacity<m_Ship.m_CCapacityBase)
        {
            m_Ship.m_CCapacity++;
            UIManager.instance.UITresor();
        }
    }

    public void LooseTresor()
    {
        if (m_Ship.m_CCapacity > 0)
        {
            Instantiate(m_TresorPrefab, m_EjectPosition.position, m_TresorPrefab.transform.rotation);
            m_Ship.m_CCapacity--;
            UIManager.instance.UITresor();
        }
    }

    public void LooseAllTresor()
    {
        while(m_Ship.m_CCapacity>0)
        {
            LooseTresor();
        }
    }

    public void DeliverTresor()
    {
        UIManager.instance.UITresor();
    }

    public void HullBreach(float time)
    {
        StartCoroutine(CHullBreach(time));
    }

    IEnumerator CHullBreach(float time)
    {
        m_CooldownHullBreach = time;
        float delay = 0;
        while (m_CooldownHullBreach > 0)
        {
            yield return new WaitForSeconds(m_Timer);
            m_CooldownHullBreach -= m_Timer;
            delay += m_Timer;

            if (delay >= 1)
            {
                delay = 0;

                LooseTresor();
            }

        }
    }


    void Update()
    {
       
        //DPad Haut
        if (Input.GetAxis("DPad_YAxis_1") < 0 || Input.GetKey(KeyCode.C))
        {
            if (m_Ship.m_NearFromHomeHarbor)
            {
                if (m_ChargingTresor == false)
                {
                    m_ChargingTresor = true;
                    AddTresor();
                    StartCoroutine(CChargingTresor());
                }
            }
        }
        else
        {
            m_ChargingTresor = false;
        }
        //DPad Bas
        if (Input.GetAxis("DPad_YAxis_1") > 0 || Input.GetKey(KeyCode.V))
        {
           
                if (m_DropingTresor == false)
                {
                    m_DropingTresor = true;
                    LooseTresor();
                    StartCoroutine(CDropingTresor());
                }
        }
        else
        {
            m_DropingTresor = false;
        }

    }

    IEnumerator CDropingTresor()
    {
        yield return new WaitForSeconds(m_DelayForCharging);
        while (m_DropingTresor && m_Ship.m_CCapacity > 0)
        {
            LooseTresor();
            yield return new WaitForSeconds(m_DelayForDroping);
           
        }
    }

    IEnumerator CChargingTresor()
    {
        yield return new WaitForSeconds(m_DelayForCharging);
        while (m_ChargingTresor && m_Ship.m_CCapacity < m_Ship.m_CCapacityBase && m_Ship.m_NearFromHomeHarbor)
        {
            AddTresor();
            yield return new WaitForSeconds(m_DelayForCharging);
            
        }
    }

}
