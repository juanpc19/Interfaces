<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtNombre = New TextBox()
        btnSaludar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' txtNombre
        ' 
        txtNombre.AccessibleName = "txtNombre"
        txtNombre.Location = New Point(308, 167)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(141, 23)
        txtNombre.TabIndex = 0
        ' 
        ' btnSaludar
        ' 
        btnSaludar.AccessibleName = "btnSaludar"
        btnSaludar.Location = New Point(336, 217)
        btnSaludar.Name = "btnSaludar"
        btnSaludar.Size = New Size(75, 23)
        btnSaludar.TabIndex = 1
        btnSaludar.Text = "Saludo"
        btnSaludar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(248, 171)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 15)
        Label1.TabIndex = 2
        Label1.Text = "Nombre: "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(336, 125)
        Label2.Name = "Label2"
        Label2.Size = New Size(0, 15)
        Label2.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnSaludar)
        Controls.Add(txtNombre)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtNombre As TextBox
    Friend WithEvents btnSaludar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
