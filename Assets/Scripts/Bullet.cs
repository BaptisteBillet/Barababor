using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public bool m_SelfDirected;
    public int m_Damages;

    public GameObject m_Cible;

    public bool m_IsGreen;
    public bool m_IsNeutral;

    [HideInInspector]
    public float m_SpeedOfBullet = 50f;

    public bool m_AsAState;

    public ShipStateAndDamageBehavior.EState m_State;
    public int m_StateValue;
    public float m_StateTime;

    public float m_MoveSpeed;

    //Self Directed0
    Vector3 m_InitialPosition;
    Rigidbody m_Rigidbody;
    float m_StartTime = Time.time;
    float m_JourneyLength;

    // Use this for initialization
    void Start()
    {
        m_Rigidbody=GetComponent<Rigidbody>();
        m_InitialPosition = this.transform.position;
        

        

        if (m_SelfDirected)
        {
            m_StartTime = Time.time;
            m_JourneyLength = Vector3.Distance(m_InitialPosition, m_Cible.transform.position);
        }
      
    }

    void Update()
    {
       if (m_SelfDirected)
            {
                if (m_Cible != null)
                {
                    float distCovered = (Time.time - m_StartTime) * m_SpeedOfBullet;
                    float fracJourney = distCovered / m_JourneyLength;

                    if (m_Cible != null)
                    {
                        transform.position = Vector3.Lerp(m_InitialPosition, m_Cible.transform.position, fracJourney);
                    }
                    else
                    {
                        DestroyMe();
                    }
                }
                else
                {
                    DestroyMe();
                }
            }
            else
            {
                m_Rigidbody.velocity = transform.forward * m_MoveSpeed;
            }
        
        
    }


    protected void DestroyMe()
    {

        Destroy(this.gameObject);
    }
}
