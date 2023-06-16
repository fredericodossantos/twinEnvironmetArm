using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConveyorButton : MonoBehaviour
{
    public Conveyor conveyor;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleConveyor);
    }

    public void ToggleConveyor()
    {
        conveyor.isActive = !conveyor.isActive;
    }
}
