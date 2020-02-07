using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockTap : MonoBehaviour
{
    public float Timelimit = 120f;
    public float Limiter;
    public float currentTime;
    public float dotTime = 0.5f;
    public float seperateTime = 1.0f;
    public float timer;
    public float Score;
    public bool dot;
    public bool dash;
    public Text display;
    public Text displayConverted;
    public Text randomLetter;
    public Text CurrentScore;
    public Text FinalScore;
    public string morseCodeConverted;
    public string morseCode;
    public string rand;
    public Dictionary<string, char> _codes = new Dictionary<string, char>();
    


    // Start is called before the first frame update
    void Start()
    {   
        _codes.Add(".-", 'A');
        _codes.Add("-..." , 'B');
        _codes.Add("-.-." , 'C');
        _codes.Add("-.." , 'D');
        _codes.Add("." , 'E');
        _codes.Add("..-." , 'F');
        _codes.Add("--." , 'G');
        _codes.Add("...." , 'H');
        _codes.Add(".." , 'I');
        _codes.Add(".---" , 'J');
        _codes.Add("-.-" , 'K');
        _codes.Add(".-.." , 'L');
        _codes.Add("--" , 'M');
        _codes.Add("-." , 'N');
        _codes.Add("---" , 'O');
        _codes.Add(".--." , 'P');
        _codes.Add("--.-" , 'Q');
        _codes.Add(".-." , 'R');
        _codes.Add("..." , 'S');
        _codes.Add("-" , 'T');
        _codes.Add("..-" , 'U');
        _codes.Add("...-" , 'V');
        _codes.Add(".--" , 'W');
        _codes.Add("-..-" , 'X');
        _codes.Add("-.--" , 'Y');
        _codes.Add("--.." , 'Z');
        _codes.Add(".----" , '1');
        _codes.Add("..---" , '2');
        _codes.Add("...--" , '3');
        _codes.Add("....-" , '4');
        _codes.Add("....." , '5');
        _codes.Add("-...." , '6');
        _codes.Add("--..." , '7');
        _codes.Add("---.." , '8');
        _codes.Add("----." , '9');
        _codes.Add("-----" , '0');

        randomCharacter();

}

       



    // Update is called once per frame
    void Update()
    {
        Limiter += Time.deltaTime;
        if (Limiter >= Timelimit)
        {
            FinalScore.text = "Score:" + Score;
            Time.timeScale = 0;
        }

        if (Limiter <= Timelimit)
        {
            CurrentScore.text = "" + Score;
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                currentTime += Time.fixedDeltaTime;
            }
            if (Input.GetButtonUp("Fire1"))
            {
                MorseDotDash();
                currentTime = 0f;
            }
            timer += Time.fixedDeltaTime;
            if (timer >= seperateTime)
            {
                CharacterEnd();
            }
        }
    }

    void MorseDotDash()
    {
        if(currentTime <= dotTime)
        {
            Dot();
        }
        else
        {
            Dash();
        }

        display.text = morseCode;

    }

    public void Dot()
    {
        print("DOT");
        morseCode = (morseCode + ".");
    }

    public void Dash()
    {
        print("DASH");
        morseCode = (morseCode + "-");
    }

    public void CharacterEnd()
    {
        char temp;
        _codes.TryGetValue(morseCode, out temp);
        print(temp);
        morseCode = "";
        display.text = morseCode;
        morseCodeConverted = "" + temp;
        displayConverted.text = morseCodeConverted;
        if (morseCodeConverted.Equals(rand)){
            randomCharacter();
            Score += 1;
        }
    }

    public void randomCharacter()
    {
        string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string random = Alphabet[Random.Range(0, Alphabet.Length)];
        randomLetter.text = random;
        rand = random;
    }
}
