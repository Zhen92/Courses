using System;

namespace FunctionObject
{
    class Program
    {
        static void GetTypeOfValue(object typeofObject)
        {
            string stringToObject = Convert.ToString(typeofObject);

            bool isSbyte = sbyte.TryParse(stringToObject, out sbyte sbyteVar);

            bool isByte = byte.TryParse(stringToObject, out byte byteVar);

            bool isUshort = ushort.TryParse(stringToObject, out ushort ushortVar);

            bool isShort = short.TryParse(stringToObject, out short shortVar);

            bool isUint = uint.TryParse(stringToObject, out uint uintVar);

            bool isInt = int.TryParse(stringToObject, out int intVar);

            bool isUlong = ulong.TryParse(stringToObject, out ulong ulongVar);

            bool islong = long.TryParse(stringToObject, out long longVar);

            bool isFloat = float.TryParse(stringToObject, out float floatVar);

            bool isDouble = double.TryParse(stringToObject, out double doubleVar);

            bool isChar = char.TryParse(stringToObject, out char charVar);

            string stringforCW;

            switch (true)
            {
                case true when isSbyte:
                    typeofObject = sbyteVar.GetType();
                    stringforCW = "sbyte";
                    break;
                case true when isByte:
                    typeofObject = byteVar.GetType();
                    stringforCW = "byte";
                    break;
                case true when isUshort:
                    typeofObject = ushortVar.GetType();
                    stringforCW = "ushort";
                    break;
                case true when isShort:
                    typeofObject = shortVar.GetType();
                    stringforCW = "short";
                    break;
                case true when isUint:
                    typeofObject = uintVar.GetType();
                    stringforCW = "uint";
                    break;
                case true when isInt:
                    typeofObject = intVar.GetType();
                    stringforCW = "int";
                    break;
                case true when isUlong:
                    typeofObject = ulongVar.GetType();
                    stringforCW = "ulong";
                    break;
                case true when islong:
                    typeofObject = longVar.GetType();
                    stringforCW = "long";
                    break;
                case true when isFloat:
                    typeofObject = floatVar.GetType();
                    stringforCW = "float";
                    break;
                case true when isDouble:
                    typeofObject = doubleVar.GetType();
                    stringforCW = "double";
                    break;
                case true when isChar:
                    typeofObject = charVar.GetType();
                    stringforCW = "char";
                    break;
                default:
                    typeofObject = stringToObject.GetType();
                    stringforCW = "string";
                    break;
            }
            Console.WriteLine($"Type of {stringToObject} is {typeofObject} or just {stringforCW}");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter ur object: ");
            object value = Console.ReadLine();
            GetTypeOfValue(value);
        }
    }
}
