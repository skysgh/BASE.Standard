using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class NavigationRouteDto : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  IHasGuidId
    {
        public Guid Id {
            get; set;
        }
        public bool Enabled
        {
            get; set;
        }


        public Guid OwnerFK
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public int DisplayOrderHint
        {
            get; set;
        }
        public string DisplayStyleHint
        {
            get; set;
        }

        public ICollection<NavigationRouteDto> Chilldren
        {
            get
            {
                return this._children ?? (this._children = new Collection<NavigationRouteDto>());
            }
        }

        private ICollection<NavigationRouteDto> _children;
    }
}
