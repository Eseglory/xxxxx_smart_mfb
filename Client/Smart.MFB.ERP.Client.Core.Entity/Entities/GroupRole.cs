using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class GroupRole : ObjectBase
    {
        long _GroupRoleId;
        long _GroupId;
        long _RoleId;
        bool _Active;

        public long GroupRoleId
        {
            get { return _GroupRoleId; }
            set
            {
                if (_GroupRoleId != value)
                {
                    _GroupRoleId = value;
                    OnPropertyChanged(() => GroupRoleId);
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

        public long RoleId
        {
            get { return _RoleId; }
            set
            {
                if (_RoleId != value)
                {
                    _RoleId = value;
                    OnPropertyChanged(() => RoleId);
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

        class GroupRoleValidator : AbstractValidator<GroupRole>
        {
            public GroupRoleValidator()
            {
                RuleFor(obj => obj.GroupId).GreaterThan(0);
                RuleFor(obj => obj.RoleId).GreaterThan(0);
            }
        }

        protected override IValidator GetValidator()
        {
            return new GroupRoleValidator();
        }
    }
}
