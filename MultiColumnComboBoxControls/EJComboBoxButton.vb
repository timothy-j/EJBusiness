Public Class EJComboBoxButton
    Inherits Button

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)
        ControlPaint.DrawComboButton(pevent.Graphics, pevent.ClipRectangle, ButtonState.Flat)
    End Sub
End Class
