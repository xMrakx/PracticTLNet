using SchoolApp;
using System;


List<Class> testClasses = new List<Class>();

School school = new("TestSchool", testClasses);

school.AddClass("class1");
school.AddClass("class2");
school.AddClass("class3");

school.AddStudent("Student 1.1", "class1");
school.AddStudent("Student 1.2", "class1");
school.AddStudent("Student 2.1", "class2");
school.AddStudent("Student 2.2", "class2");
school.AddStudent("Student 3.1", "class3");
school.AddStudent("Student 3.2", "class3");

Mark mark1 = new(5, "math", new DateTime(2012, 05, 03));
Mark mark2 = new(5, "physic", new DateTime(2012, 05, 02));
Mark mark3 = new(4, "math", new DateTime(2012, 05, 04));
Mark mark4 = new(3, "geograph", new DateTime(2012, 06, 03));
Mark mark5 = new(2, "math", new DateTime(2012, 07, 03));

school.AddMark("class1", "Student 1.1", mark1);
school.AddMark("class1", "Student 1.1", mark2);
school.AddMark("class1", "Student 1.2", mark1);
school.AddMark("class1", "Student 1.2", mark3);

school.AddMark("class2", "Student 2.1", mark2);
school.AddMark("class2", "Student 2.1", mark3);
school.AddMark("class2", "Student 2.2", mark3);
school.AddMark("class2", "Student 2.2", mark4);

school.AddMark("class3", "Student 3.1", mark3);
school.AddMark("class3", "Student 3.1", mark4);
school.AddMark("class3", "Student 3.2", mark4);
school.AddMark("class3", "Student 3.2", mark5);

Console.WriteLine($"Best student: {school.GetBestStudent().Name}");
Console.WriteLine();

List<Student> fallingStudents = school.GetListFallingStudents();
Console.WriteLine("Falling students");
foreach(Student st in fallingStudents)
{
    Console.WriteLine(st.Name);
}







