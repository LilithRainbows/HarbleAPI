Imports Sulakore.Modules
Imports Tangine

<[Module]("HarbleAPI", "Messages cache generator."), Author("Lilith")>
Partial Public Class Extension
    Inherits ExtensionForm

    Friend WithEvents Label1 As Label
    Public MainFormParent As MainForm

    Private Sub Extension_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainFormParent = New MainForm()
        MainFormParent.ExtensionChild = Me
        MainFormParent.Show()
    End Sub

    Sub New()
        Me.Size = New Point(0)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.ShowInTaskbar = False
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(282, 253)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "INVISIBLE FORM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Extension
        '
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Extension"
        Me.ResumeLayout(False)

    End Sub
End Class