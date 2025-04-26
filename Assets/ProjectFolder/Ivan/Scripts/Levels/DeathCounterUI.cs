using UnityEngine;
using TMPro;

public class DeathCounterUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DeathCounter _deathCounter;
    [SerializeField] private TMP_Text _deathText; // ������ �� TextMeshPro ���������

    [Tooltip("������������� ��������� UI ��� ��������� ��������")]
    [SerializeField] private bool _autoUpdate = true;

    private void Awake()
    {
        // ��������� DeathCounter ���� �� �����
        if (_deathCounter == null)
        {
            _deathCounter = FindObjectOfType<DeathCounter>();
        }

        if (_deathCounter == null)
        {
            Debug.LogError("DeathCounterUI: ����������� ������ �� DeathCounter!", this);
            enabled = false;
            return;
        }

        // �������� ���������� ����
        if (_deathText == null)
        {
            Debug.LogError("DeathCounterUI: ����������� ��������� ������!", this);
            enabled = false;
            return;
        }

        // �������������� ����������
        UpdateDeathText();

        // �������� �� ������� ���� ����� ��������������
        if (_autoUpdate)
        {
            _deathCounter.OnDeathAdded += UpdateDeathText;
        }
    }

    private void OnDestroy()
    {
        // ������� ��� �����������
        if (_deathCounter != null && _autoUpdate)
        {
            _deathCounter.OnDeathAdded -= UpdateDeathText;
        }
    }

    // ���������� ������ UI
    public void UpdateDeathText()
    {
        _deathText.text = _deathCounter.GetTotalDeaths().ToString();           
    }
}