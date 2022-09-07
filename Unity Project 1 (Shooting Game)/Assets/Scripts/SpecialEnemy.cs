using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SpecialEnemy : Enemy // Enemy ��ӹ��� �Ŀ��� ������ ����� �� �����
{
    public GameObject powerUp;  // special enemy�� �پ��ִ� ������

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //�������̵��ؼ� �Ŀ��� �����ۿ��� ����
        if (collision.gameObject.CompareTag("Bullet"))
        {
            powerUp.transform.parent = null;
            powerUp.SetActive(true);
        }
        base.OnCollisionEnter2D(collision);
    }


}
