using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    //public static VolumeSettings Instance; // ��������

    public AudioMixer audioMixer; // ������ �� AudioMixer
    public Slider MusicSlider;    // ������� ��� ������ 
    public Slider SFXSlider;    // ������� ��� ������ 

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

    float savedMusicVolume;
    float savedSFXVolume;


    private void Awake()
    {
        //// ���������� ���������
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject); // �� ���������� ��� �������� ����� �����
        //}
        //else
        //{
        //    Destroy(gameObject); // ���������� ��������
        //    return;
        //}

        // ��������� ����������� �������� ���������
          savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
          savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.5f); 
    }  

    void Start()
    {
        // ���� �������� ���� �� ������� ����� (��������� ����), ����������� ��
        if (MusicSlider != null && SFXSlider != null)
        {
            MusicSlider.value = savedMusicVolume;
            SFXSlider.value = savedSFXVolume;

            // ������������� �� ��������� ���������
            MusicSlider.onValueChanged.AddListener(SetMusicVolume);
            SFXSlider.onValueChanged.AddListener(SetSFXVolume);
        }
        // ��������� ��������� ���������
        SetMusicVolume(savedMusicVolume);
        SetSFXVolume(savedSFXVolume);
    }
    

    public void SetMusicVolume(float volume)
    {
        // ����������� �������� �������� � ��������������� ����� (� ��������)
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        // ��������� �������� � PlayerPrefs
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    }

    public void SetSFXVolume(float volume)
    {
        // ����������� �������� �������� � ��������������� ����� (� ��������)
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        // ��������� �������� � PlayerPrefs
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    }
}
