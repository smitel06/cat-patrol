using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FrenzyBuff : MonoBehaviour
{
    public Slider buffSlider;
    float maxValue;
    float minValue;
    public float currentValue;
    bool tickDown;
    bool buffOn;
    //other ui stuff
    public Text frenzyText;

    // Start is called before the first frame update
    void Start()
    {
        tickDown = true;
        maxValue = 100;
        minValue = 0;
        currentValue = 0;

        //set slider values
        buffSlider.maxValue = maxValue;
        buffSlider.minValue = minValue;
        buffSlider.value = currentValue;
    }

    private void Update()
    {
        buffSlider.value = currentValue;

        //every second buff is over 0 tick down 1
        if (currentValue > minValue && tickDown && !buffOn)
        {
            CancelInvoke();
            InvokeRepeating("TickDown", 3.0f, 1.0f);
            tickDown = false;
        }
        else if (currentValue <= 0)
        {
            CancelInvoke();
            currentValue = 0;
        }

        if (currentValue >= 100)
        {
            buffOn = true;

            if (currentValue > 100)
            {
                currentValue = 100;
            }

            buffed();
            
        }
        
        if(buffOn && currentValue == 0)
        {
            CancelInvoke();
            buffOn = false;
            tickDown = true;
        }
        

    }

    //add 10 to buff when cat is found
    public void addValue()
    {
        CancelInvoke();
        tickDown = true;
        currentValue += 30;
    }

    public void TickDown()
    {
        currentValue -= 1f;
    }

    public void buffed()
    {
        currentValue -= 1.0f;
        Debug.Log("buffed!");
        
        //character is in a cat frenzy
        InvokeRepeating("TickDown", 2.0f, 0.25f);
        InvokeRepeating("buffFeedback", 2.0f, 0.25f);
    }

    public void buffFeedback()
    {
        //pulsating text
        if (frenzyText.fontSize == 35)
        {
            for(int i = 0; i < 7; i++)
            {
                frenzyText.fontSize++;
            }
        }
        else
            frenzyText.fontSize = 35;


    }
    
}
