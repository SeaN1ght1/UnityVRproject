using UnityEngine;
using UnityEngine.UI; // 如果使用 Text
using TMPro;


public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;         // 拖入你的 AudioSource
    public AudioClip[] playlist;            // 拖入你所有的歌曲
    
    public TextMeshProUGUI songNameText; // 如果你用 TextMeshPro

    private int currentSongIndex = 0;

    void Start()
    {
        // 游戏开始时不播放音乐，只更新 UI
        if (playlist.Length > 0 && songNameText != null)
        {
            songNameText.text = playlist[currentSongIndex].name;
        }
    }

    // 播放当前歌曲
    public void PlayCurrentSong()
    {
        if (playlist.Length == 0) return;

        audioSource.clip = playlist[currentSongIndex];
        audioSource.Play();

        // 更新 UI 显示歌曲名字
        if (songNameText != null)
        {
            songNameText.text = playlist[currentSongIndex].name;
        }
    }

    // 播放下一首歌
    public void NextSong()
    {
        if (playlist.Length == 0) return;

        currentSongIndex++;
        if (currentSongIndex >= playlist.Length)
        {
            currentSongIndex = 0; // 循环播放
        }

        PlayCurrentSong();
    }

    // 播放上一首歌
    public void PreviousSong()
    {
        if (playlist.Length == 0) return;

        currentSongIndex--;
        if (currentSongIndex < 0)
        {
            currentSongIndex = playlist.Length - 1; // 循环播放
        }

        PlayCurrentSong();
    }

    // 新增：播放/暂停切换
    public void TogglePlayPause()
    {
        // 如果 clip 为空，说明还没有播放过，先设置当前歌曲
        if (audioSource.clip == null && playlist.Length > 0)
        {
            audioSource.clip = playlist[currentSongIndex];

            // 更新 UI
            if (songNameText != null)
                songNameText.text = playlist[currentSongIndex].name;
        }

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}