using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioS : MonoBehaviour
{
    private bool wasPut = false;
    private float nextTimeAdd = 0f;
    public float plusNextAddTime = 0.05f;

    public GameObject prefMagnitude;
    public GameObject secPrefMagnitude;
    public float loudnessPlusTwo = 2.5f;

	public bool _useMicrophone = true;
	public AudioClip _audioClip;
	public string _selectedDevice;
	private AudioSource _audioSource;
    public AudioMixerGroup _mixergroupMicrophone, _mixerGroupMaster;

    static public float sensitivity = 200; // чувствительность
	public float loudness = 0; // громкость

	private void Start()
	{

        _audioSource = GetComponent<AudioSource>();
        if (_useMicrophone)
		{
			if (Microphone.devices.Length > 0)
			{
				_selectedDevice = Microphone.devices[0].ToString();
                _audioSource.outputAudioMixerGroup = _mixergroupMicrophone;
				_audioSource.clip = Microphone.Start(_selectedDevice, true, 10, AudioSettings.outputSampleRate);
			}
			else
			{
				_useMicrophone = false;
			}
		}
		if (!_useMicrophone)
		{
            _audioSource.outputAudioMixerGroup = _mixerGroupMaster;
			_audioSource.clip = _audioClip;
		}
		_audioSource.Play();
    }
    private void Update()
    {
        if (TextScript._IsPause)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space) & !wasPut)
        {
            wasPut = true;
            loudness = 0f;
            loudnessPlusTwo = 1.0f;
            nextTimeAdd = 0;
        }
    }
    private void FixedUpdate()
    {
        if (TextScript._IsPause)
        {
            return;
        }
        loudness = GetAveragedVolume() * sensitivity;
        if (loudness > loudnessPlusTwo & !wasPut && Time.time > nextTimeAdd)
        {
            Instantiate(prefMagnitude);
            loudnessPlusTwo = loudnessPlusTwo + 0.25f;
            nextTimeAdd = Time.time + plusNextAddTime;
        }
        if (wasPut & loudness > loudnessPlusTwo & Time.time > nextTimeAdd)
        {
            Instantiate(secPrefMagnitude);
            loudnessPlusTwo = loudnessPlusTwo + 0.25f;
            nextTimeAdd = Time.time + plusNextAddTime;
        }
    }
    float GetAveragedVolume()  // метод получения громкости
	{ 
		float[] data = new float[256];
		float a = 0;
		_audioSource.GetOutputData(data,0); 
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a/256;
    }
}