namespace SchoolApp;

public class Student
{
    public Student(string name, List<Mark> marks)
    {
        Name = name;
        Marks = marks;
    }

    public string Name { get; private set; }
    public List<Mark> Marks { get; private set; }

    public double GetAvgMark()
    {
        return Marks.Average(x => x.Value);
    }

    public void AddMark(Mark mark)
    {   
        Marks.Add(mark);
    }
}