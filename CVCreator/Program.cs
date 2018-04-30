using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;

namespace CVCreator
{
    /// <summary>
    ///The main class creatint new page and printing every component
    /// </summary>
    class Page
    {
        private List<Component> components = new List<Component>();
        public Page()
        {
            for (int i = 0; i < 8; i++)
            {
                components.Add(null);
            }
        }
        public void Print()
        { 
            var document = new PdfDocument();
            var image = XImage.FromFile(Program.form1.path);
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(image, new XRect(15, 15, 150, 150));
            gfx.DrawLine(new XPen(XColors.Aqua,0.3), 15, 170, 165, 170);
            gfx.DrawLine(new XPen(XColors.Black, 0.2), 175, page.Height, 175, 0);
            string path = "cv1.pdf";          
            var brush = XBrushes.Black;
            int y = 0;
            foreach (var component in components)
            {
                if (y > page.Height)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = 15;
                }               
                if(component!=null)
                component.Print(ref gfx,ref y);
            }
            document.Save(path);
            Process.Start(path);
        }
        public void AddComponent(Component cp, int index) { components.Insert(index, cp); }
    }
    /// <summary>
    /// The base class for every specific component class
    /// </summary>
     abstract class Component:Page
    {
        //TODO
       //public virtual void Sort(List<ExpandedData> data)
       // {

       //     //for (int i = 0; i <  data.Count; i++)
       //     //{
       //     //    for (int j = i + 1; j > 0; j--)
       //     //    {
       //     //        if (inputArray[j - 1] > inputArray[j])
       //     //        {
       //     //            int temp = inputArray[j - 1];
       //     //            inputArray[j - 1] = inputArray[j];
       //     //            inputArray[j] = temp;
       //     //        }
       //     //    }
       //     //}
       //     //return inputArray;
       // }
       private List<Component> components = new List<Component>();
       public  virtual void  AddComponent(Component cp) { components.Add(cp); }
       public abstract void Print(ref XGraphics graphics,ref int y);
    }
    /// <summary>
    /// Class containing all skills user typed to form
    /// </summary>
    class Skills:Component
    {
        public override void Print(ref XGraphics graphics,ref int x)
        {
            //graphics.DrawLine(XPens.Aqua, 15, y, 165, y);
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Center;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            var rect = new XRect(15, 440, 150, 40);
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 11, XFontStyle.Regular);
            tf.DrawString("UMIEJĘTNOŚCI", font, brush, rect, XStringFormats.TopLeft);
             int y = 480;
            foreach (var skill in skills)
            {
                if(skill.Name.Length<20)
                {
                    rect = new XRect(15, y, 150, 15);
                    tf.DrawString(skill.Name, font2, brush2, rect, XStringFormats.TopLeft);
                    y += 15;
                }
                else
                {
                    rect = new XRect(15, y, 150, 135);
                    tf.DrawString(skill.Name, font2, brush2, rect, XStringFormats.TopLeft);
                    y += 35;
                }
                
            }           
        }
        private List<Skill> skills = new List<Skill>();
        public void AddSkill(Skill sk) { skills.Add(sk); }
        public override void AddComponent(Component cp)
        {
            base.AddComponent(cp); 
        }
    }
     class PersonalData:Component
    {
        public override void Print(ref XGraphics graphics,ref int y)
        {
            XTextFormatter tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Center;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 13, XFontStyle.Bold);
             y = 175;
            XRect rect = new XRect(15, y, 150, 20);
            string value = Name + " " + Surrname;// + "\n" + DateofBirth + "\n" + Adress + "\ne-mail: " + Email + "\ntelefon: " + PhoneNumber;
            tf.DrawString(value, font, brush2, rect, XStringFormats.TopLeft);
            value = "\nData ur.\n" + DateofBirth + "\n" + Adress + "\ne-mail: " + Email + "\ntelefon: " + PhoneNumber;
            font = new XFont("Verdana", 12, XFontStyle.Regular);
            y += 20;
            rect= new XRect(15, y, 150, 40);
            //data
            tf.DrawString("\nData ur.\n", font2, brush, rect, XStringFormats.TopLeft);
            y += 40;
            rect = new XRect(15, y, 150, 20);
            y += 20;
            tf.DrawString(DateofBirth, font, brush2, rect, XStringFormats.TopLeft);
            rect = new XRect(15, y, 150, 40);
            //adres
            tf.DrawString("\nAdres\n", font2, brush, rect, XStringFormats.TopLeft);
            y += 40;
            rect = new XRect(15, y, 150, 55);
            y += 25;
            tf.DrawString(Adress, font, brush2, rect, XStringFormats.TopLeft);
            rect = new XRect(15, y, 150, 40);
            //mail
            tf.DrawString("\ne-mail\n", font2, brush, rect, XStringFormats.TopLeft);
            y += 40;
            rect = new XRect(15, y, 150, 15);
            y += 15;
            tf.DrawString(Email, font, brush2, rect, XStringFormats.TopLeft);
            rect = new XRect(15, y, 150, 40);
            //telefon
            tf.DrawString("\ntelefon\n", font2, brush, rect, XStringFormats.TopLeft);
            y += 40;
            rect = new XRect(15, y, 150, 20);
            y += 20;
            tf.DrawString(PhoneNumber, font, brush2, rect, XStringFormats.TopLeft);
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 15, y, 165, y);
        }
        public string Name { get; set; }
       public string Surrname { get; set; }
       public string DateofBirth { get; set; }
       public string Adress { get; set; }
       public string Email { get; set; }
       public string PhoneNumber { get; set; }
       public string Website { get; set; }
        
    }
     class Interestings:Component
    {
        public override void Print(ref XGraphics graphics, ref int y)
        {
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Justify;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            y += 15;
            var rect = new XRect(180, y, 420, 40);
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            tf.DrawString("ZAINTERESOWANIA", font, brush, rect, XStringFormats.TopLeft);
            y += 45;
            font = new XFont("Verdana", 11, XFontStyle.Bold);
            foreach (var interest in interestings)
            {
                rect = new XRect(190, y, 250, 15);
                tf.DrawString(interest.Name, font2, brush2, rect, XStringFormats.TopLeft);
                y += 15;
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        private List<Interesting> interestings = new List<Interesting>();
        public void AddInterest(Interesting interest) { interestings.Add(interest); }
    }
     class Courses:Component
    {
        public override void Print(ref XGraphics graphics, ref int y)
        {
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Justify;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            y += 15;
            var rect = new XRect(180, y, 420, 40);
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            tf.DrawString("SZKOLENIA I KURSY", font, brush, rect, XStringFormats.TopLeft);
            y += 45;
            font = new XFont("Verdana", 11, XFontStyle.Bold);
            foreach (var course in courses)
            {
                rect = new XRect(190, y, 250, 15);
                tf.DrawString(course.Name, font2, brush2, rect, XStringFormats.TopLeft);
                y += 15;
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        private List<Course> courses = new List<Course>();
        public void AddCourse(Course course) { courses.Add(course); }
    }
     abstract class SimpleData
    {
        virtual public string Name { get; set; }
    }
     class Skill:SimpleData
    {
        public override string Name { get => base.Name; set => base.Name = value; }
 
    }
     class Interesting : SimpleData
    {
        public override string Name { get => base.Name; set => base.Name = value; }
    }
     class  Course: SimpleData
    {
        public override string Name { get => base.Name; set => base.Name = value; }
    }
     class Experiences:Component
    {
        public override void Print(ref XGraphics graphics, ref int y)
        {
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Justify;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            var rect = new XRect(180, 30, 420, 40);
            y = 70;
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            tf.DrawString("DOŚWIADCZENIE", font, brush, rect, XStringFormats.TopLeft);
             font = new XFont("Verdana", 11, XFontStyle.Bold);
            foreach (var exp in experiences)
            {
                rect = new XRect(180, y, 80, 55);
                tf.DrawString(exp.From + " \ndo " + exp.To, font2, brush2, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 250, 20);
                y += 20;
                tf.DrawString(exp.Name, font, brush, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 250, 40);
                y += 40;
                tf.DrawString(exp.Value, font2, brush2, rect, XStringFormats.TopLeft);
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        private List<Experience> experiences = new List<Experience>();
        public void AddExperience(Experience experience) { experiences.Add(experience); }
    }
     class Schooling:Component
    {
        public override void Print(ref XGraphics graphics, ref int y)
        {
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Justify;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            y += 15;
            var rect = new XRect(180, y, 420, 40);
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            tf.DrawString("WYKSZTAŁCENIE", font, brush, rect, XStringFormats.TopLeft);
            y += 45;
            font = new XFont("Verdana", 11, XFontStyle.Bold);
            foreach (var school in schools)
            {
                rect = new XRect(180, y, 80, 55);
                tf.DrawString(school.From + " \ndo " + school.To, font2, brush2, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 250, 20);
                y += 20;
                tf.DrawString(school.Name, font, brush, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 250, 40);
                y += 40;
                tf.DrawString(school.Value, font2, brush2, rect, XStringFormats.TopLeft);
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        private List<School> schools = new List<School>();
        public void AddSchool(School school) { schools.Add(school); }
    }
     abstract class ExpandedData
    {
        //TODO
        //static  public int CompareTo(ExpandedData ex1, ExpandedData ex2)
        //{
        //    if(ex1.From)
        //}
        virtual public string Name { get; set; }
        virtual public string Value { get; set; }
        virtual public string From { get; set; }
        virtual public string To { get; set; }
    }
     class Experience:ExpandedData
    {
        public override string Name { get => base.Name ; set => base.Name = value; }
        public override string Value { get => base.Value ; set => base.Value = value; }
        public override string From { get => base.From  ; set => base.From = value; }
        public override string To { get => base.To; set => base.To = value; }
    }
     class School:ExpandedData
    {
        public override string Name { get => base.Name; set => base.Name = value; }
        public override string Value { get => base.Value; set => base.Value = value; }
        public override string From { get => base.From; set => base.From = value; }
        public override string To { get => base.To; set => base.To = value; }
    }
     class Languages:Component
    {
        List<Language> languages = new List<Language>();
        public void AddLanguage(Language lang) { languages.Add(lang); }
        public override void Print(ref XGraphics graphics, ref int y)
        {
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Justify;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            y += 15;
            var rect = new XRect(180, y, 420, 40);
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            tf.DrawString("ZNAJOMOŚĆ JEZYKÓW OBCYCH", font, brush, rect, XStringFormats.TopLeft);
            y += 45;
            font = new XFont("Verdana", 11, XFontStyle.Bold);
            foreach (var language in languages)
            {
                rect = new XRect(190, y, 250, 15);
                tf.DrawString("Język "+language.Name+"   "+language.Level, font2, brush2, rect, XStringFormats.TopLeft);
                y += 15;
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        string Name { get; set; }
    }
     class Language
    {
        public  string Name { get; set; }
        public string Level { get; set; }
    }
     class Klauzula:Component
    {
        public override void Print(ref XGraphics graphics, ref int y)
        {
            //792
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Justify;
            var brush = XBrushes.Gray;
            y = 750;
            var rect = new XRect(180, y, 420, 40);
            XFont font = new XFont("Verdana", 8, XFontStyle.Regular);
            tf.DrawString(Value, font, brush, rect, XStringFormats.TopLeft);  
        }
        public string Value { get; set; }
        public Klauzula()
        {
            Value = "Wyrażam zgodę na przetwarzanie moich danych osobowych dla potrzeb niezbędnych do realizacji procesu rekrutacji (zgodnie z Ustawą z dnia 29.08.1997 roku o Ochronie Danych Osobowych; tekst jednolity: Dz. U. 2016 r. poz. 922).";
        }
    }
     static class Program
    {
        //commentsadas
        public static Page page = new Page();
        public static Skills skills = new Skills();
        public static Interestings interestings = new Interestings();
        public static Languages languages = new Languages();
        public static Experiences experiences = new Experiences();
        public static Schooling schooling = new Schooling();
        public static Courses courses = new Courses();
        public static Klauzula klauzula = new Klauzula();
        public static Form1 form1;
        public static void AddToPage()
        {
            page.AddComponent(skills,1);
            page.AddComponent(experiences,2);
            page.AddComponent(schooling,3);
            page.AddComponent(courses,4);
            page.AddComponent(languages, 5);
            page.AddComponent(interestings, 6);
            page.AddComponent(klauzula, 7);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
            Application.Run(form1);
        }
    }
}
