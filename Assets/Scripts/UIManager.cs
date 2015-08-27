using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Ship m_Ship;

  //PLAYER SPACE
    //LifeBar
    public Image m_LifeBarFull;
    public Text m_LifeText;
    //ExperienceBar
    public Image m_ExperienceBarFull;
    public Text m_ExperienceText;
    //States
    public Image[] m_StateImage = new Image[13];
    //Captain
    public Image m_CaptainFace;
    //Icone
    public Image m_Icone;
    //PlayerLevel
    public Text m_PlayerLevelText;
    //TresorBar
    public Image m_TresorBarFull;
    public Text m_TresorText;
    //ActionBar
    public Image[] m_ActionImage = new Image[4];
    //ConsomableBar
    public Image[] m_ConsomableBar = new Image[2];

    //CHAT 

    //MiniMap

    //OtherInterface
    public OtherPlayerInterface[] m_OtherPlayerInterface = new OtherPlayerInterface[4];
    
    


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
