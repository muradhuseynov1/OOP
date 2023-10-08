using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace assignment2_RX15MW
{
    interface IMood
    {
        IMood ChangeF(Fish p);
        IMood ChangeB(Bird p);
        IMood ChangeD(Dog p);
        IMood ImproveMood(); // improving mood (in case all animals have at least 5 exhilaration)
    }

    class Good : IMood
    {
        public IMood ChangeF(Fish p)
        {
            p.ModifyExhilaration(1);
            return this;
        }

        public IMood ChangeB(Bird p)
        {
            p.ModifyExhilaration(2);
            return this;
        }

        public IMood ChangeD(Dog p)
        {
            p.ModifyExhilaration(3);
            return this;
        }
        private Good() { }

        private static Good instance = null;
        public static Good Instance()
        {
            if (instance == null)
            {
                instance = new Good();
            }
            return instance;
        }

        public IMood ImproveMood() // good mood is the highest mood;
        {
            return this;
        }
    }

    class Ordinary : IMood
    {
        public IMood ChangeF(Fish p)
        {
            p.ModifyExhilaration(-3);
            return this;
        }

        public IMood ChangeB(Bird p)
        {
            p.ModifyExhilaration(-1);
            return this;
        }

        public IMood ChangeD(Dog p)
        {
            p.ModifyExhilaration(0);
            return this;
        }

        private Ordinary() { }

        private static Ordinary instance = null;

        public static Ordinary Instance()
        {
            if (instance == null)
            {
                instance = new Ordinary();
            }
            return instance;
        }

        public IMood ImproveMood()
        {
            return Good.Instance(); // ordinary mood can be improved to good mood
        }
    }

    class Bad : IMood
    {
        public IMood ChangeF(Fish p)
        {
            p.ModifyExhilaration(-5);
            return this;
        }

        public IMood ChangeB(Bird p)
        {
            p.ModifyExhilaration(-3);
            return this;
        }

        public IMood ChangeD(Dog p)
        {
            p.ModifyExhilaration(-10);
            return this;
        }

        private Bad() { }

        private static Bad instance = null;
        public static Bad Instance()
        {
            if (instance == null)
            {
                instance = new Bad();
            }
            return instance;
        }

        public IMood ImproveMood()
        {
            return Ordinary.Instance(); // bad mood can be improved to ordinary mood
        }
    }
}