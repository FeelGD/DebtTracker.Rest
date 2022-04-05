using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class DebtManager : IDebtService
    {
        private IDebtDal _debtDal;
        public DebtManager(IDebtDal debtDal)
        {
            _debtDal = debtDal;
        }

        public IResult Add(Debt debt)
        {
            _debtDal.Add(debt);
            return new SuccessResult(Messages.DebtAdded);
        }

        public IResult Delete(int id)
        {
            var debt = _debtDal.Get(d => d.Id == id);
            if (debt != null)
            {
                _debtDal.Delete(debt);
                return new SuccessResult(Messages.DebtAdded);
            }
            return new ErrorResult(Messages.DebtNotFound);
        }
        public IResult Update(Debt debt)
        {
            _debtDal.Update(debt);
            return new SuccessResult(Messages.DebtUpdated);
        }

        public IDataResult<Debt> Get(int id)
        {
            var debt = _debtDal.Get(d => d.Id == id);
            if (debt != null)
            {
                return new SuccessDataResult<Debt>(debt);
            }
            return new ErrorDataResult<Debt>(Messages.DebtNotFound);

        }

        public IDataResult<List<Debt>> GetList(int ownerId)
        {
            //TODO get users debts and calculated!!
            //TODO check request owner to the other ones in same hause


            return new SuccessDataResult<List<Debt>>(_debtDal.GetList(d => d.UserId == ownerId).ToList());
        }

    }
}
