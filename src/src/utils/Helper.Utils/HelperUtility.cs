using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Utils
{
    public class HelperUtility
    {
        public static string GetEnvironmentVariable(string key)
        {
            var value = Environment.GetEnvironmentVariable(key);


            if (value == null)
            {
                throw new NullReferenceException("Environment variable not found:" + key
                    + "\n 1.Check if docker image is using edesign.env file."
                    + "\n 2. Have declared the environment variable in edesign.env?"
                    + "\n 3. Have declared the environment variable in system settings?");
            }
            return value;
        }
    }
}
