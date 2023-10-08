using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using assignment2_RX15MW;

namespace assignment2_RX15MW_testing
{
    class Animal_testing
    {
        [TestMethod]
        public void TestFishExhilarationChangeWithGoodMood()
        {
            Fish fish = new Fish("fishie", 10);
            IMood mood = Good.Instance();

            fish.UpdateMood(mood);
            Assert.AreEqual(11, fish.Exhilaration);
        }

        [TestMethod]
        public void TestBirdExhilarationChangeWithBadMood()
        {
            Bird bird = new Bird("birdie", 20);
            IMood mood = Bad.Instance();

            bird.UpdateMood(mood);
            Assert.AreEqual(17, bird.Exhilaration);
        }

        [TestMethod]
        public void TestDogExhilarationChangeWithOrdinaryMood()
        {
            Dog dog = new Dog("doggie", 30);
            IMood mood = Ordinary.Instance();

            dog.UpdateMood(mood);
            Assert.AreEqual(30, dog.Exhilaration);
        }

        [TestMethod]
        public void TestBadMoodImprovement()
        {
            IMood mood = Bad.Instance();

            mood = mood.ImproveMood();
            Assert.IsInstanceOfType(mood, typeof(Ordinary));
        }

        [TestMethod]
        public void TestOrdinaryMoodImprovement()
        {
            IMood mood = Ordinary.Instance();

            mood = mood.ImproveMood();
            Assert.IsInstanceOfType(mood, typeof(Good));
        }

        [TestMethod]
        public void TestGoodMoodImprovement()
        {
            IMood mood = Good.Instance();

            mood = mood.ImproveMood();
            Assert.IsInstanceOfType(mood, typeof(Good));
        }

        [TestMethod]
        public void TestAnimalAlive()
        {
            Animal animal = new Dog("silvester", 5);
            Assert.IsTrue(animal.Alive());
            animal.ModifyExhilaration(-5);
            Assert.IsFalse(animal.Alive());
        }

        [TestMethod]
        public void TestMoodImprove()
        {
            IMood mood = Ordinary.Instance();
            mood = mood.ImproveMood();
            Assert.AreEqual(typeof(Good), mood.GetType());
            mood = mood.ImproveMood();
            Assert.AreEqual(typeof(Good), mood.GetType());

            mood = Bad.Instance();
            mood = mood.ImproveMood();
            Assert.AreEqual(typeof(Ordinary), mood.GetType());
        }

        [TestMethod]
        public void TestFishMoodChange()
        {
            Fish fish = new Fish("stephan", 50);
            IMood mood = Good.Instance();
            mood = mood.ChangeF(fish);
            Assert.AreEqual(51, fish.Exhilaration);

            mood = Ordinary.Instance();
            mood = mood.ChangeF(fish);
            Assert.AreEqual(48, fish.Exhilaration);

            mood = Bad.Instance();
            mood = mood.ChangeF(fish);
            Assert.AreEqual(43, fish.Exhilaration);
        }

        [TestMethod]
        public void TestBirdMoodChange()
        {
            Bird bird = new Bird("dracula", 50);
            IMood mood = Good.Instance();
            mood = mood.ChangeB(bird);
            Assert.AreEqual(52, bird.Exhilaration);

            mood = Ordinary.Instance();
            mood = mood.ChangeB(bird);
            Assert.AreEqual(51, bird.Exhilaration);

            mood = Bad.Instance();
            mood = mood.ChangeB(bird);
            Assert.AreEqual(48, bird.Exhilaration);
        }

        [TestMethod]
        public void TestDogMoodChange()
        {
            Dog dog = new Dog("bunny", 50);
            IMood mood = Good.Instance();
            mood = mood.ChangeD(dog);
            Assert.AreEqual(53, dog.Exhilaration);

            mood = Ordinary.Instance();
            mood = mood.ChangeD(dog);
            Assert.AreEqual(53, dog.Exhilaration);

            mood = Bad.Instance();
            mood = mood.ChangeD(dog);
            Assert.AreEqual(43, dog.Exhilaration);
        }

        [TestMethod]
        public void TestMultipleAnimalsMoodChange()
        {
            List<Animal> animals = new List<Animal>
            {
                new Fish("fishhie", 50),
                new Bird("birdie", 50),
                new Dog("doggie", 50)
            };

            IMood mood = Good.Instance();
            foreach (var animal in animals)
            {
                animal.UpdateMood(mood);
            }

            Assert.AreEqual(51, animals[0].Exhilaration);
            Assert.AreEqual(52, animals[1].Exhilaration);
            Assert.AreEqual(53, animals[2].Exhilaration);

            mood = Ordinary.Instance();
            foreach (var animal in animals)
            {
                animal.UpdateMood(mood);
            }

            Assert.AreEqual(48, animals[0].Exhilaration);
            Assert.AreEqual(51, animals[1].Exhilaration);
            Assert.AreEqual(53, animals[2].Exhilaration);

            mood = Bad.Instance();
            foreach (var animal in animals)
            {
                animal.UpdateMood(mood);
            }

            Assert.AreEqual(43, animals[0].Exhilaration);
            Assert.AreEqual(48, animals[1].Exhilaration);
            Assert.AreEqual(43, animals[2].Exhilaration);
        }

        [TestMethod]
        public void TestMultipleMoodsAnimalChange()
        {
            Animal fish = new Fish("fisshie", 50);
            List<IMood> moods = new List<IMood>
            {
                Good.Instance(),
                Ordinary.Instance(),
                Bad.Instance()
            };

            foreach (var mood in moods)
            {
                fish.UpdateMood(mood);
            }

            Assert.AreEqual(43, fish.Exhilaration);
        }
    }
}
