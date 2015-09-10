using UnityEngine;
using System.Collections;

public class ShipMaterialBehavior : MonoBehaviour {


    Ship m_Ship;


    // Use this for initialization
    void Start () {

        m_Ship = GetComponent<Ship>();
       
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Material")
        {
            if (m_Ship.m_MaterialNumber < m_Ship.m_MaterialMaxNumber)
            {
                AddMaterial();
                Destroy(other.transform.parent.gameObject);
            }
        }
    }

  

    void AddMaterial()
    {
        m_Ship.m_MaterialNumber++;
        UIManager.instance.ActualizeUIMaterial();
    }

    //Call by a Colonie that need a material to know if the ship can loose a material
    public bool CanLooseMaterial()
    {
        if(m_Ship.m_MaterialNumber>0)
        {
            //So we loose one
            LooseMaterial();
            return true;
        }

        return false;
    }

    void LooseMaterial()
    {
        m_Ship.m_MaterialNumber--;
        UIManager.instance.ActualizeUIMaterial();
    }
}
