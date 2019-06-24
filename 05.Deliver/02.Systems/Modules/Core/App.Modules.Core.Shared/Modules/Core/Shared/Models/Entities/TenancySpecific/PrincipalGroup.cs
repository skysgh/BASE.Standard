//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Text;
//using App.Modules.All.Shared.Models.Entities;

//namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
//{
//    public class Organisation: TenantFKRecordStatedTimestampedGuidIdEntityBase
//    {
//        /// <summary>
//        /// Gets child groups
//        /// </summary>
//        /// <value>
//        /// The groups.
//        /// </value>
//        public virtual ICollection<Organisation> Organisations
//        {
//            get
//            {
//                return _organisations ?? (_organisations = new Collection<Organisation>());
//            }
//        }
//        private ICollection<Organisation> _organisations;

//        /// <summary>
//        /// Gets the members of this Organisation.
//        /// </summary>
//        /// <value>
//        /// The members.
//        /// </value>
//        public virtual ICollection<OrganisationPrincipalAssignment> Members
//        {
//            get
//            {
//                return _members ?? (_members = new Collection<OrganisationPrincipalAssignment>());
//            }
//        }
//        private ICollection<Principal> _members;

//    }
//}
