using UnityEngine;

public class CollectTracker : MonoBehaviour
{
    public event System.Action<int> OnCollectedChanged; // ����� �������

    [SerializeField] private CollectHandler _collectHandler;
    private int _currentCollected;

    private void Awake()
    {
        if (_collectHandler == null)
            _collectHandler = FindObjectOfType<CollectHandler>();
    }

    private void OnEnable()
    {
        if (_collectHandler != null)
            _collectHandler.OnCollectValueChanged += HandleCollectUpdate;
    }

    private void OnDisable()
    {
        if (_collectHandler != null)
            _collectHandler.OnCollectValueChanged -= HandleCollectUpdate;
    }

    private void HandleCollectUpdate(int collectedCount)
    {
        _currentCollected = collectedCount;
        OnCollectedChanged?.Invoke(_currentCollected); // ������������ �������
    }

    public int GetCurrentCollected() => _currentCollected;
}