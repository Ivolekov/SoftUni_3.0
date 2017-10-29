using System.Linq;
using System.Reflection;

namespace _02BlackBoxInteger
{
    using System;

    class BlackBoxIntegerTests
    {
        static void Main(string[] args)
        {
            Type myType = typeof(BlackBoxInt);
            FieldInfo[] allFields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo innerValue = allFields.First(x => x.Name == "innerValue");

            ConstructorInfo[] nonPublicCtors = myType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            ConstructorInfo ourConstructor = nonPublicCtors[0];
            BlackBoxInt testBlackBox = (BlackBoxInt)ourConstructor.Invoke(new object[] { 0 });

            MethodInfo[] methods = myType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] commandInfo = input.Split('_');
                object[] parameters = new object[] { int.Parse(commandInfo[1]) };

                switch (commandInfo[0])
                {
                    case "Add":
                        MethodInfo addMethod = methods.First(m => m.Name == "Add");
                        addMethod.Invoke(testBlackBox, parameters);
                        break;
                    case "Subtract":
                        MethodInfo subtractMethod = methods.First(m => m.Name == "Subtract");
                        subtractMethod.Invoke(testBlackBox, parameters);
                        break;
                    case "Divide":
                        MethodInfo divideMethod = methods.First(m => m.Name == "Divide");
                        divideMethod.Invoke(testBlackBox, parameters);
                        break;
                    case "Multiply":
                        MethodInfo multiplyMethod = methods.First(m => m.Name == "Multiply");
                        multiplyMethod.Invoke(testBlackBox, parameters);
                        break;
                    case "RightShift":
                        MethodInfo rightShiftMethod = methods.First(m => m.Name == "RightShift");
                        rightShiftMethod.Invoke(testBlackBox, parameters);
                        break;
                    case "LeftShift":
                        MethodInfo leftShiftMethod = methods.First(m => m.Name == "LeftShift");
                        leftShiftMethod.Invoke(testBlackBox, parameters);
                        break;
                }
                Console.WriteLine(innerValue.GetValue(testBlackBox));
                input = Console.ReadLine();
            }

        }
    }
}
