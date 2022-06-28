namespace SchoolApp;

public class Class
{
    public Class(string classId, List<Student> students)
    {
        ClassId = classId;
        Students = students;
    }

    public string ClassId { get; private set; }
    public List<Student> Students { get; private set; }

    public int StudentsCount => Students.Count;

    public Student? GetBestStudent()
    {
        return Students.MaxBy(item => item.GetAvgMark());
    }

    public IEnumerable<Student> GetStudentsOrderedByMarks()
    {
        return Students.OrderByDescending(item => item.GetAvgMark());
    }

    public IEnumerable<Student> GetFailingStudents()
    {
        return Students.Where(item => item.GetAvgMark() <= 3);
    }

    public void AddStudent(string name)
    {
        Student student = new(name, new List<Mark>());
        Students.Add(student);
    }

    public void DeleteStudent(string name)
    {
        Student? student = Students.FirstOrDefault(s => s.Name == name);

        if (student == null)
        {
            throw new ArgumentException($"Student with name {name} was not found ");
        }

        Students.Remove(student);
    }

    public void AddMark(string studentName, Mark mark)
    {
        Student? student = Students.FirstOrDefault(s => s.Name == studentName);

        if (student == null)
        {
            throw new ArgumentException($"Student with name {studentName} was not found ");
        }

        student.AddMark(mark);
    }
}