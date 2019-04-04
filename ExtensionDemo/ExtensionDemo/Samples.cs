using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionDemo
{
    public static class Samples
    {
        //Crazify String
        public static string Crazify(this string word)
        {
            //do crazy things to string
            return "";
        }
        //Insanify Int
        public static int Insanify(this int number)
        {
            //do insane things to int
            return 0;
        }

        public static void Method()
        {
            var word = "Normal String";
            word.Crazify();

            var number = 2;
            number.Insanify();
        }
    }



}
