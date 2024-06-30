using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();

    [SerializeField] private List<GameObject> knifeIconList = new List<GameObject>();

    [SerializeField] private GameObject knifePrefab;

    [SerializeField] private GameObject knifeIconPrefab;

    [SerializeField] private Vector2 knifeIconPosition;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color passiveColor;


    [SerializeField] private int knifeCount;

    private int knifeIndex;
    void Start()
    {
        CreateKnife();
    }

    void Update()
    {
        
    }

    private void CreateKnife()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity);     
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
        }
        
        knifeList[0].SetActive(true);
    }

    private void CreateKnifeIcons()
    {
        
    }
    
    public void SetKnifeActive(){
        if (knifeIndex < knifeCount - 1)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true);
        }
    }
}
