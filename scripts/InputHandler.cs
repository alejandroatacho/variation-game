using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputHandler : MonoBehaviour
{

    public Text scoreText;
    // score teller
    int teller = 0;
    float counter, timer = 0.3f;

    void Start()
    {
        scoreText.text = ("score: 0");
    }

    void Update()
    {
        if (counter >= timer)
        {
            
            if (Input.touchCount > 0)
            {
                Touch[] screenPoints = Input.touches;
                Camera cam = Camera.current;

                for (int i = 0; i < 1; i++)
                {
                    Ray ray = cam.ScreenPointToRay(screenPoints[i].position);

                    RaycastHit hitInfo;

                    if (Physics.Raycast(ray, out hitInfo, 100))
                    {
                        //hitInfo.transform.SendMessage("Clicked");
                        //scoreText.text = ("hit: " + hitInfo.transform.name);

                        /* het vraagt eerst of de transform van hit info component( alles in de inspector)
                         * heeft die heet Format, en dan zo ja geef die component.
                         */
                        Format picture = hitInfo.transform.GetComponent<Format>();
                        //scoreText.text = ("hit: " + picture.type);
                        if (picture)
                        {
                            //Right
                            if (picture.type == PictureTypes.Right)
                            {


                                if (!GetComponent<comparison>().click)
                                {
                                    teller = (int)(teller + 1.2f * Random.Range(1, 5));
                                    scoreText.text = ("score: " + teller);

                                }

                            }
                            //wrong
                            if (picture.type == PictureTypes.Wrong)
                            {
                                if (!GetComponent<comparison>().click)
                                {

                                    teller = (int)(teller - 1.2f * Random.Range(1, 5));
                                    scoreText.text = ("score: " + teller);
                                }

                            }
                            GetComponent<comparison>().NextImage();
                            counter = 0;
                        }
                    }
                }
            }
            } else
            {
                counter += Time.deltaTime;
            } 
        }
    }


