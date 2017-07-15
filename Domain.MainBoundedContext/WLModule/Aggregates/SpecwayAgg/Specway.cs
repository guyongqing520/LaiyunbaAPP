
//===================================================================================
// Copyright (c) GuYongQing Corporation.  All Rights Reserved.
//===================================================================================

using Domain.MainBoundedContext.Resources;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MainBoundedContext.WLModule.Aggregates.SpecwayAgg
{
    /// <summary>
    /// Aggregate root for GooderProduct Aggregate.
    /// </summary>
    public class Specway : Entity, IValidatableObject
    {

        #region Members

        bool _IsEnabled;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set user userid as AccountId
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set gooder name
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourcePrivince { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourceCity { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourceArea { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourceAddress { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourceTelehone { get; set; }

        /// <summary>
        /// Get or set gooder source's city of adress
        /// </summary>
        public string SourceMobile { get; set; }

        /// <summary>
        /// Get or set gooder dest city one city of adress
        /// </summary>
        public string DestCity { get; set; }

        /// <summary>
        /// Get or set gooder dest city Second city of adress
        /// </summary>
        public string DestCity1 { get; set; }

        /// <summary>
        /// Get or set gooder dest city third city of adress
        /// </summary>
        public string DestCity2 { get; set; }

        /// <summary>
        /// Get or set gooder dest city third city of adress
        /// </summary>
        public string DestCity3 { get; set; }

        /// <summary>
        /// Get Driver's car of type
        /// </summary>
        public DateTime CrateOn { get; set; }

        /// <summary>
        /// Get gooder's Volume
        /// </summary>
        public DateTime LateDate { get; set; }

        /// <summary>
        /// Get gooder's Volume
        /// </summary>
        public string HeadUrl { get; set; }

        /// <summary>
        /// Get gooder's height
        /// </summary>
        public string CardPositiveUrl { get; set; }

        /// <summary>
        /// Get the gooder loading of time or lay of time
        /// </summary>
        public string CardnegativeUrl { get; set; }

        /// <summary>
        /// Get the gooder loading of time or lay of time
        /// </summary>
        public string BusinessUrl { get; set; }

        #region SceneUrl

        /// <summary>
        /// Get or set the unit price for this gooder
        /// </summary>
        public string SceneUrl1 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl2 { get; set; }

        /// <summary>
        /// Get the gooder Payway
        /// </summary>
        public string SceneUrl3 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl4 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl5 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl6 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl7 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl8 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl9 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl10 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl11 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl12 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl13 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl14 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl15 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl16 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl17 { get; set; }

        /// <summary>
        /// Get the gooder Transferway
        /// </summary>
        public string SceneUrl18 { get; set; }

        #endregion

        /// <summary>
        /// Get the gooder Remark
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Get or set good user's lng
        /// </summary>
        public float Lng { get; set; }

        /// <summary>
        /// Get or set good user's lat
        /// </summary>
        public float Lat { get; set; }

        /// <summary>
        /// Get or set good user's location info
        /// </summary>
        public DbGeography Location { get; set; }

        /// <summary>
        /// Get the gooder loading of time or lay of time
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Get log current state
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            private set
            {
                _IsEnabled = value;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Set log info of state is false for disable
        /// </summary>
        public void Disable()
        {
            if (IsEnabled)
                this._IsEnabled = false;
        }

        /// <summary>
        /// Set log info of state is true for enable
        /// </summary>
        public void Enable()
        {
            if (!IsEnabled)
                this._IsEnabled = true;
        }


        #endregion

        #region IValidatableObject Members

        /// <summary>
        /// <see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/>
        /// </summary>
        /// <param name="validationContext"><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></param>
        /// <returns><see cref="M:System.ComponentModel.DataAnnotations.IValidatableObject.Validate"/></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrEmpty(this.Name))
                validationResults.Add(new ValidationResult(Messages.validation_SpecwayNameNotAllNull, new string[] { "Name" }));

            if (string.IsNullOrEmpty(this.SourcePrivince))
                validationResults.Add(new ValidationResult(Messages.validation_SpecwaySourcePrivinceNull, new string[] { "SourcePrivince" }));

            if (string.IsNullOrEmpty(this.SourceCity))
                validationResults.Add(new ValidationResult(Messages.validation_SpecwaySourceCityFristNull, new string[] { "SourceCity" }));

            if (string.IsNullOrEmpty(this.DestCity))
                validationResults.Add(new ValidationResult(Messages.validation_SpecwayDestCityNull, new string[] { "DestCity" }));


            return validationResults;
        }

        #endregion


    }
}
