using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mosing2.Models
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("traveling", Namespace = "", IsNullable = false)]
    public partial class Traveling
    {

        private travelingRoute[] routeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("route")]
        public travelingRoute[] route
        {
            get
            {
                return this.routeField;
            }
            set
            {
                this.routeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class travelingRoute
    {

        private travelingRoutePlace[] placeField;

        private string partField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("place")]
        public travelingRoutePlace[] place
        {
            get
            {
                return this.placeField;
            }
            set
            {
                this.placeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string part
        {
            get
            {
                return this.partField;
            }
            set
            {
                this.partField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class travelingRoutePlace
    {

        private string nameField;

        private decimal latField;

        private decimal longField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public decimal lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }

        /// <remarks/>
        public decimal @long
        {
            get
            {
                return this.longField;
            }
            set
            {
                this.longField = value;
            }
        }
    }
}
