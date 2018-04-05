using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public static class DictionaryToList
    {
        public static string[] dictList => dict.Keys.ToArray();

        public static IDictionary<string, string> dict = new Dictionary<string, string> {
            {"WORKABLE","workable" },
            {"NONWORKABLE","nonworkabe" },
            {"CLOSABLE","closable" },
            {"WORKABLEB","workableb" },
            {"NONWORKABLEB","nonworkabeb" },
            {"CLOSABLEB","closableb" },
            {"WORKABLEC","workablec" },
            {"NONWORKABLEC","nonworkabec" },
            {"CLOSABLEC","closablec" },
            {"WORKABLED","workabled" },
            {"NONWORKABLED","nonworkabed" },
            {"CLOSABLED","closabled" },
            {"WORKABLEE","workablee" },
            {"NONWORKABLEE","nonworkabee" },
            {"CLOSABLEE","closablee" },
            {"WORKABLEF","workablef" },
            {"NONWORKABLEF","nonworkabef" },
            {"CLOSABLEF","closablef" },
            {"WORKABLEG","workableG" },
            {"NONWORKABLEG","nonworkabeG" },
            {"CLOSABLEG","closableG" },
            {"WORKABLEH","workableH" },
            {"NONWORKABLEH","nonworkabeH" },
            {"CLOSABLEH","closableH" },
            {"WORKABLEI","workableI" },
            {"NONWORKABLEI","nonworkabeI" },
            {"CLOSABLEI","closableI" },
            {"WORKABLEJ","workableJ" },
            {"NONWORKABLEJ","nonworkabeJ" },
            {"CLOSABLEJ","closableJ" },
            {"WORKABLEK","workableK" },
            {"NONWORKABLEK","nonworkabeK" },
            {"CLOSABLEK","closableK" },
            {"WORKABLEL","workableL" },
            {"NONWORKABLEL","nonworkabeL" },
            {"CLOSABLEL","closableL" },
        };

        public static string[] numer = new[]
        {
            "WORKABLE",
            "NONWORKABLE",
            "CLOSABLE",
            "WORKABLEB",
            "NONWORKABLEB",
            "CLOSABLEB",
            "WORKABLEC",
            "NONWORKABLEC",
            "CLOSABLEC",
            "WORKABLED",
            "NONWORKABLED",
            "CLOSABLED",
            "WORKABLEE",
            "NONWORKABLEE",
            "CLOSABLEE",
            "WORKABLEF",
            "NONWORKABLEF",
            "CLOSABLEF",
            "WORKABLEG",
            "NONWORKABLEG",
            "CLOSABLEG",
            "WORKABLEH",
            "NONWORKABLEH",
            "CLOSABLEH",
            "WORKABLEI",
            "NONWORKABLEI",
            "CLOSABLEI",
            "WORKABLEJ",
            "NONWORKABLEJ",
            "CLOSABLEJ",
            "WORKABLEK",
            "NONWORKABLEK",
            "CLOSABLEK",
            "WORKABLEL",
            "NONWORKABLEL",
            "CLOSABLEL",

        };

        public static string UseTheSwitch(int branch)
        {
            switch (branch)
            {
                case 0:
                    return "WORKABLE";
                case 1:
                    return "NONWORKABLE";
                case 2:
                    return "CLOSABLE";
                case 3:
                    return "WORKABLEB";
                case 4:
                    return "NONWORKABLEB";
                case 5:
                    return "CLOSABLEB";
                case 6:
                    return "WORKABLEC";
                case 7:
                    return "NONWORKABLEC";
                case 8:
                    return "CLOSABLEC";
                case 9:
                    return "WORKABLED";
                case 10:
                    return "NONWORKABLED";
                case 11:
                    return "CLOSABLED";
                case 12:
                    return "WORKABLEE";
                case 13:
                    return "NONWORKABLEE";
                case 14:
                    return "CLOSABLEE";
                case 15:
                    return "WORKABLEF";
                case 16:
                    return "NONWORKABLEF";
                case 17:
                    return "CLOSABLEF";
                case 18:
                    return "WORKABLEG";
                case 19:
                    return "NONWORKABLEG";
                case 20:
                    return "CLOSABLEG";
                case 21:
                    return "WORKABLEH";
                case 22:
                    return "NONWORKABLEH";
                case 23:
                    return "CLOSABLEH";
                case 24:
                    return "WORKABLEI";
                case 25:
                    return "NONWORKABLEI";
                case 26:
                    return "CLOSABLEI";
                case 27:
                    return "WORKABLEJ";
                case 28:
                    return "NONWORKABLEJ";
                case 29:
                    return "CLOSABLEJ";
                case 30:
                    return "WORKABLEK";
                case 31:
                    return "NONWORKABLEK";
                case 32:
                    return "CLOSABLEK";
                case 33:
                    return "WORKABLEL";
                case 34:
                    return "NONWORKABLEL";
                case 35:
                    return "CLOSABLEL";
            }
            return "";
        }

    }
}
