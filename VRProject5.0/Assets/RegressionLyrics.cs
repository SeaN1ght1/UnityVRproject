using TMPro;
using UnityEngine;

public class RegressionLyrics : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;

    private TextMeshProUGUI textUI;

    [System.Serializable]
    public class LyricLine
    {
        public float time;
        public string lyric;

        public LyricLine(float t, string l)
        {
            time = t;
            lyric = l;
        }
    }

    private LyricLine[] lyrics =
    {
        new LyricLine(0.00f, "Regression - HOYO-MiX"),
        new LyricLine(1.16f, "¥ £∫TetraCalyx"),
        new LyricLine(1.29f, "«˙£∫¡÷“ª∑≤Fan(HOYO-MiX)"),
        new LyricLine(1.63f, "±‡«˙£∫π¨∆ÊGon(HOYO-MiX)/¡÷“ª∑≤Fan(HOYO-MiX)"),
        new LyricLine(2.23f, "÷∆◊˜»À£∫π¨∆ÊGon(HOYO-MiX)"),

        new LyricLine(2.62f, "Too much of the past for one to memorize"),
        new LyricLine(16.13f, "Too many words remained for one to read through the lines"),
        new LyricLine(29.35f, "The ebb and flow of the crowd floods the world and paradise"),
        new LyricLine(42.15f, "Along the path of time"),

        new LyricLine(51.12f, "Every night brings a dream but the day relentlessly keeps me awake"),
        new LyricLine(64.44f, "All the rest will be torn up whenever a choice is made"),
        new LyricLine(77.49f, "Every living soul in the fray striving for their own safe place"),
        new LyricLine(91.40f, "Life is too long to end at a grave"),

        new LyricLine(105.82f, "Just a drop of water suffices"),
        new LyricLine(110.26f, "Encompassed and swallowed through space by the universe"),
        new LyricLine(116.25f, "Back to the source"),

        new LyricLine(118.87f, "Gone are those years living for a reason"),
        new LyricLine(123.10f, "Here it comes the moment of the scene of lost and found"),

        new LyricLine(131.54f, "Personas played out on the stage"),
        new LyricLine(137.32f, "Will return to the self when there's a curtain call"),

        new LyricLine(153.12f, "Every night brings a dream but the day relentlessly keeps me awake"),
        new LyricLine(166.31f, "All the rest will be torn up whenever a choice is made"),

        new LyricLine(179.20f, "Everyone has their own desire leading to the ultimate"),
        new LyricLine(193.08f, "Life is too long to end at a grave"),

        new LyricLine(207.79f, "Just a drop of water suffices"),
        new LyricLine(211.62f, "Still I wish to embrace the world with my thoughts"),

        new LyricLine(218.31f, "A eulogy"),

        new LyricLine(220.78f, "Time to leave where I have stood so long"),

        new LyricLine(225.04f, "Letting you go recover traces overlapped"),

        new LyricLine(231.89f, "Ends then begins"),

        new LyricLine(233.94f, "»À…˘¬º“Ù Vocal Recording£∫–ÏÕ˛@52HzStudio"),
        new LyricLine(234.76f, "œ“¿÷ Strings£∫¡˙÷Æ“’ΩªœÏ¿÷Õ≈"),
        new LyricLine(235.25f, "ªÏ“Ù Mixing Engineer£∫π¨∆ÊGon(HOYO-MiX)"),
        new LyricLine(235.54f, "ƒ∏¥¯ Mastering Engineer£∫π¨∆ÊGon(HOYO-MiX)"),
        new LyricLine(235.83f, "≥ˆ∆∑ Produced by£∫HOYO-MiX")
    };

    private int currentIndex = 0;

    void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        currentIndex = 0;

        if (textUI == null)
            textUI = GetComponent<TextMeshProUGUI>();

        if (textUI != null)
            textUI.text = "";
    }

    void Update()
    {
        if (audioSource == null)
            return;

        if (!audioSource.isPlaying)
            return;

        if (currentIndex >= lyrics.Length)
            return;

        if (audioSource.time >= lyrics[currentIndex].time)
        {
            textUI.text = lyrics[currentIndex].lyric;

            currentIndex++;
        }
    }
}