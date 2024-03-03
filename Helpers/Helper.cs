using System;
namespace WebApp.web.Helpers
{
    public class Helper : IHelper
	{
		

        public string Upper(string text)
        {
            return text.ToUpper();
        }
    }
}

