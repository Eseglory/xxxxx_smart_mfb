using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class Group : ObjectBase
    {
        long _GroupId;
        string _Name;
        string _Description;
        bool _Active;

        public long GroupId
        {
            get { return _GroupId; }
            set
            {
                if (_GroupId != value)
                {
                    _GroupId = value;
                    OnPropertyChanged(() => GroupId);
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
                return string.Format("{0} {1}", _Name,_Description );
            }
        }

        class GroupValidator : AbstractValidator<Group>
        {
            public GroupValidator()
            {
                RuleFor(obj => obj.Name).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new GroupValidator();
        }
    }
}
