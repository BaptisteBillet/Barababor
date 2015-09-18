using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Cardinal
{
    North,
    South,
    East,
    West
}


public class ShipEffectsBehavior : MonoBehaviour {

    public GameObject[] m_ArrayOfCanons = new GameObject[17];

    GameObject[] m_ArrayOfCanonsForward = new GameObject[3];
    GameObject[] m_ArrayOfCanonsBack = new GameObject[6];
    GameObject[] m_ArrayOfCanonsLeft = new GameObject[5];
    GameObject[] m_ArrayOfCanonsRight = new GameObject[5];

    ShipCanonParticule m_ShipCanonParticule;

    Ship m_Ship;

    int[] m_DegreeReference = new int[18];

    // Use this for initialization
    void Start()
    {
        m_Ship = GetComponent<Ship>();

        #region Degree Reference
        m_DegreeReference[0] = 0;
        m_DegreeReference[1] = 30;
        m_DegreeReference[2] = 60;
        m_DegreeReference[3] = 90;
        m_DegreeReference[4] = 106;
        m_DegreeReference[5] = 122;
        m_DegreeReference[6] = 138;
        m_DegreeReference[7] = 154;
        m_DegreeReference[8] = 170;
        m_DegreeReference[9] = 190;
        m_DegreeReference[10] = 206;
        m_DegreeReference[11] = 222;
        m_DegreeReference[12] = 238;
        m_DegreeReference[13] = 254;
        m_DegreeReference[14] = 270;
        m_DegreeReference[15] = 300;
        m_DegreeReference[16] = 330;
        //m_DegreeReference[17] = 360;
        #endregion

        //Forward
        m_ArrayOfCanonsForward[0] = m_ArrayOfCanons[16];
        m_ArrayOfCanonsForward[1] = m_ArrayOfCanons[0];
        m_ArrayOfCanonsForward[2] = m_ArrayOfCanons[1];

        //Back
        m_ArrayOfCanonsBack[0] = m_ArrayOfCanons[11];
        m_ArrayOfCanonsBack[1] = m_ArrayOfCanons[10];
        m_ArrayOfCanonsBack[2] = m_ArrayOfCanons[9];
        m_ArrayOfCanonsBack[3] = m_ArrayOfCanons[8];
        m_ArrayOfCanonsBack[4] = m_ArrayOfCanons[7];
        m_ArrayOfCanonsBack[5] = m_ArrayOfCanons[6];

        //Left
        m_ArrayOfCanonsLeft[0] = m_ArrayOfCanons[12];
        m_ArrayOfCanonsLeft[1] = m_ArrayOfCanons[13];
        m_ArrayOfCanonsLeft[2] = m_ArrayOfCanons[14];
        m_ArrayOfCanonsLeft[3] = m_ArrayOfCanons[15];
        m_ArrayOfCanonsLeft[4] = m_ArrayOfCanons[16];

        //Right
        m_ArrayOfCanonsRight[0] = m_ArrayOfCanons[5];
        m_ArrayOfCanonsRight[1] = m_ArrayOfCanons[4];
        m_ArrayOfCanonsRight[2] = m_ArrayOfCanons[3];
        m_ArrayOfCanonsRight[3] = m_ArrayOfCanons[2];
        m_ArrayOfCanonsRight[4] = m_ArrayOfCanons[1];
    }


    public void ShootWhithCanon(Cardinal cardinal)
    {
        List<int> m_ListOfCanonToShoot = new List<int>();
        switch (cardinal)
        {
            case Cardinal.North:
                m_ListOfCanonToShoot.Add(0);
                m_ListOfCanonToShoot.Add(1);
                m_ListOfCanonToShoot.Add(16);
                break;
            case Cardinal.East:
                m_ListOfCanonToShoot.Add(1);
                m_ListOfCanonToShoot.Add(2);
                m_ListOfCanonToShoot.Add(3);
                m_ListOfCanonToShoot.Add(4);
                m_ListOfCanonToShoot.Add(5);
                break;
            case Cardinal.South:
                m_ListOfCanonToShoot.Add(6);
                m_ListOfCanonToShoot.Add(7);
                m_ListOfCanonToShoot.Add(8);
                m_ListOfCanonToShoot.Add(9);
                m_ListOfCanonToShoot.Add(10);
                m_ListOfCanonToShoot.Add(11);
                break;
            case Cardinal.West:
                m_ListOfCanonToShoot.Add(12);
                m_ListOfCanonToShoot.Add(13);
                m_ListOfCanonToShoot.Add(14);
                m_ListOfCanonToShoot.Add(15);
                m_ListOfCanonToShoot.Add(16);
                break;
        }

        Action(m_ListOfCanonToShoot);
    }

    public void ShootWhithCanon()
    {
        List<int> m_ListOfCanonToShoot = new List<int>();
        m_ListOfCanonToShoot.Add(0);
        m_ListOfCanonToShoot.Add(1);
        m_ListOfCanonToShoot.Add(2);
        m_ListOfCanonToShoot.Add(3);
        m_ListOfCanonToShoot.Add(4);
        m_ListOfCanonToShoot.Add(5);
        m_ListOfCanonToShoot.Add(6);
        m_ListOfCanonToShoot.Add(7);
        m_ListOfCanonToShoot.Add(8);
        m_ListOfCanonToShoot.Add(9);
        m_ListOfCanonToShoot.Add(10);
        m_ListOfCanonToShoot.Add(11);
        m_ListOfCanonToShoot.Add(12);
        m_ListOfCanonToShoot.Add(13);
        m_ListOfCanonToShoot.Add(14);
        m_ListOfCanonToShoot.Add(15);
        m_ListOfCanonToShoot.Add(16);

        Action(m_ListOfCanonToShoot);
    }

    void ShootWhithCanon(int number, bool group)
    {
        List<int> m_ListOfCanonToShoot = new List<int>();

        m_ListOfCanonToShoot.Add(number);

        if(group)
        {
            //2 more up
            if (number + 1 > 16)
            {
                m_ListOfCanonToShoot.Add(0);
                m_ListOfCanonToShoot.Add(1);
            }
            else
            {
                if (number + 2 > 16)
                {
                    m_ListOfCanonToShoot.Add(16);
                    m_ListOfCanonToShoot.Add(0);
                }
                else
                {
                    m_ListOfCanonToShoot.Add(number + 1);
                    m_ListOfCanonToShoot.Add(number + 2);
                }
            }

            //2 more down
            if (number - 1 < 0)
            {
                m_ListOfCanonToShoot.Add(16);
                m_ListOfCanonToShoot.Add(15);
            }
            else
            {
                if (number - 2 < 0)
                {
                    m_ListOfCanonToShoot.Add(16);
                    m_ListOfCanonToShoot.Add(0);
                }
                else
                {
                    m_ListOfCanonToShoot.Add(number - 1);
                    m_ListOfCanonToShoot.Add(number - 2);
                }
            }


        }

        Action(m_ListOfCanonToShoot);
    }

    public void ShootWhithCanon(float degree, bool group)
    {
        List<int> m_ListOfCanonToShoot = new List<int>();

        for (int i=1; i<m_DegreeReference.Length;i++)
        {
            if(degree>= m_DegreeReference[i-1] && degree <= m_DegreeReference[i])
            {
                ShootWhithCanon(i, group);
                break;
            }
        }
    }

    void Action(List<int> m_ListOfCanonToShoot)
    {
        foreach (int i in m_ListOfCanonToShoot)
        {
            m_ArrayOfCanons[i].GetComponentInChildren<ShipCanonParticule>().UseCanon();
        }

        m_ListOfCanonToShoot.Clear();
    }

}
