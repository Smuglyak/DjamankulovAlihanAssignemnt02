using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//things to understand: multiply, add, substract, and the way the arrays being manipulated.

namespace HugeInteger
{
    class HugeInteger
    {
        private int[] intArray = new int[40];//the array
        public HugeInteger()//init the array with values of 0
        {
            for (int i = 0; i < 40; i++)
            {
                intArray[i] = 0;
            }
        }

        //the input for the number as string
        public void Input(string str) 
        {

            char[] arr = str.Trim().PadLeft(40, '0').ToCharArray(); // takes input and turns it to char array which has 40 chars
            //takes  input first and removes all white space then makes sure it is at least 40 digits by padding it to left
            //takes the string and turns into char array so all characters are as one in array elements
            intArray = new int[40];
            for (int i = 39; i >= 0; i--)
            {
                intArray[i] = arr[i] - '0';//int array stores all the integer value elements from the char array
            }

        }
        public override string ToString()
        {
            bool started = false;
            string str = "";
            for (int i = 0; i < intArray.Length; i++)
            {
                if (!started && intArray[i] == 0)
                    continue;
                else if (!started)
                    started = true;
                str = str + intArray[i];//string + the integer, to show the string representation of integer
            }
            if (string.IsNullOrEmpty(str))//if the array is the empty, then give zero as string.
                return "0";
            return str;
        }
        public HugeInteger Multiply(HugeInteger secondNum)
        {
            HugeInteger multiResult = new HugeInteger(); // instantiating HugeInteger class object with all methods for the result object
            multiResult.Input("0"); //setting the input for it to be 0. 
            if (!secondNum.IsZero()) // if the input given is not object with zero as its input, do this
            {
                var count = 0; //count of 0
               // for-loop in reverse each digit from the left-hand number
                foreach (var digitChar in secondNum.ToString().ToCharArray().Reverse())// for each digitChar in the otherNum object we do smh
                {
                    count++; //we augment the count by 1
                    var digit = digitChar - '0';  //we create a var in which we store the int value of the digitChar
                    var carry = 0;// we create carry var
           

                    var thisCount = 0; //we create another count of 0
                    
                    foreach( var thisDigitChar in this.ToString().ToCharArray().Reverse())//thats another digitChar that we going through in the object mentioned and do the same loop(2 loop inside 1 loop)
                    {
                        thisCount++; // another count goes up
                        var thisDigit = (thisDigitChar - '0') + carry; //we create a var for second loop in which we store the int value of the digitChar and add carry to it.
                        var multResult = thisDigit * digit; // we get the multiplication result by multiplying the digit from before and this digit.
                        carry = multResult / (10 * thisCount);// we set the carry to the result divided by thiscount multiplied by 10

                        var addResult = new HugeInteger();//addresult is a new HugeInteger object
                        var addResultStr = multResult.ToString().PadRight(1 + (count -1) + (thisCount - 1), '0');//addResult but a string
                        addResult.Input(addResultStr);//addresult gets the addresultstr as input
                        multiResult.Add(addResult);//result object adds the addresult to it.
                        // add to  huge integer
                    }
                } 
            }
            return multiResult;// return the result object again
        }

        public HugeInteger Divide(HugeInteger secondNum)
        {
            HugeInteger result = new HugeInteger();
            HugeInteger timesDivided = new HugeInteger();
            result.Input("0");//input 0 to hugecount
            timesDivided.Input("1");//input 1 for increment
            //hugeCount.Add(hugeCount);
            while (this.IsGreaterThanOrEqualTo(secondNum))//while firstnum is bigger than second num
            {
                this.Subtract(secondNum);//firstnum substract the secondnum
                result = result.Add(timesDivided);//counts times divided for the result
            }
            return result;
        }

        public HugeInteger Remainder(HugeInteger secondNum)
        {
            HugeInteger num1 = new HugeInteger();
            HugeInteger num2 = new HugeInteger();
            HugeInteger result = new HugeInteger();
            num1.Input(this.Divide(secondNum).Multiply(secondNum).ToString());
            num2.Input(this.ToString());
            string ans = num2.Subtract(num1).ToString().TrimStart('0');
            if (ans.Equals(""))
            {
                ans = "0";
            }
            result.Input(ans);
            return result;
        }
        public HugeInteger Add(HugeInteger secondNum)
        {
            string str1 = this.ToString();
            string str2 = secondNum.ToString();
            if (str1.Length > str2.Length)
            {
                string temp = this.ToString();
                str1 = secondNum.ToString();
                str2 = temp;
            }

            string str = "";
            int diff = str2.Length - str1.Length;//difference btw lengths of nums
            int carry = 0;

            for (int i = str1.Length - 1; i >= 0; i--)
            {
                int sum = ((char)(str1[i] - '0') + (char)(str2[i + diff] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            for (int i = str2.Length - str1.Length - 1; i >= 0; i--)
            {
                int sum = ((char)(str2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            if (carry > 0)
                str += (char)(carry + '0');

            char[] ch2 = str.ToCharArray();
            Array.Reverse(ch2);
            string reverse = new string(ch2);
            this.Input(reverse);
            return this;
        }
        public HugeInteger Subtract(HugeInteger secondNum)
        {
            string str = "";
            int difference = this.intArray.Length - secondNum.intArray.Length;
            int carry = 0;

            for (int i = secondNum.intArray.Length - 1; i >= 0; i--)
            {
                int sub = intArray[i + difference] - secondNum.intArray[i] - carry;

                if (sub < 0)
                {
                    sub += 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
                str += sub.ToString();
            }
            for (int i = intArray.Length - secondNum.intArray.Length - 1; i >= 0; i--)
            {
                if (intArray[i] == 0 && carry > 0)
                {
                    str += "9";
                    continue;
                }
                int sub = intArray[i] - carry;
                if (i > 0 || sub > 0)
                {
                    str += sub.ToString();
                }
                carry = 0;
            }
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            string reverse = new string(charArray);
            this.Input(reverse);
            return this;
        }

        public Boolean IsZero()
        {
            HugeInteger zero = new HugeInteger();//insantiating zero object
            zero.Input("0");//putting zero as the input for it

            if (this.IsEqualTo(zero)) //gives true if the object mentioned is equal to zero object, not false
            {
                return true;
            }
            return false;

        }

        public Boolean IsEqualTo(HugeInteger secondNum)
        {
            string str = this.ToString();
            string str2 = secondNum.ToString();
            str = str.TrimStart('0');
            str2 = str2.TrimStart('0');//removes all 0s from the strings and
            if (str.Equals(str2))//checks if they are equal
            {
                return true;
            }
            return false;
        }

        public Boolean IsNotEqualTo(HugeInteger secondNum)
        {
            return !IsEqualTo(secondNum);//reverses the equalto method
        }

        public Boolean IsGreaterThan(HugeInteger secondNum)
        {
            string str = this.ToString();
            string str2 = secondNum.ToString();
            str = str.TrimStart('0');
            str2 = str2.TrimStart('0');
            if (str.Length > str2.Length)
            {
                return true;
            }
            else if (str.Length < str2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] > str2[i])
                    {
                        return true;
                    }
                    else if (str[i] == str2[i])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public Boolean IsLessThan(HugeInteger secondNum)
        {
            return !(IsGreaterThan(secondNum) || IsEqualTo(secondNum));
        }


        public Boolean IsGreaterThanOrEqualTo(HugeInteger secondNum)
        {
            if (this.IsZero() && secondNum.IsZero())
            {
                return true;
            }
            for (int i = 0; i < intArray.Length; i++)
            {
                if (this.intArray[i] > secondNum.intArray[i])
                    return true;
                else if (this.intArray[i] < secondNum.intArray[i])
                    return false;
            }
            return true;
        }

        public Boolean IsLessThanOrEqualTo(HugeInteger secondNum)
        {
            return !IsGreaterThan(secondNum);
        }

    }
}