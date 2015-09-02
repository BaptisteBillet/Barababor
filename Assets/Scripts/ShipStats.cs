using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShipStats : ScriptableObject {

    #region Singleton
    static private ShipStats s_Instance;
    static public ShipStats instance
    {
        get
        {
            return s_Instance;
        }
    }

    void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
        //DontDestroyOnLoad(this);
    }
    #endregion


    public int m_CounterBOOSTED;
    public int m_CounterSLOWED;
    public int m_CounterUNSINKABLE;
    public int m_CounterCONSOLIDATED;
    public int m_CounterSHIELD;
    public int m_CounterWEAKENED;
    public int m_CounterORGANIZED;
    public int m_CounterCROWDED;
    public int m_CounterCLAIRVOYANT;
    public int m_CounterDAZZLED;
    public int m_CounterINSENSIBLE;
    public int m_CounterREFURBISHMENT;
    public int m_CounterSTRIKE;
    public int m_CounterZEAL;
    public int m_CounterMANGY;
    public int m_CounterPACIFIST;
    public int m_CounterCEASEFIRE;
    public int m_CounterINFIRE;
    public int m_CounterHULLBREACH;
    public int m_CounterLOCKED;
    public int m_CounterDAMN;
    public int m_CounterREPAIR;
    public int m_CounterTERMITE;
 
    public int m_TimeOfMove;





}
