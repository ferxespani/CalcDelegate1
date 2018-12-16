using System;
using Newtonsoft.Json;
using System.IO;


namespace CalcDelegate
{
    class Calc
    {
        public delegate double Operation();
        public Settings s = File.Exists("json.json") ? JsonConvert.DeserializeObject<Settings>(File.ReadAllText("json.json")) : new Settings { };

        public Calc()
        {
        }

        public void DoOperation(Operation operation)
        {
            var result = operation();
            Console.WriteLine(result);
        }
        
        public double Sum()
        {
            double result = 0;
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

                            result += double.Parse(temp.ToString());

                            temp = " ";
                        }
                    }
                    break;
                }
            }
            Console.Write($"Sum of {s.Numbers} equals   ");
            return result;
        }

        
        public double Sub()
        {
            double result = 0;
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
                                result = double.Parse(s.Numbers[j].ToString());
                            else
                                result -= double.Parse(temp.ToString());

                            temp = "";
                        }
                    }
                    break;
                }
            }
            Console.Write($"Sub of {s.Numbers} equals   ");
            return result;
        }

        public double Multiplication()
        {
            double result = 0;
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
                                result = double.Parse(s.Numbers[j].ToString());
                            else if (result == 0 && temp != "")
                                result = double.Parse(temp.ToString());
                            else
                                result *= double.Parse(temp.ToString());

                            temp = "";
                        }
                    }
                    break;
                }
            }
            Console.Write($"Multiply of {s.Numbers} equals   ");
            return result;
        }

        public double Dividing()
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
            Console.Write($"Dividing of {s.Numbers} equals   ");
            return result;
        }
    }
}
