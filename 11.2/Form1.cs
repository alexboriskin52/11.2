namespace _11._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<STUDENT> time_table = new List<STUDENT>();
        class STUDENT
        {
            public string fio;
            public string numbergr;
            public string ocenki;

            public STUDENT(string fio, string numbergr, string ocenki)
            {
                this.fio = fio;
                this.numbergr = numbergr;
                this.ocenki = ocenki;
            }
            public string Print()
            {
                return $"{fio} {numbergr} {ocenki}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] fio = { "Харин А.А.", "Милков Р.И.", "Антонов И.К.", "Романов М.Ю.", "Золотов Я.Н." };
            string[] numbergr = { "231-1", "432-2", "212-1", "456-2", "564-1" };


            Random random = new Random();
            
            
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            time_table.Add(new STUDENT(fio[random.Next(0, 5)], numbergr[random.Next(0, 5)], Gen()));
            for (int i = 0; i < time_table.Count; i++)
            {
                listBox1.Items.Add(time_table[i].Print());
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\admin\\Desktop\\STUDENT.txt", false))
            {
                for (int i = 0; i < time_table.Count; i++)
                {
                    writer.WriteLine(time_table[i].Print());
                }

            }
        }

        private string Gen()
        {
            Random random = new Random();
            string grades = "";
            for (int i = 0; i < 5; i++)
            {
                grades = grades + $"{random.Next(3, 6)}"; // Случайное число от 3 до 5
            }
            return grades;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.Items.Clear();
                }
            }
            if (time_table.Count != 0)
            {
                time_table.Clear();
            }
            using (StreamReader reader = new StreamReader("C:\\Users\\admin\\Desktop\\STUDENT.txt"))
            {
                string content = reader.ReadToEnd();
                string[] str_sentens = content.Split("\n");
                for (int k = 0; k < str_sentens.Length - 1; k++)
                {
                    string[] zabiv = str_sentens[k].Split(' ');
                    time_table.Add(new STUDENT(zabiv[0], zabiv[1], $"{zabiv[2]}, {zabiv[3]}")); 
                }
                foreach (string str in str_sentens)
                {
                    listBox1.Items.Add(str);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            List<STUDENT> selectedStudents = new List<STUDENT>();

            foreach (STUDENT student in time_table)
            {
                if (student.ocenki.Contains("4") && student.ocenki.Contains("5"))
                {
                    selectedStudents.Add(student);
                }
            }

            // Сортировка списка по убыванию среднего балла
            selectedStudents.Sort((x, y) => GetAverageGrade(y.ocenki).CompareTo(GetAverageGrade(x.ocenki)));

            foreach (STUDENT student in selectedStudents)
            {
                listBox2.Items.Add(student.Print());
            }
        }

        // Метод для вычисления среднего балла
        private double GetAverageGrade(string grades)
        {
            double sum = 0;
            foreach (char grade in grades)
            {
                sum += Char.GetNumericValue(grade);
            }
            return sum / grades.Length;
        }
    }
}
