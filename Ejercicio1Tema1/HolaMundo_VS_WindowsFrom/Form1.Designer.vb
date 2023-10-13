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
        boton1 = New Button()
        cajatexto = New TextBox()
        SuspendLayout()
        ' 
        ' boton1
        ' 
        boton1.Location = New Point(221, 168)
        boton1.Name = "boton1"
        boton1.Size = New Size(96, 76)
        boton1.TabIndex = 0
        boton1.Text = "Button1"
        boton1.UseVisualStyleBackColor = True
        ' 
        ' cajatexto
        ' 
        cajatexto.Location = New Point(323, 196)
        cajatexto.Name = "cajatexto"
        cajatexto.Size = New Size(357, 23)
        cajatexto.TabIndex = 1
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(cajatexto)
        Controls.Add(boton1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents boton1 As Button
    Friend WithEvents cajatexto As TextBox
End Class
