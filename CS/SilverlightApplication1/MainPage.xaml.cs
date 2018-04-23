using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using DevExpress.XtraScheduler;
using DevExpress.Xpf.Scheduler;
using DevExpress.Xpf.Scheduler.Drawing;

namespace SilverlightApplication1 {
    public partial class MainPage : UserControl {
        Dictionary<Resource, BitmapImage> resourceImages = new Dictionary<Resource, BitmapImage>();

        public MainPage() {
            InitializeComponent();

            schedulerControl1.Start = new System.DateTime(2010, 7, 19, 0, 0, 0, 0);

            DataTemplate template = (DataTemplate)this.Resources["AppointmentTooltipContentTemplate"];
            schedulerControl1.WeekView.AppointmentToolTipContentTemplate = template;
        }

        #region #AppointmentCollectionModifiedEvent
        // Commit changes to the database.
        private void SchedulerStorage_AppointmentCollectionModified(object sender, EventArgs e) {
            if (domainDataSource1.HasChanges) {
                domainDataSource1.SubmitChanges();
            }
        }
        #endregion #AppointmentCollectionModifiedEvent

        private void DomainDataSource_LoadedData(object sender, LoadedDataEventArgs e) {
            if (e.HasError) {
                MessageBox.Show("Connection could not be established." + Environment.NewLine +
                                e.Error.Message, "Connection Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        private void DomainDataSource_SubmittedChanges(object sender, SubmittedChangesEventArgs e) {
            if (e.HasError) {
                MessageBox.Show(e.Error.ToString(), "Submit Changes Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        #region #AppointmentViewInfoCustomizing
        private void schedulerControl1_AppointmentViewInfoCustomizing(object sender, 
                                                        AppointmentViewInfoCustomizingEventArgs e) {
            AppointmentViewInfo viewInfo = e.ViewInfo;
            Resource resource = schedulerControl1.Storage.ResourceStorage.
                                GetResourceById(viewInfo.Appointment.ResourceId);
            if (resource == Resource.Empty || resource.Image == null)
                viewInfo.CustomViewInfo = null;
            else {
                if (!this.resourceImages.ContainsKey(resource))
                    this.resourceImages[resource] = resource.Image.Source as BitmapImage;
                viewInfo.CustomViewInfo = this.resourceImages[resource];
            }
        }
        #endregion #AppointmentViewInfoCustomizing
    }
}
