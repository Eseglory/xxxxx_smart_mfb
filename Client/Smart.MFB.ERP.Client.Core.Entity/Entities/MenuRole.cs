using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class MenuRole : ObjectBase
    {
        long _MenuRoleId;
        long _MenuId;
        long _RoleId;
        bool _Active;

        public long MenuRoleId
        {
            get { return _MenuRoleId; }
            set
            {
                if (_MenuRoleId != value)
                {
                    _MenuRoleId = value;
                    OnPropertyChanged(() => MenuRoleId);
                }
            }
        }

        public long MenuId
        {
            get { return _MenuId; }
            set
            {
                if (_MenuId != value)
                {
                    _MenuId = value;
                    OnPropertyChanged(() => MenuId);
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

        class MenuRoleValidator : AbstractValidator<MenuRole>
        {
            public MenuRoleValidator()
            {
                RuleFor(obj => obj.MenuId).GreaterThan(0);
                RuleFor(obj => obj.RoleId).GreaterThan(0);
            }
        }

        protected override IValidator GetValidator()
        {
            return new MenuRoleValidator();
        }
    }
}
