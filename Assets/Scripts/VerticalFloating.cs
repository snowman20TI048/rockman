using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;     //Dotween���g�����߂ɕK�v

public class VerticalFloating : MonoBehaviour
{
    [Header("�����̂ɂ����鎞��")]
    public float moveTime;

    [Header("�����͈�")]
    public float moveRange;

    Tweener tweener; //DOTween �̏����̑���p


    // Start is called before the first frame update
    void Start()
    {
        //DoTween �ɂ�閽�߂����s���A�����Tweener�^��tweener�ϐ��ɑ��
        tweener = transform.DOMoveY(transform.position.y - moveRange, moveTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        
    }

    private void OnDestroy()  //���̃Q�[���I�u�W�F�N�g���폜���ꂽ�Ƃ��ɍs�����\�b�h
    {
        //�Q�[���I�u�W�F�N�g�̔j���ɍ��킹��DoTween�̏�����j������i���̌��ʁA�������[�v��������������j
        //Dotween�����s����^�C�~���O�ŕϐ��ɑ�����Ă������ƂŁA���Ƃ�DoTween�ɖ��߂��o�����Ƃ��o����
        tweener.Kill();
    }
}
