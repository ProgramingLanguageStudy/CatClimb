using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicCastingStudy : MonoBehaviour
{
    public Text TestText;

    public int MyInt = 0;
    public float MyFloat = 0.0f;
    public string MyString = string.Empty;    // = "";


    // Start is called before the first frame update
    void Start()
    {
        // 1. int -> string
        MyString = MyInt.ToString();

        // "D3"의 의미: D는 Decimal 약자.
        // 정수값을 표시할 때 사용하는 표시 형식
        // 숫자 '3' 자리에는 여러 숫자가 올 수 있는데
        // 표시하고 싶은 최소 자리수를 의미한다.
        MyString = MyInt.ToString("D2");

        MyString = MyInt.ToString("N0");

        // 2. float -> string
        MyString = MyFloat.ToString();

        // 소수점을 0자리까지만 보여 주겠다.
        MyString = MyFloat.ToString("F0");

        // 소수점을 2번째 자리까지만 보여 주겠다.
        MyString = MyFloat.ToString("F2");

        MyString = MyFloat.ToString("N5");

        // 3. int -> float
        // C#에서 자동으로 int값을 float값으로 변환해서 처리
        //MyFloat = MyInt;
        // int값과 float값을 혼합하여 연산을 할 경우
        // C#에서 int값을 자동으로 float값으로 변환하여
        // float값 결과를 되돌려주는 연산을 진행한다.
        //MyFloat = MyFloat + MyInt;

        // 4. float -> int

        // float의 소수점 아래 숫자들을 버리고 int값으로 변환
        MyInt = (int)MyFloat;

        // float값을 반올림해서 int값으로 변환
        MyInt = Mathf.RoundToInt(MyFloat);

        // float값을 내림해서 int값으로 변환
        MyInt = Mathf.FloorToInt(MyFloat);

        // float값을 올림해서 int값으로 변환
        MyInt = Mathf.CeilToInt(MyFloat);

        // 5. string -> int
        MyString = "1 2^3";

        // int.Parse() 함수는 string 값을 매개변수로 받아서
        // 해당 string 값이 정수로 변환이 가능한 값이면
        // 변환해서 되돌려 준다.
        //MyInt = int.Parse(MyString);

        // int.TryParse() 함수는 string 값을 매개변수로 받아서
        // 해당 string 값이 정수로 변환이 가능한 값이면
        // true를 되돌려 준다. out 키워드로 변환된 int값을 되돌려 준다.
        // out 키워드 뒤에는 변환된 int값을 받을 변수를 적어 주면 된다.
        // 변환이 실패하면 out 키워드 뒤의 int 변수에 0 값을 저장하게 된다.
        if(int.TryParse(MyString, out MyInt))
        {
            Debug.Log("변환된 정수: " + MyInt);
        }
        else
        {
            Debug.Log("정수로 변환할 수 없는 문자열입니다.");
        }

        // 6. string -> float
        MyString = "-13.5";
        //MyFloat = float.Parse(MyString);

        if(float.TryParse(MyString, out MyFloat))
        {
            Debug.Log("변환된 실수: " + MyFloat);
        }
        else
        {
            Debug.Log("실수로 변환할 수 없는 문자열입니다.");
        }

        UpdateTestText();
    }

    void UpdateTestText()
    {
        string str = "MyInt: " + MyInt
            + "\nMyFloat: " + MyFloat
            + "\nMyString: " + MyString;

        TestText.text = str;
    }
}
