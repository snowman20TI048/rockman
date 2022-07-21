using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;   //DoTween�𗘗p���邽�߂ɐ錾��ǉ�

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtInfo;

    [SerializeField]
    private CanvasGroup canvasGroupInfo;


    //�Q�[���I�[�o�[�\��
    public void DisplayGameOverInfo()
    {
        //InfoBackGround�Q�[���I�u�W�F�N�g�̎���CanvasGroup�R���|�[�l���g��Alpha�̒l���A
        //1�b������1�ɕύX���āA�w�i�ƕ�����������悤�ɂ���
        canvasGroupInfo.DOFade(1.0f, 1.0f);

        //��������A�j���[�V���������ĕ\��
        txtInfo.DOText("Gane Over ...", 1.0f);

    }


}
