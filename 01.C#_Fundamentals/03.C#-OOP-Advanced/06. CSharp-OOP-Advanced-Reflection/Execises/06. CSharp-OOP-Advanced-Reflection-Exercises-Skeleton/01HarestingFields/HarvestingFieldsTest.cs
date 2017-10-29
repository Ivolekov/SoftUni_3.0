using System.Reflection;

namespace _01HarestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Type theType = typeof(HarvestingFields);

            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "protected":
                        FieldInfo[] protectedFields = theType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                        foreach (var protectedField in protectedFields)
                        {
                            if (protectedField.IsFamily)
                            {
                                Console.WriteLine($"{GetAccessString(protectedField)} {protectedField.FieldType.ToString().Substring(protectedField.FieldType.ToString().LastIndexOf('.') + 1)} {protectedField.Name}");
                            }
                        }
                        break;

                    case "public":
                        FieldInfo[] publicFields = theType.GetFields(BindingFlags.Instance | BindingFlags.Public);

                        foreach (var publicField in publicFields)
                        {
                            if (publicField.IsPublic)
                            {
                                Console.WriteLine($"{GetAccessString(publicField)} {publicField.FieldType.ToString().Substring(publicField.FieldType.ToString().LastIndexOf('.') + 1)} {publicField.Name}");
                            }
                        }
                        break;

                    case "private":
                        FieldInfo[] privateFields = theType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

                        foreach (var privateField in privateFields)
                        {
                            if (privateField.IsPrivate)
                            {
                                Console.WriteLine($"{GetAccessString(privateField)} {privateField.FieldType.ToString().Substring(privateField.FieldType.ToString().LastIndexOf('.') + 1)} {privateField.Name}");
                            }
                        }
                        break;

                    case "all":

                        FieldInfo[] fields = theType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                        foreach (var field in fields)
                        {
                            Console.WriteLine($"{GetAccessString(field)} {field.FieldType.ToString().Substring(field.FieldType.ToString().LastIndexOf('.') + 1)} {field.Name}");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }

        public static string GetAccessString(FieldInfo accessor)
        {
            if (accessor.IsFamily)
            {
                return "protected";
            }
            else if (accessor.IsPublic)
            {
                return "public";
            }
            else if (accessor.IsPrivate)
            {
                return "private";

            }
            return null;
        }
    }
}
