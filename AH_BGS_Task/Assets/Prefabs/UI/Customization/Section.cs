using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] ItemUI itemUIPrefab;

    public void Setup(SectionInfo sectionInfo)
    {
        for (int i = 0; i < sectionInfo.itemInfos.Length; i++)
        {
            ItemUI go = Instantiate(itemUIPrefab.gameObject, transform).GetComponent<ItemUI>();
            go.Setup(sectionInfo.itemInfos[i], sectionInfo.bodyPart);
        }
    }
}
