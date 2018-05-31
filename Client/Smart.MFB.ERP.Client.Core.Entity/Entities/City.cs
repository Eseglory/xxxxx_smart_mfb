using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class City : ObjectBase
    {
        long _CityId;
        string _Code;
        string _Name;
        string _Description;
        long _StateId;
        bool _Active;

        public long CityId
        {
            get { return _CityId; }
            set
            {
                if (_CityId != value)
                {
                    _CityId = value;
                    OnPropertyChanged(() => CityId);
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

        public long StateId
        {
            get { return _StateId; }
            set
            {
                if (_StateId != value)
                {
                    _StateId = value;
                    OnPropertyChanged(() => StateId);
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

        class CityValidator : AbstractValidator<City>
        {
            public CityValidator()
            {
                RuleFor(obj => obj.Code).NotEmpty();
                RuleFor(obj => obj.Name).NotEmpty();
                RuleFor(obj => obj.StateId).GreaterThan(0);
            }
        }

        protected override IValidator GetValidator()
        {
            return new CityValidator();
        }
    }
}
