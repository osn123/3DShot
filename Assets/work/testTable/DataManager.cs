using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    public TableData tableData;

    void Start()
    {
        // �f�[�^�ւ̃A�N�Z�X��
        foreach (RowData row in tableData.rows)
        {
            Debug.Log($"ID: {row.id}, Name: {row.name}, Value: {row.value}");
        }
    }

    // �����ID�����s������
    public RowData FindRowById(int id)
    {
        return System.Array.Find(tableData.rows, row => row.id == id);
    }
}