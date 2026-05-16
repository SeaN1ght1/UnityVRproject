using TMPro;
using UnityEngine;

public class MoonHaloLyrics : MonoBehaviour
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
        new LyricLine(0.00f, "Moon Halo - HOYO-MiX"),
        new LyricLine(3.96f, "¥ £∫TetraCalyx"),
        new LyricLine(4.38f, "«˙£∫≤ÃΩ¸∫≤Zoe(HOYO-MiX)/TetraCalyx"),
        new LyricLine(5.66f, "±‡«˙£∫π¨∆ÊGon(HOYO-MiX)"),
        new LyricLine(6.79f, "÷∆◊˜»À£∫π¨∆ÊGon(HOYO-MiX)"),

        new LyricLine(8.99f, "Some deserts on this planet were oceans once"),
        new LyricLine(16.07f, "Somewhere shrouded by the night the sun will shine"),
        new LyricLine(23.02f, "Sometimes I see a dying bird fall to the ground"),
        new LyricLine(29.54f, "But it used to fly so high"),

        new LyricLine(36.02f, "I thought I were no more than a bystander till I felt a touch so real"),
        new LyricLine(43.05f, "I will no longer be a transient when I see smiles with tears"),

        new LyricLine(50.09f, "If I have never known the sore of farewell and pain of sacrifices"),
        new LyricLine(57.89f, "What else should I engrave on my mind"),

        new LyricLine(65.42f, "Frozen into icy rocks that's how it starts"),
        new LyricLine(72.37f, "Crumbled like the sands of time that's how it ends"),

        new LyricLine(79.49f, "Every page of tragedy is thrown away burned out in the flame"),

        new LyricLine(92.44f, "A shoulder for the past"),
        new LyricLine(95.00f, "Let out the cries imprisoned for so long"),

        new LyricLine(99.40f, "A pair of wings for me at this moment"),
        new LyricLine(103.91f, "To soar above this world"),

        new LyricLine(106.59f, "Turn into a shooting star that briefly shines but warms up every heart"),

        new LyricLine(114.45f, "May all the beauty be blessed"),
        new LyricLine(121.35f, "May all the beauty be blessed"),

        new LyricLine(129.95f, "I will never go"),
        new LyricLine(136.94f, "There's a way back home"),

        new LyricLine(142.91f, "Brighter than tomorrow and yesterday"),

        new LyricLine(150.23f, "May all the beauty be blessed"),

        new LyricLine(163.07f, "Wave good-bye to the past when hope and faith have grown so strong and sound"),

        new LyricLine(169.96f, "Unfold this pair of wings for me again"),

        new LyricLine(174.53f, "To soar above this world"),

        new LyricLine(177.13f, "Turned into a moon that always tells the warmth and brightness of the sun"),

        new LyricLine(185.13f, "May all the beauty be blessed"),
        new LyricLine(192.00f, "May all the beauty be blessed"),

        new LyricLine(199.03f, "»À…˘¬º“Ù Recording£∫–ÏÕ˛@52HzStudio"),
        new LyricLine(199.80f, "œ“¿÷ Strings£∫¡˙÷Æ“’ΩªœÏ¿÷Õ≈"),
        new LyricLine(200.14f, "ªÏ“Ù Mixing Engineer£∫π¨∆ÊGon(HOYO-MiX)"),
        new LyricLine(200.43f, "ƒ∏¥¯ Mastering Engineer£∫π¨∆ÊGon(HOYO-MiX)"),
        new LyricLine(200.73f, "≥ˆ∆∑ Produced by£∫HOYO-MiX")
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