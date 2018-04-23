
namespace SilverlightApplication1.Web {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies CarSchedulingMetadata as the class
    // that carries additional metadata for the CarScheduling class.
    [MetadataTypeAttribute(typeof(CarScheduling.CarSchedulingMetadata))]
    public partial class CarScheduling {

        // This class allows you to attach custom attributes to properties
        // of the CarScheduling class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CarSchedulingMetadata {

            // Metadata classes are not meant to be instantiated.
            private CarSchedulingMetadata() {
            }

            public bool AllDay { get; set; }

            public Nullable<int> CarId { get; set; }

            public string ContactInfo { get; set; }

            public string Description { get; set; }

            public Nullable<DateTime> EndTime { get; set; }

            public Nullable<int> EventType { get; set; }

            public int ID { get; set; }

            public Nullable<int> Label { get; set; }

            public string Location { get; set; }

            public Nullable<decimal> Price { get; set; }

            public string RecurrenceInfo { get; set; }

            public string ReminderInfo { get; set; }

            public Nullable<DateTime> StartTime { get; set; }

            public Nullable<int> Status { get; set; }

            public string Subject { get; set; }

            public Nullable<int> UserId { get; set; }
        }
    }
}
