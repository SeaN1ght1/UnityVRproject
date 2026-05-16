using TMPro;
using UnityEngine;

public class DaCapoLyrics : MonoBehaviour
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
        new LyricLine(0.00f, "Da Capo - HOYO-MiX"),
        new LyricLine(0.40f, "作词 : TetraCalyx"),
        new LyricLine(1.30f, "When good old friends are going away"),
        new LyricLine(7.26f, "Will you wish them to remember your name?"),
        new LyricLine(14.25f, "When good old days are passing away"),
        new LyricLine(20.02f, "Will you promise your heart remains the same"),
        new LyricLine(27.60f, "Never can we suspend the time"),
        new LyricLine(34.10f, "Having to leave the tracks behind"),
        new LyricLine(40.61f, "there is a longer way ahead, After all."),
        new LyricLine(55.10f, "There used to be a story teller"),
        new LyricLine(60.99f, "who always painted the sunshine and the rain"),
        new LyricLine(67.72f, "One has to eventually grow up"),
        new LyricLine(73.45f, "Spending a lifetime to taste the love and pain"),
        new LyricLine(80.66f, "Never can we suspend the time"),
        new LyricLine(87.53f, "Having to leave the tracks behind"),
        new LyricLine(94.25f, "there is a longer way ahead, After all."),
        new LyricLine(107.33f, "If it’s too hard to say goodbye"),
        new LyricLine(113.68f, "Give us a try to sing a rhyme"),
        new LyricLine(120.16f, "\"May you, the beauty of this world, always shine.\""),
        new LyricLine(132.73f, "演唱 Vocal Artist：车子玉Ziyu Che"),
        new LyricLine(134.51f, "弦乐 Strings：龙之艺交响乐团"),
        new LyricLine(136.55f, "混音 Mixing Engineer：宫奇Gon"),
        new LyricLine(137.14f, "出品 Produced by：HOYO-MiX")
    };

    private int currentIndex = 0;

    void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();

        if (textUI != null)
        {
            textUI.text = "";
        }
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
}