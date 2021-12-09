using Server.Data;
using Server.IRepository;

namespace Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Group> _groups;
        private IGenericRepository<GroupSubject> _groupSubjects;
        private IGenericRepository<LecturerSubject> _lecturerSubjects;
        private IGenericRepository<StudentGrade> _studentGrades;
        private IGenericRepository<StudentGroup> _studentGroups;
        private IGenericRepository<Subject> _subjects;
        private IGenericRepository<User> _users;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Group> Groups => _groups ??= new GenericRepository<Group>(_context);

        public IGenericRepository<GroupSubject> GroupSubjects => _groupSubjects ??= new GenericRepository<GroupSubject>(_context);

        public IGenericRepository<LecturerSubject> LecturerSubjects => _lecturerSubjects ??= new GenericRepository<LecturerSubject>(_context);

        public IGenericRepository<StudentGrade> StudentGrades => _studentGrades ??= new GenericRepository<StudentGrade>(_context);

        public IGenericRepository<StudentGroup> StudentGroups => _studentGroups ??= new GenericRepository<StudentGroup>(_context);

        public IGenericRepository<Subject> Subjects => _subjects ??= new GenericRepository<Subject>(_context);

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
