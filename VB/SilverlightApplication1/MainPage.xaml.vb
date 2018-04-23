Imports System
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging
Imports DevExpress.XtraScheduler
Imports DevExpress.Xpf.Scheduler
Imports DevExpress.Xpf.Scheduler.Drawing

Partial Public Class MainPage
    Inherits UserControl
    Private resourceImages As Dictionary(Of Resource, BitmapImage) = New Dictionary(Of Resource,  _
                        BitmapImage)()
    Public Sub New()
        InitializeComponent()

        schedulerControl1.Start = New DateTime(2010, 7, 19, 0, 0, 0, 0)

        Dim template As DataTemplate = CType(Me.Resources("AppointmentTooltipContentTemplate"),  _
         DataTemplate)
        schedulerControl1.WeekView.AppointmentToolTipContentTemplate = template
    End Sub

#Region "#AppointmentCollectionModifiedEvent"
    ' Commit changes to the database.
    Private Sub SchedulerStorage_AppointmentCollectionModified(sender As Object, e As EventArgs)
        If domainDataSource1.HasChanges Then
            domainDataSource1.SubmitChanges()
        End If
    End Sub
#End Region

    Private Sub DomainDataSource_LoadedData(sender As Object, _
                                            e As LoadedDataEventArgs)
        If e.HasError Then
            MessageBox.Show("Connection could not be established." _
                            & Environment.NewLine & e.Error.Message, "Connection Error", _
                            MessageBoxButton.OK)
            e.MarkErrorAsHandled()
        End If
    End Sub

    Private Sub DomainDataSource_SubmittedChanges(sender As Object, e As SubmittedChangesEventArgs)
        If e.HasError Then
            MessageBox.Show(e.Error.ToString(), "Submit Changes Error", MessageBoxButton.OK)
            e.MarkErrorAsHandled()
        End If
    End Sub

#Region "#AppointmentViewInfoCustomizing"
    Private Sub schedulerControl1_AppointmentViewInfoCustomizing(sender As Object, _
                                                        e As AppointmentViewInfoCustomizingEventArgs)
        Dim viewInfo As AppointmentViewInfo = e.ViewInfo
        Dim resource As Resource = _
            schedulerControl1.Storage.ResourceStorage.GetResourceById(viewInfo.Appointment.ResourceId)
        If resource Is resource.Empty OrElse resource.Image Is Nothing Then
            viewInfo.CustomViewInfo = Nothing
        Else
            If (Not Me.resourceImages.ContainsKey(resource)) Then
                Me.resourceImages(resource) = TryCast(resource.Image.Source, BitmapImage)
            End If
            viewInfo.CustomViewInfo = Me.resourceImages(resource)
        End If
    End Sub
#End Region
End Class

