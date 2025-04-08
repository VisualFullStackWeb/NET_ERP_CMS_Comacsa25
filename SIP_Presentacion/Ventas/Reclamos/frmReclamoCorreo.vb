Imports SIP_Entidad
Imports System.ComponentModel

Public Class frmReclamoCorreo

    Private _PermitirAgregar As Boolean
    Public Property PermitirAgregar() As Boolean
        Get
            Return _PermitirAgregar
        End Get
        Set(ByVal value As Boolean)
            _PermitirAgregar = value
        End Set
    End Property

    Private _ListaCorreos As BindingList(Of ETReclamoPersona)
    Public Property ListaCorreos() As BindingList(Of ETReclamoPersona)
        Get
            Return _ListaCorreos
        End Get
        Set(ByVal value As BindingList(Of ETReclamoPersona))
            _ListaCorreos = value
        End Set
    End Property




    'Public Sub New()
    '    ' Esta llamada es requerida por el diseñador.
    '    InitializeComponent()
    '    ' Inicializar la lista de correos
    '    _RegistraListaCorreosAdd = New BindingList(Of ETReclamoPersona)()
    '    ' Enlazar la lista de correos al control
    '    ugCorreos.DataSource = _RegistraListaCorreosAdd
    '    'btnGuardar.Visible = PermitirAgregar

    'End Sub

    'Public Property RegistraListaCorreosAdd() As BindingList(Of ETReclamoPersona)
    '    Get
    '        Return _RegistraListaCorreosAdd
    '    End Get
    '    Set(ByVal value As BindingList(Of ETReclamoPersona))
    '        _RegistraListaCorreosAdd = value
    '        ugCorreos.DataSource = _RegistraListaCorreos
    '        ugCorreos.DataBind()
    '    End Set
    'End Property

    'Public Sub RegistraListaCorreos(ByVal CorreoPersona As ETReclamoPersona)
    '    'RegistraListaCorreosAdd(persona)
    '    ugCorreos.DataSource = Nothing
    '    ugCorreos.DataSource = ListaCorreos
    '    ugCorreos.DataBind() ' Actualiza el control
    'End Sub

    Private Sub frmReclamoCorreo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ugCorreos.DataSource = ListaCorreos
        ugCorreos.DataBind()
        btnGuardar.Visible = PermitirAgregar
        ugCorreos.RowUpdateCancelAction = Infragistics.Win.UltraWinGrid.RowUpdateCancelAction.RetainDataAndActivation
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ugCorreos_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugCorreos.ClickCellButton
        If e.Cell.Column.Key = "ELIMINAR" Then
            If MsgBox("¿Desea eliminar la fila seleccionada?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                ugCorreos.ActiveRow.Delete(False)
                'ugCorreos.DeleteSelectedRows()
                'ugCorreos.UpdateData()
            End If
        End If
    End Sub

    Private Sub ugCorreos_BeforeRowInsert(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowInsertEventArgs) Handles ugCorreos.BeforeRowInsert

    End Sub

    Private Sub ugCorreos_BeforeCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles ugCorreos.BeforeCellUpdate
        'If e.Cell.Column.Key = "Correo" AndAlso e.NewValue = "" Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub ugCorreos_BeforeRowUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableRowEventArgs) Handles ugCorreos.BeforeRowUpdate
        'If e.Row.IsAddRow Then

        'End If

        If Not esEmailValido(e.Row.Cells("Correo").Text) Then
            MessageBox.Show("El correo ingresado no tiene un formato válido", msgComacsa)
            e.Cancel = True
        End If


    End Sub

    Function esEmailValido(ByVal cadena As String) As Boolean

        Try
            Dim m As New System.Net.Mail.MailAddress(cadena)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub ugCorreos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugCorreos.InitializeLayout

    End Sub
End Class