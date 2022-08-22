using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text txtInfo;

    [SerializeField]
    private CanvasGroup canvasGroupInfo;


    ////* ��������ǉ� *////

    [SerializeField]
    private ResultPopUp resultPopUpPrefab;

    [SerializeField]
    private Transform canvasTran;

    ////* �����܂� *////


    /// <summary>
    /// �Q�[���I�[�o�[�\��
    /// </summary>
    public void DisplayGameOverInfo()
    {

        // InfoBackGround �Q�[���I�u�W�F�N�g�̎��� CanvasGroup �R���|�[�l���g�� Alpha �̒l���A1�b������ 1 �ɕύX���āA�w�i�ƕ�������ʂɌ�����悤�ɂ���
        canvasGroupInfo.DOFade(1.0f, 1.0f);

        // ��������A�j���[�V���������ĕ\��
        txtInfo.DOText("Game Over...", 1.0f);
    }


    ////* �V�������\�b�h���P�ǉ��B�������� *////

    /// <summary>
    /// ResultPopUp�̐���
    /// </summary>
    public void GenerateResultPopUp()
    {
        // ResultPopUp �𐶐�
        ResultPopUp resultPopUp = Instantiate(resultPopUpPrefab, canvasTran, false);

        // ResultPopUp �̐ݒ���s��
        resultPopUp.SetUpResultPopUp();
    }

    ////* �����܂� *////

}