using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UIElements;

public class PowerUp : MonoBehaviour
{
    public float moveSpeed = 1.0f;          // 이동속도
    public float dirChangeTime = 5.0f;      // 이동방향 바뀌는데 걸리는 시간
    public float selfDestroyTime = 10.0f;   // 없어지는데 걸리는 시간
    

    Player player;  // 파워업 아이템의 이동방향 설정에 필요한 플레이어
    Vector2 dir;    // 현재 이동방향
    WaitForSeconds waitTime;  // 코루틴에서 사용하기 위한 기다리는 시간

    private void Start()
    {
        waitTime = new WaitForSeconds(dirChangeTime); // dirChangeTime 만큼 기다리도록 waitTime 미리 생성
        player = FindObjectOfType<Player>();  // Player 타입을 찾기
        SetRandomDir();  // 랜덤하게 현재 이동방향 설정
        StartCoroutine(DirChange());  // 코루틴 실행해서 일정 시간 간격으로 이동방향 변경되게 설정
        Destroy(this.gameObject, selfDestroyTime);  // selfDestroyTime 초 후에 스스로 사라지기
    }

    private void Update()
    { 
        
        transform.Translate(moveSpeed * Time.deltaTime * dir);

    }

    IEnumerator DirChange()
    {
        while(true) // 무한 반복
        {
            yield return waitTime;  // dirChangeTime 만큼 대기한 후에
            SetRandomDir(false);    // 랜덤하게 현재 이동 방향 설정
        }
    }

    void SetRandomDir(bool allRandom = true)  // 디폴트 파라메터. 값을 지정하지 않으면 디폴트 값이 대신 들어간다.
    {
        if (allRandom)
        {
            dir = Random.insideUnitCircle;  // 반지름 1인 원한의 랜덤한 위치 리턴 => 이 원의 원점에서 랜덤한 위치로 가는 방향 백터 생성
            dir = dir.normalized;  // 단위 백터로 수정
        }
        else
        {
            Vector2 playerToPowerUp = transform.position - player.transform.position; // 플레이어 위치에서 파워업 아이템 위치로 가는 방향 백터 계산.
            playerToPowerUp = playerToPowerUp.normalized;  // 단위백터로 수정

            if (Random.value < 0.6) // 60%확률
            {
                // playerToPowerUp 백터를 z 축으로 -90~+90 만큼 회전시켜서 dir 에 넣기
                dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;
            }
            else // 40%확률
            {
               
                dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;
            }
              
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            dir = Vector2.Reflect(dir, collision.contacts[0].normal);
   
        }
    }

}
