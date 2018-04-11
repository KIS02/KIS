using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitUI : MonoBehaviour {

	Unit Character;
	public RectTransform i_healthbar;

	void Awake () {
		
		Character = GetComponentInParent<Unit> ();
        i_healthbar = GetComponent<RectTransform>();


    }

	public void SyncHealth(){

		i_healthbar.sizeDelta = new Vector2 (Character.StatePercent( UNIT_TYPE.Health ) * 100f, i_healthbar.sizeDelta.y);

	}

}
