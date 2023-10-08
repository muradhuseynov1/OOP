using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assigment1_RX15MW
{
    class Menu
    {
        private readonly Bag b = new();
        public void Run()
        {
            int v;
            do
            {
                v = GetMenuPoint();
                switch(v)
                {
                    case 1:
                        PutIn();
                        Console.WriteLine("Updated Bag:");
                        Write();
                        break;
                    case 2:
                        TakeOut();
                        Console.WriteLine("Updated Bag:");
                        Write();
                        break;
                    case 3:
                        GetFreq();
                        Console.WriteLine("Current Bag:");
                        Write();
                        break;
                    case 4:
                        GetLarg();
                        Console.WriteLine("Current Bag:");
                        Write();
                        break;
                    case 5:
                        Console.WriteLine("Current Bag:");
                        Write();
                        break;
                    default:
                        Console.WriteLine("\nGoodBye!");
                        break;
                }
            } while(v != 0);
        }

        private static int GetMenuPoint()
        {
            try
            {
                int v;
                Console.WriteLine("\n************************");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Insert Element");
                Console.WriteLine("2. Remove Element");
                Console.WriteLine("3. Get Frequency of an Element");
                Console.WriteLine("4. Get the Largest Element");
                Console.WriteLine("5. Print the Bag");

                Console.WriteLine("\nChoose an Option:");
                v = int.Parse(Console.ReadLine());

                return v;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nEXCEPTION THROWN: Wrong Format! Enter an integer:\n");
                Console.WriteLine("\nChoose an Option:");
                int v = int.Parse(Console.ReadLine());
                return v;
            }
        }

        private void PutIn()
        {
            try
            {
                Console.WriteLine("Enter An Element To Insert Into The Bag:");
                int elem;
                elem = int.Parse(Console.ReadLine());
                b.InsertElement(elem);
                Console.WriteLine("\nUPDATE: The Element Has Been Inserted To The Bag Successfully!\n");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nEXCEPTION THROWN: Wrong Format! Enter an integer:\n");
            }
        }

        private void TakeOut()
        {
            bool err = false;
            try
            {
                int elem;
                Console.WriteLine("Enter An Element To Remove From The Bag:");
                elem = int.Parse(Console.ReadLine());
                b.RemoveElement(elem);
                Console.WriteLine("\nUPDATE: The Element Has Been Deleted From The Bag Successfully!\n");
            }
            catch(Bag.EmptyBag)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: The Bag Is Empty!\n");
            }
            catch(Bag.NonExistingElement)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: The Element Is Not In The List!\n");
            }
            catch(Bag.UnknownError)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: Other Error!\n");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("\nEXCEPTION THROWN: Wrong Format! Enter an integer:\n");
            }
        }

        private void GetFreq()
        {
            bool err = false;
            try
            {
                int elem;
                Console.WriteLine("Enter An Element To Get Its Frequency:");
                elem = int.Parse(Console.ReadLine());

                int freq;
                freq = b.GetFrequency(elem);
                Console.WriteLine("\nUPDATE: The Frequency Of The Element " + elem + " Is " + freq + "\n");
            }
            catch (Bag.EmptyBag)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: The Bag Is Empty!\n");
            }
            catch (Bag.NonExistingElement)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: The Element Is Not In The List!\n");
            }
            catch (Bag.UnknownError)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: Other Error!\n");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("\nEXCEPTION THROWN: Wrong Format! Enter an integer:\n");
            }
        }

        private void GetLarg()
        {
            bool err = false;
            try
            {
                int larg = b.GetLargest();
                Console.WriteLine("\nUPDATE: The Largest Element Is " + larg + "\n");
            }
            catch (Bag.EmptyBag)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: The Bag Is Empty!\n");
            }
            catch (Bag.UnknownError)
            {
                err = true;
                Console.WriteLine("\nEXCEPTION THROWN: Other Error!\n");
            }
        } 

        private void Write()
        {
            b.Write();
        }
    }
}