using TMPro;
using UnityEngine;

public class BeforeDepartureLyrics : MonoBehaviour
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
        new LyricLine(0.04f, "在出发之前 - 陶典/hanser/爆裂菊是也/HOYO-MiX"),
        new LyricLine(2.49f, "作词 Lyricist：Hanser"),
        new LyricLine(3.30f, "作曲 Composer：刘佳诺 Raven Rossignol (HOYO-MiX)"),
        new LyricLine(4.15f, "编曲 Arranger：刘佳诺 Raven Rossignol (HOYO-MiX)"),

        new LyricLine(4.37f, "站在旅途的尽头"),
        new LyricLine(8.19f, "面对 下一个 岔路口"),

        new LyricLine(17.56f, "张开手心 它看似很空"),
        new LyricLine(24.35f, "其实已包含所有"),

        new LyricLine(31.58f, "一次次向后回望 想起"),
        new LyricLine(36.89f, "最初 的模样"),

        new LyricLine(45.01f, "目光的方向"),
        new LyricLine(48.27f, "染上了霞光"),
        new LyricLine(51.77f, "却还是不肯翻开下一幅篇章"),

        new LyricLine(58.75f, "不再害怕做不到的事情"),
        new LyricLine(65.51f, "有你为我践行"),
        new LyricLine(70.95f, "（一路践行）"),

        new LyricLine(72.33f, "那些美好或悲伤的记忆"),
        new LyricLine(79.17f, "都藏进背包里"),

        new LyricLine(113.93f, "要去往你所在的 地方"),
        new LyricLine(119.06f, "归程会太长"),

        new LyricLine(127.17f, "思念有翅膀"),
        new LyricLine(130.64f, "也知晓方向"),
        new LyricLine(134.03f, "它会凭借着月光落在我肩膀"),

        new LyricLine(141.15f, "不再害怕会遇见的阻碍"),
        new LyricLine(147.80f, "因为你一直在"),
        new LyricLine(153.58f, "（只要你在）"),

        new LyricLine(154.70f, "就算没迎来同一片未来"),
        new LyricLine(161.54f, "也始终没离开"),

        new LyricLine(196.89f, "“我们 就在这里”"),
        new LyricLine(199.30f, "想一起书写更多的奇迹"),

        new LyricLine(206.06f, "一起穿过星云"),
        new LyricLine(211.21f, "（去看繁星）"),

        new LyricLine(212.94f, "想站在云端前那个身影"),
        new LyricLine(219.77f, "转身依然是你"),
        new LyricLine(223.18f, "（多希望依然是你）"),

        new LyricLine(226.66f, "还有太多没能说完的话"),
        new LyricLine(233.47f, "都来不及传达"),
        new LyricLine(238.57f, "（想要传达）"),

        new LyricLine(240.41f, "若朝着认定的方向出发"),
        new LyricLine(247.18f, "就还会遇见吧"),

        new LyricLine(254.16f, "会再次遇见吧")
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