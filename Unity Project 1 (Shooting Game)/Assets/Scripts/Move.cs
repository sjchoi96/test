using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;

    Vector3 dir;


    public void Start()
    {

    }

    private void Update()
    {
        transform.position += (speed * Time.deltaTime * dir);
    }

    private void Test_OldInputManager()
    {
        //Vector3 : 벡터를 표현하기 위한 구조체, 위치를 표현할 때도 많이 사용한다.
        // 벡터 : 힘의 방향과 크기를 나타내는 단위
        //transform.position += Vector3.right;
        /*transform.position += new Vector3(1, 0, 0);*/ //오른쪽


        //Time.deltaTime : 이전 프레임에서 지금 프레임까지 걸린 시간 => 1프레임당 걸린 시간

        //new Vector3(1, 0, 0); // 오른쪽 Vector3.right;
        //new Vector3(-1, 0, 0); // 왼쪽 Vector3.left;
        //new Vector3(0, 1, 0); // 위쪽 Vector3.up;
        //new Vector3(0,-1, 0); // 아래쪽 Vector3.down;
        /*transform.position += (speed * Time.deltaTime * Vector3.down);*/ // 아래쪽 방향으로 speed 만큼 움직여라 (매 초마다)


        //Input Manager를 이용한 입력처리
        //Busy wait 이 발생. (하는일은 없지만 사용되고 있는 상태 => 전력 세이빙을 방해 => 전력커짐)

        //if (Input.GetKeyDown(KeyCode.W) )
        //{
        //    Debug.Log("W가 눌러졌다");
        //    dir = Vector3.up;    
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Debug.Log("S가 눌러졌다");
        //    dir = Vector3.down;
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("A가 눌러졌다");
        //    dir = Vector3.left;
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("D가 눌러졌다");
        //    dir = Vector3.right;
        //}

       

        //Input System
        //Event-driven (이벤트 드리븐) 방식으로 구현 -> 일이 있을 때만 동작한다. (전력을 아끼기에 적합한 구조)

    }

    public void MoveInput(InputAction.CallbackContext context)
    {                
        //if (context.started) //매핑된 키가 누른 직후
        //{
        //    Debug.Log("입력들어옴 - started");
        //}

        //if (context.performed) //매핑된 키가 확실하게 눌려졋다
        //{
        //    Debug.Log("입력들어옴 - performed");
        //}

        //if (context.canceled) //매핑된 키가 떨어졌을때.
        //{
        //    Debug.Log("입력들어옴 - canceled");
        //}

        Vector2 inputDir = context.ReadValue<Vector2>();
        Debug.Log(inputDir);
        dir = inputDir; // dir.x = inputDir.x ; dir.y = inputDir.y; dirz = 0.0f;

        // vector : 방향과 크기
        // vector2: 유니티에서 제공하는 구조체(struct). 2차원 벡터를 표현하기 위한 구조체 (x,y)
        // vector3: 유니티에서 제공하는 구조체(struct). 3차원 벡터를 표현하기 위한 구조체 (x,y,z)

    }

    public void FireInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("발사!");
        }
    }
}