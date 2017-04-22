using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationScript : MonoBehaviour {

    public Text dialogue;
    public Text option1;
    public Text option2;
    int trgNumber;
    int trgNumber2;
    bool addOption = false;
    bool chooseOption = false;
    string trgText;
    public List<string> trgTexts;
    int num = 0;
    int num2 = 0;

    float asd = 0f;


	// Use this for initialization
	void Start () {

        // trgTexts = new List<string>();
        trgText = "It's your uncle's neighbour.";

        dialogue.text = "";
        
		
	}
	
	// Update is called once per frame
	void Update () {


       

        asd += Time.deltaTime*50f;
        if(asd> 1*(num+1) && num < trgText.Length)
        {
            dialogue.text += trgText[num];
            num += 1;
            
        }



        if(num >= trgText.Length)
        {

            if(addOption)
            {
                string[] optionText = trgTexts[num2].Split(' ');
                print(optionText.Length);

                for(int i = 1; i < optionText.Length;i++)
                {
                    option1.text += optionText[i] + " ";
                }

                optionText = trgTexts[num2 + 1].Split(' ');
                print(optionText.Length);
                for (int i = 1; i < optionText.Length;i++)
                {
                    option2.text += optionText[i] + " ";
                }
                chooseOption = true;

                addOption = false;
            }
            

            if(Input.GetKeyDown(KeyCode.Z))
            {

                ProcessNextDialog();

                if(chooseOption)
                {

                    num2 = trgNumber;
                    string[] split3 = trgTexts[num2+1].Split(' ');
                    int indexx;
                    bool numeric = int.TryParse(split3[0], out indexx);
                    if (split3.Length != 1 ||!numeric)
                    {
                        trgText = trgTexts[num2];
                    }else
                    {
                        trgText = trgTexts[indexx];
                    }
                    num2 += 1;
                    option1.text = "";
                    option2.text = "";

                    chooseOption = false;
                }
             

                num = 0;
                asd = 0f;
                dialogue.text = "";
                
            }
            


            if (Input.GetKeyDown(KeyCode.X))
            {

                ProcessNextDialog();

                if (chooseOption)
                {
                    num2 = trgNumber2;
                    print("fuken" + trgNumber2);
                    string[] split3 = trgTexts[num2 + 1].Split(' ');
                    int indexx;
                    bool numeric = int.TryParse(split3[0], out indexx);
                    if (split3.Length != 1 || !numeric)
                    {
                        trgText = trgTexts[num2];
                    }
                    else
                    {
                        trgText = trgTexts[indexx];
                    }
                    num2 += 1;
                    option1.text = "";
                    option2.text = "";

                    chooseOption = false;
                }

                num = 0;
                asd = 0f;
                dialogue.text = "";
            }
        }

        
        

        

        








    }

    void ProcessNextDialog()
    {
        trgText = trgTexts[num2];

        num2 += 1;
        string[] split = trgTexts[num2].Split(' ');
        string[] split2 = trgTexts[num2 + 1].Split(' ');


        int index;
        int index2;
        bool isNumber = int.TryParse(split[0], out index);
        bool isNumber2 = int.TryParse(split2[0], out index2);


        if (isNumber && !chooseOption)
        {

            if (split.Length == 1)
            {
                num2 = index;
                trgText = trgTexts[num2];
                num2 += 1;
                print("num2:" +num2);


            }
            else
            {
                addOption = true;
                trgNumber = index;
                print("numero 1:" + trgNumber);
                trgNumber2 = index2;
                print("numero 2:" + trgNumber2);
            }

        }
    }

    

        
    
}
