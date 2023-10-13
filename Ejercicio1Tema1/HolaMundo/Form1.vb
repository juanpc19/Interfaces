Imports Biblioteca

Public Class Form1
    Private vacio As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSaludar.Click
        Dim Persona As New Persona()
        Persona.Nombre = txtNombre.Text

        If String.IsNullOrEmpty(Persona.Nombre) Then
            vacio = True
        Else
            vacio = False
            MessageBox.Show("Hola " & Persona.Nombre)
        End If

        ActualizarLabel2()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        ActualizarLabel2()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ActualizarLabel2()
        If vacio Then
            Label2.ForeColor = Color.Red
            Label2.Text = "ERROR: El nombre no puede estar vacío"
        Else
            Label2.Text = ""
        End If
    End Sub
End Class
