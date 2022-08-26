using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ResultPopUp : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private CanvasGroup canvasGroupRestart;

    [SerializeField]
    private Button btnTitle;

    /// <summary>
    /// ResultPopUp�̐ݒ�
    /// </summary>
    /// <param name="score"></param>
    public void SetUpResultPopUp()
    {
        // �ŏ��ɓ����ɂ���
        canvasGroup.alpha = 0;

        // ���X��ResultPopUp��\��
        canvasGroup.DOFade(1.0f, 1.0f);

        // ���X�^�[�g�̃��b�Z�[�W���������Ɠ_�ŃA�j��������
        canvasGroupRestart.DOFade(0, 1.0f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);

        // �{�^���Ƀ��\�b�h��o�^
        btnTitle.onClick.AddListener(OnClickRestart);
    }

    /// <summary>
    /// �{�^�����������ۂ̐���
    /// </summary>
    private void OnClickRestart()
    {

        // ���U���g�\�������X�ɔ�\���ɂ���
        canvasGroup.DOFade(0, 1.0f).SetEase(Ease.Linear);

        // ���݂̃V�[�����ēx�ǂݍ���
        StartCoroutine(Restart());
    }

    /// <summary>
    /// ���݂̃V�[�����ēx�ǂݍ���
    /// </summary>
    /// <returns></returns>
    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.0f);

        // ���݂̃V�[���̖��O���擾
        string sceneName = SceneManager.GetActiveScene().name;

        // �ēx�ǂݍ��݁A�Q�[�����ăX�^�[�g
        SceneManager.LoadScene(sceneName);
    }
}