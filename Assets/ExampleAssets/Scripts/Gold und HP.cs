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

    // Start is called before the first frame update
    void Start()
    {
        nachrichthp = GetComponent<TextMeshProUGUI>();
        nachrichtgold = GetComponent<TextMeshProUGUI>();
        hp=50;
    }

    // Update is called once per frame
    void Update()
    {
        nachrichthp.SetText("" + hp);
        nachrichtgold.SetText("" + gold);
    }
}
