using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : Object {

    public int m_Level;
    public int m_LevelUp;
    public string m_Name;
    public int m_Damage;
    public int m_DamageUpgrade;
    public float m_Range;
    public float m_RangeUpgrade;
    public float m_Width;
    public float m_WidthUpgrade; 
    public int m_Cooldown;
    public int m_CooldownUpgrade;
    public int m_ShootType;
    public int m_ShootTypeUpgrade;
    public int m_Cost;
    public string m_Grade;
    public string m_Rank;
    public string m_State1;
    public string m_State2;
    public string m_Description;
    public string m_Type;
    public string m_ShownName;

    public WeaponList m_Weapon;

    void Start()
    {
        string name="";

        switch(m_Weapon)
        {
            case WeaponList.LeBonVieuxCanonDesFamilles:
                name = "LeBonVieuxCanonDesFamilles";
                break;
            case WeaponList.SalveDePetitPlomb:
                name = "SalveDePetitPlomb";
                break;
            case WeaponList.LourdParpaingDeDureRealite:
                name = "LourdParpaingDeDureRealite";
                break;
        }

        if(name!="")
        {
            FillEquipment(name);
        }

    }

    void FillEquipment(string name )
    {
        m_Level = TriDataBase.instance.m_WeaponDico[name].m_Level;
        m_LevelUp = TriDataBase.instance.m_WeaponDico[name].m_LevelUp;                 
        m_Name = TriDataBase.instance.m_WeaponDico[name].m_Name;
        m_Damage = TriDataBase.instance.m_WeaponDico[name].m_Damage;
        m_DamageUpgrade = TriDataBase.instance.m_WeaponDico[name].m_DamageUpgrade;
        m_Range = TriDataBase.instance.m_WeaponDico[name].m_Range;
        m_RangeUpgrade = TriDataBase.instance.m_WeaponDico[name].m_RangeUpgrade;
        m_Cooldown = TriDataBase.instance.m_WeaponDico[name].m_Cooldown;
        m_CooldownUpgrade = TriDataBase.instance.m_WeaponDico[name].m_CooldownUpgrade;
        m_ShootType = TriDataBase.instance.m_WeaponDico[name].m_ShootType;
        m_ShootTypeUpgrade = TriDataBase.instance.m_WeaponDico[name].m_ShootTypeUpgrade;
        m_Cost = TriDataBase.instance.m_WeaponDico[name].m_Cost;
        m_Grade = TriDataBase.instance.m_WeaponDico[name].m_Grade;
        m_Rank = TriDataBase.instance.m_WeaponDico[name].m_Rank;
        m_State1 = TriDataBase.instance.m_WeaponDico[name].m_State1;
        m_State2 = TriDataBase.instance.m_WeaponDico[name].m_State2;
        m_Description = TriDataBase.instance.m_WeaponDico[name].m_Description;
        m_Type = TriDataBase.instance.m_WeaponDico[name].m_Type;
        m_ShownName = TriDataBase.instance.m_WeaponDico[name].m_ShownName;
    }

}
