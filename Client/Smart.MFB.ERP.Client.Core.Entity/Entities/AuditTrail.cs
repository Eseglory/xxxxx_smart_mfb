using System;
using System.Linq;
using FluentValidation;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Client.Core.Entities
{
    public class AuditTrail : ObjectBase
    {
        long _AuditTrailId;
        string _RevisionStamp;
        string _TableName;
        string _UserName;
        string _IPAddress;
        string _Actions;
        string _ActionDescription;
        string _ChangedColumns;
        string _OldData;
        string _NewData;
        bool _Active;

        public long AuditTrailId
        {
            get { return _AuditTrailId; }
            set
            {
                if (_AuditTrailId != value)
                {
                    _AuditTrailId = value;
                    OnPropertyChanged(() => AuditTrailId);
                }
            }
        }

        public string RevisionStamp
        {
            get { return _RevisionStamp; }
            set
            {
                if (_RevisionStamp != value)
                {
                    _RevisionStamp = value;
                    OnPropertyChanged(() => RevisionStamp);
                }
            }
        }

        public string TableName
        {
            get { return _TableName; }
            set
            {
                if (_TableName != value)
                {
                    _TableName = value;
                    OnPropertyChanged(() => TableName);
                }
            }
        }

        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    OnPropertyChanged(() => UserName);
                }
            }
        }

        public string IPAddress
        {
            get { return _IPAddress; }
            set
            {
                if (_IPAddress != value)
                {
                    _IPAddress = value;
                    OnPropertyChanged(() => IPAddress);
                }
            }
        }

        public string Actions
        {
            get { return _Actions; }
            set
            {
                if (_Actions != value)
                {
                    _Actions = value;
                    OnPropertyChanged(() => Actions);
                }
            }
        }

        public string ActionDescription
        {
            get { return _ActionDescription; }
            set
            {
                if (_ActionDescription != value)
                {
                    _ActionDescription = value;
                    OnPropertyChanged(() => ActionDescription);
                }
            }
        }

        public string OldData
        {
            get { return _OldData; }
            set
            {
                if (_OldData != value)
                {
                    _OldData = value;
                    OnPropertyChanged(() => OldData);
                }
            }
        }

        public string NewData
        {
            get { return _NewData; }
            set
            {
                if (_NewData != value)
                {
                    _NewData = value;
                    OnPropertyChanged(() => NewData);
                }
            }
        }

        public string ChangedColumns
        {
            get { return _ChangedColumns; }
            set
            {
                if (_ChangedColumns != value)
                {
                    _ChangedColumns = value;
                    OnPropertyChanged(() => ChangedColumns);
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


        class AuditTrailValidator : AbstractValidator<AuditTrail>
        {
            public AuditTrailValidator()
            {
                RuleFor(obj => obj.RevisionStamp).NotEmpty();
                RuleFor(obj => obj.TableName).NotEmpty();
                RuleFor(obj => obj.UserName).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new AuditTrailValidator();
        }
    }
}
