using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class Role : ObjectBase
    {
        long _RoleId;
        string _Name;
        long _ModuleId;
        string _Description;
        bool _Active;

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

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        public long ModuleId
        {
            get { return _ModuleId; }
            set
            {
                if (_ModuleId != value)
                {
                    _ModuleId = value;
                    OnPropertyChanged(() => ModuleId);
                }
            }
        }

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged(() => Description);
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
                return string.Format("{0} {1}", _Name,_Description );
            }
        }

        class RoleValidator : AbstractValidator<Role>
        {
            public RoleValidator()
            {
                RuleFor(obj => obj.Name).NotEmpty();
                RuleFor(obj => obj.ModuleId).GreaterThan(0);
            }
        }

        protected override IValidator GetValidator()
        {
            return new RoleValidator();
        }
    }
}
