using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInterface : MonoBehaviour {

	[HideInInspector] public Unit Character;

	public PlayerManager m_Manager;
	public Canvas m_Interface;

	public Button[] m_button;
	public Image[] m_image;

	public RectTransform[] m_Inters = new RectTransform[3];


	void Awake () {
		m_Manager = GetComponent<PlayerManager> ();

		m_Interface = GetComponentInChildren<Canvas> ();

		m_button = GetComponentsInChildren<Button> ();
	}

	void Start() {

		//m_Inters [0].position = Camera.main.ScreenToWorldPoint(new Vector3(0.14f, 0.11f, 0f ));

		Character = m_Manager.Character;

		SetButtenIcon (1, 1);
		//Instantiate (m_Interface, );

	}

	public void InputButten( int Key ){

		m_button [Key].Select();
        if (Key == 1)
            Character.UseAbility(0);
        if (Key == 2)
            Character.UseAbility(1);


    }

	public void SetButtenIcon( int Key, int Id ){

		m_button [Key].image.sprite = CustomData.instance.image[Id];

	}
}
