namespace Users.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string)value;
            string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(stringValue);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
