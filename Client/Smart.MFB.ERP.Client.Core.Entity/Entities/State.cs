using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class State : ObjectBase
    {
        long _StateId;
        string _Code;
        string _Name;
        string _Description;
        string _CountryCode;
        bool _Active;

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

        public string CountryCode
        {
            get { return _CountryCode; }
            set
            {
                if (_CountryCode != value)
                {
                    _CountryCode = value;
                    OnPropertyChanged(() => CountryCode);
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

        class StateValidator : AbstractValidator<State>
        {
            public StateValidator()
            {
                RuleFor(obj => obj.Code).NotEmpty();
                RuleFor(obj => obj.Name).NotEmpty();
                RuleFor(obj => obj.CountryCode).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new StateValidator();
        }
    }
}
