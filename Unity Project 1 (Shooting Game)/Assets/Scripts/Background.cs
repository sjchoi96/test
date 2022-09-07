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
        for (int i = 0; i <transform.childCount; i++) // ��Ȯ�� �ε����� �ʿ��� �� ����
        {
            bgSlots[i] = transform.GetChild(i);
        }
    }

    public void Update()
    {
        float minusX = transform.position.x - Background_Width;
        //foreach(Transform slot in bgSlots) // for ���� ������. for each �� bgSlots �� �� index ���� ������� foreach �ȿ� �մ� ���� �����Ѵ�.
        //{
        //    slot.Translate (scrollingSpeed * Time.deltaTime * -transform.right);

        //    if (slot.position.x < minusX) 
        //    {
        //        // ���������� Background_Width �� 3�� (bgSlots.Length�� 3���� ��������ϱ�) ��ŭ �̵�
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
