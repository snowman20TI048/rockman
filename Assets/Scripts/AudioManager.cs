using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] audioSources;

    /// <summary>
    /// BGM�Đ�
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public IEnumerator PlayBGM(int index)
    {

        // �Đ��O�ɕʂ̋Ȃ�����Ă���ꍇ
        if (index != 0)
        {
            // ���X�Ƀ{�����[����������
            audioSources[index - 1].DOFade(0, 0.75f);
            //Debug.Log("�O�̋Ȃ̃{�����[��������");
        }
        if (index == 3)
        {
            // ���X�Ƀ{�����[����������
            audioSources[index - 2].DOFade(0, 0.75f);
        }

        // �O�̋Ȃ̃{�����[����������̂�҂�
        yield return new WaitForSeconds(0.45f);

        // �V�����w�肳�ꂽ�Ȃ��Đ�
        audioSources[index].Play();

        //Debug.Log("�V�����Ȃ��Đ����A�{�����[�����グ��");

        // ���X�Ƀ{�����[�����グ�Ă������ƂŁA�O�̋ȂƏd�Ȃ�N���X�t�F�[�h���o���ł���
        audioSources[index].DOFade(0.1f, 0.75f);     // ����ǉ�����SE����������悤��BGM�͏����߂̃o�����X�ɂ���

        // �O�ɗ���Ă���BGM���~
        if (index != 0)
        {
            // �O�ɗ���Ă����Ȃ̃{�����[����0�ɂȂ�����
            yield return new WaitUntil(() => audioSources[index - 1].volume == 0);

            // �Đ����~
            audioSources[index - 1].Stop();
            //Debug.Log("�O�̋Ȃ��~");
        }
    }
}