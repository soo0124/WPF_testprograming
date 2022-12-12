class Human
{
    protected string Name;
    protected int Age;

    public Human(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Intro()
    {
        Console.WriteLine("이름은 : " + Name);
        Console.WriteLine("나이는 : " + Age);
    }
}

class Student : Human
{
    protected int StNum;

    public Student(string Name, int Age, int stNum) : base(Name, Age)
    {
        StNum = stNum;
    }

    public override void Intro()
    {
        base.Intro();
        Console.WriteLine("학생번호 : " + StNum);
    }

    public void Study()
    {
        Console.WriteLine("STUDY");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Student std = new Student("sh", 14, 1);

        std.Study();

        std.Intro();
    }
}