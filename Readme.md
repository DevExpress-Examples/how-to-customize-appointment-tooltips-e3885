<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/SilverlightApplication1/MainPage.xaml) (VB: [MainPage.xaml](./VB/SilverlightApplication1/MainPage.xaml))
* [MainPage.xaml.cs](./CS/SilverlightApplication1/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/SilverlightApplication1/MainPage.xaml.vb))
<!-- default file list end -->
# How to customize appointment tooltips


<p>The following example demonstrates how to customize the visual representation of appointment tooltips, including showing resource images within appointment tooltips.</p>


<h3>Description</h3>

<p>To show resource images within tooltips displayed for appointments, you should do the following:<br /> 1. Handle the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfSchedulerSchedulerControl_AppointmentViewInfoCustomizingtopic"><u>SchedulerControl.AppointmentViewInfoCustomizing</u></a> event.<br /> 2. In the event handler, assign the resource images to the <strong>CustomViewInfo</strong> property of the <strong>AppointmentViewInfo</strong> object, which is accessible via <strong>AppointmentViewInfoCustomizingEventArgs.ViewInfo</strong>.<br /> 3. In XAML, define a custom template for the appointment tooltips and bind the <strong>Image</strong> object to the <strong>CustomViewInfo</strong> property.<br /> 4. Assign the template to the <a href="http://documentation.devexpress.com/#Silverlight/DevExpressXpfSchedulerSchedulerViewBase_AppointmentToolTipContentTemplatetopic"><u>AppointmentToolTipContentTemplate</u></a> property.</p>

<br/>


