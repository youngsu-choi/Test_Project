using System;
using System.Collections.Generic;

namespace Flight
{
    class Person
    {
        public static int count = 0;
        public string name;
        public int birth;
        public int number;

        public Person()
        {
            count++;
        }

        public void personPrint()
        {
            Console.Write(name + ", " + birth + ", ");
        }
    }

    class Employee : Person
    {
        private int c_number;
        public int C_number
        {
            get { return c_number; }
            set
            {
                while (true)
                {
                    if (value > 0)
                    {
                        c_number = value;
                        break;
                    }
                    c_number = 0;
                    Console.WriteLine("0보다 큰 값을 입력하시오.");
                    value = int.Parse(Console.ReadLine());
                }
            }
        }
        private int pay;
        private string grade;
        
        public string getGrade()
        {
            return this.grade;
        }
        public int getPay()
        {
            return this.pay;
        }
        public void setPayGrade(int payD)
        {
            while (true)
            {
                if (payD > 0)
                {
                    this.pay = payD;
                    break;
                }
                Console.WriteLine("급여는 0보다 커야합니다.");
                payD = int.Parse(Console.ReadLine());
            }
        }
        public void setPayGrade(string gradeD)
        {
            while (true)
            {
                if (gradeD == "S" || gradeD == "A" || gradeD == "B" || gradeD == "C" || gradeD == "D")
                {
                    grade = gradeD;
                    break;
                }
                Console.WriteLine("연말평가는 S, A, B, C, D 중 하나여야 합니다.");
                gradeD = Console.ReadLine();
            }
        }

        public void employeePrint()
        {
            Console.Write(C_number + ", " + getPay() + ", " + getGrade() + ", ");
        }
    }

    class Pilot : Employee
    {
        public const int maxPilot = 2;
        public static int currentPilot = 0;
        public readonly int id;
        private int road;
        public int Road
        {
            get { return road; }
            set
            {
                while (true)
                {
                    if (value > 0)
                    {
                        road = value;
                        break;
                    }
                    road = 0;
                    Console.WriteLine("0보다 큰 값을 입력하시오.");
                    value = int.Parse(Console.ReadLine());
                }
            }
        }
        public int M_number { get; set; }

        public Pilot() { }

        public Pilot(string name, int birth, int c_number, int pay, string grade, int road, int M_number)
        {
            currentPilot++;
            id = count;
            this.name = name;
            this.birth = birth;
            this.C_number = c_number;
            setPayGrade(pay);
            setPayGrade(grade);
            this.Road = road;
            this.M_number = M_number;
        }

        public void pilotPrint()
        {
            Console.WriteLine(Road + ", " + M_number);
        }
    }

    class Attendant : Employee
    {
        public const int maxAtt = 3;
        public static int currentAtt = 0;
        public readonly int id;
        private string service_class;
        public string Service_class
        {
            get { return service_class; }
            set
            {
                while (true)
                {
                    if (value == "First" || value == "Business" || value == "Economy")
                    {
                        service_class = value;
                        break;
                    }
                    service_class = null;
                    Console.WriteLine("First, Business, Economy 중 하나를 입력하시오.");
                    value = Console.ReadLine();
                }
            }
        }
        public string service_position;

        public Attendant() { }

        public Attendant(string name, int birth, int c_number, int pay, string grade, string service_class, string service_position)
        {
            currentAtt++;
            id = count;
            this.name = name;
            this.birth = birth;
            this.C_number = c_number;
            setPayGrade(pay);
            setPayGrade(grade);
            this.Service_class = service_class;
            this.service_position = service_position;
        }

        public void atPrint()
        {
            Console.WriteLine(Service_class + ", " + service_position);
        }
    }

    class Passenger : Person
    {
        public const int maxPa = 5;
        public static int currentPa = 0;
        public readonly int id;
        public int seatNumber;
        public int mile;

        public Passenger() { }

        public Passenger(string name, int birth, int seatNumber, int mile)
        {
            currentPa++;
            id = count;
            this.name = name;
            this.birth = birth;
            this.seatNumber = seatNumber;
            this.mile = mile;
        }

        public void paPrint()
        {
            Console.WriteLine(seatNumber + ", " + mile);
        }
    }

    class Persons
    {
        List<Person> list = new List<Person>();

        string name;
        int birth;
        int number; // 사번
        int pay;
        string grade;
        int road;
        int m_number;   //면허 번호
        string service_class;
        string service_position;
        int mile;

        public void Add(Person person)
        {
            list.Add(person);
        }

        public void P_Add()
        {
            if(Pilot.currentPilot >= Pilot.maxPilot)
            {
                Console.WriteLine("파일럿은 최대 2명 입니다.");
                return;
            }

            Console.Write("이름: ");
            name = Console.ReadLine();
            Console.Write("생년: ");
            birth = int.Parse(Console.ReadLine());
            Console.Write("사번: ");
            number = int.Parse(Console.ReadLine());
            Console.Write("급여: ");
            pay = int.Parse(Console.ReadLine());
            Console.Write("연말평가: ");
            grade = Console.ReadLine();
            Console.Write("총 비행거리: ");
            road = int.Parse(Console.ReadLine());
            Console.Write("면허번호: ");
            m_number = int.Parse(Console.ReadLine());

            list.Add(new Pilot(name, birth, number, pay, grade, road, m_number));

        }

        public void AttAdd()
        {
            if(Attendant.currentAtt >= Attendant.maxAtt)
            {
                Console.WriteLine("승무원은 최대 3명 입니다.");
                return;
            }

            Console.Write("이름: ");
            name = Console.ReadLine();
            Console.Write("생년: ");
            birth = int.Parse(Console.ReadLine());
            Console.Write("사번: ");
            number = int.Parse(Console.ReadLine());
            Console.Write("급여: ");
            pay = int.Parse(Console.ReadLine());
            Console.Write("연말평가: ");
            grade = Console.ReadLine();
            Console.Write("서비스 클래스: ");
            service_class = Console.ReadLine();
            Console.Write("서비스 구역: ");
            service_position = Console.ReadLine();

            list.Add(new Attendant(name, birth, number, pay, grade, service_class, service_position));
        }

        public void PassenAdd()
        {
            if(Passenger.currentPa >= Passenger.maxPa)
            {
                Console.WriteLine("승객은 최대 5명 입니다.");
                return;
            }

            Console.Write("이름: ");
            name = Console.ReadLine();
            Console.Write("생년: ");
            birth = int.Parse(Console.ReadLine());
            Console.Write("좌석번호: ");
            number = int.Parse(Console.ReadLine());
            Console.Write("마일리지: ");
            mile = int.Parse(Console.ReadLine());

            list.Add(new Passenger(name, birth, number, mile));
        }

        public void AllPrint()
        {
            foreach (var item in list)
            {
                if (item is Pilot)
                {
                    var a = item as Pilot;

                    Console.Write("탑승번호: " + a.id + ", 파일럿, ");
                    ((Person)a).personPrint();
                    ((Employee)a).employeePrint();
                    a.pilotPrint();
                }
            }
            foreach (var item in list)
            {
                if (item is Attendant)
                {
                    var a = item as Attendant;

                    Console.Write("탑승번호: " + a.id + ", 승무원, ");
                    ((Person)a).personPrint();
                    ((Employee)a).employeePrint();
                    a.atPrint();
                }
            }
            foreach (var item in list)
            {
                if (item is Passenger)
                {
                    var a = item as Passenger;

                    Console.Write("탑승번호: " + a.id + ", 승객, ");
                    ((Person)a).personPrint();
                    a.paPrint();
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Persons persons = new Persons();
            persons.Add(new Passenger("김가나", 970713, 2020, 19000));
            persons.Add(new Passenger("김다라", 990913, 2000, 100));
            persons.Add(new Passenger("김마바", 970720, 1020, 1900));
            persons.Add(new Passenger("김사아", 000713, 2030, 2000));
            persons.Add(new Attendant("이자차", 220826, 190020, 2000000, "S", "First", "Z"));
            persons.Add(new Attendant("박카타", 210926, 190021, 3000000, "A", "Business", "C"));
            persons.Add(new Pilot("김하하", 960926, 190019, 5000000, "B", 2000, 202020));


            while (true)
            {
                Console.WriteLine("1.  파일럿추가, 2. 승무원추가, 3. 승객추가, 4. 현황 출력, 5. 종료");
                Console.Write("입력: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        persons.P_Add();
                        continue;
                    case 2:
                        persons.AttAdd();
                        continue;

                    case 3:
                        persons.PassenAdd();
                        continue;

                    case 4:
                        persons.AllPrint();
                        continue;

                    case 5:
                        break;
                }
                break;
            }
        }
    }
}
