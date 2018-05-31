using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class User : ObjectBase
    {
        long _UserId;
        string _LoginID;
        string _FirstName;
        string _LastName;
        string _Email;
        string _Mobile;
        EntityScopeEnum _EntityScope;
        string _ScopeCode;
        long _GroupId;
        string _EmployeeCode;
        DateTime _LastLoginDate;
        bool _IsLock;
        bool _Active;

        public long UserId
        {
            get { return _UserId; }
            set
            {
                if (_UserId != value)
                {
                    _UserId = value;
                    OnPropertyChanged(() => UserId);
                }
            }
        }

        public string LoginID
        {
            get { return _LoginID; }
            set
            {
                if (_LoginID != value)
                {
                    _LoginID = value;
                    OnPropertyChanged(() => LoginID);
                }
            }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }

        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                if (_Mobile != value)
                {
                    _Mobile = value;
                    OnPropertyChanged(() => Mobile);
                }
            }
        }

        public EntityScopeEnum EntityScope
        {
            get { return _EntityScope; }
            set
            {
                if (_EntityScope != value)
                {
                    _EntityScope = value;
                    OnPropertyChanged(() => EntityScope);
                }
            }
        }

        public string ScopeCode
        {
            get { return _ScopeCode; }
            set
            {
                if (_ScopeCode != value)
                {
                    _ScopeCode = value;
                    OnPropertyChanged(() => ScopeCode);
                }
            }
        }

        public long GroupId
        {
            get { return _GroupId; }
            set
            {
                if (_GroupId != value)
                {
                    _GroupId = value;
                    OnPropertyChanged(() => GroupId);
                }
            }
        }

        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set
            {
                if (_EmployeeCode != value)
                {
                    _EmployeeCode = value;
                    OnPropertyChanged(() => EmployeeCode);
                }
            }
        }

        public DateTime LastLoginDate
        {
            get { return _LastLoginDate; }
            set
            {
                if (_LastLoginDate != value)
                {
                    _LastLoginDate = value;
                    OnPropertyChanged(() => LastLoginDate);
                }
            }
        }

        public bool IsLock
        {
            get { return _IsLock; }
            set
            {
                if (_IsLock != value)
                {
                    _IsLock = value;
                    OnPropertyChanged(() => IsLock);
                }
            }
        }

        public bool Active
        {
            get { return _Active; }
            set
            {
                if (_Active != value)
                {
                    _Active = value;
                    OnPropertyChanged(() => Active);
                }
            }
        }

        public string LongIsLock
        {
            get
            {
                return string.Format("{0} {1}", _Email, _LoginID);
            }
        }

        class UserValidator : AbstractValidator<User>
        {
            public UserValidator()
            {
                RuleFor(obj => obj.FirstName).NotEmpty();
                RuleFor(obj => obj.LastName).NotEmpty();
                RuleFor(obj => obj.LoginID).NotEmpty();
                RuleFor(obj => obj.Email).NotEmpty();
                RuleFor(obj => obj.EntityScope).NotEmpty();
                RuleFor(obj => obj.EmployeeCode).NotEmpty();

            }
        }

        protected override IValidator GetValidator()
        {
            return new UserValidator();
        }
    }
}
