using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class Menu : ObjectBase
    {
        long _MenuId;
        string _Name;
        string _Code;
        string _Alias;
        string _Action;
        string _Controller;
        long _ModuleId;
        long? _ParentId;
        string _Description;
        string _ImageUrl;
        byte[] _Image;
        bool _Active;

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

        public string Action
        {
            get { return _Action; }
            set
            {
                if (_Action != value)
                {
                    _Action = value;
                    OnPropertyChanged(() => Action);
                }
            }
        }

        public string Controller
        {
            get { return _Controller; }
            set
            {
                if (_Controller != value)
                {
                    _Controller = value;
                    OnPropertyChanged(() => Controller);
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

        public long? ParentId
        {
            get { return _ParentId; }
            set
            {
                if (_ParentId != value)
                {
                    _ParentId = value;
                    OnPropertyChanged(() => ParentId);
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

        public string ImageUrl
        {
            get { return _ImageUrl; }
            set
            {
                if (_ImageUrl != value)
                {
                    _ImageUrl = value;
                    OnPropertyChanged(() => ImageUrl);
                }
            }
        }

        public byte[] Image
        {
            get { return _Image; }
            set
            {
                if (_Image != value)
                {
                    _Image = value;
                    OnPropertyChanged(() => Image);
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

        class MenuValidator : AbstractValidator<Menu>
        {
            public MenuValidator()
            {
                RuleFor(obj => obj.Name).NotEmpty();
                RuleFor(obj => obj.Code).NotEmpty();
                RuleFor(obj => obj.Alias).NotEmpty();
                RuleFor(obj => obj.ModuleId).GreaterThan(0);
            }
        }

        protected override IValidator GetValidator()
        {
            return new MenuValidator();
        }
    }
}
