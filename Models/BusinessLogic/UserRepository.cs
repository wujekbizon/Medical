using BCrypt.Net;
using Medical.Models.EntitiesForView;
using System.Linq;
using System.Net;

namespace Medical.Models.BusinessLogic
{
    public class UserRepository : DatabaseClass
    {
        #region Konstruktor
        public UserRepository(MedicalEntities medicalEntities)
          : base(medicalEntities)
        {
        }
        #endregion

        #region Funkcje Pomocnicze
        public bool AuthenticateUser(NetworkCredential credential)
        {
            if (credential == null || string.IsNullOrWhiteSpace(credential.UserName))
                return false;

            var user = medicalEntities.User
                .FirstOrDefault(u => u.Username == credential.UserName);

            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(credential.Password, user.PasswordHash);
        }

        public UserForAllView GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var user = medicalEntities.User
                .Where(u => u.Username == username)
                .Select(u => new UserForAllView
                {
                    Id = u.Id,
                    Username = u.Username,
                    Name = u.Name,
                    LastName = u.LastName,
                    Email = u.Email
                })
                .FirstOrDefault();

            return user;
        }
        #endregion


    }
}
