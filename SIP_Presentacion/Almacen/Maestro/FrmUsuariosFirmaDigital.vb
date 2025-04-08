Imports System.IO
Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmUsuariosFirmaDigital

    '   *****   LISTAS      *****
    Dim Requerimiento As New List(Of ETUsuario)
    Dim Req As ETUsuario

    Dim OrdenCompra As New List(Of ETUsuario)
    Dim Oc As ETUsuario

    Dim Firma As New List(Of ETUsuario)
    Dim Fir As ETUsuario

    Dim lstdet As New List(Of ETLstUsuarioFirmaDigital)
    Dim lob As ETLstUsuarioFirmaDigital

    Dim xlstdet As New List(Of ETLstUsersFirma)
    Dim xlob As ETLstUsersFirma

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Listar Users"
    Private Sub ListarUsers()
        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Sistema = gSistema
        End With
        CmbUsuario.DataSource = Negocio.Usuario.ListarUsers(Entidad.Usuario, "LTO")
        CmbUsuario.DisplayMember = "Login"
        CmbUsuario.ValueMember = "Login"
        CmbUsuario.SelectedIndex = -1
    End Sub
#End Region

#Region "Listar Area"
    Private Sub ListarArea()
        Dim dtAreas As New DataTable
        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Login = CmbUsuario.Value
        End With
        dtAreas = Negocio.Usuario.UsersFirma(Entidad.Usuario, "4")

        lstdet = New List(Of ETLstUsuarioFirmaDigital)

        If dtAreas.Rows.Count > 0 Then
            For i As Integer = 0 To dtAreas.Rows.Count - 1
                lob = New ETLstUsuarioFirmaDigital
                With lob
                    .Area = Trim(dtAreas.Rows(i).Item("Area") & "")
                    .AreaID = Trim(dtAreas.Rows(i).Item("AreaID") & "")
                    If Trim(dtAreas.Rows(i).Item("Aprobar") & "") = "True" Then
                        .Aprobar = True
                    Else
                        .Aprobar = False
                    End If

                    If Trim(dtAreas.Rows(i).Item("AprobarRequerimiento") & "") = "True" Then
                        .AprobarRequerimiento = True
                    Else
                        .AprobarRequerimiento = False
                    End If

                    .Item = Trim(dtAreas.Rows(i).Item("Item") & "")
                End With
                lstdet.Add(lob)
            Next
            ugAreas.DataSource = lstdet
            ugAreas.Refresh()
        End If
    End Sub
#End Region

#Region "Users Firma"
    Private Sub UsersFirma()
        Dim dttUsersFirma As New DataTable
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With
        dttUsersFirma = Negocio.Usuario.UsersFirma(Entidad.Usuario, "5")
        xlstdet = New List(Of ETLstUsersFirma)
        If dttUsersFirma.Rows.Count > 0 Then
            For i As Integer = 0 To dttUsersFirma.Rows.Count - 1
                xlob = New ETLstUsersFirma
                With xlob
                    .Login = Trim(dttUsersFirma.Rows(i).Item("Login") & "")
                    .Usuario = Trim(dttUsersFirma.Rows(i).Item("Usuario") & "")
                    If Trim(dttUsersFirma.Rows(i).Item("Firma") & "") = "True" Then
                        .Firma = True
                    Else
                        .Firma = False
                    End If

                    .Item = Trim(dttUsersFirma.Rows(i).Item("Item") & "")
                End With
                xlstdet.Add(xlob)
            Next
            ugFirmas.DataSource = xlstdet
            ugFirmas.Refresh()
        End If
    End Sub
#End Region

#Region "Mostrar Imagen"
    Private Sub MostrarImagen()
        Dim ds As DataSet
        Dim c As Integer
        If CmbUsuario.SelectedIndex = -1 Then
            Me.upbFirma.Image = ""
            Exit Sub
        End If
        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Name_User = CmbUsuario.Value
            .Sistema = gSistema
        End With
        ds = Negocio.Usuario.MostrarFirma(Entidad.Usuario)
        c = ds.Tables(0).Rows.Count
        If c > 0 Then
            Dim byteBLOBData(-1) As [Byte]
            byteBLOBData = CType(ds.Tables(0).Rows((c - 1))("Firma"), [Byte]())
            Dim stmBLOBData As New MemoryStream(byteBLOBData)
            Me.upbFirma.Image = Image.FromStream(stmBLOBData)
        Else
            Me.upbFirma.Image = ""
            ChkMarcarTodo.Visible = True
        End If
        Me.utxtRuta.Clear()
    End Sub
#End Region

#Region "Efectos"
    Private Sub Efectos()

        ugAreas.DisplayLayout.Bands(0).Columns.Add("Area")
        ugAreas.DisplayLayout.Bands(0).Columns("Area").CellAppearance.TextHAlign = HAlign.Center
        ugAreas.DisplayLayout.Bands(0).Columns("Area").CellAppearance.TextVAlign = HAlign.Center
        ugAreas.DisplayLayout.Bands(0).Columns("Area").CellActivation = Activation.ActivateOnly
        ugAreas.DisplayLayout.Bands(0).Columns("Area").CellAppearance.FontData.Bold = DefaultableBoolean.False
        ugAreas.DisplayLayout.Bands(0).Columns("Area").CellAppearance.FontData.SizeInPoints = 8
        ugAreas.DisplayLayout.Bands(0).Columns("Area").Width = 334
        ugAreas.DisplayLayout.Bands(0).Columns("Area").Header.Appearance.FontData.SizeInPoints = 8
        ugAreas.DisplayLayout.Bands(0).Columns("Area").Header.Appearance.FontData.Bold = DefaultableBoolean.False


        ugAreas.DisplayLayout.Bands(0).Columns.Add("AreaID")
        ugAreas.DisplayLayout.Bands(0).Columns("AreaID").Hidden = True

        ugAreas.DisplayLayout.Bands(0).Columns.Add("Item")
        ugAreas.DisplayLayout.Bands(0).Columns("Item").Hidden = True

        ugAreas.DisplayLayout.Bands(0).Columns.Add("Aprobar")
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").CellAppearance.TextHAlign = HAlign.Center
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").CellAppearance.TextVAlign = HAlign.Center
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").Style = UltraWinGrid.ColumnStyle.CheckBox
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").CellAppearance.FontData.Bold = DefaultableBoolean.False
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").CellAppearance.FontData.SizeInPoints = 8
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").Width = 147
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").Header.Caption = "Aprobar O/C"
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").Header.Appearance.FontData.SizeInPoints = 8
        ugAreas.DisplayLayout.Bands(0).Columns("Aprobar").Header.Appearance.FontData.Bold = DefaultableBoolean.False


        ugAreas.DisplayLayout.Bands(0).Columns.Add("AprobarRequerimiento")
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").CellAppearance.TextHAlign = HAlign.Center
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").CellAppearance.TextVAlign = HAlign.Center
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").Style = UltraWinGrid.ColumnStyle.CheckBox
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").CellAppearance.FontData.Bold = DefaultableBoolean.False
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").CellAppearance.FontData.SizeInPoints = 8
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").Width = 142
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").Header.Caption = "Aprobar Requerimiento"
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").Header.Appearance.FontData.SizeInPoints = 9
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").Header.Appearance.FontData.SizeInPoints = 8
        ugAreas.DisplayLayout.Bands(0).Columns("AprobarRequerimiento").Header.Appearance.FontData.Bold = DefaultableBoolean.False

    End Sub
#End Region

#Region "Efectos 1"
    Private Sub Efectos1()

        ugFirmas.DisplayLayout.Bands(0).Columns.Add("Usuario")
        ugFirmas.DisplayLayout.Bands(0).Columns("Usuario").CellAppearance.TextVAlign = HAlign.Center
        ugFirmas.DisplayLayout.Bands(0).Columns("Usuario").CellActivation = Activation.ActivateOnly
        ugFirmas.DisplayLayout.Bands(0).Columns("Usuario").CellAppearance.FontData.Bold = DefaultableBoolean.False
        ugFirmas.DisplayLayout.Bands(0).Columns("Usuario").CellAppearance.FontData.SizeInPoints = 8
        ugFirmas.DisplayLayout.Bands(0).Columns("Usuario").Width = 400
        ugFirmas.DisplayLayout.Bands(0).Columns("Usuario").Header.Appearance.FontData.SizeInPoints = 8
        ugFirmas.DisplayLayout.Bands(0).Columns("Usuario").Header.Appearance.FontData.Bold = DefaultableBoolean.False

        ugFirmas.DisplayLayout.Bands(0).Columns.Add("Login")
        ugFirmas.DisplayLayout.Bands(0).Columns("Login").Hidden = True
        ugFirmas.DisplayLayout.Bands(0).Columns("Login").Header.Appearance.FontData.SizeInPoints = 8
        ugFirmas.DisplayLayout.Bands(0).Columns("Login").Header.Appearance.FontData.Bold = DefaultableBoolean.False

        ugFirmas.DisplayLayout.Bands(0).Columns.Add("Item")
        ugFirmas.DisplayLayout.Bands(0).Columns("Item").Hidden = True
        ugFirmas.DisplayLayout.Bands(0).Columns("Item").Header.Appearance.FontData.SizeInPoints = 8
        ugFirmas.DisplayLayout.Bands(0).Columns("Item").Header.Appearance.FontData.Bold = DefaultableBoolean.False

        ugFirmas.DisplayLayout.Bands(0).Columns.Add("Firma")
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").CellAppearance.TextHAlign = HAlign.Center
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").CellAppearance.TextVAlign = HAlign.Center
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").Style = UltraWinGrid.ColumnStyle.CheckBox
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").CellAppearance.FontData.Bold = DefaultableBoolean.False
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").CellAppearance.FontData.SizeInPoints = 8
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").Width = 100
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").Header.Appearance.FontData.SizeInPoints = 8
        ugFirmas.DisplayLayout.Bands(0).Columns("Firma").Header.Appearance.FontData.Bold = DefaultableBoolean.False

    End Sub
#End Region

#Region "Validar"
    Public Function Validar() As Boolean
        If utxtRuta.Text = "" Then
            If upbFirma.Image = True Then
                Return False
            Else
                Return False
            End If
        End If
        Return True
    End Function
#End Region

#Region "Get MAC"
    Public Function GetMAC() As String
        Dim str As String
        Dim p As New Process
        'StartInfo representa el conjunto de parámetros que se van a utilizar para iniciar un proceso. 
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.FileName = "GetMac.exe"
        p.StartInfo.Arguments = "/fo list"
        p.Start()
        'StandardOutput Obtiene una secuencia que se utiliza  para leer la salida de la aplicación.
        str = p.StandardOutput.Read
        str = p.StandardOutput.Read
        str = p.StandardOutput.ReadLine
        str = p.StandardOutput.ReadLine
        str = p.StandardOutput.ReadLine
        p.WaitForExit()
        Return str.Substring(0, 17)
    End Function

#End Region

#End Region       '   Funciones Locales

#Region "Eventos Controles"

#Region "UchkUsuario - CheckedChanged"
    Private Sub uchkUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchkUsuario.CheckedChanged
        CmbUsuario.Enabled = uchkUsuario.Checked
        If uchkUsuario.CheckState = CheckState.Unchecked Then
            TxtUsuario.Text = "AUTOMATICO"
            TxtUsuario.Visible = True
            ugFirmas.Visible = True
            CmbUsuario.SelectedIndex = -1
            ugAreas.Visible = False
            ChkMarcarTodo.Visible = False
        Else

            ugFirmas.Visible = False
            TxtUsuario.Visible = False
            CmbUsuario.SelectedIndex = -1
            CmbUsuario.Focus()
            ugAreas.Visible = True
            ChkMarcarTodo.Visible = False
        End If
    End Sub
#End Region

#Region "CmbUsuario - ValueChanged"
    Private Sub CmbUsuario_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbUsuario.ValueChanged
        Call MostrarImagen()
        ugAreas.DataSource = Nothing
        Call Efectos()
        Call ListarArea()
    End Sub
#End Region

#Region "ChkMarcarTodo - CheckedChanged"
    Private Sub ChkMarcarTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcarTodo.CheckedChanged
        If ugAreas.Rows.Count > 0 Then
            If ChkMarcarTodo.Checked = True Then
                For j As Integer = 0 To ugAreas.Rows.Count - 1
                    ugAreas.Rows(j).Cells("Aprobar").Value = True
                    ugAreas.Rows(j).Cells("AprobarRequerimiento").Value = True
                Next
            Else
                For j As Integer = 0 To ugAreas.Rows.Count - 1
                    ugAreas.Rows(j).Cells("Aprobar").Value = False
                    ugAreas.Rows(j).Cells("AprobarRequerimiento").Value = False
                Next
            End If
        End If
    End Sub
#End Region

    '#Region "BtnBorrar - Click"
    '    Private Sub BtnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrar.Click
    '        If CmbUsuario.SelectedIndex = -1 Then
    '            MsgBox("Debe seleccionar un USUARIO para continuar.", MsgBoxStyle.Critical, "Comacsa")
    '            CmbUsuario.Focus()
    '            Return
    '        End If

    '        If MsgBox("¿Esta Seguro de Borrar la Imagen ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
    '            With objBE
    '                .Cod_Cia = Companhia
    '                .Cod_Usuario = CmbUsuario.Value
    '            End With

    '            Try
    '                ResultadoBE = objBL.BorrarImagen(objBE)
    '            Catch ex As Exception
    '                MsgBox(ex.Message.ToString.Trim)
    '            End Try

    '            If ResultadoBE.Realizo = True Then
    '                MsgBox("La imagen se borro con éxito.", MsgBoxStyle.Information, "Comacsa")
    '                CmbUsuario.SelectedIndex = -1
    '            End If
    '        End If

    '    End Sub
    '#End Region

#End Region       '   Eventos Controles

#Region "Funciones Globales"

#Region "Buscar"
    Public Sub Buscar()
        ofdFirma.ShowDialog()
        Me.utxtRuta.Text = Me.ofdFirma.FileName
        Try
            Me.upbFirma.Image = Image.FromFile(Me.utxtRuta.Text.Trim)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If CmbUsuario.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un usuario.", MsgBoxStyle.Critical, "Comacsa")
            CmbUsuario.Focus()
            Exit Sub
        End If
        If MsgBox("¿Esta seguro de ELIMINAR las áreas para el usuario " + CmbUsuario.Text + " ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            With Entidad.Usuario
                .Name_User = CmbUsuario.Text
                .Cod_Cia = Companhia
            End With

            Entidad.Resultado = Negocio.Usuario.EliminarAreaAprobacionRequerimiento(Entidad.Usuario)

            If Entidad.Resultado.Realizo = True Then
                MsgBox("Se eliminarón los datos correctamente.", MsgBoxStyle.Information, "Comacsa")
                Call Nuevo()
                Call UsersFirma()

            End If


        End If

    End Sub
#End Region

#Region "Grabar"
    Public Sub Grabar()
        If ugFirmas.Visible = False Then

            If CmbUsuario.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un usuario.", MsgBoxStyle.Critical, "Comacsa")
                CmbUsuario.Focus()
                Exit Sub
            End If

            If MsgBox("¿Esta seguro de GRABAR las áreas para el usuario " + CmbUsuario.Value + " ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then

                utxtRuta.Focus()
                Dim nro As Integer
                Dim MyData(nro) As Byte

                If utxtRuta.Text <> "" Then
                    Dim fs As New FileStream(Me.utxtRuta.Text.Trim, FileMode.OpenOrCreate, FileAccess.Read)
                    nro = fs.Length
                    fs.Read(MyData, 0, fs.Length)
                    fs.Close()
                End If

                With Entidad.Usuario
                    .Cod_Cia = Companhia
                    .Login = CmbUsuario.Value
                    If utxtRuta.Text <> "" Then
                        .Firma = MyData
                    End If
                    .Sistema = gSistema
                    .Name_User = CmbUsuario.Text
                End With


                If ugAreas.Rows.Count > 0 Then
                    For i As Integer = 0 To ugAreas.Rows.Count - 1
                        If ugAreas.Rows(i).Cells("Aprobar").Value = True Then
                            Oc = New ETUsuario
                            With Oc
                                .Cod_Cia = Companhia
                                .Login = CmbUsuario.Value
                                .Area = ugAreas.Rows(i).Cells("AreaID").Value.ToString.Trim
                                .User_Crea = User_Sistema
                            End With
                            OrdenCompra.Add(Oc)
                        End If
                    Next
                End If


                If ugAreas.Rows.Count > 0 Then
                    For i As Integer = 0 To ugAreas.Rows.Count - 1
                        If ugAreas.Rows(i).Cells("AprobarRequerimiento").Value = True Then
                            Req = New ETUsuario
                            With Req
                                .Cod_Cia = Companhia
                                .Name_User = CmbUsuario.Value
                                .Area = ugAreas.Rows(i).Cells("AreaID").Value.ToString.Trim
                                .User_Crea = User_Sistema
                            End With
                            Requerimiento.Add(Req)
                        End If
                    Next
                End If


                If utxtRuta.Text.Trim = "" Then
                    Entidad.Resultado = Negocio.Usuario.AreaAprobacionRequerimiento(Entidad.Usuario, Requerimiento, OrdenCompra, "")
                Else
                    Entidad.Resultado = Negocio.Usuario.AreaAprobacionRequerimiento(Entidad.Usuario, Requerimiento, OrdenCompra, "S")
                End If



                If Entidad.Resultado.Realizo = True Then
                    Call Nuevo()
                    Call UsersFirma()
                    MsgBox("Se grabarón los datos correctamente.", MsgBoxStyle.Information, "Comacsa")
                End If

                Requerimiento = New List(Of ETUsuario)
                OrdenCompra = New List(Of ETUsuario)
                Firma = New List(Of ETUsuario)


            End If
        Else

            If ugFirmas.Rows.Count > 0 Then
                If MsgBox("¿Esta seguro de GRABAR las firmas digitales?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                    TxtUsuario.Focus()
                    For i As Integer = 0 To ugFirmas.Rows.Count - 1
                        Fir = New ETUsuario
                        With Fir
                            .Cod_Cia = Companhia
                            .Name_User = ugFirmas.Rows(i).Cells("Usuario").Value
                            If ugFirmas.Rows(i).Cells("Firma").Value = True Then
                                .Opcion = "6"
                            Else
                                .Opcion = "7"
                            End If
                        End With
                        Firma.Add(Fir)
                    Next

                    Entidad.Resultado = Negocio.Usuario.FirmasDigitales(Firma)


                    If Entidad.Resultado.Realizo = True Then
                        MsgBox("Se grabarón los datos correctamente.", MsgBoxStyle.Information, "Comacsa")
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        lstdet = New List(Of ETLstUsuarioFirmaDigital)
        xlstdet = New List(Of ETLstUsersFirma)
        CmbUsuario.SelectedIndex = -1
    End Sub
#End Region

#End Region      '   Funciones Globales

#Region "Load"
    Private Sub FrmUsuariosFirmaDigital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarUsers()
        ugFirmas.DataSource = Nothing
        Call Efectos1()
        Call UsersFirma()
    End Sub
#End Region                    '   Load

    '#Region "Recuperar IP"
    '    Private Structure IP
    '        Public dwAddr As Long ' Dirección Ip   
    '        Public dwIndex As Long
    '        Public dwMask As Long
    '        Public dwBCastAddr As Long
    '        Public dwReasmSize As Long
    '        Public unused1 As Integer
    '        Public unused2 As Integer
    '    End Structure

    '    Private Structure MIB_IPADDRTABLE
    '        Public dEntrys As Long 'Numero de entradas de la tabla   
    '        '  Public mIPInfo(5) As IPINFO 'Array de entradas de direcciones Ip   
    '    End Structure

    '    Private Structure IP_Array
    '        Public mBuffer As MIB_IPADDRTABLE
    '        Public BufferLen As Long
    '    End Structure

    '    'Función Api CopyMemory   
    '    Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByVal Destination As Object, ByVal Source As Object, ByVal Length As Long)

    '    'Función Api GetIpAddrTable para obtener la tabla de direcciones IP   
    '    Private Declare Function GetIpAddrTable Lib "IPHlpApi" (ByVal pIPAdrTable As Byte, ByVal pdwSize As Long, ByVal Sort As Long) As Long

    '    'Función para Convertir el valor de tipo Long a un string   
    '    Private Function ConvertirDirecciónAstring(ByVal longAddr As Long) As String
    '        Dim myByte(3) As Byte 'array de tipo Byte   
    '        Dim Cnt As Long

    '        CopyMemory(myByte(0), longAddr, 4)
    '        For Cnt = 0 To 3
    '            ConvertirDirecciónAstring = ConvertirDirecciónAstring + CStr(myByte(Cnt)) + "."
    '        Next Cnt
    '        ConvertirDirecciónAstring = Left$(ConvertirDirecciónAstring, Len(ConvertirDirecciónAstring) - 1)
    '    End Function

    '    'Función que retorna un string con la dirección Ip final   
    '    Private Function RecuperarIP() As String

    '        Dim Ret As Long, Tel As Long
    '        Dim bBytes() As Byte
    '        Dim TempList() As String
    '        Dim TempIP As String
    '        Dim Tempi As Long
    '        Dim Listing As MIB_IPADDRTABLE
    '        Dim L3 As String

    '        On Error GoTo errSub

    '    GetIpAddrTable ByVal 0&, Ret, True  

    '        If Ret <= 0 Then Exit Function
    '    ReDim bBytes(0 To Ret - 1) As Byte  
    '    ReDim TempList(0 To Ret - 1) As String  

    '        'recuperamos la tabla con las ip   
    '        GetIpAddrTable(bBytes(0), Ret, False)
    '        CopyMemory(Listing.dEntrys, bBytes(0), 4)

    '        For Tel = 0 To Listing.dEntrys - 1
    '            'Copiamos la estructura entera a la lista   
    '            CopyMemory(Listing.mIPInfo(Tel), bBytes(4 + (Tel * Len(Listing.mIPInfo(0)))), Len(Listing.mIPInfo(Tel)))
    '            TempList(Tel) = ConvertirDirecciónAstring(Listing.mIPInfo(Tel).dwAddr)
    '        Next Tel

    '        TempIP = TempList(0)
    '        For Tempi = 0 To Listing.dEntrys - 1
    '            L3 = Left(TempList(Tempi), 3)
    '            If L3 <> "169" And L3 <> "127" And L3 <> "192" Then
    '                TempIP = TempList(Tempi)
    '            End If
    '        Next Tempi

    '        RecuperarIP = TempIP

    '        Exit Function
    'errSub:

    '        RecuperarIP = ""

    '    End Function

    '    Private Sub Form_Load()
    '        MsgBox(RecuperarIP, vbInformation)
    '    End Sub

    '#End Region

End Class