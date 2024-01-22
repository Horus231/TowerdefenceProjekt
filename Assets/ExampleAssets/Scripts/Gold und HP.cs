using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldundHP : MonoBehaviour
{
    public TMP_Text nachrichthp;
    public TMP_Text nachrichtgold;
    public static int gold=0;
    public static int hp=0;

    void Start()
    {
        nachrichthp = GetComponent<TextMeshProUGUI>();
        nachrichtgold = GetComponent<TextMeshProUGUI>();
        hp=50;
    }

    void Update()
    {
        nachrichthp.SetText("" + hp);
        nachrichtgold.SetText("" + gold);
    }
}
