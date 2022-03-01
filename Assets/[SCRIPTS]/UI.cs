using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private Canvas _canvStart = default;

    public void Awake()
    {
        while (_canvStart.enabled == true)
        {

        }
    }

    public void UIPlay()
    {
        _canvStart.enabled = false;
    }

   
}
