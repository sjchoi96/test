using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� ������ ���� ������Ʈ�� �ݵ�� Animator�� ������.
[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // �� ���� ������Ʈ�� Ȱ��ȭ�� �Ǹ�
        // anim.GetCurrentAnimatorClipInfo(0)[0].clip.length�� �Ŀ� �� ���� ������Ʈ�� �����϶�
        Destroy(this.gameObject, anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }


}