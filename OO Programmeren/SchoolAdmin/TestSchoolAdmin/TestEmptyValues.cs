using System.Collections.Immutable;
using SchoolAdmin;
namespace TestSchoolAdmin;

[TestClass]
public class TestEmptyValues
{
    Course course;
    Student student;
    [TestInitialize]
    public void Initialize()
    {
        student = new Student("naam", new DateTime(), "");
        course = new Course("Vak", 3);
    }

    [TestMethod]
    public void TestNullValueCourse()
    {
        //Arrange
        //Act
        CourseRegistration reg = new CourseRegistration(student, null, 4);

        //Assert
        Assert.IsNull(reg.Course);
    }

    [TestMethod]
    public void TestNullValueStudent()
    {
        //Arrange

        //Act
        CourseRegistration reg = new CourseRegistration(null, course, 4);
        //Assert
        Assert.IsNull(reg.Student);
    }

   

    [TestCleanup]
    public void Cleanup()
    {
        Student.AllPersons.Clear();
        Course.AllCourses.Clear();
    }
}

[TestClass]
public class TestEquals
{


    [TestMethod]
    public void TestEqualStudent()
    {
        //Arrange
        Student stu1 = new Student("Jason", new DateTime(),"");
        Student stu2 = new Student("Jason", new DateTime(),"");
        //Act
        //Assert

        Assert.IsFalse(stu1.Equals(stu2));
        
    }

    [TestMethod]
    public void TestEqualLecturer()
    {
        Lecturer lec1 = new Lecturer("jason", new DateTime(),new Dictionary<string, byte>());
        Lecturer lec2 = new Lecturer("jason", new DateTime(), new Dictionary<string, byte>());

        Assert.IsFalse(lec1.Equals(lec2));
    }
}

[TestClass]
public class TestSearchCourse
{
    Course course1;
    Course course2;
    [TestInitialize]
    public void Initialize()
    {
        course1 = new Course("Oop", 3);
        course2 = new Course("Netwerken",9);
    }

    [TestCleanup]
    public void CleanUp()
    {
        Course.AllCourses = ImmutableList.CreateBuilder<Course>();
    }

    [TestMethod]
    public void TestSearchCourseGivesCourse()
    {
        //Arrange
        //Act
        //Assert
        Assert.IsInstanceOfType(Course.SearchCourseById(1), typeof(Course));
    }

    [TestMethod]
    public void TestSearchCourseCorrectCours()
    {
        //Arramge
        //Act
        //Assert
        Assert.AreSame(course1, Course.SearchCourseById(1));
    }

    [TestMethod]
    public void TestSearchCourseCorrectID()
    {
        //Arrange
        //Act
        //Assert
        Assert.AreEqual(course1.Id, Course.SearchCourseById(1).Id);
    }
}
