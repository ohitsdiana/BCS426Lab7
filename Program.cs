/* Lab 7
* 
* Diana Guerrero
* Professor Aydin
* BCS 426 
* 4/18/21
* 
* Partner(s): Patrick Adams & Anthony Alvarez
* Resource(s): 
* 1. https://drive.google.com/drive/folders/1ynj9Cz-1nNYyzL2_J6NWa9xendwqONeu
*/

using System;

namespace BCS426Lab7
{
    // 1a. Student Class with Properties such as (Name, Date of Birth, Major, Status, Registered)
    public class Student
    {
        public string name
        {
            get;
            set;
        }

        public DateTime dob
        {
            get;
            set;
        }

        public string major
        {
            get;
            set;
        }

        public enum status
        {
            Freshman,
            Sophomore,
            Junior,
            Senior
        }

        public status Status
        {
            get;
            set;
        }

        public bool registered
        {
            get;
            set;
        }

        // 1b. Add other appropriate methods and constructors
        public Student(string _name, DateTime _dob, string _major, status _Status, bool _registered)
        {
            name = _name;
            dob = _dob;
            major = _major;
            Status = _Status;
            registered = _registered;
        }
        
        // Part 2 to 1c. (Delegate) Event newStudentArrived event will be Fired to be Handled by the Consumer Class Registrar
        public event EventHandler<StudentInfoEventArgs> NewStudentArrived;

        public void NewStudent(string _name, DateTime _dob, string _major, status _Status, bool _registered)
        {
            Console.WriteLine($"New Student Information: Name: {_name}, Date of Birth: {_dob}, Major: {_major}, School Year: {_Status}, Registration: {_registered} \n");
            Console.WriteLine("'Invoke' Method (If Not Null): ");
            NewStudentArrived?.Invoke(this, new StudentInfoEventArgs(_name, _dob, _major, _Status, _registered));
        }

    }

    // Part 1 to 1c. Event newStudentArrived event will be Fired to be Handled by the Consumer Class Registrar

    public class StudentInfoEventArgs : EventArgs
    {
        public StudentInfoEventArgs(string _name, DateTime _dob, string _major, Student.status _Status, bool _registered)
        {
            name = _name;
            dob = _dob;
            major = _major;
            status = _Status;
            registered = _registered;
        }
        public string name
        {
            get;
        }

        public DateTime dob
        {
            get;
        }

        public string major
        {
            get;
        }

        public Student.status status
        {
            get;
        }

        public bool registered
        {
            get;
        }
    }

    // 2. Subscriber (Consumer) side: Create a class Registrar
    public class Registrar
    {
        private string recName;
        public Registrar(string _recName) => recName = _recName;
        public void NewStudentArrive(object sender, StudentInfoEventArgs et) => Console.WriteLine($"New Student Information: Name: {et.name}, Date of Birth: {et.dob}, Major: {et.major}, School Year: {et.status}, Registration: {et.registered} \n");

        // Create Array
        Student[] studentRegistrationList = new Student[3];
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Student 1
            var student = new Student("Diana", new DateTime(1999, 8, 21), "CPIS", Student.status.Senior, true);
            var record1 = new Registrar("Record 1");
            student.NewStudentArrived += record1.NewStudentArrive;

            student.NewStudent("Diana 2.0", new DateTime(1999, 8, 21), "CPIS", Student.status.Senior, true);

            // Student 2
            var student2 = new Student("Andrea", new DateTime(1995, 10, 6), "Accounting", Student.status.Freshman, true);
            var record2 = new Registrar("Record 2");
            student.NewStudentArrived += record2.NewStudentArrive;

            student.NewStudent("Andrea 2.0", new DateTime(1995, 10, 6), "Accounting", Student.status.Freshman, true);

            // Student 3
            var student3 = new Student("Gilbert", new DateTime(2000, 11, 6), "HVAC", Student.status.Junior, true);
            var record3 = new Registrar("Record 3");
            student.NewStudentArrived += record3.NewStudentArrive;

            student.NewStudent("Gilbert 2.0", new DateTime(2000, 11, 6), "HVAC", Student.status.Junior, true);

            // Wasn't able to complete 3b. where you have a new student created every N milliseconds and using Thread.Sleep Method
        }
    }
}