using UnityEngine;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Prject�r���[�̉E�N���b�N���j���[��ScriptableObject�𐶐����郁�j���[��ǉ�
// fileName: ���������ScriptableObject�̃t�@�C����
// menuName: criptableObject�𐶐����郁�j���[�̖��O
// order: ���j���[�̕\����(0�Ȃ̂ň�ԏ�ɕ\�������)
[CreateAssetMenu(fileName = "SheetData", menuName = "ScriptableObject�̐���/SheetData�̐���", order = 0)]

// �V�[�g�f�[�^���Ǘ�����ScriptableObject
public class SheetData : ScriptableObject
{
    public SheetDataRecord[] sheetDataRecord;    // �V�[�g�f�[�^�̃��X�g
    [SerializeField] string url;    // �X�v���b�g�V�[�g��URL

    [System.Serializable]
    public class SheetDataRecord
    {
        /////////////////////////////////////////////
        // �X�v���b�g�V�[�g�̗�ɑΉ�����ϐ����`
        // �D���ɕύX���Ă�������
        public int id;
        public string name;
        public enum Type { A, B, C, }
        public Type type; // enum���g�p�ł���
                          /////////////////////////////////////////////
    }

#if UNITY_EDITOR
    //�X�v���b�g�V�[�g�̏���sheetDataRecord�ɔ��f�����郁�\�b�h
    public void LoadSheetData()
    {
        // url����CSV�`���̕�������_�E�����[�h����
        using UnityWebRequest request = UnityWebRequest.Get(url);
        request.SendWebRequest();
        while (request.isDone == false)
        {
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
        }

        // �_�E�����[�h����CSV���f�V���A���C�Y(SerializeField�ɓ���)����
        sheetDataRecord = CSVSerializer.Deserialize<SheetDataRecord>(request.downloadHandler.text);

        // �f�[�^�̍X�V������������AScriptableObject��ۑ�����
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();

        Debug.Log(" �f�[�^�̍X�V���������܂���");
    }
#endif
}

//SheetData�̃C���X�y�N�^��LoadSheetData()���Ăяo���{�^����\������N���X
#if UNITY_EDITOR
[CustomEditor(typeof(SheetData))]
public class SheetDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // �f�t�H���g�̃C���X�y�N�^��\��
        base.OnInspectorGUI();

        // �f�[�^�X�V�{�^����\��
        if (GUILayout.Button("�f�[�^�X�V"))
        {
            ((SheetData)target).LoadSheetData();
        }
    }
}
#endif