using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Bonuses : MonoBehaviour
{
    public List<Sprite> imagesBonuses = new List<Sprite>();
    public List<string> namesBonuses = new List<string>();
    public PersistentDatas persistentDatas;
    public string key;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    public GameObject sceneMananger;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = sceneMananger.GetComponent<AudioSource>();
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        persistentDatas = GameObject.Find("Constants").GetComponent<PersistentDatas>();

        int randomChoice = Random.Range(0, 5);
        text.text = namesBonuses[randomChoice];
        key = namesBonuses[randomChoice];
        image.sprite = imagesBonuses[randomChoice];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {

        persistentDatas.activeBonuses.Add(key);
        persistentDatas.UpdateBonuses();
        SceneManager.LoadScene("GameState");
    }

    private IEnumerator SoundAndLoadScene()
    {
        audioSource.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameState");

    }


}
