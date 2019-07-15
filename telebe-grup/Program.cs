using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telebe_grup
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter how many Groups do you want to create: ");
            int count1 = int.Parse(Console.ReadLine());
            Group[] GroupList = new Group[count1];
            for (int i = 0; i < GroupList.Length; i++)
            {
                Console.Write($"Please enter {i + 1}th Group's name: ");
                string NewGroup = Console.ReadLine().ToUpper();
                GroupList[i] = new Group();
                bool isExist = false;
                foreach (Group item in GroupList)
                {
                    if (item != null && item.name == NewGroup)
                    {
                        Console.WriteLine("This name has already exist! Please enter another name.");
                        isExist = true;
                    }
                }
                    if (!isExist)
                    {
                        GroupList[i].name = NewGroup;
                    }
                    else
                    {
                        i--;
                    }
                

            }
            Console.Write("Please enter how many students do you want to add: ");
            int count2 = int.Parse(Console.ReadLine());
            Student[] StudentList = new Student[count2];
            for (int i = 0; i < StudentList.Length; i++)
            {
                Console.Write($"Please enter {i + 1}th Student's name: ");
                StudentList[i] = new Student();
                StudentList[i].FirstName = Console.ReadLine();
                Console.Write($"Please enter {i + 1} Student's Surname: ");
                StudentList[i].LastName = Console.ReadLine();

                Console.Write("Please enter Group name where you want to add this student: ");
                string SelectGroup =Console.ReadLine().ToUpper();
                bool isname = false;
                foreach(Group item in GroupList)
                {
                    if(item.name == SelectGroup)
                    {
                        StudentList[i].GroupID = item.ID;
                        isname = true;
                    }
                    
                }
                if (!isname)
                {
                 Console.WriteLine("This group dosn't exist,please enter right group name");
                 i--;
                }

            }
            Console.WriteLine("Please select seach method: For student ID search press 1. \n For Group ID search press 2. " +
                "\n For list of students press 3."  );
            string keyword =Console.ReadLine();
            if (keyword == "1")
            {
                Console.Write("Please enter student ID: ");
                int searchedID =int.Parse(Console.ReadLine());
               foreach(Student item in StudentList)
                {
                if(item.ID == searchedID)
                    {
                        Console.WriteLine(item.FirstName +" " + item.LastName );
                    }
                }
            }
            if (keyword == "2")
            {
                Console.Write("Please enter Group ID: ");
                int searchedGroupID = int.Parse(Console.ReadLine());
                foreach (Group item in GroupList)
                {
                    if (item.ID == searchedGroupID)
                    {
                        Console.WriteLine(item.name);
                    }
                }
            }
            if (keyword == "3")
            {
                Console.Write("Please enter student Group name: ");
                string searchedGroup = Console.ReadLine().ToUpper();
                foreach (Group item in GroupList)
                {
                    if (item.name == searchedGroup)
                    {
                     foreach (Student st in StudentList)
                        {
                       if(st.GroupID == item.ID)
                            {
                                Console.WriteLine(st.FirstName + " " + st.LastName);
                            }
                        }
                    }
                }
            }
            else
            {
            Console.WriteLine("0 result was founded");
            }
            Console.ReadKey();
        }
        class Group
        {
            public static int _id;
            public string name { get; set; }
            public int ID { get; private set; }
            static Group()
            {
                _id = 1001;
            }
            public Group()
            {
                ID = _id++;
            }
        }
        class Student 
        {
            public int GroupID;
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; private set; }
            public static int _id;
            static Student()
            {
                _id = 2001;
            }
            public Student()
            {
                ID = _id++;
            }
        }
       
    }
}
