using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculette : MonoBehaviour
{
    public GameObject displayComponent;
    private string currentDisplay ="";
    private int currentFigure;
    private List<byte> currentNumber = new List<byte>();
    private string currentSymbol;
    private int currentIndex = 0;
    private List<int> memory = new List<int>();
    private bool symbolInput = false;
    
    public void NumSelect( int chiffreInt)
    {
        byte chiffre = (byte)chiffreInt;
        if (!symbolInput)
        {
            symbolInput = true;

        }

        currentFigure = chiffre;
        currentNumber.Add(chiffre);
        currentDisplay += chiffre.ToString();
        TextMeshProUGUI Target = displayComponent.GetComponent<TextMeshProUGUI>();
        Target.text = currentDisplay;

    }
    public void SymSelect(string symbol)
    {
        Debug.Log("symbol" + symbol.ToString());
        if (symbolInput)
        {
            Debug.Log("symbol ok " );
            if (symbol == "egal")
            {
                
                    
                string numberStr = "";
                currentNumber.ForEach(n =>
                    {
                        numberStr += n.ToString();
                    }
                );

                int nb = int.Parse(numberStr);
                memory.Add(nb);
                //memory[currentIndex] = nb;
                currentIndex++;
                currentNumber = new List<byte>();
                currentDisplay = "";
                Debug.Log(" memory " + memory.ToString());

                if (memory.Count > 1)
                {

                    Debug.Log("count ");
                    int resultat = 0;
                    switch (currentSymbol)
                    {
                        case "ajouter":
                            {
                                Debug.Log("ajout");
                                resultat = memory[0] + memory[1];
                                Debug.Log(resultat);
                            }
                            break;

                    }
                    TextMeshProUGUI Target = displayComponent.GetComponent<TextMeshProUGUI>();
                    currentDisplay = resultat.ToString();
                    Target.text = currentDisplay;

                }
            }
            else
            {
                currentSymbol = symbol;
                TextMeshProUGUI target = displayComponent.GetComponent<TextMeshProUGUI>();
                target.text = "";
                string numberStr = "";
                currentNumber.ForEach(n =>
                {
                    numberStr += n.ToString();
                }
                );
                
                int nb = int.Parse(numberStr);
                memory.Add(nb);
                //memory[currentIndex] = nb;
                currentIndex++;
                currentNumber = new List<byte>();
                currentDisplay = "";
                /*NumericInput = true;*/
            }




        }


    }
    
}
