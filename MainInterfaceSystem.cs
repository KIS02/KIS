using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainInterfaceSystem : MonoBehaviour {

    public string[] g_scene;

    Button[] m_buttons;
    
	
	void Start () {
        m_buttons = GetComponentsInChildren<Button>();
        m_buttons[0].onClick.AddListener(StartGame);
	}
	
    void StartGame()
    {

        Application.LoadLevel(g_scene[0]);

    }


}
