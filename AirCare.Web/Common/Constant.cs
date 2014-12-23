using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirCare.Web.Core
{
    public class Constant
    {
        public static String[] SECURITY_QUESTIONS = {
			"What is the first name of the person you first kissed?",
			"What is the last name of the teacher who gave you your first failing grade?",
			"What is the name of the place your wedding reception was held?",
			"What is the name of the first beach you visited?",
			"In what city or town did you meet your spouse/partner?",
			"What was the make and model of your first car?",
			"What was your maternal grandfather's first name?",
			"In what city or town does your nearest sibling live?" };

        public static String[] AIRLINES = { "Deutsche Lufthansa",
			"United Continental Holdings", "Delta Air Lines", "Air France-KLM",
			"American Airlines Group", "International Airlines Group",
			"Southwest Airlines", "All Nippon Airways",
			"China Southern Airlines", "Qantas Airways" };
    }
}