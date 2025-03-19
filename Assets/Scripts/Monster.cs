using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Health = 100;                        //ü���� ���� �Ѵ�. (����)
    public float Timer = 1.0f;                      //Ÿ�̸Ӹ� ���� �Ѵ�. 
    public int AttackPoint = 10;                    //���ݷ��� ���� �Ѵ�. 

    // ù ������ ������ �ѹ� ���� �ȴ�. 
    void Start()
    {
        Health = 100;                 //ù ������ ������ ü���� 100���� ���� ���ش�. 
    }

    //�Ź� ������ �� ȣ�� �ȴ�. 
    void Update()
    {
        CharacterHealthUp();
        CheckDeath();                               //�Լ� ȣ��
    }

    void CharacterHealthUp()
    {
        Timer -= Time.deltaTime;       //�ð��� �� �����Ӹ��� ���� ��Ų��. (deltaTime �����Ӱ��� �ð� ������ �ǹ��Ѵ�.)

        if (Timer <= 0)                  //���� Timer�� ��ġ�� 0���Ϸ� ������ ���
        {
            Timer = 1.0f;               //�ٽ� 1�ʷ� ���� �����ش�.
            Health += 20;               //1�ʸ��� ü�� 20�� �÷��ش�.     (Health = Health + 20)
        }
    }

    public void CharacterHit(int Damage)               //Ŀ���� �������� �޴� �Լ��� ����Ѵ�. 
    {
        Health -= Damage;                       //���� ���ݷ¿� ���� ü���� ���� ��Ų��. 
    }
    void CheckDeath()                           //�Լ� ����
    {
        if (Health <= 0)                     //ü���� 0 ���Ϸ� �������� �ı� ��ĭ��.
            Destroy(gameObject);                //�� ������Ʈ�� �ı� �Ѵ�. 
    }
}