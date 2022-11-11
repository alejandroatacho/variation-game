using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class comparison : MonoBehaviour {

    // empty strings op het moment.
    public string option1, option2, main;
    // deze images zijn allemaal goeie images.
     Texture2D[] imagesCorrect;
    // deze images zijn allemaal foute images.
     Texture2D[] imagesWrong;
    // voor images die al geweest zijn, zodat je geen duplicate hebt.
    List<int> imagesSeen = new List<int>();
    // Transform positie, rotation and scale(size).
    Transform[] placeholders;
    //
    Renderer Picturerenderer;
    //
    Material temp;
    // Use this for initialization
    int RandomNr;

    float counter = 0;

    int timer = 1;

    int mainIndex = 0, option1Index = 0, option2Index = 0;

    public bool click = false;

    void Start () {

        placeholders = new Transform[3];
        for (int i = 0; i < transform.childCount; i++)
        {
            //dan pak het de childrens, i(index) , position van waar de images komen ook.
            placeholders[i] = transform.GetChild(i);
        }
        // load tot resource dan moet je zelf de path zetten van de folder. 
        //(texture2D load alle images net als je hebt int string heb je ook texture 2D)
        // nu is de array imagesCorrect gevulled met alle images van het folder Correct.
       imagesCorrect = Resources.LoadAll<Texture2D>("pictures/Correct");
        // path maar voor wrong
       imagesWrong = Resources.LoadAll<Texture2D>("pictures/Wrong");

        // random generator van 0 tot array zijn max.length -1 omdat in programmeren beginnen we bij 0 en niet 1.
        //en ook nog in een variable zetten.
       

        
        RandomNr = UnityEngine.Random.Range(0, imagesCorrect.Length - 1);
        

       
        for (int i = 0; i < placeholders.Length; i++)
        {
            if (placeholders[i].name == main)
            {
                mainIndex = i;
            }

            if(placeholders[i].name == option1)
            {
                option1Index = i;
            }
            if(placeholders[i].name == option2)
            {
                option2Index = i;
            }
        }
        SetImage(mainIndex, imagesCorrect);

        //image slots om een mix te krijgen zodat het niet alleen 1 kant goed is en andere kant fout.
     
            Random random = new Random();
        int randomNumber = random.Next(0, 50);


        if (randomNumber >= 25)
        {
            placeholders[option1Index].GetComponent<Format>().type = PictureTypes.Right;
            placeholders[option2Index].GetComponent<Format>().type = PictureTypes.Wrong;
            SetImage(option2Index, imagesWrong);
            SetImage(option1Index, imagesCorrect);
            SetImage(mainIndex, imagesCorrect);

        }
        else
        {
            placeholders[option1Index].GetComponent<Format>().type = PictureTypes.Wrong;
            placeholders[option2Index].GetComponent<Format>().type = PictureTypes.Right;
            SetImage(option2Index, imagesCorrect);
            SetImage(option1Index, imagesWrong);
            SetImage(mainIndex, imagesCorrect);
        }


    }

    // Update is called once per frame
    void Update () {

    
        // de timer voor 3 seconden, blijft checken bij else statement als de counter groter is dan de timer zodat 
        //mensen het spel/image niet kunnen spamm klikken * ook nog omdat het spel kapot gaat als we het niet doet*
		if (counter >= timer)
        {
            click = false;
            counter = 0;
        }
        else

        {
               // deltatime telt seconden in de timer.
            counter += Time.deltaTime;
        }

	}
    public void NextImage()
    {
        if (click == true)
        {
            return;
        }
        click = true;

        Random random = new Random();
        int randomNumber = random.Next(0, 50);
        
        
        if (randomNumber >= 25)
        {
            placeholders[option1Index].GetComponent<Format>().type = PictureTypes.Right;
            placeholders[option2Index].GetComponent<Format>().type = PictureTypes.Wrong;
            SetImage(option2Index, imagesWrong);
            SetImage(option1Index, imagesCorrect);
            SetImage(mainIndex, imagesCorrect);

        }
        else
        {
            placeholders[option2Index].GetComponent<Format>().type = PictureTypes.Right;
            placeholders[option1Index].GetComponent<Format>().type = PictureTypes.Wrong;
            SetImage(option2Index, imagesCorrect);
            SetImage(option1Index, imagesWrong);
            SetImage(mainIndex, imagesCorrect);
        }

        if (imagesSeen.Contains(RandomNr))
        {
            RandomNr = UnityEngine.Random.Range(0, imagesCorrect.Length - 1);
        }

    }
    public void SetImage(int placeholderIndex, Texture2D[] images)
    {
        Picturerenderer = placeholders[placeholderIndex].GetComponent<Renderer>();
        temp = Picturerenderer.material;
        temp.SetTexture("_MainTex", images[RandomNr]);
        placeholders[placeholderIndex].GetComponent<Renderer>().material = temp;
        imagesSeen.Add(RandomNr);
    }


}
