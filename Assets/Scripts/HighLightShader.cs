using UnityEngine;
using System.Collections;

public class HighLightShader : MonoBehaviour
{
    bool m_IsAims=false;

    public Renderer m_Renderer;
    public Material m_MaterialOutline;

    Material m_MaterialOrigin;

    void Start()
    {
        m_MaterialOrigin = m_Renderer.material;
        //m_MaterialOutline.CopyPropertiesFromMaterial(m_MaterialOrigin);
        m_MaterialOutline.color = m_MaterialOrigin.color;
        m_MaterialOutline.mainTexture = m_MaterialOrigin.mainTexture;
        m_MaterialOutline.mainTextureOffset = m_MaterialOrigin.mainTextureOffset;
        m_MaterialOutline.mainTextureScale = m_MaterialOrigin.mainTextureScale;
    }

    void OnTriggerStay(Collider other)
    {

        if (m_IsAims==false)
        {
            
            if (other.tag == "Aims")
            {
                m_IsAims = true;
                m_Renderer.material = m_MaterialOutline;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Aims")
        {
            Debug.Log("exit");
            m_IsAims = false;
            m_Renderer.material = m_MaterialOrigin;
        }

    }




}
