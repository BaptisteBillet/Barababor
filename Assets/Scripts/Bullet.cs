using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public bool m_SelfDirected;
    public int m_Damages;

    public GameObject m_Cible;

    Rigidbody m_Rigidbody;

    Vector3 m_InitialPosition;
    
    float m_SpeedOfBullet = 50f;
    float m_StartTime = Time.time;
    float m_JourneyLength;
    
    /*
    public Transform sunrise;
    public Transform sunset;
    public float journeyTime = 1.0F;
    private float startTime;
    */

    // Use this for initialization
    void Start()
    {
        m_Rigidbody=GetComponent<Rigidbody>();
        m_InitialPosition = this.transform.position;
        /*
        m_Direction = transform.localPosition;
        m_Direction = m_Direction.normalized;
        */

        
        m_StartTime = Time.time;
        m_JourneyLength = Vector3.Distance(m_InitialPosition, m_Cible.transform.position);
        

        /*
        sunrise= this.transform;
        sunset = m_Cible.transform;
        startTime = Time.time;
        */
    }

    void Update()
    {
        
        //m_Rigidbody.velocity += m_Direction * 10;
        float distCovered = (Time.time - m_StartTime) * m_SpeedOfBullet;
        float fracJourney = distCovered / m_JourneyLength;
        transform.position = Vector3.Lerp(m_InitialPosition, m_Cible.transform.position, fracJourney);
        
        /*
        Vector3 center = (sunrise.position + sunset.position) * 0.5F;
        center -= new Vector3(0, 1, 0);
        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;
        float fracComplete = (Time.time - startTime) / journeyTime;
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
        */

    }


    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Ship>().m_ShipStateAndDamageBehavior.TakeDamage(m_Damages);
            DestroyMe();
        }
        /*
        if (other.tag == "Colonie")
        {
            DestroyMe();
        }
        if (other.tag == "Harbor")
        {
            DestroyMe();
        }

        if (other.tag == "Sea")
        {
            DestroyMe();
        }
        */
    }

    void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
