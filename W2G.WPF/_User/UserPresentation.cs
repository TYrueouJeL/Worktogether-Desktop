using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using W2G.WPF.Core;
using W2G.EF;
using Microsoft.EntityFrameworkCore;

namespace W2G.WPF
{
    internal class UserPresentation : EntityPresentation<UserEntity>
    {
        public new UserController Controller => (UserController)base.Controller;

        #region Email
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                ClearAndNotify();
                ValidateEmail();
            }
        }
        #endregion

        #region PasswordFirstName
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                ClearAndNotify();
                ValidatePassword();
            }
        }
        #endregion

        #region Firstname
        private string _Firstname;
        public string Firstname
        {
            get { return _Firstname; }
            set
            {
                _Firstname = value;
                ClearAndNotify();
                ValidateFirstname();
            }
        }
        #endregion

        #region Lastname
        private string _Lastname;
        public string Lastname
        {
            get { return _Lastname; }
            set
            {
                _Lastname = value;
                ClearAndNotify();
                ValidateLastname();
            }
        }
        #endregion

        #region FullName
        private string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set
            {
                _FullName = value;
                ClearAndNotify();
            }
        }
        #endregion

        #region Role
        public UserRole _Role;
        public string Role
        {
            get { return _Role.ToString(); }
            set
            {
                _Role = (UserRole)Enum.Parse(typeof(UserRole), value);
                ClearAndNotify();
            }
        }

        private List<string> _userRoles;
        public List<string> UserRole
        {
            get
            {
                if (_userRoles == null)
                {
                    _userRoles = Enum.GetValues(typeof(UserRole))
                                     .Cast<UserRole>()
                                     .Select(r => r.ToString())
                                     .ToList();
                }
                return _userRoles;
            }
        }
        #endregion

        private void ValidateEmail()
        {
            if (string.IsNullOrEmpty(_Email))
            {
                AddError(nameof(Email), "Veuillez indiquer une adresse email");
            }
            else
            {
                var user = GetUserByEmail(_Email);
                if (user != null && user.Id != Entity.Id)
                {
                    AddError(nameof(Email), "Cette adresse email est déjà utilisée");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(_Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    AddError(nameof(Email), "Veuillez indiquer une adresse email valide");
                }
            }
        }

        public UserEntity GetUserByEmail(string email)
        {
            return Controller.Context.Set<UserEntity>()
                .FirstOrDefault(u => u.Email == email);
        }

        private void ValidatePassword()
        {
            if (string.IsNullOrEmpty(_Password))
            {
                AddError(nameof(Password), "Veuillez indiquer un mot de passe");
            }
            else if (_Password.Length < 8)
            {
                AddError(nameof(Password), "Le mot de passe doit contenir au moins 8 caractères");
            }
        }

        private void ValidateFirstname()
        {
            if (string.IsNullOrEmpty(_Firstname))
            {
                AddError(nameof(Firstname), "Veuillez indiquer un prénom");
            }
        }

        private void ValidateLastname()
        {
            if (string.IsNullOrEmpty(_Lastname))
            {
                AddError(nameof(Lastname), "Veuillez indiquer un nom");
            }
        }

        public UserPresentation(UserController controller, UserEntity entity) : base(controller, entity)
        {
            _Email = entity.Email;
            _Password = entity.Password;
            _Firstname = entity.FirstName;
            _Lastname = entity.LastName;
            _FullName = entity.FullName;
            _Role = entity.Role;
        }

        public override bool SaveFields()
        {
            Entity.Email = _Email;
            Entity.Password = _Password;
            Entity.FirstName = _Firstname;
            Entity.LastName = _Lastname;
            Entity.Role = _Role;

            return true;
        }

        public override void ResetFields()
        {
            Email = Entity.Email;
            Password = Entity.Password;
            Firstname = Entity.FirstName;
            Lastname = Entity.LastName;
            FullName = Entity.FullName;
            Role = Entity.Role.ToString();
        }
    }
}
