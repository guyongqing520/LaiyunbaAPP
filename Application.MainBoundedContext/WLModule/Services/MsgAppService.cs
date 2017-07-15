using Application.MainBoundedContext.DTO;
using Application.MainBoundedContext.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Seedwork;
using Infrastructure.Crosscutting.Validator;
using Infrastructure.Crosscutting.Logging;
using Domain.MainBoundedContext.WLModule.Aggregates.MsgAgg;

namespace Application.MainBoundedContext.WLModule.Services
{
    public class MsgAppService : IMsgAppService
    {

        #region Members

        readonly IMsgRepository _msgRepository;

        #endregion

        #region Constructors


        /// <summary>
        /// Create a new instance of msg Management Service
        /// </summary>
        /// <param name="vipRepository">Associated msgRepository, intented to be resolved with DI</param>
        public MsgAppService(IMsgRepository msgRepository) //the msg repository                   
        {

            if (msgRepository == null)
                throw new ArgumentNullException("msgRepository");

            _msgRepository = msgRepository;

        }


        #endregion


        #region PraiseRepository Members

        /// <summary>
        /// news a account
        /// </summary>
        /// <param name="praiseDTO"></param>
        /// <returns></returns>
        public MsgDTO AddNewMsg(MsgDTO msgDTO)
        {
            //check preconditions
            if (msgDTO == null)
                throw new ArgumentException(Messages.warning_CannotAddMsgWithEmptyInformation);

            //Create the entity and the required associated data
            var msg = MsgFactory.CreateMsg(msgDTO.Context, msgDTO.MsType);

            //save entity
            SaveMsg(msg);

            //return the data with id and assigned default values
            return msg.ProjectedAs<MsgDTO>();

        }

        /// <summary>
        ///  <see cref="Application.MainBoundedContext.Services.IFavoriterManagement.FindCountries"/>
        /// </summary>
        /// <param name="pageIndex"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <param name="pageCount"> <see cref="Application.MainBoundedContext.Services.ICustomerManagement.FindFavorites"/></param>
        /// <returns> <see cref="M:Application.MainBoundedContext.ERPModule.Services.ICustomerManagement.FindCountries"/></returns>
        public List<MsgDTO> FindMsgs(int pageIndex, int pageCount)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentsForFindSmss);

            //recover praise
            var msgs = _msgRepository.GetPaged(pageIndex, pageCount, c => c.CreateOn, false);

            if (msgs != null
                &&
                msgs.Any())
            {
                return msgs.ProjectedAsCollection<MsgDTO>();
            }
            else // no data.
                return null;
        }


        #endregion

        #region Private Methods

       

        void SaveMsg(Msg msg)
        {
            //recover validator
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid(msg)) //if favorite is valid
            {
                //add the favorite into the repository
                _msgRepository.Add(msg);

                //commit the unit of work
                _msgRepository.UnitOfWork.Commit();
            }
            else //customer is not valid, throw validation errors
                throw new ApplicationValidationErrorsException(validator.GetInvalidMessages<Msg>(msg));
        }

        #endregion

        #region IDisposable Members


        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            //dispose all resources
            _msgRepository.Dispose();
        }

        #endregion

    }
}
