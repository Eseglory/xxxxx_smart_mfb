using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class Theme : ObjectBase
    {
        long _ThemeId;
        string _Code;
        bool _Active;

        public long ThemeId
        {
            get { return _ThemeId; }
            set
            {
                if (_ThemeId != value)
                {
                    _ThemeId = value;
                    OnPropertyChanged(() => ThemeId);
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
                return string.Format("{0} ", _Code);
            }
        }

        class ThemeValidator : AbstractValidator<Theme>
        {
            public ThemeValidator()
            {
                RuleFor(obj => obj.Code).NotEmpty();

            }
        }

        protected override IValidator GetValidator()
        {
            return new ThemeValidator();
        }
    }
}
