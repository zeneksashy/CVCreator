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
            //not working with image
            for (int i = 0; i < 22; i++)
            {
                var experience = new Experience();
                experience.From = "10.10.2012";
                experience.To = "12.12.2015";
                experience.Name = "NAZWA FIRMy";
                experience.Value = "OPIS";
                Program.experiences.AddExperience(experience);                
            }
            Program.AddToPage();
            Program.page.Print();


        }
    }
}
