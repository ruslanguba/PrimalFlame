using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    [Header("����� ������")]
    [SerializeField] private int _level;

    [Header("��������� �����")]
    [Tooltip("����������� �� ������� � �������")]
    [SerializeField] private float _timeLimit = 5;

    [Header("������ � �������")]
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private Image _Scrin;
    [SerializeField] private TextMeshProUGUI _textInfo;

    [Header("������")]
    [SerializeField] private Image[] starImage;

    private Button _myButton;
    private LoadData _loadData;

    private void Awake()
    {
        _myButton = GetComponent<Button>();
        _loadData = FindObjectOfType<LoadData>();      
    }

    private void Start()
    {
        
        if (_myButton.interactable)
        {
            ActiveButton();
            OpenStar();
        }
        else
        {
            InactiveButton();
        }
    } 
    void ActiveButton()
    {
        _infoPanel.SetActive(true);

        int minutes = Mathf.FloorToInt(_loadData.LoadTimer(_level) / 60);//��������� ����� � ������ � �������
        int seconds = Mathf.FloorToInt(_loadData.LoadTimer(_level) % 60);
        //������� � ��������� ��������
        _textInfo.text = $"�����: {minutes:00}:{seconds:00} \n�������: {_loadData.LoadDeths(_level)}\n�����: {_loadData.LoadCollect(_level)}/{3}";

        _Scrin.color = Color.white;//������ ����
    }
    void InactiveButton()
    {
        _infoPanel.SetActive(false);
        _Scrin.color = Color.gray;
    }
    
    void OpenStar()
    {
        for (int i = 0; i < starImage.Length; i++)
        {
            starImage[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _loadData.LoadStar(_level); i++)
        {
            starImage[i].gameObject.SetActive(true);
        }
    }
}
