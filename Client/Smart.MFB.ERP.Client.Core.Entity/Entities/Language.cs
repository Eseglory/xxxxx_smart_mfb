using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class Language : ObjectBase
    {
        long _LanguageId;
        string _Code;
        string _Name;
        string _Description;
        bool _Active;

        public long LanguageId
        {
            get { return _LanguageId; }
            set
            {
                if (_LanguageId != value)
                {
                    _LanguageId = value;
                    OnPropertyChanged(() => LanguageId);
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
                return string.Format("{0} {1}", _Name, _Code);
            }
        }

        class LanguageValidator : AbstractValidator<Language>
        {
            public LanguageValidator()
            {
                RuleFor(obj => obj.Code).NotEmpty();
                RuleFor(obj => obj.Name).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new LanguageValidator();
        }
    }
}
