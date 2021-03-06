﻿using UnityEngine;
using System.Collections;


public class ColonieSystem : MonoBehaviour {

    int m_GreenShipNear;
    int m_OrangeShipNear;

    [HideInInspector]
    public Colonie m_Colonie;

    // Use this for initialization
    void Start()
    {
        m_Colonie = transform.parent.GetComponent<Colonie>();
        m_GreenShipNear = 0;
        m_OrangeShipNear = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Ship>().m_IsGreen)
            {
                m_GreenShipNear++;
            }
            else
            {
                m_OrangeShipNear++;
            }
            ConquestCalcul();
        }
        if (other.tag == "Mousse")
        {
            if (other.gameObject.GetComponent<Mousse>().m_IsGreen)
            {
                m_GreenShipNear++;
            }
            else
            {
                m_OrangeShipNear++;
            }
            ConquestCalcul();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (m_Colonie.m_IsNeutre == false)
        {
            if (other.tag == "Player")
            {
                Ship m_ship = other.gameObject.GetComponent<Ship>();
                if (m_Colonie.m_IsGreen == m_ship.m_IsGreen)
                {

                    if (m_Colonie.m_ColonieFortification.m_IsInConstruction == false)
                    {
                        if (m_Colonie.m_ColonieLevel < 5)
                        {
                            if (m_ship.m_ShipMaterialBehavior.CanLooseMaterial())
                            {
                                m_Colonie.m_ColonieFortification.StartConstruction();
                            }
                        }


                        else if (m_Colonie.m_ColonieLife < m_Colonie.m_ColonieMaxLife)
                        {
                            if (m_ship.m_ShipMaterialBehavior.CanLooseMaterial())
                            {
                                m_Colonie.m_ColonieLife = m_Colonie.m_ColonieMaxLife;
                            }
                        }
                    }
                }
            }

        }
       
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Ship>().m_IsGreen)
            {
                m_GreenShipNear--;
            }
            else
            {
                m_OrangeShipNear--;
            }
            ConquestCalcul();
        }
        if (other.tag == "Mousse")
        {
            if (other.gameObject.GetComponent<Mousse>().m_IsGreen)
            {
                m_GreenShipNear--;
            }
            else
            {
                m_OrangeShipNear--;
            }
            ConquestCalcul();
        }
    }

    void ConquestCalcul()
    {
        if(m_GreenShipNear == 0 ^ m_OrangeShipNear == 0)
        {
            //if the island is neutral OR not neutral and no life
            if(((m_Colonie.m_IsNeutre)|| (m_Colonie.m_IsNeutre == false)) && m_Colonie.m_ColonieLife == 0)
            {
                if(m_GreenShipNear>0)
                {
                    m_Colonie.m_IsGreen = true;
                    m_Colonie.m_IsOrange = false;
                }
                if(m_OrangeShipNear>0)
                {
                    m_Colonie.m_IsOrange = true;
                    m_Colonie.m_IsGreen = false;
                }

                m_Colonie.m_IsNeutre = false;
                m_Colonie.m_ColonieMaxLife = m_Colonie.m_ColonieFortification.m_CabaneLife;
                m_Colonie.m_ColonieLife = m_Colonie.m_ColonieMaxLife;
                m_Colonie.m_ColonieFortification.ConstructionFortificationGraphismes();
                m_Colonie.ActualizeUIColonisation();
            }
        }
    }

    public void TakeDamage(int damages)
    {
        if(m_Colonie.m_IsNeutre==false)
        {
            m_Colonie.m_ColonieLife -= damages;
            if(m_Colonie.m_ColonieLife<0)
            {
                m_Colonie.m_ColonieLife =0;
            }

            m_Colonie.ActualizeUIColonisation();
        }
    }


}


/*
 Colonie m_Colonie;

    int m_GreenShipNear;
    int m_OrangeShipNear;

    bool m_IsConquestLoading;

    public float counter;

    // Use this for initialization
    void Start ()
    {
        m_Colonie = transform.parent.GetComponent<Colonie>();
        m_GreenShipNear = 0;
        m_OrangeShipNear = 0;
        m_IsConquestLoading = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if(other.gameObject.GetComponent<Ship>().m_IsGreen)
            {
                m_GreenShipNear++;
            }
            else
            {
                m_OrangeShipNear++;
            }
            ConquestCalcul();
        }
        if (other.tag == "Mousse")
        {
            if (other.gameObject.GetComponent<Mousse>().m_IsGreen)
            {
                m_GreenShipNear++;
            }
            else
            {
                m_OrangeShipNear++;
            }
            ConquestCalcul();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<Ship>().m_IsGreen)
            {
                m_GreenShipNear--;
            }
            else
            {
                m_OrangeShipNear--;
            }
            ConquestCalcul();
        }
        if (other.tag == "Mousse")
        {
            if (other.gameObject.GetComponent<Mousse>().m_IsGreen)
            {
                m_GreenShipNear--;
            }
            else
            {
                m_OrangeShipNear--;
            }
            ConquestCalcul();
        }
    }

    void ConquestCalcul()
    {
      if(m_Colonie.m_ColonieLevel==0)
        {
            m_Colonie.m_Neutre = false;
            if (m_IsConquestLoading==false)
            {
                m_IsConquestLoading = true;
                StartCoroutine(CConquestLoading());
            }
        }
    }

    IEnumerator CConquestLoading()
    {
       while(m_GreenShipNear == 0 ^ m_OrangeShipNear ==0)
        {
            if (m_GreenShipNear > 0 && m_OrangeShipNear == 0)
            {
                m_Colonie.m_ColonisationLevel++;

                if(m_Colonie.m_ColonisationLevel<0)
                {
                    m_Colonie.m_ColonisationLevel = 0;
                }

                if(m_Colonie.m_ColonisationLevel >= 100)
                {
                    m_Colonie.m_ColonisationLevel = 100;
                    m_Colonie.m_IsGreen = true;
                    m_Colonie.m_IsOrange = false;

                    break;
                }
            }

            if (m_OrangeShipNear > 0 && m_GreenShipNear == 0)
            {
                if (m_Colonie.m_ColonisationLevel > 0)
                {
                    m_Colonie.m_ColonisationLevel = 0;
                }


                m_Colonie.m_ColonisationLevel--;
                if (m_Colonie.m_ColonisationLevel <= -100)
                {
                    m_Colonie.m_ColonisationLevel = -100;
                    m_Colonie.m_IsGreen = false;
                    m_Colonie.m_IsOrange = true;
                    

                    break;
                }
            }

            yield return new WaitForSeconds(0.1f);
            counter += 0.1f;
            m_Colonie.ActualizeUIColonisation();
        }

        m_Colonie.ActualizeUIColonisation();
        m_IsConquestLoading = false;

        //If the colonisation isn't over

        if ((m_Colonie.m_IsGreen && m_Colonie.m_ColonisationLevel<0)|| (m_Colonie.m_IsOrange && m_Colonie.m_ColonisationLevel > 0))
        {

        }


    }


    IEnumerator CConquestDecrease()
    {
        while (m_IsConquestLoading == false)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
*/