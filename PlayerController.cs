using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[HideInInspector] public Unit Character;
    //[HideInInspector]
    public Camera PlayerCamera;


	public PlayerManager m_Manager;
	public PlayerInterface m_Inter;
	public InputManager m_Input;



	public int[] Index;
	//---[명령에 따른 응답처리 설정용 베이스]---
	//index[0] = 좌클릭 
	//1 = 우클릭
	//2 = 휠 클릭
	// 3~10 q~v
	// 11~18 1~6
	Vector3 CameraLocation;
	//카메라 위치.



	void Awake () {
		m_Manager = GetComponent<PlayerManager> ();
		m_Inter = GetComponent<PlayerInterface> ();
		m_Input = GetComponent<InputManager> ();
	}

	void Start() {
		
		Character = m_Manager.Character;
		PlayerCamera = m_Manager.PlayerCamera;
		SetCamLoc( 0f, 3f, -8f );

	}

	void Update () {
		if (Character.IsLive == true) {
			c_Order ();
			c_Move ();
			c_Cam ();
		}
	}



	//기능 관련 메솓

	Vector3 movement;
	Quaternion Angle;
	//[HideInInspector]
	public float MouseSensitivity = 180f;
	float h_Angle = 0f;
	#region

	void c_Set( int index, int value ){

		Index [index] = value;

	}

    void c_Order() {
        //KeyCode key;
     //   switch (key) {


        if (Input.GetKeyDown(m_Input.m_MenuKey)) {
            m_Inter.InputButten(0);
        }

        if (Input.GetKeyDown(m_Input.m_Butten1)) {
            m_Inter.InputButten(1);
            
        }
        if (Input.GetKeyDown(m_Input.m_Butten2)) {
            m_Inter.InputButten(2);
            
        }
        if (Input.GetKeyDown(m_Input.m_Butten3)) {
            m_Inter.InputButten(3);
            
        }
        if (Input.GetKeyDown(m_Input.m_Butten4)) {
            m_Inter.InputButten(4);
            
        }
        if (Input.GetKeyDown(m_Input.m_Butten5)) {
            m_Inter.InputButten(5);
            
        }
        if (Input.GetKeyDown(m_Input.m_Butten6)) {
            m_Inter.InputButten(6);
            
        }
        if (Input.GetKeyDown(m_Input.m_Butten7)) {
            m_Inter.InputButten(7);

        }
        if (Input.GetKeyDown(m_Input.m_Butten8)) {
            m_Inter.InputButten(8);

        }

        if (Input.GetKeyDown(m_Input.m_Butten1_2)) {
            m_Inter.InputButten(9);

        }
        if (Input.GetKeyDown(m_Input.m_Butten2_2)) {
            m_Inter.InputButten(10);

        }
        if (Input.GetKeyDown(m_Input.m_Butten3_2)) {
            m_Inter.InputButten(11);

        }
        if (Input.GetKeyDown(m_Input.m_Butten4_2)) {
            m_Inter.InputButten(12);

        }
        if (Input.GetKeyDown(m_Input.m_Butten5_2)) {
            m_Inter.InputButten(13);

        }
        if (Input.GetKeyDown(m_Input.m_Butten6_2)) {
            m_Inter.InputButten(14);

        }
	}

		
	//카메라 움직
	void c_Cam(){

		float x = Input.GetAxisRaw ("Mouse X");
		float y = Input.GetAxisRaw ("Mouse Y");
		x = x * MouseSensitivity * Time.deltaTime;
		y = -y * MouseSensitivity * 0.5f * Time.deltaTime;


		//y축 은 x매니저
		Character.transform.Rotate (0f, x, 0f);
		//x축은 y카메라
		//-70~20
		if (h_Angle + y <= 20f && h_Angle + y >= -70f ) {
			PlayerCamera.transform.Rotate (y, 0f, 0f);
			h_Angle = h_Angle + y;
		}


	}


	//객체 움직
	void c_Move(){
		float x = 0;
		float y = 0;
		if (Input.GetKey (m_Input.m_Front)) {
			x = x + 1f;
		}
		if (Input.GetKey (m_Input.m_Back)) {
			x = x - 1f;
		}
		if (Input.GetKey (m_Input.m_Left)) {
			y = y + 1f;
		}
		if (Input.GetKey (m_Input.m_Right)) {
			y = y - 1f;
		}

		movement.Set (y, 0f, x);

		movement = movement.normalized * Character.Speed * Time.deltaTime;

		//앞으로만 이동 조작키는 방향회전.

		if ((x) != 0 || (y) != 0) {
			Character.SetAnim ("Walk");
			Angle = Quaternion.Euler( 0f, Character.m_Transform.rotation.eulerAngles.y + AngleBetweenPoint( Character.m_Transform.position, Character.m_Transform.position + movement ) - 90f, 0f );
			Character.m_Form.rotation = Angle;
			movement.Set (-y, 0f, x);
			movement = movement.normalized * Character.Speed * Time.deltaTime;
			Character.m_Transform.Translate (movement);
		} else {
			Character.SetAnim ("Stand");
		}

	}


	#endregion

	//개발 관련 메솓
	#region

	void SetCamLoc( float p_x, float p_y, float p_z ){
        if (PlayerCamera == null)
            PlayerCamera = Camera.main;
		CameraLocation.Set (p_x, p_y, p_z);
		PlayerCamera.transform.position = Character.m_Transform.position + CameraLocation;

	}

	void SetCamLoc( Vector3 p_Vector ){

		CameraLocation = p_Vector;
        PlayerCamera.transform.position = Character.m_Transform.position + CameraLocation;

    }

	float AngleBetweenPoint( Vector3 begin, Vector3 final ){

		return 57.296f * Mathf.Atan2(final.z - begin.z, final.x - begin.x);

	}
	#endregion
}
