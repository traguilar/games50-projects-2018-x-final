using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowHealth : MonoBehaviour
{
    public GameObject Bar;
    private Slider slider;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        slider = Bar.GetComponent<Slider>();
        text = GetComponent<TextMeshProUGUI>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.RoundToInt(slider.value).ToString() + " / " + slider.maxValue.ToString();
    }
}
