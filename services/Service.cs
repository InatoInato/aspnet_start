using AspStart.models;

namespace AspStart.services
{
    public class Service
    {
        private readonly AppDb _appDb;
        public Service(AppDb appDb)
        {
            _appDb = appDb;
        }
        public List<User> GetUsers()
        {
            return _appDb.Users.ToList();
        }

        public User CreateUser(User user)
        {
            _appDb.Users.Add(user);
            _appDb.SaveChanges();
            return user;
        }

        public User? GetUserById(int id)
        {
            return _appDb.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? UpdateUser(int id, User updateUser)
        {
            var user = _appDb.Users.FirstOrDefault(u => u.Id == id);
            if(user == null) return null;

            user.Username = updateUser.Username;
            user.Age = updateUser.Age;
            user.Email = updateUser.Email;
            user.Country = updateUser.Country;

            _appDb.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            var user = _appDb.Users.FirstOrDefault(u => u.Id == id);
            if(user == null) return false;

            _appDb.Users.Remove(user);
            _appDb.SaveChanges();
            return true;
        }
    }
}
