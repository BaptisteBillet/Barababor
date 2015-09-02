using UnityEngine;
using System.Collections;

public class StateBox : MonoBehaviour {

    [Space(10)]
    public bool BOOSTED;
    public int Value0;
    public float Time0;
    [Space(10)]
    public bool SLOWED;
    public int Value1;
    public float Time1;[Space(10)]
    public bool UNSINKABLE;
    public int Value2;
    public float Time2;[Space(10)]
    public bool CONSOLIDATED;
    public int Value3;
    public float Time3;[Space(10)]
    public bool SHIELD;
    public int Value4;
    public float Time4;[Space(10)]
    public bool WEAKENED;
    public int Value5;
    public float Time5;[Space(10)]
    public bool ORGANIZED;
    public int Value6;
    public float Time6;[Space(10)]
    public bool CLUTTERED;
    public int Value7;
    public float Time7;[Space(10)]
    public bool CLAIRVOYANT;
    public int Value8;
    public float Time8;[Space(10)]
    public bool DAZZLED;
    public int Value9;
    public float Time9;[Space(10)]
    public bool INSENTIENT;
    public int Value10;
    public float Time10;[Space(10)]
    public bool REFURBISHMENT;
    public int Value11;
    public float Time11;[Space(10)]
    public bool STRIKE;
    public int Value12;
    public float Time12;[Space(10)]
    public bool ZEAL;
    public int Value13;
    public float Time13;[Space(10)]
    public bool WARHUNGRY;
    public int Value14;
    public float Time14;[Space(10)]
    public bool PACIFIST;
    public int Value15;
    public float Time15;[Space(10)]
    public bool CEASEFIRE;
    public int Value16;
    public float Time16;[Space(10)]
    public bool ONFIRE;
    public int Value17;
    public float Time17;[Space(10)]
    public bool HULLBREACH;
    public int Value18;
    public float Time18;[Space(10)]
    public bool LOCKED;
    public int Value19;
    public float Time19;[Space(10)]
    public bool DAMN;
    public int Value20;
    public float Time20;[Space(10)]
    public bool REPAIR;
    public int Value21;
    public float Time21;[Space(10)]
    public bool TERMITE;
    public int Value22;
    public float Time22;
    [Space(10)]
    public int m_Damages;
    [Space(10)]
    public int m_Experiences;
    [Space(10)]
    public int m_Leveling;

    private bool[] ArrayOfBool = new bool[23];


    public GameObject go_State;
    State sb_State;

    void Start()
    {
        sb_State = go_State.GetComponent<State>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Ship m_Ship = other.gameObject.GetComponent<Ship>();
            //Damages
            if(m_Damages>0)
            {
                m_Ship.m_ShipStateAndDamageBehavior.TakeDamage(m_Damages);
            }
            //Experiences
            if (m_Experiences > 0)
            {
                m_Ship.m_ShipLevelingBehavior.AddExperience(m_Experiences);
            }
            //Level
            if(m_Leveling>0)
            {
                for(int i=m_Leveling;i>0;i--)
                {
                    m_Ship.m_ShipLevelingBehavior.LevelUp(0);
                }
                
            }
            //States
            for (int i=0; i<ArrayOfBool.Length;i++)
            {
                if (ArrayOfBool[i] == true)
                {
                    #region Establishement
                    switch (i)
                    {
                        case 0:                                                              
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.BOOSTED;                
                            sb_State.m_Value = Value0;                        
                            sb_State.m_Time = Time0;                          
                            break;                                           
                                                                             
                        case 1 :                                             
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.SLOWED;                 
                            sb_State.m_Value = Value1;
                            sb_State.m_Time = Time1;                          
                            break;                                           
                                                                             
                        case 2 :                                             
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.UNSINKABLE;             
                            sb_State.m_Value = Value2;                        
                            sb_State.m_Time = Time2;                          
                            break;                                           
                                                                             
                        case 3 :                                             
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.CONSOLIDATED;           
                            sb_State.m_Value = Value3;                        
                            sb_State.m_Time = Time3;                          
                            break;                                           
                                                                             
                        case 4 :
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.SHIELD;
                            sb_State.m_Value = Value4;
                            sb_State.m_Time = Time4;
                            break;

                        case 5 :
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.WEAKENED;
                            sb_State.m_Value = Value5;
                            sb_State.m_Time = Time5;
                            break;

                        case 6 :
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.ORGANIZED;
                            sb_State.m_Value = Value6;
                            sb_State.m_Time = Time6;
                            break;

                        case 7 :
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.CLUTTERED;
                            sb_State.m_Value = Value7;
                            sb_State.m_Time = Time7;
                            break;

                        case 8 :
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.CLAIRVOYANT;
                            sb_State.m_Value = Value8;
                            sb_State.m_Time = Time8;
                            break;

                        case 9 :
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.DAZZLED;
                            sb_State.m_Value = Value9;
                            sb_State.m_Time = Time9;
                            break;

                        case 10:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.INSENTIENT;
                            sb_State.m_Value = Value10;
                            sb_State.m_Time = Time10;
                            break;

                        case 11:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.REFURBISHMENT;
                            sb_State.m_Value = Value11;
                            sb_State.m_Time = Time11;
                            break;

                        case 12:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.STRIKE;
                            sb_State.m_Value = Value12;
                            sb_State.m_Time = Time12;
                            break;

                        case 13:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.ZEAL;
                            sb_State.m_Value = Value13;
                            sb_State.m_Time = Time13;
                            break;

                        case 14:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.WARHUNGRY;
                            sb_State.m_Value = Value14;
                            sb_State.m_Time = Time14;
                            break;

                        case 15:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.PACIFIST;
                            sb_State.m_Value = Value15;
                            sb_State.m_Time = Time15;
                            break;

                        case 16:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.CEASEFIRE;
                            sb_State.m_Value = Value16;
                            sb_State.m_Time = Time16;
                            break;

                        case 17:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.ONFIRE;
                            sb_State.m_Value = Value17;
                            sb_State.m_Time = Time17;
                            break;

                        case 18:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.HULLBREACH;
                            sb_State.m_Value = Value18;
                            sb_State.m_Time = Time18;
                            break;

                        case 19:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.LOCKED;
                            sb_State.m_Value = Value19;
                            sb_State.m_Time = Time19;
                            break;

                        case 20:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.DAMN;
                            sb_State.m_Value = Value20;
                            sb_State.m_Time = Time20;
                            break;

                        case 21:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.REPAIR;
                            sb_State.m_Value = Value21;
                            sb_State.m_Time = Time21;
                            break;

                        case 22:
                            sb_State.m_State = ShipStateAndDamageBehavior.EState.TERMITE;
                            sb_State.m_Value = Value22;
                            sb_State.m_Time = Time22;
                            break;
                    }

                    #endregion


                    m_Ship.m_ShipStateAndDamageBehavior.AddState(go_State);
                }

            }
            



            Destroy(transform.parent.gameObject);
        }
    }

    void Update()
    {
        ArrayOfBool[0]=  BOOSTED;
        ArrayOfBool[1]=  SLOWED;
        ArrayOfBool[2]=  UNSINKABLE;
        ArrayOfBool[3]=  CONSOLIDATED;
        ArrayOfBool[4]=  SHIELD;     
        ArrayOfBool[5]=  WEAKENED;
        ArrayOfBool[6]=  ORGANIZED;
        ArrayOfBool[7]=  CLUTTERED;
        ArrayOfBool[8]=  CLAIRVOYANT;
        ArrayOfBool[9]=  DAZZLED;
        ArrayOfBool[10]= INSENTIENT;
        ArrayOfBool[11]= REFURBISHMENT;
        ArrayOfBool[12]= STRIKE;
        ArrayOfBool[13]= ZEAL;
        ArrayOfBool[14]= WARHUNGRY;
        ArrayOfBool[15]= PACIFIST;
        ArrayOfBool[16]= CEASEFIRE;
        ArrayOfBool[17]= ONFIRE;
        ArrayOfBool[18]= HULLBREACH;
        ArrayOfBool[19]= LOCKED;
        ArrayOfBool[20]= DAMN;
        ArrayOfBool[21]= REPAIR;
        ArrayOfBool[22]= TERMITE;

    }

}
