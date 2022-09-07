using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform[] bgSlots;
    public float scrollingSpeed = 2.5f;

    float Background_Width = 13.6f;


    protected virtual void Awake()
    {
        bgSlots = new Transform[transform.childCount];
        for (int i = 0; i <transform.childCount; i++) // 정확한 인덱스가 필요할 때 유리
        {
            bgSlots[i] = transform.GetChild(i);
        }
    }

    public void Update()
    {
        float minusX = transform.position.x - Background_Width;
        //foreach(Transform slot in bgSlots) // for 보다 빠르다. for each 는 bgSlots 에 각 index 들이 순서대로 foreach 안에 잇는 식을 실행한다.
        //{
        //    slot.Translate (scrollingSpeed * Time.deltaTime * -transform.right);

        //    if (slot.position.x < minusX) 
        //    {
        //        // 오른쪽으로 Background_Width 의 3배 (bgSlots.Length에 3개가 들어있으니까) 만큼 이동
        //        slot.Translate(Background_Width * bgSlots.Length * transform.right);
        //    }
        
        //}
        for (int i=0; i<bgSlots.Length; i++)
        {
            bgSlots[i].Translate(scrollingSpeed * Time.deltaTime * -transform.right);
            if (bgSlots[i].position.x < minusX)
            {
                MoveRightEnd(i);
            }
        }
    }
    
    protected virtual void MoveRightEnd (int index)
    {
        bgSlots[index].Translate(Background_Width * bgSlots.Length * transform.right);
    }
}
