using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour
{
    [Header("LifeSystem")]
    [SerializeField] private int _playerNumber = default;
    [SerializeField] private int _life = default;
    [SerializeField] private Slider _healthSlider = default;
    
    [Header("Dynamic Win Sys")]
    [SerializeField] private TextMeshProUGUI _winnerName = default;
    [SerializeField] private int _PlayerWinner = default;

    public void MinusLife(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            _life--;
            if (_life <= 0)
            {
                GameManager.Instance.PlayerDeath(_playerNumber);
                WinnerUIChange();
            }
        }
    }

    public void UpdateSlider()
    {
        _healthSlider.value = _life;
    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "smallFist":
                MinusLife(1);
                break;
            case "mediumFist":
                MinusLife(2);
                break;
            case "bigFist":
                MinusLife(3);
                break;
            case "block":
                MinusLife(0);
                break;
            case "ComboFist":
                MinusLife(5);
                break;
            default:
                break;
        }
        UpdateSlider();
    }
    
    public void WinnerUIChange()
    {
        GameManager.Instance.PlayerWin(_winnerName, _playerNumber, _PlayerWinner);
    }
}
