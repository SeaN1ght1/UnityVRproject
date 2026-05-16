using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LyricsControllerXR : MonoBehaviour
{
    [Header("LRC File")]
    public TextAsset lrcFile;

    [Header("Audio")]
    public AudioSource audioSource;

    [Header("Lyrics UI")]
    public TextMeshProUGUI lyricText;

    [Header("Fade")]
    public float fadeSpeed = 3f;

    private List<LyricLine> lyrics = new List<LyricLine>();

    private int currentIndex = 0;

    private Color textColor;

    void Start()
    {
        ParseLRC();

        textColor = lyricText.color;
        textColor.a = 0f;
        lyricText.color = textColor;
    }

    void Update()
    {
        if (audioSource == null || !audioSource.isPlaying)
            return;

        if (currentIndex < lyrics.Count)
        {
            if (audioSource.time >= lyrics[currentIndex].time)
            {
                ShowLyric(lyrics[currentIndex].lyric);

                currentIndex++;
            }
        }

        FadeText();
    }

    void ParseLRC()
    {
        lyrics.Clear();

        string[] lines = lrcFile.text.Split('\n');

        foreach (string line in lines)
        {
            if (!line.StartsWith("["))
                continue;

            int endBracket = line.IndexOf("]");

            if (endBracket < 0)
                continue;

            string timeStr = line.Substring(1, endBracket - 1);

            string lyric = line.Substring(endBracket + 1);

            string[] timeParts = timeStr.Split(':');

            if (timeParts.Length < 2)
                continue;

            float minutes = float.Parse(timeParts[0]);

            float seconds = float.Parse(timeParts[1]);

            float totalTime = minutes * 60 + seconds;

            LyricLine lyricLine = new LyricLine();

            lyricLine.time = totalTime;
            lyricLine.lyric = lyric;

            lyrics.Add(lyricLine);
        }
    }

    void ShowLyric(string lyric)
    {
        lyricText.text = lyric;

        textColor.a = 0f;
        lyricText.color = textColor;
    }

    void FadeText()
    {
        if (textColor.a < 1f)
        {
            textColor.a += Time.deltaTime * fadeSpeed;

            lyricText.color = textColor;
        }
    }
}