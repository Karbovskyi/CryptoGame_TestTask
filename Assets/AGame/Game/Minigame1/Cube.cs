using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    public CubeType CubeType;
    public int Id;
    public TMP_Text Text;
    [SerializeField] private ClickableObject ClickableObject;
    
    public UnityEvent<CubeType, Cube> OnClick;

    private void Awake()
    {
        ClickableObject.onClick.AddListener(OnCubeClick);
    }

    private void OnCubeClick()
    {
        OnClick.Invoke(CubeType, this);
    }
}