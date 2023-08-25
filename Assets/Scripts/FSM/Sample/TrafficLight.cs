using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLight : FSMSystem
{
    public GreenState greenState;
    public YellowState yellowState;
    public RedState redState;

    public Image lightImage;
    // Start is called before the first frame update
    void Start()
    {
        greenState.parent = this;
        AddState(greenState);

        yellowState.parent = this;
        AddState(yellowState);

        redState.parent = this;
        AddState(redState);
    }


}
