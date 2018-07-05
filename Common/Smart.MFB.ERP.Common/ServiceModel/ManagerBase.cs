using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.ServiceModel;
using Smart.MFB.ERP.Common.Core;

namespace Smart.MFB.ERP.Common.ServiceModel
{
    public class ManagerBase
    {
        public ManagerBase()
        {
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                try
                {
                    _LoginName = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("String", "System");
                    if (_LoginName.IndexOf(@"\") > -1) _LoginName = string.Empty;
                }
                catch
                {
                    _LoginName = string.Empty;
                }
            }

            if (ObjectBase.Container != null)
                ObjectBase.Container.SatisfyImportsOnce(this);

            RegisterModule();

        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual void RegisterModule()
        {

        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual void InstalledModule()
        {

        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public virtual void UninstalledModule()
        {

        }

        protected string _LoginName = string.Empty;

        protected virtual bool AllowAccessToOperation(string moduleName, List<string> groupNames)
        {
            return false;
        }

        protected virtual void CompanyAuthorization(long entityCompanyId,long sessionCompanyId)
        {
            if (entityCompanyId != sessionCompanyId)
            {
                AuthorizationValidationException ex = new AuthorizationValidationException(string.Format("Account session for {0} has an active company different from that of the model been work on.", _LoginName));
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                 throw new FaultException(ex.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
