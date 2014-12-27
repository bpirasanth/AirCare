using AirCare.Data;
using AirCare.Data.Core;
using AirCare.Model.Entities;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebMatrix.WebData;

namespace AirCare.Web.Security
{
    public class CustomMembershipProvider : ExtendedMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            IUnitOfWork UnitOfWork = UowFactory.Create();
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            var sha1csp = new SHA1CryptoServiceProvider();
            byte[] sha1 = sha1csp.ComputeHash(passwordBytes);
            byte[] userPwd =
                UnitOfWork.GetEntityRepository<User>()
                    .GetAll()
                    .Where(s => s.UserName.Equals(username))
                    .Select(s => s.Sha1Password).SingleOrDefault();
            if (userPwd == null) return false;
            byte[] pw = userPwd.ToArray();
            return sha1.SequenceEqual(pw);

        }

        public override bool ConfirmAccount(string accountConfirmationToken)
        {
            throw new System.NotImplementedException();
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken)
        {
            throw new System.NotImplementedException();
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            throw new System.NotImplementedException();
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, System.Collections.Generic.IDictionary<string, object> values)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteAccount(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            throw new System.NotImplementedException();
        }

        public override System.Collections.Generic.ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override System.DateTime GetCreateDate(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override System.DateTime GetLastPasswordFailureDate(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override System.DateTime GetPasswordChangedDate(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override int GetUserIdFromPasswordResetToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsConfirmed(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new System.NotImplementedException(); }
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new System.NotImplementedException(); }
        }

        public override System.Web.Security.MembershipPasswordFormat PasswordFormat
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}