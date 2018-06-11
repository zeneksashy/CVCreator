using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PdfSharp.Drawing.Layout;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace CVCreator
{
    /// <summary>
    ///The main class creatint new page and printing every component
    /// </summary>
    [DataContract]
    [KnownType(typeof(Component))]
    public class Page
    {
        //save after printing
        public void Save(string path)
        {
            var serializer = new DataContractSerializer(typeof(Page));//,new Type[] { typeof(Skills), typeof(PersonalData), typeof(Experiences), typeof(Languages), typeof(Interestings), typeof(Schooling), typeof(Courses) });
            Stream xw =  File.Create(path);
            serializer.WriteObject(xw, this);
            xw.Flush();
            xw.Close();
        }
        //open before adding data
        public void Open(string path)
        {
            var serializer = new DataContractSerializer(typeof(Page));// new Type[] { typeof(Skills), typeof(PersonalData), typeof(Experiences), typeof(Languages), typeof(Interestings), typeof(Schooling), typeof(Courses) });
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            Page p = (Page)serializer.ReadObject(reader,false);
            foreach (var comp in p.components)
            {
                Type typeofcomp = comp.GetType();
                switch (typeofcomp.Name)
                {
                    case "PersonalData": Program.personal = comp as PersonalData; break;
                    case "Skills": Program.skills = comp as Skills; break;
                    case "Courses": Program.courses = comp as Courses; break;
                    case "Schooling": Program.schooling = comp as Schooling; break;
                    case "Interestings": Program.interestings = comp as Interestings; break;
                    case "Klauzula": Program.klauzula = comp as Klauzula; break;
                    case "Experiences": Program.experiences = comp as Experiences; break;
                    case "Languages": Program.languages = comp as Languages; break;
                    default:
                        break;
                }
            }
        }
        [DataMember]
        private List<Component> components = new List<Component>();
        public void Print()
        {
          //  components.RemoveRange(8, 7);
            var document = new PdfDocument();
            var image = XImage.FromFile(Program.form1.photopath);
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            gfx.DrawImage(image, new XRect(15, 15, 150, 150));
            gfx.DrawLine(new XPen(XColors.Aqua,0.3), 15, 170, 165, 170);
            gfx.DrawLine(new XPen(XColors.Black, 0.2), 175, page.Height, 175, 0);
            string path = "cv-gracjan1.pdf";          
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
        public void AddComponent(Component cp) {  components.Add(cp); }
    }
    /// <summary>
    /// The base class for every specific component class
    /// </summary>
    [DataContract,KnownType(typeof(Skills)), KnownType(typeof(Interestings)), KnownType(typeof(PersonalData)), KnownType(typeof(Courses)), KnownType(typeof(Experiences)), KnownType(typeof(Languages)), KnownType(typeof(Schooling)),KnownType(typeof(Klauzula))]
    public abstract class Component:Page
    {
       private List<Component> components = new List<Component>();
       public  virtual void  AddComponent(Component cp) { components.Add(cp); }
       public abstract void Print(ref XGraphics graphics,ref int y);
        public virtual void Save(XmlSerializer serializer) { }
    }
    //
    //Container classes (Inherit from componenet)
    //
    public class Klauzula : Component
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
    /// <summary>
    /// Class containing all skills user typed to form
    /// </summary> 
    [DataContract]
    public class Skills:Component
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

        [DataMember]
        private List<Skill> skills = new List<Skill>();
        public void AddSkill(Skill sk) { skills.Add(sk); }
        public override void AddComponent(Component cp)
        {
            base.AddComponent(cp); 
        }
    }
    /// <summary>
    /// Class containing all personal data user typed to form
    /// </summary>
    [DataContract]
    public class PersonalData:Component
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
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surrname { get; set; }
        [DataMember]
        public string DateofBirth { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Website { get; set; }
        
    }
    /// <summary>
    /// Class containing all intresting  user typed to form
    /// </summary>
    [DataContract]
    public class Interestings:Component
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
        [DataMember]
        private List<Interesting> interestings = new List<Interesting>();
        public void AddInterest(Interesting interest) { interestings.Add(interest); }
    }
    /// <summary>
    /// Class containing all courses  user typed to form
    /// </summary>
    [DataContract]
    public class Courses:Component
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
        [DataMember]
        private List<Course> courses = new List<Course>();
        public void AddCourse(Course course) { courses.Add(course); }
    }
    /// <summary>
    /// Class containing all experiences  user typed to form
    /// </summary>
    [DataContract]
    public class Experiences : Component
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
            font = new XFont("Verdana", 11, XFontStyle.Regular);
            foreach (var exp in experiences)
            {
                rect = new XRect(180, y, 80, 55);
                tf.DrawString(exp.From + " \n" + exp.To, font2, brush2, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 250, 20);
                y += 20;
                tf.DrawString(exp.Name, font, brush, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 280, 35);
                y += 35;
                tf.DrawString(exp.Value, font2, brush2, rect, XStringFormats.TopLeft);
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        [DataMember]
        private List<Experience> experiences = new List<Experience>();
        public void AddExperience(Experience experience) {  experiences.Add(experience); experiences.Sort(); }
    }
    /// <summary>
    /// Class containing all schools  user typed to form
    /// </summary>
    [DataContract]
    public class Schooling : Component
    {
        public override void Print(ref XGraphics graphics, ref int y)
        {
            var tf = new XTextFormatter(graphics);
            tf.Alignment = XParagraphAlignment.Justify;
            var brush = XBrushes.DarkBlue;
            var brush2 = XBrushes.Black;
            y += 15;
            var rect = new XRect(180, y, 420, 35);
            XFont font = new XFont("Verdana", 15, XFontStyle.Bold);
            var font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            tf.DrawString("WYKSZTAŁCENIE", font, brush, rect, XStringFormats.TopLeft);
            y += 40;
            font = new XFont("Verdana", 11, XFontStyle.Regular);
            foreach (var school in schools)
            {
                rect = new XRect(180, y, 80, 55);
                tf.DrawString(school.From + " \n" + school.To, font2, brush2, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 250, 20);
                y += 20;
                tf.DrawString(school.Name, font, brush, rect, XStringFormats.TopLeft);
                rect = new XRect(285, y, 280, 30);
                y += 30;
                tf.DrawString(school.Value, font2, brush2, rect, XStringFormats.TopLeft);
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        [DataMember]
        private List<School> schools = new List<School>();
        public void AddSchool(School school) { schools.Add(school);schools.Sort(); }
    }
    /// <summary>
    /// Class containing all languages  user typed to form
    /// </summary>
    [DataContract]
    public class Languages : Component
    {
        [DataMember]
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
                tf.DrawString("Język " + language.Name + "   " + language.Level, font2, brush2, rect, XStringFormats.TopLeft);
                y += 15;
            }
            graphics.DrawLine(new XPen(XColors.Aqua, 0.3), 180, y, 595, y);
        }
        string Name { get; set; }
    }
    //
    //All simple data type classes
    //
    [DataContract]
    public abstract class SimpleData
    {
        [DataMember]
        virtual public string Name { get; set; }
    }
    [DataContract]
    public class Skill:SimpleData
    {
        [DataMember]
        public override string Name { get => base.Name; set => base.Name = value; }
 
    }
    [DataContract]
    public class Interesting : SimpleData
    {
        [DataMember]
        public override string Name { get => base.Name; set => base.Name = value; }
    }
    [DataContract]
    public class  Course: SimpleData
    {
        [DataMember]
        public override string Name { get => base.Name; set => base.Name = value; }
    }
   //
   //All expanded data type classes
   //
    [DataContract]
    public abstract class ExpandedData:IComparable<ExpandedData>
    {
        //TODO
        public int CompareTo(ExpandedData ex2)
        {
            DateTime date1 = DateTime.ParseExact(this.To, "dd-MM-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(ex2.To, "dd-MM-yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (date1 > date2)
                return -1;
            if (date1 < date2)
                return 1;
            return 0;
        }
        [DataMember ]
        virtual public string Name { get; set; }
        [DataMember]
        virtual public string Value { get; set; }
        [DataMember]
        virtual public string From { get; set; }
        [DataMember]
        virtual public string To { get; set; }
    }
    [DataContract]
    public class Experience:ExpandedData
    {
        [DataMember]
        public override string Name { get => base.Name ; set => base.Name = value; }
        [DataMember]
        public override string Value { get => base.Value ; set => base.Value = value; }
        [DataMember]
        public override string From { get => base.From  ; set => base.From = value; }
        [DataMember]
        public override string To { get => base.To; set => base.To = value; }
    }
    [DataContract]
    public class School:ExpandedData
    {
        [DataMember]
        public override string Name { get => base.Name; set => base.Name = value; }
        [DataMember]
        public override string Value { get => base.Value; set => base.Value = value; }
        [DataMember]
        public override string From { get => base.From; set => base.From = value; }
        [DataMember]
        public override string To { get => base.To; set => base.To = value; }
    }
    [DataContract]
    public class Language
    {
        [DataMember]
        public  string Name { get; set; }
        [DataMember]
        public string Level { get; set; }
    }
    //Main class
    public static class Program
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
        public static PersonalData personal = new PersonalData();
        public static Form1 form1;
        public static void AddToPage()
        {
            page.AddComponent(personal);
            page.AddComponent(skills);
            page.AddComponent(experiences);
            page.AddComponent(schooling);
            page.AddComponent(courses);
            page.AddComponent(languages);
            page.AddComponent(interestings);
            page.AddComponent(klauzula);
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
