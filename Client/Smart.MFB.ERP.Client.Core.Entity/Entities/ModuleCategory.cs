using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class ModuleCategory : ObjectBase
    {
        long _ModuleCategoryId;
        string _Name;
        string _Code;
        string _Alias;
        string _Description;
        bool _Active;

        public long ModuleCategoryId
        {
            get { return _ModuleCategoryId; }
            set
            {
                if (_ModuleCategoryId != value)
                {
                    _ModuleCategoryId = value;
                    OnPropertyChanged(() => ModuleCategoryId);
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

        public string Code
        {
            get { return _Code; }
            set
            {
                if (_Code != value)
                {
                    _Code = value;
                    OnPropertyChanged(() => Code);
                }
            }
        }

        public string Alias
        {
            get { return _Alias; }
            set
            {
                if (_Alias != value)
                {
                    _Alias = value;
                    OnPropertyChanged(() => Alias);
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
                return string.Format("{0} {1}", _Alias, _Code);
            }
        }

        class ModuleCategoryValidator : AbstractValidator<ModuleCategory>
        {
            public ModuleCategoryValidator()
            {
                RuleFor(obj => obj.Name).NotEmpty();
                RuleFor(obj => obj.Code).NotEmpty();
                RuleFor(obj => obj.Alias).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new ModuleCategoryValidator();
        }
    }
}
