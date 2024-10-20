using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;    // File�ǂݍ��ݗp

/// <summary>
/// CSV��ǂݍ��ނ��߂̃N���X
/// </summary>
public class CSVReader2 : MonoBehaviour
{
    private TextAsset csvFile;
    private List<string[]> csvDatas = new List<string[]>(); // CSV�̒��g���i�[���郊�X�g
    [Tooltip("�t�@�C���p�X���i�[����ϐ�"), FileDesignation, SerializeField] private string filePath;

    void Start()
    {
        LoadCSV();
        Debug.Log(GetCsvDatas());
    }

    /// <summary>
    /// CSV�t�@�C���̓ǂݍ��݂��s���֐�
    /// </summary>
    private void LoadCSV()
    {
        filePath = Path.GetFileNameWithoutExtension(filePath);
        csvFile = Resources.Load(filePath) as TextAsset;
        StringReader csvReader = new StringReader(csvFile.text);

        while (csvReader.Peek() > -1)
        {
            string cell = csvReader.ReadLine();
            csvDatas.Add(cell.Split(','));  // ','��ڈ��Ƀ��X�g�Ɋi�[���Ă���   
        }
        csvReader.Close();
    }

    /// <summary>
    /// �ǂݍ���CSV�̃f�[�^�����ׂĎ󂯓n���֐�
    /// </summary>
    /// <returns>CSV�f�[�^�̒��g�S�Ă̕�����</returns>
    public List<string[]> GetCsvDatas()
    {
        return csvDatas;
    }

    /// <summary>
    /// �ǂݍ���CSV�f�[�^�̎w�����󂯓n���֐�
    /// </summary>
    /// <param name="lineNum">�s�ԍ�</param>
    /// <returns>CSV�f�[�^�̎w���̕�����</returns>
    public string[] GetCsvLine(int lineNum)
    {
        return csvDatas[lineNum];
    }

    /// <summary>
    /// �ǂݍ���CSV�̎w�肳�ꂽ�Z���̕�������󂯓n���֐�
    /// </summary>
    /// <param name="lineNum">�s�ԍ�</param>
    /// <param name="columnNum">��ԍ�</param>
    /// <returns></returns>
    public string GetCsvCell(int lineNum, int columnNum)
    {
        return csvDatas[lineNum][columnNum];
    }
}
