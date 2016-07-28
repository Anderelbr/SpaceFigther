using UnityEngine;
using UnityEngine.UI;

public class UI_AIPLayer : MonoBehaviour
{
    Camera main;
    public Scrollbar bar;

    void Start()
    {
        main = Camera.main;
    }

    void Update()
    {
        bar.size = GetComponent<Player>().currentHealth / GetComponent<Player>().health;
    }
}
