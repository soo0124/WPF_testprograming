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
    enum Color { Apple, Banana, Mango };
    static void Main(string[] args)
    {
        Student std = new Student("sh", 14, 1);

        std.Study();

        std.Intro();

        //---------------------------------------//

        int x = 7, y = 4;

        bool result = (x > y) ? true : false; // if 1줄

        Console.WriteLine(result);

        //자주바뀌는 문자열은 String < StringBuilder가 더 효율적.

        //Const 불변, readonly 객체 생성자에 의해 변화는 가능

        //Nullable<T>(= T?) 변수가 값을 갖고 있는지 없는지 표현하는 플래그 기능 (DataBase 조회시 데이터없을때 유용) 
        //Example : int? = Nullable<int>
        //          int j = x ?? 0; = x가 null이면 0으로 할당.

        //선형탐색 : 일렬된 자료를 좌측부터 우측방향으로 차례대로 탐색하는 알고리즘 (=순차 탐색)
        //이진탐색 : 찾으려는 값의 범위를 중간으로부터 상/하로 나누어 찾는 알고리즘

        //버블정렬 : 배열의 값들을 하나하나 비교하여 큰수 작은수 비교하고 위로 올리는 구조
    }
}