namespace SchoolApp;

public class School
{
    public School(string name, List<Class> classes)
    {
        SchoolName = name;
        Classes = classes;
    }

    public string SchoolName { get; private set; }
    public List<Class> Classes { get; private set; }

    public int ClassCount => Classes.Count;
    public int StudentsCount => Count();

    private int Count()
    {
        int count = 0;
        foreach(Class classInSchool in Classes)
        {
            count += classInSchool.StudentsCount;
        }
        return count;
    }

    public void AddClass(string classId)
    {
        Class? find = Classes.FirstOrDefault(c => c.ClassId == classId);

        if (find != null)
        {
            throw new Exception("ClassId is busy");
        }

        Class newClass = new(classId, new List<Student>());
        Classes.Add(newClass);
    }

    public void DeleteClass(string classId)
    {
        Class? classToDel = Classes.FirstOrDefault(c => c.ClassId == classId);

        if (classToDel == null)
        {
            throw new ArgumentException($"Class with name {classId} was not found");
        }

        Classes.Remove(classToDel);
    }

    public void AddStudent(string name, string classId)
    {
        Class? find = Classes.FirstOrDefault(c => c.ClassId == classId);

        if (find == null)
        {
            throw new ArgumentException($"Class with name {name} was not found");
        }

        find.AddStudent(name);
    }

    public void DeleteStudent(string classId, string studentName)
    {
        Class? find = Classes.FirstOrDefault(c => c.ClassId == classId);

        if (find == null)
        {
            throw new Exception($"Class with name {classId} was not found ");
        }

        try
        {
            find.DeleteStudent(studentName);
        }
        catch(ArgumentException ex)
        {
            throw ex;
        }
     }

    public void AddMark(string classId, string studentName, Mark mark)
    {
        Class? @class = Classes.FirstOrDefault(c => c.ClassId == classId);

        if (@class == null)
        {
            throw new ArgumentException($"Class with name {classId} was not found");
        }

        try
        {
            @class.AddMark(studentName, mark);
        }
        catch(ArgumentException ex)
        {
            throw ex;
        }
        
    }

    public Student? GetBestStudent()
    {
        List<Student> students = new List<Student>();
        Student? best = null;
        foreach(Class @class in Classes)
        {
            best = @class.GetBestStudent();
            if (best != null)
            {
                students.Add(best);
            }
        }
        return students.MaxBy(item => item.GetAvgMark());
    }

    public List<Student> GetListFallingStudents()
    {
        List<Student> students = new List<Student>();
        foreach(Class @class in Classes)
        { 
            students.AddRange(@class.GetFailingStudents().ToList());
        }

        return students;
    }
}