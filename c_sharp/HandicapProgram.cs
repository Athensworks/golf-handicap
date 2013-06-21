using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Athensworks.GolfHandicap.Application
{
    class HandicapProgram
    {

        // Please edit this string to match your local file
        private static string filePath = "C:\\Users\\Sidney\\Documents\\Development\\Athensworks.GolfHandicap\\Athensworks.GolfHandicap.Application\\scores.xml";

        private class Round
        {
            public int Score { get; set; }
            public int Slope { get; set; }
            public double Rating { get; set; }
            public int Par { get; set; }
        }
        static void Main(string[] args)
        {
            // get the list of scores
            List<Round> rounds = Scores2List();
            // compute the handicap 15.1
            double handicap = Get_Handicap(rounds);
            // output the result
            Console.Write("The handicap is: " + handicap.ToString());
            Console.ReadLine();
        }
        private static List<Round> Scores2List()
        {
            // load the XML file
            StreamReader scoresFile = new StreamReader(filePath);
            string scoresXML = scoresFile.ReadToEnd();
            scoresFile.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(scoresXML);
            // defined the XML node containing a round object
            XmlNodeList idNodes = doc.SelectNodes("scores/score");
            // create a new list of rounds
            List<Round> rounds = new List<Round>();
            // populate the list of rounds
            foreach (XmlNode node in idNodes)
            {
                Round newRound = new Round();
                newRound.Score = Convert.ToInt32(node.ChildNodes[0].InnerText);
                newRound.Slope = Convert.ToInt32(node.ChildNodes[1].InnerText);
                newRound.Rating = Convert.ToDouble(node.ChildNodes[2].InnerText);
                newRound.Par = Convert.ToInt32(node.ChildNodes[3].InnerText);
                rounds.Add(newRound);
            }
            // return the list of rounds
            return rounds;
        }
        private static double Get_Handicap(List<Round> ScoreList)
        {
            List<double> diff_List = new List<double>();
            List<double> Result_diffs = new List<double>();
            for (int i = 0; i < ScoreList.Count; i++) // Loop through List with for
            {
                double diff = 0;
                Round c = ScoreList[i];
                diff = ((double)c.Score - c.Rating) * 113 / (double)c.Slope;
                diff_List.Add(diff);
            }
            Result_diffs = get_correct_diffs(diff_List);
            double sum = 0;
            for (int i = 0; i < Result_diffs.Count; i++) // Loop through List with for
            {
                double c = Result_diffs[i];
                sum += c;
            }
            double result = sum / Result_diffs.Count;
            result =  result * .96;
            result = Math.Truncate(10 * result) / 10;
            return result;
        }
        private static List<double> get_correct_diffs(List<double> org_diffs)
        {
            List<Double> result = new List<double>();
            int count = org_diffs.Count;
            int num_diffs = NumLowest(count);
            org_diffs.Sort();
            for (int i = 0; i < num_diffs; i++)
            {
                result.Add(org_diffs[i]);
            }
            return result;
        }
        private static int NumLowest(int num)
        {
            switch (num)
            {
                case 5:
                    return 1;
                    break;
                case 6:
                    return 1;
                    break;
                case 7:
                    return 2;
                    break;
                case 8:
                    return 2;
                    break;
                case 9:
                    return 3;
                    break;
                case 10:
                    return 3;
                    break;
                case 11:
                    return 4;
                    break;
                case 12:
                    return 4;
                    break;
                case 13:
                    return 5;
                    break;
                case 14:
                    return 5;
                    break;
                case 15:
                    return 6;
                    break;
                case 16:
                    return 6;
                    break;
                case 17:
                    return 7;
                    break;
                case 18:
                    return 8;
                    break;
                case 19:
                    return 9;
                    break;
                case 20:
                    return 10;
                    break;
                default:
                    return 0;
                    break;
            }
        }
    }
}
