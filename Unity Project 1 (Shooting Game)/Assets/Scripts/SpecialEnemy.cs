using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SpecialEnemy : Enemy // Enemy 상속받은 파워업 아이템 드랍용 적 비행기
{
    public GameObject powerUp;  // special enemy에 붙어있는 아이템

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //오버라이드해서 파워업 아이템용을 생성
        if (collision.gameObject.CompareTag("Bullet"))
        {
            powerUp.transform.parent = null;
            powerUp.SetActive(true);
        }
        base.OnCollisionEnter2D(collision);
    }


}
