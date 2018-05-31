using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class UserGroup : ObjectBase
    {
        long _UserGroupId;
        long _GroupId;
        long _UserId;
        bool _Active;

        public long UserGroupId
        {
            get { return _UserGroupId; }
            set
            {
                if (_UserGroupId != value)
                {
                    _UserGroupId = value;
                    OnPropertyChanged(() => UserGroupId);
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

        public string LongDescription
        {
            get
            {
                return "";
            }
        }

        class UserGroupValidator : AbstractValidator<UserGroup>
        {
            public UserGroupValidator()
            {
                RuleFor(obj => obj.GroupId).GreaterThan(0);
                RuleFor(obj => obj.UserId).GreaterThan(0);
            }
        }

        protected override IValidator GetValidator()
        {
            return new UserGroupValidator();
        }
    }
}
