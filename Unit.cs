using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 
public enum UNIT_TYPE{
	Health, Energy
}

public class Unit : MonoBehaviour {

	[HideInInspector]public float MaxHealth = 100f;
	//유닛의 초기 체력값을 설정한다. 동시에 유닛의 최대 체력값이다.
	[HideInInspector]public float MaxEnergy = 100f;
	//유닛의 초기 소모값을 설정한다. 동시에 유닛의 최대 소모값이다.
	[HideInInspector]public float InitSpeed = 1f;
	//유닛의 초기 이동속도값을 설정한다. 동시에 유닛의 기본 이동속도이다.

	public float Health;
	//유닛의 현재 체력값이다.
	public float Energy;
	//유닛의 현재 소모값이다.
	public float Speed;
	//유닛의 현재 이동속도값이다.

	public int[] AbilityCode = new int[AbilityManager.index];
	//현재 유닛이 가지고 있는 능력의 코드이다. 정수값에 따라 능력의 레벨이 변경된다. ( 0은 배우지 않음 )

	public Transform m_Transform;
	//유닛의 트렌스폼이자 위치 관리용
	public Transform m_Form;
	//유닛의 트렌스폼이자 모델 및 형체 관리용

	Animation m_Anim;
	//유닛의 모션을 관리한다.

	public UnitUI m_UI;
	//유닛의 상태에 따라 유닛의 고유 인터페이스가 변한다.

	public bool IsLive = true;
    //유닛의 생존 여부



    void Awake(){

		Health = MaxHealth;

		Energy = MaxEnergy;

		Speed = InitSpeed;

		m_Anim = GetComponentInChildren<Animation> ();

		m_Transform = GetComponent<Transform> ();
		m_Form = transform.Find("Form");
		m_UI = GetComponentInChildren<UnitUI> ();
	}

	void Start(){
		SetAnim ("Stand");
	}

	//모션 제어 부분
	#region

	public float m_fade = 0.1f;
	//유닛의 모션 변경의 페이드 시간. ( 기본 값 = 0.1f )
	string anim;
	//현재 수행중인 모션

	//가장 기본적인 모션 함수. 유닛에게 파라미터 값에 해당하는 모션을 명령한다.
	public void SetAnim( string Anim ){
		if ( !m_Anim.IsPlaying(anim) )
			m_Anim.CrossFade (Anim, m_fade);

	}

	//명령한 모션을 끝까지 수행할 때 까지 다른 모션명령을 무시합니다.
	public void NeverAnim( string Anim ){
		anim = Anim;
		m_Anim.CrossFade (Anim, m_fade);

	}

	#endregion

	public void TakeDamage( float Damage ){
		if (Damage > 0 && Health > 0)
			Health -= Damage;
		
		m_UI.SyncHealth ();
		//체력바를 상태에 따라 동기화 시킵니다.


				if ( Health <= 0 ) {

					IsLive = false;
					NeverAnim ("Death");
				}

	}

	public float StatePercent( UNIT_TYPE type ){
		if (type == UNIT_TYPE.Health) {
			return Health / MaxHealth;
		}
		if (type == UNIT_TYPE.Energy) {
			return Energy / MaxEnergy;
		}
		return 0f;
	}

	public void UseAbility( int value ){
        if ( AbilityCode[value] > 0 )
            AbilityManager.instance.UseAbility(this, value);
        //기초능력사용되게만들기
    }

	//유닛의 값을 퍼센트로 반환합니다.
}

