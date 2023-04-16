using Web.Application.Persistence.Models;

namespace Web.Application.Persistence.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate="2019-09-01"},
                new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate="2017-09-01"},
                new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate="2018-09-01"},
                new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate="2017-09-01"},
                new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate="2017-09-01"},
                new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate="2016-09-01"},
                new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate="2018-09-01"},
                new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate="2019-09-01"}
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}
