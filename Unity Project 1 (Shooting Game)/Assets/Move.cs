using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 0.1f;
    // 유니티 이벤트 함수 : 유니티가 특정 타이밍에 실행 시키는 함수

    // Start 함수. 게임이 시작될때 (첫번째 Update 함수가 호출되기 직전에 호출되는 함수)
    public void Start()
    {
        Debug.Log("Hello Unity");
    }

    // Update 함수. 매 프레임마다 호출되는 함수 
    private void Update()
    {
        //Vector3 : 벡터를 표현하기 위한 구조체, 위치를 표현할 때도 많이 사용한다.
        // 벡터 : 힘의 방향과 크기를 나타내는 단위
        //transform.position += Vector3.right;
        /*transform.position += new Vector3(1, 0, 0);*/ //오른쪽


        //Time.deltaTime : 이전 프레임에서 지금 프레임까지 걸린 시간
        transform.position += (speed * Time.deltaTime * Vector3.down); // 아래쪽 방향으로 speed 만큼 움직여라 (매 초마다)

        new Vector3(1, 0, 0); // 오른쪽 Vector3.right;
        new Vector3(-1, 0, 0); // 왼쪽 Vector3.left;
        new Vector3(0, 1, 0); // 위쪽 Vector3.up;
        new Vector3(0,-1, 0); // 아래쪽 Vector3.down;
    }
}
