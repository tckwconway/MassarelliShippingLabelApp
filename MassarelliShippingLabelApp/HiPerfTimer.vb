Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Threading


Friend Class HiPerfTimer
    <DllImport("Kernel32.dll")> _
    Private Shared Function QueryPerformanceCounter(ByRef lpPerformanceCount As Long) As Boolean
    End Function

    <DllImport("Kernel32.dll")> _
    Private Shared Function QueryPerformanceFrequency(ByRef lpFrequency As Long) As Boolean
    End Function

    Private startTime As Long, stopTime As Long
    Private freq As Long

    ' Constructor
    Public Sub New()
        startTime = 0
        stopTime = 0

        If QueryPerformanceFrequency(freq) = False Then
            ' high-performance counter not supported
            Throw New Win32Exception()
        End If
    End Sub

    ' Start the timer
    Public Sub Start()
        ' lets do the waiting threads there work
        Thread.Sleep(0)

        QueryPerformanceCounter(startTime)
    End Sub

    ' Stop the timer
    Public Sub [Stop]()
        QueryPerformanceCounter(stopTime)
    End Sub

    ' Returns the duration of the timer (in seconds)
    Public ReadOnly Property Duration() As Double
        Get
            Return CDbl(stopTime - startTime) / CDbl(freq)
        End Get
    End Property
End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
