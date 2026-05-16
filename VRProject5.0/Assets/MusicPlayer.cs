using UnityEngine;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playlist;
    public TextMeshProUGUI songNameText;

    [Header("Lyrics Objects")]
    public GameObject lyric;    // Da Capo
    public GameObject lyric2;   // Moon Halo
    public GameObject lyric3;   // Regression
    public GameObject lyric4;   // 在出发之前

    private int currentSongIndex = 0;

    void Start()
    {
        // 默认关闭全部歌词
        SetLyrics(false, false, false, false);

        if (playlist.Length > 0 && songNameText != null)
        {
            songNameText.text = playlist[currentSongIndex].name;
        }
    }

    // 播放当前歌曲
    public void PlayCurrentSong()
    {
        if (playlist.Length == 0)
            return;

        audioSource.clip = playlist[currentSongIndex];

        // 重置播放时间
        audioSource.time = 0f;

        audioSource.Play();

        // 更新歌曲名
        if (songNameText != null)
        {
            songNameText.text = playlist[currentSongIndex].name;
        }

        // 切换歌词
        SwitchLyrics(currentSongIndex);

        // 重置歌词状态
        ResetLyricsScripts();
    }

    // 下一首
    public void NextSong()
    {
        if (playlist.Length == 0)
            return;

        currentSongIndex++;

        if (currentSongIndex >= playlist.Length)
        {
            currentSongIndex = 0;
        }

        PlayCurrentSong();
    }

    // 上一首
    public void PreviousSong()
    {
        if (playlist.Length == 0)
            return;

        currentSongIndex--;

        if (currentSongIndex < 0)
        {
            currentSongIndex = playlist.Length - 1;
        }

        PlayCurrentSong();
    }

    // 播放 / 暂停
    public void TogglePlayPause()
    {
        if (playlist.Length == 0)
            return;

        // 如果还没播放
        if (audioSource.clip == null)
        {
            PlayCurrentSong();
            return;
        }

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();

            // 恢复当前歌词显示
            SwitchLyrics(currentSongIndex);
        }
    }

    // =========================
    // 切换歌词
    // =========================
    void SwitchLyrics(int index)
    {
        switch (index)
        {
            case 0:
                // Da Capo
                SetLyrics(true, false, false, false);
                break;

            case 1:
                // Moon Halo
                SetLyrics(false, true, false, false);
                break;

            case 2:
                // Regression
                SetLyrics(false, false, true, false);
                break;

            case 3:
                // 在出发之前
                SetLyrics(false, false, false, true);
                break;

            default:
                SetLyrics(false, false, false, false);
                break;
        }
    }

    // =========================
    // 控制歌词显示
    // =========================
    void SetLyrics(bool l1, bool l2, bool l3, bool l4)
    {
        if (lyric != null)
            lyric.SetActive(l1);

        if (lyric2 != null)
            lyric2.SetActive(l2);

        if (lyric3 != null)
            lyric3.SetActive(l3);

        if (lyric4 != null)
            lyric4.SetActive(l4);
    }

    // =========================
    // 重置歌词脚本
    // =========================
    void ResetLyricsScripts()
    {
        ResetLyric(lyric);
        ResetLyric(lyric2);
        ResetLyric(lyric3);
        ResetLyric(lyric4);
    }

    void ResetLyric(GameObject obj)
    {
        if (obj == null)
            return;

        MonoBehaviour script = obj.GetComponent<MonoBehaviour>();

        if (script != null)
        {
            script.Invoke("OnEnable", 0f);
        }
    }
}