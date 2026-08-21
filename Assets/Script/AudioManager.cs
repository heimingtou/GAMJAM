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
    public void PlaySFX(string soundName, Vector3 position = default)
    {
        if (soundDict.ContainsKey(soundName))
        {
            AudioClip clip = soundDict[soundName];

            // Cách 1: Dùng PlayClipAtPoint để không bị tranh chấp AudioSource khi âm thanh ngắn phát liên tục
            // Nếu không truyền vị trí, nó sẽ lấy vị trí mặc định (0,0,0) hoặc vị trí camera
            if (position == default && Camera.main != null)
            {
                position = Camera.main.transform.position;
            }

            AudioSource.PlayClipAtPoint(clip, position);

            // Hoặc nếu bạn vẫn muốn dùng sfxSource có sẵn nhưng muốn an toàn hơn cho âm thanh cực ngắn:
            // sfxSource.PlayOneShot(clip);

            Debug.Log("Phát âm thanh: " + soundName);
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