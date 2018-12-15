using System;
using Newtonsoft.Json;
using System.IO;


namespace CalcDelegate
{
    class Calc
    {
        public delegate void LogToConsole(string msg);
        LogToConsole _l;
        public Settings s = File.Exists("json.json") ? JsonConvert.DeserializeObject<Settings>(File.ReadAllText("json.json")) : new Settings { };

        public Calc(LogToConsole l)
        {
            _l = l;
        }

        
        public void Sum()
        {
            int result = 0;
            string temp = " ";
            for (int i = 0; i < s.Operations.Length; i++)
            {
                if (s.Operations[i] == '+')
                {
                    for (int j = 0; j < s.Numbers.Length; j++)
                    {
                        if (s.Numbers[j] == ',')
                            continue;
                        else
                        {
                            if (j + 1 < s.Numbers.Length)
                            {
                                if (s.Numbers[j + 1] != ',')
                                {
                                    temp += s.Numbers[j].ToString();
                                    continue;
                                }
                            }
                            temp += s.Numbers[j].ToString();

                            result += int.Parse(temp.ToString());

                            temp = " ";
                        }
                    }
                    break;
                }
            }
            _l($"Sum of numbers {s.Numbers}: {result}");
        }

        
        public void Sub()
        {
            int result = 0;
            string temp = "";
            for (int i = 0; i < s.Operations.Length; i++)
            {
                if (s.Operations[i] == '-')
                {
                    for (int j = 0; j < s.Numbers.Length; j++)
                    {
                        if (s.Numbers[j] == ',')
                            continue;
                        else
                        {
                            if (j + 1 < s.Numbers.Length)
                            {
                                if (s.Numbers[j + 1] != ',')
                                {
                                    temp += s.Numbers[j].ToString();
                                    continue;
                                }
                            }
                            temp += s.Numbers[j].ToString();

                            if (j == 0)
                                result = int.Parse(s.Numbers[j].ToString());
                            else
                                result -= int.Parse(temp.ToString());

                            temp = "";
                        }
                    }
                    break;
                }
            }
            _l($"Sub of numbers {s.Numbers}: {result}");
        }

        public void Multiplication()
        {
            int result = 0;
            string temp = "";
            for (int i = 0; i < s.Operations.Length; i++)
            {
                if (s.Operations[i] == '*')
                {
                    for (int j = 0; j < s.Numbers.Length; j++)
                    {
                        if (s.Numbers[j] == ',')
                            continue;
                        else
                        {
                            if (j + 1 < s.Numbers.Length)
                            {
                                if (s.Numbers[j + 1] != ',')
                                {
                                    temp += s.Numbers[j].ToString();
                                    continue;
                                }
                            }
                            temp += s.Numbers[j].ToString();

                            if (j == 0)
                                result = int.Parse(s.Numbers[j].ToString());
                            else if (result == 0 && temp != "")
                                result = int.Parse(temp.ToString());
                            else
                                result *= int.Parse(temp.ToString());

                            temp = "";
                        }
                    }
                    break;
                }
            }
            _l($"Multiplication of numbers {s.Numbers}: {result}");
        }

        public void Dividing()
        {
            double result = 0;
            string temp = "";
            for (int i = 0; i < s.Operations.Length; i++)
            {
                if (s.Operations[i] == '/')
                {
                    for (int j = 0; j < s.Numbers.Length; j++)
                    {
                        if (s.Numbers[j] == ',')
                            continue;
                        else
                        {
                            if (j + 1 < s.Numbers.Length)
                            {
                                if (s.Numbers[j + 1] != ',')
                                {
                                    temp += s.Numbers[j].ToString();
                                    continue;
                                }
                            }
                            temp += s.Numbers[j].ToString();

                            if (j == 0)
                                result = double.Parse(s.Numbers[j].ToString());
                            else if(result == 0 && temp != "")
                                result = double.Parse(temp.ToString());
                            else
                                result /= double.Parse(temp.ToString());

                            temp = "";
                        }
                    }
                    break;
                }
            }
            _l($"Dividing of numbers {s.Numbers}: {result}");
        }
    }
}
