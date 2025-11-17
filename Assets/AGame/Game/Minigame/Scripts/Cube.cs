using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    public CubeType CubeType;
    public int Id;
    public TMP_Text Text;
    public TMP_Text Text2;
    [SerializeField] private ClickableObject ClickableObject;
    [SerializeField] private ParticleSystem _linked;
    [SerializeField] private ParticleSystem _linkFailed;
    [SerializeField] private ParticleSystem _error;
    
    public UnityEvent<CubeType, Cube> OnClick;

    private void Awake()
    {
        ClickableObject.onClick.AddListener(OnCubeClick);
    }

    private void OnCubeClick()
    {
        OnClick.Invoke(CubeType, this);
    }

    public void Linked()
    {
       var x = Instantiate(_linked, transform.position, transform.rotation, transform);
       x.gameObject.SetActive(true);
    }

    public void LinkFailed()
    {
        var x = Instantiate(_linkFailed, transform.position, transform.rotation, transform);
        x.gameObject.SetActive(true);
    }

    public void Error()
    {
        var x = Instantiate(_error, transform.position, transform.rotation, transform);
        x.gameObject.SetActive(true);
    }
}