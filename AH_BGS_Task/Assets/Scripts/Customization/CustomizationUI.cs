using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationUI : MonoBehaviour
{
    [SerializeField] Section sectionPrefab;
    [SerializeField] Transform content;
    [SerializeField] ItemInfosSO itemInfosSO;

    void Start()
    {
        for (int i = 0; i < itemInfosSO.sectionInfos.Length; i++)
        {
            Section s = Instantiate(sectionPrefab.gameObject, content).GetComponent<Section>();
            s.Setup(itemInfosSO.sectionInfos[i]);
        }
    }
    public void Done()
    {
        DataManager.Instance.SaveData();
        FadeScreen.Instance.FadeOut(LoadScene);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
