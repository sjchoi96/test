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
    //    foreach (Transform slot in starSlots) // for 보다 빠르다. for each 는 bgSlots 에 각 index 들이 순서대로 foreach 안에 잇는 식을 실행한다.
    //    {
    //        slot.Translate(scrollingSpeed * Time.deltaTime * -transform.right);

    //        if (slot.position.x < minusX)
    //        {  
    //            // 오른쪽으로 Background_Width 의 3배 (bgSlots.Length에 3개가 들어있으니까) 만큼 이동
    //            slot.Translate(starBackground_Width * starSlots.Length * transform.right);
    //        }

    //    }
    //}
}

