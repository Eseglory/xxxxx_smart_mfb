using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class Religion : ObjectBase
    {
        long _ReligionId;
        string _Code;
        string _Name;
        string _Description;
        bool _Active;

        public long ReligionId
        {
            get { return _ReligionId; }
            set
            {
                if (_ReligionId != value)
                {
                    _ReligionId = value;
                    OnPropertyChanged(() => ReligionId);
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

        class ReligionValidator : AbstractValidator<Religion>
        {
            public ReligionValidator()
            {
                RuleFor(obj => obj.Code).NotEmpty();
                RuleFor(obj => obj.Name).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new ReligionValidator();
        }
    }
}
