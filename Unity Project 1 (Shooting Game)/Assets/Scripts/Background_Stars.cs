using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Stars : Background
{
    SpriteRenderer[] spriteRenderers;


    protected override void Awake()
    {
        base.Awake();

        spriteRenderers = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spriteRenderers[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
    }

    protected override void MoveRightEnd(int index)
    {
        base.MoveRightEnd(index);

        int rand = Random.Range(0, 4);
        spriteRenderers[index].flipX = (rand & 0b_01) != 0;
        spriteRenderers[index].flipY = (rand & 0b_10) != 0;
    }

    //private void Awake()
    //{
    //    starSlots = new Transform[transform.childCount];
    //    for(int i = 0; i < transform.childCount; i++)
    //    {
    //        starSlots[i] = transform.GetChild(i);
    //    }
    //    SpriteRenderer sprite = GetComponent<SpriteRenderer>();
    //    sprite.flipX = false;
    //    sprite.flipY = false;

    //    int rand = Random.Range(0,1);

    //    sprite.flipX = (rand & 0b_01) != 0; 
    //    sprite.flipY = (rand & 0b_10) != 0; 

    //}

    //private void Update()
    //{
    //    float minusX = transform.position.x - starBackground_Width;
    //    foreach (Transform slot in starSlots) // for ���� ������. for each �� bgSlots �� �� index ���� ������� foreach �ȿ� �մ� ���� �����Ѵ�.
    //    {
    //        slot.Translate(scrollingSpeed * Time.deltaTime * -transform.right);

    //        if (slot.position.x < minusX)
    //        {  
    //            // ���������� Background_Width �� 3�� (bgSlots.Length�� 3���� ��������ϱ�) ��ŭ �̵�
    //            slot.Translate(starBackground_Width * starSlots.Length * transform.right);
    //        }

    //    }
    //}
}

