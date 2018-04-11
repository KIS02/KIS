using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Unit Character;
	//자신이 제어 할 유닛.
	public Camera PlayerCamera;
	//무조건 유저의 카메라.

	void Awake(){

		Character = GetComponentInChildren<Unit>();
		//유닛 설정 (필수)
		PlayerCamera = Camera.main;
		//카메라 설정 (필수)
	}


}
