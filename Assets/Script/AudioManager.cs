using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Cấu hình Audio Source")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    // Tạo class phụ để dễ kéo thả trong Inspector
    [System.Serializable]
    public struct SoundEffect
    {
        public string name;
        public AudioClip clip;
    }
    public List<SoundEffect> soundEffects;

    private Dictionary<string, AudioClip> soundDict;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Khởi tạo Dictionary từ List để truy xuất cực nhanh
            soundDict = new Dictionary<string, AudioClip>();
            foreach (var s in soundEffects)
            {
                if (!soundDict.ContainsKey(s.name))
                    soundDict.Add(s.name, s.clip);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Hàm gọi phát âm thanh dựa trên tên
    public void PlaySFX(string soundName)
    {
        if (soundDict.ContainsKey(soundName))
        {
            sfxSource.PlayOneShot(soundDict[soundName]);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy âm thanh: " + soundName);
        }
    }

    // Hàm phát nhạc nền
    public void PlayMusic(string musicName)
    {
        if (soundDict.ContainsKey(musicName))
        {
            musicSource.clip = soundDict[musicName];
            musicSource.Play();
        }
    }
}