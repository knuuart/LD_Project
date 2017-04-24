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
    public Text TimeLeft;
    public Text ShamePoints;
    public GameManagerScript gm;
    public Transform timer;
    int trgNumber;
    int trg2Number;
    int trgNumber2;
    int trg2Number2;
    int trgNumber3;
    int trg2Number3;
    int trgNumber4;
    int trg2Number4;
    bool addOption = false;
    bool chooseOption = false;
    bool noMoreText = false;
    public string trgText;
    public List<string> trgTexts;
    int num = 0;
    int num2 = 0;
    float timerXmaxscale;
    float timerYscale;
    float minusScale;

    float asd = 0f;


	// Use this for initialization
	void Start () {



        // trgTexts = new List<string>();
        

        gm = FindObjectOfType<GameManagerScript>();

        dialogue.text = "";

        timerXmaxscale = timer.localScale.x;
        timerYscale = timer.localScale.y;

        timer.localScale = new Vector3(0f, timerYscale, 0f);
        
        
        
		
	}
	
	// Update is called once per frame
	void Update () {

        ShamePoints.text = "Shame tolerance "+gm.ShameMeter + "/" + gm.shameThreshold;


       

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

                for(int i = 1; i < optionText.Length-1;i++)
                {
                    option1.text += optionText[i] + " ";
                }

                optionText = trgTexts[num2 + 1].Split(' ');
                print(optionText.Length);
                for (int i = 1; i < optionText.Length-1;i++)
                {
                    option2.text += optionText[i] + " ";
                }

                if(trgNumber3 != 12345)
                {
                    optionText = trgTexts[num2 + 2].Split(' ');

                    for(int i = 1; i < optionText.Length-1;i++)
                    {
                        option3.text += optionText[i] + " ";
                    }
                }

                if (trgNumber4 != 12345 && trgNumber3 !=12345)
                {
                    optionText = trgTexts[num2 + 3].Split(' ');

                    for (int i = 1; i < optionText.Length-1; i++)
                    {
                        option4.text += optionText[i] + " ";
                    }
                }



                chooseOption = true;

                addOption = false;

                timer.localScale = new Vector3(timerXmaxscale,timerYscale,1f);
            }


            if(chooseOption)
            {

                minusScale += Time.deltaTime;

                var timeleftvar =  6 - (int) minusScale;

                int someshit;

                if(timeleftvar < 0)
                {
                    someshit = 0;
                }else
                {
                    someshit = timeleftvar;
                }
                

                TimeLeft.text = someshit + "";

                timer.localScale = new Vector3(timerXmaxscale - minusScale, timerYscale, 1f);


                if(timeleftvar < 0)
                {
                    chooseOption = false;
                    minusScale = 0f;
                    timer.localScale = new Vector3(0, timerYscale, 1f);
                    

                    int inndex;
                    int number2;
                    string[] moresplit = trgTexts[num2 - 1].Split(' ');
                    int.TryParse(moresplit[moresplit.Length-2], out inndex);

                    int.TryParse(moresplit[moresplit.Length - 1], out number2);


                    gm.ShameMeter += number2;

                    print("testnumber " + inndex);
                    num2 = inndex;
                    trgText = trgTexts[num2];
                    num2 += 1;


                    num = 0;
                    asd = 0f;
                    dialogue.text = "";

                    option1.text = "";
                    option2.text = "";
                    option3.text = "";
                    option4.text = "";

                    int number;

                    string[] evenmoresplit = trgTexts[num2].Split(' ');
                    bool onkonumero = int.TryParse(evenmoresplit[0], out number);



                    if (onkonumero)
                    {
                        if(evenmoresplit.Length==1)
                        {
                            num2 = number;
                            trgText = trgTexts[num2];
                            num2 += 1;

                        }else
                        {
                            num2 -= 1;
                            ProcessNextDialog();
                            
                        }
                    }



                }

            }else
            {
                TimeLeft.text = "";
            }


            if (!noMoreText)
            {

                if (Input.GetKeyDown(KeyCode.Z))
                {

                    ProcessNextDialog();

                    if (chooseOption)
                    {

                        chooseOption = false;

                        num2 = trgNumber;
                        string[] split3 = trgTexts[num2 + 1].Split(' ');
                        int indexx;

                        bool numeric = int.TryParse(split3[0], out indexx);

                        gm.ShameMeter += trg2Number;

                        if (!numeric)
                        {
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else if (split3.Length == 1)
                        {
                            num2 = indexx;
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else
                        {

                            ProcessNextDialog();
                            minusScale = 0f;
                        }

                        option1.text = "";
                        option2.text = "";
                        option3.text = "";
                        option4.text = "";


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
                        string[] split3 = trgTexts[num2 + 1].Split(' ');
                        chooseOption = false;

                        num2 = trgNumber2;
                        print("fuken" + trgNumber2);
                        
                        int indexx;

                        bool numeric = int.TryParse(split3[0], out indexx);

                        gm.ShameMeter += trg2Number2;
                        if (!numeric)
                        {
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else if (split3.Length == 1)
                        {
                            num2 = indexx;
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else
                        {

                            ProcessNextDialog();
                            minusScale = 0f;
                        }
                        option1.text = "";
                        option2.text = "";
                        option3.text = "";
                        option4.text = "";


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

                        string[] split3 = trgTexts[num2 + 2].Split(' ');
                        chooseOption = false;

                        num2 = trgNumber3;
                        print("fuken" + trgNumber3);
                        
                        
                        int indexx;

                        bool numeric = int.TryParse(split3[0], out indexx);

                        gm.ShameMeter += trg2Number3;
                        if (!numeric)
                        {
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else if (split3.Length == 1)
                        {
                            num2 = indexx;
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else
                        {

                            ProcessNextDialog();
                            minusScale = 0f;
                        }
                        option1.text = "";
                        option2.text = "";
                        option3.text = "";
                        option4.text = "";


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

                        string[] split3 = trgTexts[num2 + 3].Split(' ');
                        chooseOption = false;

                        num2 = trgNumber4;
                        print("fuken" + trgNumber4);
                        
                        int indexx;

                        bool numeric = int.TryParse(split3[0], out indexx);

                        gm.ShameMeter += trg2Number4;
                        if (!numeric)
                        {
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else if (split3.Length == 1)
                        {
                            num2 = indexx;
                            trgText = trgTexts[num2];
                            num2 += 1;
                        }
                        else
                        {

                            ProcessNextDialog();
                            minusScale = 0f;
                        }
                        option1.text = "";
                        option2.text = "";
                        option3.text = "";
                        option4.text = "";


                    }

                    num = 0;
                    asd = 0f;
                    dialogue.text = "";
                }
            }




        }

        
        

        

        








    }

    void ProcessNextDialog()
    {
        print("asddfffffffffffffggh");

        if (num2 < trgTexts.Count)
        {
            trgText = trgTexts[num2];
        }
        if(num2 > trgTexts.Count -1 )
        {
            print("ohi on");
            noMoreText = true;
            gm.currentState = GameManagerScript.GameState.Running;
        }

        print("sdf");
        string[] txt = trgText.Split(' ');

        int numero;
        int numero2;
        bool lastnumeric = false;
        if (txt.Length > 1)
        {
            lastnumeric = int.TryParse(txt[txt.Length - 1], out numero);
        }

        bool secondtolastnumeric = false;
        if (txt.Length > 2)
        {
            secondtolastnumeric = int.TryParse(txt[txt.Length - 2], out numero2);
        }

        print("jossain ");

        if(lastnumeric)
        {
            trgText = "";
            if(secondtolastnumeric)
            {
                for(int i = 0; i < txt.Length - 2; i++)
                {
                    trgText += txt[i] + " ";
                }
            }else
            {
                for (int i = 0; i < txt.Length - 1; i++)
                {
                    trgText += txt[i] + " ";
                }
            }
        }

        print("tää ");
        print(num2);
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

        print("menee ");


        int index = 0;
        int indexx1 = 0;
        int index2 = 0;
        int indexx2 = 0;
        int index3 = 0;
        int indexx3 = 0;
        int index4 = 0;
        int indexx4 = 0;

        bool isNumber = false;
        bool isNumber2 = false;
        bool isNumber3 = false;
        bool isNumber4 = false;

        print("test1");
        if (!abort1)
        {
            isNumber = int.TryParse(split[0], out index);
            int.TryParse(split[split.Length - 1], out indexx1);
        }
        print("test2");
        if (!abort2)
        {
            isNumber2 = int.TryParse(split2[0], out index2);
            int.TryParse(split2[split2.Length - 1], out indexx2);
        }
        if (!abort3)
        {
            isNumber3 = int.TryParse(split3[0], out index3);
            int.TryParse(split3[split3.Length - 1], out indexx3);
        }
        if (!abort4)
        {
            isNumber4 = int.TryParse(split4[0], out index4);
            int.TryParse(split4[split4.Length - 1], out indexx4);
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
                trg2Number = indexx1;
                print("numero 1:" + trgNumber);
                trgNumber2 = index2;
                trg2Number2 = indexx2;
                print("numero 2:" + trgNumber2);
                if (isNumber3)
                {
                    trgNumber3 = index3;
                }else
                {
                    trgNumber3 = 12345;
                }
                trg2Number3 = indexx3;
                if (isNumber4)
                {
                    trgNumber4 = index4;
                }else
                {
                    trgNumber4 = 12345;
                }
                trg2Number4 = indexx4;
            


            }
            

        }
        print("rikki ");
        
    }

    

        
    
}
