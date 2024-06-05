using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Achievement        //���� Ŭ���� ���� ( ��� �����̺�� ���ֱ� ) 
{
    public string name;             //���� �̸�
    public string description;      //���� ����
    public bool isUnlocked;         //��� ����
    public int currentProgress;     //���� ����
    public int goal;                //�Ϸ� ����

    public Achievement(string name, string description, int goal)
    {
        this.name = name;                       //Achievement Ŭ������ ���� �� �� �̸��� �μ��� �޾Ƽ� ����
        this.description = description;         //Achievement Ŭ������ ���� �� �� ������ �μ��� �޾Ƽ� ����
        this.isUnlocked = false;                //Achievement Ŭ������ ���� �� �� false
        this.currentProgress = 0;               //Achievement Ŭ������ ���� �� �� 0
        this.goal = goal;                       //Achievement Ŭ������ ���� �� �� �Ϸ� ����
    }

    public void AddProgress(int amount)         //���� ���൵ �Լ�
    {
        if(!isUnlocked)                         //������� �ʴٸ�
        {
            currentProgress += amount;
            if(currentProgress >= goal)         //���൵���� �Ϸ� ���ڰ� �� ���� �� 
            {
                isUnlocked = true;
                OnAchievmentUnlocked();         //���� �޼��� Debug.Log �� ���
            }
        }
    }

    protected virtual void OnAchievmentUnlocked()
    {
        Debug.Log($"���� �޼� : {name}");               //%ǥ�ð� ����ִ� String���� {} ���� ���� ��� �� �� �ִ�.
    }
}
