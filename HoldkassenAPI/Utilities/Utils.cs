﻿using System.Dynamic;

namespace HoldkassenAPI.Utilities
{
    public class Utils
    {
        public static object ReturnableErrorMessage(string message)
        {
            dynamic e = new ExpandoObject();
            e.Message = message;
            return e;
        }
    }
}