using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace assignment2_RX15MW
{
    abstract class Animal
    {
        public string Name { get; }
        public int Exhilaration { get; protected set; }
        public void ModifyExhilaration(int e)
        {
            Exhilaration += e;
            if (Exhilaration > 100) Exhilaration = 100;
            else if (Exhilaration < 0) Exhilaration = 0;
        }
        public bool Alive() { return Exhilaration > 0; }

        protected Animal(string str, int e = 0) { Name = str; Exhilaration = e; }

        protected abstract IMood Transmute(IMood mood);

        public void UpdateMood(IMood mood)
        {
            Transmute(mood);
        }

        public void UpdateMoodList(ref List<IMood> track)
        {
            for(int j = 0; Alive() && j < track.Count; ++j)
            {
                track[j] = Transmute(track[j]);
            }
        }

        public class NoDaysGiven : Exception { } // when no moods are given in the input file
        public class NoAnimalsGiven : Exception { } // when no animals are given in the input file
        public class AllAnimalsDead : Exception { } // when exhilaration off all animal are below zero and all animals are dead
    }

    // class fish
    class Fish : Animal
    {
        public Fish(string str, int e = 0) : base(str, e) { }
        protected override IMood Transmute(IMood mood)
        {
            return mood.ChangeF(this);
        }
    }

    // class bird
    class Bird : Animal
    {
        public Bird(string str, int e = 0) : base(str, e) { }
        protected override IMood Transmute(IMood mood)
        {
            return mood.ChangeB(this);
        }
    }

    // class dog
    class Dog : Animal
    {
        public Dog(string str, int e = 0) : base(str, e) { }
        protected override IMood Transmute(IMood mood)
        {
            return mood.ChangeD(this);
        }
    }
}
