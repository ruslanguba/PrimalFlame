using System;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    [HideInInspector] public float TimeElapsed; // �����, ��������� � ������ �������
    private bool _isRunning; // ����, �����������, ������� �� ������

    public event Action<int, int> OnTimeChanged; // ������� ��� ���������� ������� (������, �������)

    void Start()
    {
        TimeElapsed = 0f;
        _isRunning = true;
        StartCoroutine(UpdateTimerCoroutine()); // ��������� �������� ��� ���������� �������
    }

    private IEnumerator UpdateTimerCoroutine()
    {
        while (_isRunning)
        {
            TimeElapsed++; // ����������� ����� �� 1 �������
            UpdateTimerText(); // ��������� ����� �������
            yield return new WaitForSeconds(1f); // ���� 1 �������
        }
    }

    private void UpdateTimerText()
    {
        // ����������� ����� � ������ � �������
        int minutes = Mathf.FloorToInt(TimeElapsed / 60);
        int seconds = Mathf.FloorToInt(TimeElapsed % 60);
        OnTimeChanged?.Invoke(minutes, seconds); // ���������� ����������� �� ��������� �������
    }

    public void StopTimer()
    {
        _isRunning = false; // ������������� ������
    }

    public void StartTimer()
    {
        _isRunning = true; // ��������� ������
    }
}
