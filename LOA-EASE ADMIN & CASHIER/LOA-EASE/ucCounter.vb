Public Class ucCounter
    Public Property QueueNumber As String
        Get
            Return lblQueueNumber.Text
        End Get
        Set(value As String)
            lblQueueNumber.Text = value
        End Set
    End Property

    Public Property CounterName As String
        Get
            Return lblCounterName.Text
        End Get
        Set(value As String)
            lblCounterName.Text = value
        End Set
    End Property


End Class