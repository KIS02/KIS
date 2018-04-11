using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityManager : MonoBehaviour {

    delegate IEnumerator Ability(Unit u);
    //능력임.
    public const int index = 100;
    Ability[] abilitylist = new Ability[index];

    public static AbilityManager instance;

    void Start()
    {
        instance = GetComponent<AbilityManager>();
        SetAbil(Ability0);
        SetAbil(Ability1);
        SetAbil(Ability2);
    }

    int stack = 0;

    private void SetAbil( Ability a)
    {

        abilitylist[stack] = a;
        stack = stack + 1;

    }

    public void UseAbility( Unit u, int index )
    {

        StartCoroutine( abilitylist[index](u) );

    }

    IEnumerator Ability0(Unit u)
    {
        int j = 0;
        for ( int i = 0; i <= 4; i++)
        {
            
            if (i <= 3 && j == 0) {
                u.m_Form.localScale += new Vector3(0.2f, 0f, 0f);
                u.m_Form.localScale += new Vector3(0f, -0.2f, 0f);
            } else if (i <= 3 && j == 1)
            {
                u.m_Form.localScale += new Vector3(-0.2f, 0f, 0f);
                u.m_Form.localScale += new Vector3(0f, 0.2f, 0f);
            } else if (i <= 3 && j == 2)
            {
                u.m_Form.localScale += new Vector3(-0.2f, 0f, 0f);
                u.m_Form.localScale += new Vector3(0f, 0.2f, 0f);
            } else if (i <= 3 && j == 3 )
            {
                u.m_Form.localScale += new Vector3(0.2f, 0f, 0f);
                u.m_Form.localScale += new Vector3(0f, -0.2f, 0f);
            } else
            {
                j++;
                i = 0;
                if (j == 2)
                    u.m_Transform.Translate(0f, 0f, 10f);
                if (j >= 4)
                    break;
            }
            yield return new WaitForSeconds( 0.001f );


        }
        yield return null;
        u.m_Form.localScale = new Vector3(1f, 1f, 1f);

    }

    IEnumerator Ability1( Unit u )
    {
        float AddSpeed = (u.Speed * 1f);
        u.Speed = u.Speed + AddSpeed;
        u.GetComponent<Collider>().isTrigger = true;
        u.GetComponent<Rigidbody>().useGravity = false;

        for ( int i = 0; i <= 30; i++)
        {
            Destroy(Instantiate(CustomData.instance.dummy[0], u.m_Transform.position, u.m_Transform.rotation ), 0.5f);

            yield return new WaitForSeconds(0.1f);
            
        }
        

        u.GetComponent<Collider>().isTrigger = false;
        u.GetComponent<Rigidbody>().useGravity = true;
        u.Speed = u.Speed - AddSpeed;

        yield return null;

    }

    IEnumerator Ability2(Unit u)
    {
        yield return null;

    }

    IEnumerator timer( float delay )
    {
        yield return new WaitForSeconds(delay);

    }
}
