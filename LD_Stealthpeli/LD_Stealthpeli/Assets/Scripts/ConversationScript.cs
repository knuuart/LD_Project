using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationScript : MonoBehaviour {

    public Text dialogue;
    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    int trgNumber;
    int trgNumber2;
    int trgNumber3;
    int trgNumber4;
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
        trgText = "It's a guy from your junior high. He was a bit of a jock.";

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

                if(trgNumber3 != 12345)
                {
                    optionText = trgTexts[num2 + 2].Split(' ');

                    for(int i = 1; i < optionText.Length;i++)
                    {
                        option3.text += optionText[i] + " ";
                    }
                }

                if (trgNumber4 != 12345 && trgNumber3 !=12345)
                {
                    optionText = trgTexts[num2 + 3].Split(' ');

                    for (int i = 1; i < optionText.Length; i++)
                    {
                        option4.text += optionText[i] + " ";
                    }
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
                    option3.text = "";
                    option4.text = "";

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
                    option3.text = "";
                    option4.text = "";

                    chooseOption = false;
                }

                num = 0;
                asd = 0f;
                dialogue.text = "";
            }


            if (Input.GetKeyDown(KeyCode.C) && option3.text != "")
            {

                ProcessNextDialog();

                if (chooseOption)
                {
                    num2 = trgNumber3;
                    print("fuken" + trgNumber3);
                    string[] split3 = trgTexts[num2 + 2].Split(' ');
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
                    option3.text = "";
                    option4.text = "";

                    chooseOption = false;
                }

                num = 0;
                asd = 0f;
                dialogue.text = "";
            }

            if (Input.GetKeyDown(KeyCode.V) && option4.text != "")
            {

                ProcessNextDialog();

                if (chooseOption)
                {
                    num2 = trgNumber4;
                    print("fuken" + trgNumber4);
                    string[] split3 = trgTexts[num2 + 3].Split(' ');
                    int indexx;
                    bool numeric = int.TryParse(split3[0], out indexx);
                    if (split3.Length != 1 || !numeric)
                    {
                        trgText = trgTexts[num2];
                        print("wtf");
                    }
                    else
                    {
                        trgText = trgTexts[indexx];
                        print("ok");
                    }
                    num2 += 1;
                    option1.text = "";
                    option2.text = "";
                    option3.text = "";
                    option4.text = "";

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
        string[] split = { "aee, eaa" };

        bool abort1;
        bool abort2;
        bool abort3;
        bool abort4;
        if (trgTexts.Count > num2)
        {
            split = trgTexts[num2].Split(' ');
            abort1 = false;
        }else
        {
            abort1 = true;
        }

        string[] split2 = { "aee, eaa" };
        if (trgTexts.Count > num2 + 1)
        {
            split2 = trgTexts[num2 + 1].Split(' ');
            abort2 = false;
        }else
        {
            abort2 = true;
        }

        string[] split3 = { "aee", "eaa" };
        if (trgTexts.Count > num2 + 2)
        { 
            split3 = trgTexts[num2 + 2].Split(' ');
            abort3 = false;


        }else
        {
            abort3 = true;
        }
        string[] split4 = { "aee", "eaa" };
        if (trgTexts.Count > num2 + 3)
        {
            split4 = trgTexts[num2 + 3].Split(' ');
            abort4 = false;
        }else
        {
            abort4 = true;
        }



        int index = 0;
        int index2 = 0;
        int index3 = 0;
        int index4 = 0;

        bool isNumber = false;
        bool isNumber2 = false;
        bool isNumber3 = false;
        bool isNumber4 = false;

        if (!abort1)
        {
            isNumber = int.TryParse(split[0], out index);
        }

        if (!abort2)
        {
            isNumber2 = int.TryParse(split2[0], out index2);
        }
        if (!abort3)
        {
            isNumber3 = int.TryParse(split3[0], out index3);
        }
        if (!abort4)
        {
            isNumber4 = int.TryParse(split4[0], out index4);
        }


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
                if (isNumber3)
                {
                    trgNumber3 = index3;
                }else
                {
                    trgNumber3 = 12345;
                }
                if (isNumber4)
                {
                    trgNumber4 = index4;
                }else
                {
                    trgNumber4 = 12345;
                }
            


            }

        }
    }

    

        
    
}
