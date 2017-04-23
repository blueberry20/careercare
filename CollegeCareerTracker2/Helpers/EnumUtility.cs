using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CollegeCareerTracker2.Enums.Enums;

namespace CollegeCareerTracker2.Helpers
{
    public class EnumUtility
    {
        public static string GetStringValue(AnswerOptionsEnum value)
        {
            //System.Diagnostics.Debug.Write("test:"+ value);
            string result;
            switch (value)
            {
                case AnswerOptionsEnum.NotImportant:
                    result = "Not Important";
                    break;
                case AnswerOptionsEnum.Important:
                    result = "Important";
                    break;
                case AnswerOptionsEnum.NotSure:
                    result = "Not Sure";
                    break;
                default:
                    result = "Not Found";
                    break;

            }
            return result;
        }
    }
}