using Server.Data;

namespace Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Group> Groups { get; }
        IGenericRepository<GroupSubject> GroupSubjects { get; }
        IGenericRepository<LecturerSubject> LecturerSubjects { get; }
        IGenericRepository<StudentGrade> StudentGrades { get; }
        IGenericRepository<StudentGroup> StudentGroups { get; }
        IGenericRepository<Subject> Subjects { get; }
        IGenericRepository<User> Users { get; }
        Task Save();
    }
}
