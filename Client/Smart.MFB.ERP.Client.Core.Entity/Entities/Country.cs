using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class Country : ObjectBase
    {
        long _CountryId;
        string _Code;
        string _Name;
        string _ShortCode;
        string _Description;
        bool _Active;

        public long CountryId
        {
            get { return _CountryId; }
            set
            {
                if (_CountryId != value)
                {
                    _CountryId = value;
                    OnPropertyChanged(() => CountryId);
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

        public string ShortCode
        {
            get { return _ShortCode; }
            set
            {
                if (_ShortCode != value)
                {
                    _ShortCode = value;
                    OnPropertyChanged(() => ShortCode);
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

        class CountryValidator : AbstractValidator<Country>
        {
            public CountryValidator()
            {
                RuleFor(obj => obj.Code).NotEmpty();
                RuleFor(obj => obj.Name).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new CountryValidator();
        }
    }
}
