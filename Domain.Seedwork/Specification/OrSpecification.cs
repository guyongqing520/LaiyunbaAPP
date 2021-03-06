﻿
using System;
using System.Linq.Expressions;
namespace Domain.Seedwork.Specification
{
    public sealed class OrSpecification<T>
         : CompositeSpecification<T>
         where T : class
    {
        #region Members

        private ISpecification<T> _RightSideSpecification = null;
        private ISpecification<T> _LeftSideSpecification = null;

        #endregion

        #region Public Constructor

  
        public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == (ISpecification<T>)null)
                throw new ArgumentNullException("leftSide");

            if (rightSide == (ISpecification<T>)null)
                throw new ArgumentNullException("rightSide");

            this._LeftSideSpecification = leftSide;
            this._RightSideSpecification = rightSide;
        }

        #endregion

        #region Composite Specification overrides

   
        public override ISpecification<T> LeftSideSpecification
        {
            get { return _LeftSideSpecification; }
        }

        public override ISpecification<T> RightSideSpecification
        {
            get { return _RightSideSpecification; }
        }
      
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = _LeftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = _RightSideSpecification.SatisfiedBy();

            return (left.Or(right));
            
        }

        #endregion
    }
}
