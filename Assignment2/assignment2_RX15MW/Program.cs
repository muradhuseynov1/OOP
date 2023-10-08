using TextFile;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

[assembly: InternalsVisibleTo("assignment2_RX15MW_testing")]

namespace assignment2_RX15MW
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new("input8.txt"); // handling text file: these parts taken from the sample
            

            reader.ReadLine(out string line); int n = int.Parse(line);
            List<Animal> animals = new();
            for (int i = 0; i < n; ++i)
            {
                char[] separators = new char[] { ' ', '\t' };
                Animal animal = null;

                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    char ch = char.Parse(tokens[0]);
                    string name = tokens[1];
                    int p = int.Parse(tokens[2]);

                    switch (ch)
                    {
                        case 'F': animal = new Fish(name, p); break;
                        case 'B': animal = new Bird(name, p); break;
                        case 'D': animal = new Dog(name, p); break;
                    }
                }
                animals.Add(animal);
            }

            reader.ReadLine(out line);
            List<IMood> track = new();
            string moods = line;
            if (string.IsNullOrEmpty(moods))
            {
                throw new Animal.NoDaysGiven();
            }

            for (int j = 0; j < moods.Length; ++j)
            {
                char c = moods[j];
                IMood mood = Ordinary.Instance(); // initializing mood
                switch (c)
                {
                    case 'g': mood = Good.Instance(); track.Add(mood); break;
                    case 'o': mood = Ordinary.Instance(); track.Add(mood); break;
                    case 'b': mood = Bad.Instance(); track.Add(mood); break;
                }

                bool allAnimals5 = true; // checking if all animals have exhilaration at least 5
                for (int i = 0; i < animals.Count; i++)
                {
                    animals[i].UpdateMood(mood);
                    if (animals[i].Exhilaration <= 5) allAnimals5 = false;
                }
                if (allAnimals5) mood = mood.ImproveMood(); // if true, improve moods by one.
            }

            bool allAnimalsDead = true; // checking if all animals are dead
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Alive())
                {
                    allAnimalsDead = false;
                    break;
                }
            }
            if (allAnimalsDead)
            {
                throw new Animal.AllAnimalsDead();
            }

            bool err = false; // error for the exceptions 
            try
            {
                List<Animal> minExhilarationAnimals = new List<Animal>(); // contains minimum exhilarations, minimum search
                int minExhilaration = 101; // initializing the minimum exhilaration with a number greater then the max exhilaration
                for (int i = 0; i < animals.Count; ++i)
                {
                    animals[i].UpdateMoodList(ref track);
                    if (animals[i].Alive()) // check if the animals are alive
                    {
                        if (animals[i].Exhilaration < minExhilaration) // compare the alive animals exhilarations with the minimum
                        {
                            minExhilaration = animals[i].Exhilaration; // if new minimum exhilaration found, updating the minimum
                            minExhilarationAnimals.Clear(); // then clearing the list
                            minExhilarationAnimals.Add(animals[i]); // adding the animal with min exhilaration to the list
                        }
                        else if (animals[i].Exhilaration == minExhilaration)
                        {
                            // if there are more than one animal with the min exhilaration, add it the to the list as well
                            minExhilarationAnimals.Add(animals[i]);
                        }
                    }
                }

                // printing all animals with minimum exhilaration
                for (int i = 0; i < minExhilarationAnimals.Count; i++)
                {
                    Console.WriteLine(minExhilarationAnimals[i].Name);
                }

                if (animals.Count == 0) throw new Animal.NoAnimalsGiven();
            }
            catch (Animal.AllAnimalsDead)
            {
                err = true;
                Console.WriteLine("All animals are dead");
            }
            catch (Animal.NoAnimalsGiven)
            {
                err = true;
                Console.WriteLine("no animals provided in the input file");
            }
            catch (Animal.NoDaysGiven e)
            {
                err = true;
                Console.WriteLine("no days given in the input file");
            }
            catch (System.IO.FileNotFoundException)
            {
                err = true;
                Console.WriteLine("File not found\nCheck if the file exists or the name of the file has been enteren correctly!");
            }
        }
    }
}
