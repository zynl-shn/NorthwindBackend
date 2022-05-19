﻿using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private IOperationClaimService _operationClaimService;
        private readonly IUserService _userService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IOperationClaimService operationClaimService, IUserService userService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _operationClaimService = operationClaimService;
            _userService = userService;
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), Messages.UserOperationClaimsListed);
        }

        public IDataResult<UserOperationClaim> GetById(int userOperationClaim)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(claim => claim.Id == userOperationClaim));
        }

        public IDataResult<UserOperationClaim> GetByUserId(int userId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(claim => claim.UserId == userId));
        }

        public IDataResult<UserOperationClaim> GetByOperationClaimId(int operationClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(claim => claim.OperationClaimId == operationClaimId));
        }
        
        public List<IResult> Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new List<IResult>() { new SuccessResult(Messages.UserOperationClaimAdded) };
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        public IResult Delete(int operationClaimId)
        {
            var entity = _userOperationClaimDal.Get(claim => claim.OperationClaimId == operationClaimId);
            _userOperationClaimDal.Delete(entity);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }

        private IResult CheckIfOperationClaimExist(int operationClaimId)
        {
            var result = _operationClaimService.GetById(operationClaimId);
            if (result.Data==null)
            {
                return new ErrorResult(Messages.OperaClaimNotFound);
            }

            return new SuccessResult();
        }

        // private IResult CheckIfUserExist(int userId)
        // {
        //     var result = _userService.(p => p.Id == userId).Any();
        //     if (!result)
        //     {
        //         return new ErrorResult(Messages.UserNotFound);
        //     }
        //
        //     return new SuccesResult();
        // }
    }
}