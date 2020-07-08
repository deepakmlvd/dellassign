using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Utils
{
    public class CustomValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string _description = value.ToString();
                if (_description != "")
                {
                    List<string> _specialCharacters = new List<string> { "@", "+", "-", "=", "<", ">", "/" };

                    if (_specialCharacters.Exists(p => p.Equals(_description[0].ToString())))
                        return false;
                    else
                        return true;
                }
            }
            return true;
        }
    }
   
}
