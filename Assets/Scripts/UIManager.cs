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

    [SerializeField]
    private ResultPopUp resultPopUpPrefab;

    [SerializeField]
    private Transform canvasTran;

    [SerializeField]
    private Button btnInfo;

    [Header("BGM")]
    [SerializeField]
    private AudioManager audioManager;              // �q�G�����L�[�ɂ��� AudioManager �X�N���v�g�̃A�^�b�`����Ă���Q�[���I�u�W�F�N�g���A�T�C��

    /// <summary>
    /// �Q�[���I�[�o�[�\��
    /// </summary>
    public void DisplayGameOverInfo()
    {
        // �Q�[���I�[�o�[�ȍĐ�
        StartCoroutine(audioManager.PlayBGM(2));

        // InfoBackGround �Q�[���I�u�W�F�N�g�̎��� CanvasGroup �R���|�[�l���g�� Alpha �̒l���A1�b������ 1 �ɕύX���āA�w�i�ƕ�������ʂɌ�����悤�ɂ���
        canvasGroupInfo.DOFade(1.0f, 1.0f);

        // ��������A�j���[�V���������ĕ\��
        txtInfo.DOText("Game Over...", 1.0f);

        btnInfo.onClick.AddListener(RestartGame);


    }



    /// <summary>
    /// ResultPopUp�̐���
    /// </summary>
    public void GenerateResultPopUp()
    {
       

        // ResultPopUp �𐶐�
        ResultPopUp resultPopUp = Instantiate(resultPopUpPrefab, canvasTran, false);

        // ResultPopUp �̐ݒ���s��
        resultPopUp.SetUpResultPopUp();

        btnInfo.onClick.AddListener(RestartGame);
    }



    /// <summary>
    /// �^�C�g���֖߂�
    /// </summary>
    public void RestartGame()
    {

        // �{�^�����烁�\�b�h���폜(�d���N���b�N�h�~)
        btnInfo.onClick.RemoveAllListeners();

       /* // ���݂̃V�[���̖��O���擾
        string sceneName = SceneManager.GetActiveScene().name;
       */
        canvasGroupInfo.DOFade(0f, 1.0f)
            .OnComplete(() => {
                Debug.Log("Restart");
                SceneManager.LoadScene("TitleScene");
            });
    }

}