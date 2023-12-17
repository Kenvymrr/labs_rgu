using System;

class Student : IEquatable<Student>
{
    private string fullName;
    private string group;
    private string studentId;
    private int course;

    public Student(string fullName, string group, string studentId, int course)
    {
        if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(group) || string.IsNullOrEmpty(studentId))
        {
            throw new ArgumentNullException("The FCs, study group and record book number cannot be empty.");
        }

        if (course < 1 || course > 4)
        {
            throw new ArgumentOutOfRangeException("The course should be a number from 1 to 4.");
        }

        this.fullName = fullName;
        this.group = group;
        this.studentId = studentId;
        this.course = course;
    }

    public string FullName
    {
        get { return fullName; }
    }

    public string Group
    {
        get { return group; }
    }

    public string StudentId
    {
        get { return studentId; }
    }

    public int Course
    {
        get { return course; }
    }

    public override string ToString()
    {
        return $"Student: {fullName}, Group: {group}, Number of the record book: {studentId}, Course: {course}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Student other = (Student)obj;
        return this.fullName == other.fullName &&
               this.group == other.group &&
               this.studentId == other.studentId &&
               this.course == other.course;
    }

    public override int GetHashCode()
    {
        unchecked // disabling overflow check
        {
            int hash = 31; // choosing the base number for the hash
            hash = hash * 31 + fullName.GetHashCode(); // combining the hash of each field
            hash = hash * 31 + group.GetHashCode();
            hash = hash * 31 + studentId.GetHashCode();
            hash = hash * 31 + course.GetHashCode();
            return hash;
        }
    }

    public bool Equals(Student other)
    {
        if (other == null)
        {
            return false;
        }

        return this.fullName == other.fullName &&
               this.group == other.group &&
               this.studentId == other.studentId &&
               this.course == other.course;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Student student1 = new Student("Ivanov Ivan Ivanovich", "Group 101", "123456", 2);
            Student student2 = new Student("Petrov Peter Petrovich", "Group 102", "789012", 3);

            Console.WriteLine(student1);
            Console.WriteLine(student2);

            Console.WriteLine($"Student 1 is equal to student 2? {student1.Equals(student2)}");
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
