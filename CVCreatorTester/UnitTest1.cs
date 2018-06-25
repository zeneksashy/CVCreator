using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CVCreator;

namespace CVCreatorTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingExperienceTest()
        {
            Random r = new Random();
            Program.personal = new CVCreator.PersonalData() { Name = "Zdzislaw", Surrname = "Kowalski", Adress = "Jakas ulica 123", DateofBirth = "20.20.1955", Email = "zdzichu@gmail.com", PhoneNumber = "637457123" };
            //not working with image

            //Program.
            for (int i = 0; i < 22; i++)
            {
                var experience = new Experience();
                int mies= r.Next(1, 12);
                int dzien = r.Next(1, 28);
                int rok = r.Next(1975, 2018);
                experience.From = dzien+"."+mies+"."+rok;
                 mies = r.Next(1, 12);
                 dzien = r.Next(1, 28);
                 rok = r.Next(1975, 2018);
                experience.To = dzien + "." + mies + "." + rok;
                experience.Name = "NAZWA FIRMy";
                experience.Value = "OPIS";
                Program.experiences.AddExperience(experience);                
            }
            Program.form1.photopath = @"C:\\Users\\Public\\Pictures\\Sample Pictures\\Penguins.jpg";
            Program.AddToPage();
            Program.page.Print();
        }
    }
}
