using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v�I�I

public class TitleDirector : MonoBehaviour
{
    [Header("���C��BGM")]
    [SerializeField]
    private AudioManager audioManager;              // �q�G�����L�[�ɂ��� AudioManager �X�N���v�g�̃A�^�b�`����Ă���Q�[���I�u�W�F�N�g���A�T�C��

    void Start()
    {
        // �^�C�g���ȍĐ�
        StartCoroutine(audioManager.PlayBGM(0));
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
