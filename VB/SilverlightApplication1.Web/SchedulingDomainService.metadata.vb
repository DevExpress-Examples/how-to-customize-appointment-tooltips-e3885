
Option Compare Binary
Option Infer On
Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server


'The MetadataTypeAttribute identifies CarSchedulingMetadata as the class
' that carries additional metadata for the CarScheduling class.
<MetadataTypeAttribute(GetType(CarScheduling.CarSchedulingMetadata))>  _
Partial Public Class CarScheduling
    
    'This class allows you to attach custom attributes to properties
    ' of the CarScheduling class.
    '
    'For example, the following marks the Xyz property as a
    ' required property and specifies the format for valid values:
    '    <Required()>
    '    <RegularExpression("[A-Z][A-Za-z0-9]*")>
    '    <StringLength(32)>
    '    Public Property Xyz As String
    Friend NotInheritable Class CarSchedulingMetadata
        
        'Metadata classes are not meant to be instantiated.
        Private Sub New()
            MyBase.New
        End Sub
        
        Public Property AllDay As Boolean
        
        Public Property CarId As Nullable(Of Integer)
        
        Public Property ContactInfo As String
        
        Public Property Description As String
        
        Public Property EndTime As Nullable(Of DateTime)
        
        Public Property EventType As Nullable(Of Integer)
        
        Public Property ID As Integer
        
        Public Property Label As Nullable(Of Integer)
        
        Public Property Location As String
        
        Public Property Price As Nullable(Of Decimal)
        
        Public Property RecurrenceInfo As String
        
        Public Property ReminderInfo As String
        
        Public Property StartTime As Nullable(Of DateTime)
        
        Public Property Status As Nullable(Of Integer)
        
        Public Property Subject As String
        
        Public Property UserId As Nullable(Of Integer)
    End Class
End Class

