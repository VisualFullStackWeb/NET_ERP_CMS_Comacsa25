Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Object
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.TreeView
Imports System.Windows.Forms.ListBox.ObjectCollection
Imports System.Windows.Forms.CheckedListBox.ObjectCollection

Public Class FrmMaestroEmpleoLabor

    '   *****   LISTAS  *****
    Dim Activo As New List(Of ETEmpleoLabor)
    Dim act As ETEmpleoLabor

    Dim Linea As New List(Of ETEmpleoLabor)
    Dim lin As ETEmpleoLabor

    Dim SubLinea As New List(Of ETEmpleoLabor)
    Dim sLi As ETEmpleoLabor

    Dim Cantera As New List(Of ETEmpleoLabor)
    Dim can As ETEmpleoLabor


    '   ***** VARIABLES PUBLICAS *****
    Dim xLinea As String
    Dim xActivo As String
    Public L As Boolean = False
    Dim dtActivo As New DataTable
    Dim dtSuministros As New DataTable
    Dim dtCantera As New DataTable
    Dim dtLinea As New DataTable
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

#Region "Listar Tv-Linea"
    Private Sub CargarTvLinea()
        Dim Linea As New DataTable
        Dim Codigo_Linea, Nodo_Linea, Datos_Linea As String
        Dim i As Integer

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        With Entidad.Producto
            .Cod_Cia = Companhia
        End With
        Linea = Negocio.Producto.Listar_Linea_SubLinea(Entidad.Producto, "L2")

        TvLinea.Nodes.Clear()
        For i = 0 To Linea.Rows.Count - 1
            Codigo_Linea = Linea.Rows(i).Item("Codigo")
            Nodo_Linea = Linea.Rows(i).Item("Descripcion")
            Datos_Linea = Codigo_Linea + " - " + Nodo_Linea
            TvLinea.Nodes.Add(Datos_Linea)
        Next
    End Sub
#End Region

#Region "Listar Tv-Activo"
    Private Sub CargarTvActivo()
        Dim Activo As New DataTable
        Dim Codigo_Activo, Nodo_Activo, Datos_Activo As String
        Dim i As Integer

        Activo = Negocio.Maestros2.ListarActivo("C" & Companhia)

        For i = 0 To Activo.Rows.Count - 1
            Codigo_Activo = Activo.Rows(i).Item("Codigo")
            Nodo_Activo = Activo.Rows(i).Item("Descripcion")
            Datos_Activo = Codigo_Activo + " - " + Nodo_Activo
            TvActivo.Nodes.Add(Datos_Activo)
        Next
    End Sub
#End Region

#Region "Listar Solo Linea"
    Private Sub SoloLinea()
        Dim i As Integer
        LvLinea.Clear()
        With Entidad.Producto
            .Cod_Cia = Companhia
            .Empleo = Trim(TxtCodigoEmpleo.Text & "")
        End With
        dtLinea = Negocio.Producto.Listar_Linea_SubLinea(Entidad.Producto, "L1")

        LvLinea.Clear()
        LvLinea.CheckBoxes = True
        Dim item1 As ListViewItem
        For i = 0 To dtLinea.Rows.Count - 1
            item1 = New ListViewItem(dtLinea.Rows(i).Item("DESCRIPCION").ToString, dtLinea.Rows(i).Item("CODIGO").ToString)
            item1.Checked = CType(dtLinea.Rows(i).Item("IsExist").ToString, Boolean)
            LvLinea.Items.AddRange(New ListViewItem() {item1})
        Next
    End Sub
#End Region

#Region "Listar Sub-Linea"
    Private Sub SubLineaSuministros()
        Dim i As Integer
        LvSuministros.Clear()
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodLinea = TvLinea.SelectedNode.Text
            .CodLinea = .CodLinea.Substring(0, 3)
            xLinea = .CodLinea
            .Empleo = Trim(TxtCodigoEmpleo.Text & "")
        End With
        dtSuministros = Negocio.Producto.ListarSubLinea(Entidad.Producto, "LMO")

        LvSuministros.Clear()
        LvSuministros.CheckBoxes = True
        Dim item1 As ListViewItem
        For i = 0 To dtSuministros.Rows.Count - 1
            item1 = New ListViewItem(dtSuministros.Rows(i).Item("DESCRIPCION").ToString, dtSuministros.Rows(i).Item("CODIGO").ToString)
            item1.Checked = CType(dtSuministros.Rows(i).Item("IsExist").ToString, Boolean)
            LvSuministros.Items.AddRange(New ListViewItem() {item1})
        Next
    End Sub
#End Region

#Region "Listar Descripcion Activo"
    Private Sub DescripcionActivo()
        Negocio.Maestros2 = New NGMaestros2

        Dim i As Integer
        xActivo = TvActivo.SelectedNode.Text
        xActivo = xActivo.Substring(0, 2)
        dtActivo = Negocio.Maestros2.ListarDescripcionActivo(Companhia, xActivo, Trim(TxtCodigoEmpleo.Text & ""), "LMO")
        LvActivo.Clear()

        LvActivo.CheckBoxes = True
        Dim item1 As ListViewItem
        For i = 0 To dtActivo.Rows.Count - 1
            item1 = New ListViewItem(dtActivo.Rows(i).Item("Descripcion").ToString, dtActivo.Rows(i).Item("Codigo").ToString)
            item1.Checked = CType(dtActivo.Rows(i).Item("IsExist").ToString, Boolean)
            LvActivo.Items.AddRange(New ListViewItem() {item1})

        Next
    End Sub

#End Region

#Region "Listar Canteras"
    Private Sub CargarCanteras()
        Dim i As Integer
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Empleo = Trim(TxtCodigoEmpleoLabor.Text & "")
        End With
        dtCantera = Negocio.EmpleoLabor.Cantera(Entidad.EmpleoLabor, "LMO")

        LvCantera.Clear()
        LvCantera.CheckBoxes = True
        Dim item1 As ListViewItem
        For i = 0 To dtCantera.Rows.Count - 1
            item1 = New ListViewItem(dtCantera.Rows(i).Item("Descripcion").ToString, dtCantera.Rows(i).Item("Codigo").ToString)
            item1.Checked = CType(dtCantera.Rows(i).Item("IsExist").ToString, Boolean)
            LvCantera.Items.AddRange(New ListViewItem() {item1})
        Next
    End Sub
#End Region

#Region "Listar Empleo Labor"
    Private Sub ListarEmpleoLabor()
        DgvListarEmpleoLabor.DataSource = Negocio.EmpleoLabor.ListarEmpleoLabor(Entidad.EmpleoLabor, "LT1")
    End Sub
#End Region

#Region "Limpiar"
    Public Sub NuevoFin()
        Call CargarTvActivo()
        Call CargarTvLinea()
        Call CargarCanteras()
        TxtCodigoEmpleoLabor.Clear()
        TxtCodigoEmpleo.Clear()
        TxtNombreEmpleoLabor.Clear()
        TxtDescripcionEmpleo.Clear()
        CboArea.Value = 0
        TxtNombreEmpleoLabor.Enabled = True
        CboArea.Enabled = True
        LvActivo.Clear()
        LvSuministros.Clear()
        LvLinea.Clear()
        TabMaestroEmpleoLabor.Tabs("Listar").Selected = True
        Call ListarEmpleoLabor()
    End Sub
#End Region

#End Region   'Funciones Locales

#Region "Eventos Controles"

#Region "CheckBox"
    Private Sub ChkSubLinea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkSubLinea.Click
        If dtSuministros.Rows.Count > 0 Then
            If ChkSubLinea.Checked = True Then
                LvSuministros.Clear()
                LvSuministros.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtSuministros.Rows.Count - 1
                    item1 = New ListViewItem(dtSuministros.Rows(i).Item("DESCRIPCION").ToString, dtSuministros.Rows(i).Item("CODIGO").ToString)
                    item1.Checked = True
                    LvSuministros.Items.AddRange(New ListViewItem() {item1})
                Next
            Else
                LvSuministros.Clear()
                LvSuministros.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtSuministros.Rows.Count - 1
                    item1 = New ListViewItem(dtSuministros.Rows(i).Item("DESCRIPCION").ToString, dtSuministros.Rows(i).Item("CODIGO").ToString)
                    item1.Checked = False
                    LvSuministros.Items.AddRange(New ListViewItem() {item1})

                Next
            End If

        Else
            MsgBox("NO hay elementos de elección", MsgBoxStyle.Information, "Comacsa")
            ChkSubLinea.Checked = False
        End If

    End Sub

    Private Sub ChkActivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkActivo.Click
        If dtActivo.Rows.Count > 0 Then
            If ChkActivo.Checked = True Then
                LvActivo.Clear()
                LvActivo.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtActivo.Rows.Count - 1
                    item1 = New ListViewItem(dtActivo.Rows(i).Item("Descripcion").ToString, dtActivo.Rows(i).Item("Codigo").ToString)
                    item1.Checked = True
                    LvActivo.Items.AddRange(New ListViewItem() {item1})
                Next
            Else
                LvActivo.Clear()
                LvActivo.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtActivo.Rows.Count - 1
                    item1 = New ListViewItem(dtActivo.Rows(i).Item("Descripcion").ToString, dtActivo.Rows(i).Item("Codigo").ToString)
                    item1.Checked = False
                    LvActivo.Items.AddRange(New ListViewItem() {item1})

                Next
            End If

        Else
            MsgBox("NO hay elementos de elección", MsgBoxStyle.Information, "Comacsa")
            ChkActivo.Checked = False
        End If
    End Sub

    Private Sub ChkCantera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkCantera.CheckedChanged
        If dtCantera.Rows.Count > 0 Then
            If ChkCantera.Checked = True Then
                LvCantera.Clear()
                LvCantera.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtCantera.Rows.Count - 1
                    item1 = New ListViewItem(dtCantera.Rows(i).Item("Descripcion").ToString, dtCantera.Rows(i).Item("Codigo").ToString)
                    item1.Checked = True
                    LvCantera.Items.AddRange(New ListViewItem() {item1})
                Next
            Else
                LvCantera.Clear()
                LvCantera.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtCantera.Rows.Count - 1
                    item1 = New ListViewItem(dtCantera.Rows(i).Item("Descripcion").ToString, dtCantera.Rows(i).Item("Codigo").ToString)
                    item1.Checked = False
                    LvCantera.Items.AddRange(New ListViewItem() {item1})
                Next
            End If
        Else
            MsgBox("NO hay elementos de elección", MsgBoxStyle.Information, "Comacsa")
            ChkCantera.Checked = False
        End If
    End Sub

    Private Sub ChkSoloLinea_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSoloLinea.CheckedChanged
        If dtLinea.Rows.Count > 0 Then
            If ChkSoloLinea.Checked = True Then
                LvLinea.Clear()
                LvLinea.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtLinea.Rows.Count - 1
                    item1 = New ListViewItem(dtLinea.Rows(i).Item("Descripcion").ToString, dtLinea.Rows(i).Item("Codigo").ToString)
                    item1.Checked = True
                    LvLinea.Items.AddRange(New ListViewItem() {item1})
                Next
            Else
                LvLinea.Clear()
                LvLinea.CheckBoxes = True
                Dim item1 As ListViewItem
                For i = 0 To dtLinea.Rows.Count - 1
                    item1 = New ListViewItem(dtLinea.Rows(i).Item("Descripcion").ToString, dtLinea.Rows(i).Item("Codigo").ToString)
                    item1.Checked = False
                    LvLinea.Items.AddRange(New ListViewItem() {item1})
                Next
            End If
        Else
            MsgBox("NO hay elementos de elección", MsgBoxStyle.Critical, "Comacsa")
            ChkCantera.Checked = False
        End If
    End Sub

#End Region

#Region "TvLinea - AfterSelect"
    Private Sub TvLinea_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TvLinea.AfterSelect
        ChkSubLinea.Checked = False
        Call SubLineaSuministros()
    End Sub
#End Region

#Region "TvActivo - AfterSelect"
    Private Sub TvActivo_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TvActivo.AfterSelect
        ChkActivo.Checked = False
        Call DescripcionActivo()
    End Sub
#End Region

#Region "DgvListarEmpleoLabor - Click"
    Private Sub DgvListarEmpleoLabor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgvListarEmpleoLabor.Click
        If DgvListarEmpleoLabor.Rows.Count > 0 Then
            TxtCodigoEmpleo.Text = DgvListarEmpleoLabor.ActiveRow.Cells("Codigo_Empleo").Value.ToString
            TxtDescripcionEmpleo.Text = DgvListarEmpleoLabor.ActiveRow.Cells("Empleo").Value.ToString
        End If
    End Sub
#End Region

#Region "DgvListarEmpleoLabor - DoubleClickRow"
    Private Sub DgvListarEmpleoLabor_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvListarEmpleoLabor.DoubleClickRow
        TxtCodigoEmpleoLabor.Text = e.Row.Cells("Codigo_Empleo").Value
        TxtNombreEmpleoLabor.Text = e.Row.Cells("Empleo").Value
        CboArea.Text = e.Row.Cells("Area").Value
        TabMaestroEmpleoLabor.Tabs("Empleo").Selected = True
        TabMaestroEmpleoLabor.Tabs("Empleo").Enabled = True
        Call CargarCanteras()
        Call SoloLinea()
    End Sub

#End Region

#End Region   'Eventos Controles

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        Dim i As Integer

        If TxtNombreEmpleoLabor.Text <> "" Then
            If MsgBox("¿Esta Seguro de Grabar el Empleo / Labor ?", MsgBoxStyle.YesNo, "Empleo / Labor") = MsgBoxResult.Yes Then
                Try

                    '   *****   AGREGANDO EL NUEVO EMPLEO LABOR   *****
                    With Entidad.EmpleoLabor
                        .Cod_Cia = Companhia
                        .Cod_Area = CboArea.Value
                        .Descripcion = TxtNombreEmpleoLabor.Text
                        .User = User_Sistema
                        .Cod_Tipo_Activo = xActivo
                        .Cod_Linea = xLinea
                    End With

                    '   *****   AGREGANDO LOS ACTIVOS PARA EL EMPLEO LABOR    *****
                    For i = 0 To LvActivo.Items.Count - 1
                        If LvActivo.Items.Item(i).Checked = True Then
                            act = New ETEmpleoLabor
                            With act
                                .Cod_Cia = Companhia
                                .Cod_Area = CboArea.Value
                                .Cod_Tipo_Activo = xActivo
                                .User = User_Sistema
                                .Cod_Activo = LvActivo.Items.Item(i).ImageKey
                            End With
                            Activo.Add(act)

                            If i = LvActivo.Items.Count Then
                                Exit For
                            End If
                        End If
                    Next

                    '   *****   AGREGANDO SOLO LINEA PARA EL EMPLEO LABOR   *****
                    For i = 0 To LvLinea.Items.Count - 1
                        If LvLinea.Items.Item(i).Checked = True Then

                            lin = New ETEmpleoLabor
                            With lin
                                .Cod_Cia = Companhia
                                .Cod_Area = CboArea.Value
                                .User = User_Sistema
                                .Cod_Linea = LvLinea.Items.Item(i).ImageKey
                            End With
                            Linea.Add(lin)

                            If i = LvLinea.Items.Count Then
                                Exit For
                            End If

                        End If
                    Next

                    '   *****   AGREGANDO LAS LINEAS / SUBLINEAS PARA EL EMPLEO LABOR   *****
                    For i = 0 To LvSuministros.Items.Count - 1
                        If LvSuministros.Items.Item(i).Checked = True Then
                            sLi = New ETEmpleoLabor
                            With sLi
                                .Cod_Cia = Companhia
                                .Cod_Area = CboArea.Value
                                .Cod_Linea = xLinea
                                .User = User_Sistema
                                .Cod_SubLinea = LvSuministros.Items.Item(i).ImageKey
                            End With
                            SubLinea.Add(sLi)

                            If i = LvSuministros.Items.Count Then
                                Exit For
                            End If

                        End If
                    Next

                    '   *****   AGREGANDO LAS CANTERAS PARA EL EMPLEO LABOR   *****

                    For i = 0 To LvCantera.Items.Count - 1
                        If LvCantera.Items.Item(i).Checked = True Then
                            can = New ETEmpleoLabor
                            With can
                                .Cod_Cia = Companhia
                                .Cod_Area = CboArea.Value
                                .User = User_Sistema
                                .Cod_Cantera = LvCantera.Items.Item(i).ImageKey
                            End With
                            Cantera.Add(can)
                        End If
                    Next


                    If TxtCodigoEmpleoLabor.Text = "" Then
                        Entidad.Resultado = Negocio.EmpleoLabor.AgregarEmpleoLabor(Entidad.EmpleoLabor, Activo, Linea, SubLinea, Cantera, "AGR")
                    Else
                        Entidad.Resultado = Negocio.EmpleoLabor.AgregarEmpleoLabor(Entidad.EmpleoLabor, Activo, Linea, SubLinea, Cantera, "MOD")
                    End If


                    If Entidad.Resultado.Realizo = True Then
                        MsgBox("Se guardaron correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
                        TxtCodigoEmpleoLabor.Text = Entidad.Resultado.Mensaje
                        Call ListarEmpleoLabor()
                    End If


                Catch ex As Exception
                    Throw
                End Try

            End If
        Else
            MsgBox("Debe escrbir una DESCRIPCIÓN para el Empleo / Labor", MsgBoxStyle.Information, "Empleo / Labor")
            TxtNombreEmpleoLabor.Focus()
        End If

    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()

        If TxtCodigoEmpleo.Text <> "" Then
            If MsgBox("¿Esta Seguro de ELIMINAR el Empleo / Labor ?", MsgBoxStyle.YesNo, "Empleo / Labor") = MsgBoxResult.Yes Then
                Try
                    With Entidad.EmpleoLabor
                        .Cod_Cia = Companhia
                        .Cod_Empleo = TxtCodigoEmpleo.Text
                        .User = User_Sistema
                    End With
                    Entidad.Resultado = Negocio.EmpleoLabor.EliminarEmpleoLabor(Entidad.EmpleoLabor)

                    If Entidad.Resultado.Realizo = True Then
                        MsgBox("Se realizo la ELIMINACIÓN del Empleo / Labor : " & TxtCodigoEmpleo.Text, MsgBoxStyle.Information, "Empleo / Labor")
                        TabMaestroEmpleoLabor.Tabs("Listar").Selected = True
                        Call ListarEmpleoLabor()
                    End If


                Catch ex As Exception
                    Throw New ApplicationException("Exception Occured")
                End Try

            End If
        Else
            MsgBox("Debe seleccionar un Empleo / Labor que desea Eliminar", MsgBoxStyle.Information, "Empleo / Labor")
        End If

    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        Call CargarTvActivo()
        Call CargarTvLinea()
        Call CargarCanteras()
        TxtCodigoEmpleoLabor.Clear()
        TxtCodigoEmpleo.Clear()
        TxtNombreEmpleoLabor.Clear()
        TxtDescripcionEmpleo.Clear()
        CboArea.Value = 0

        TxtNombreEmpleoLabor.Enabled = True
        CboArea.Enabled = True
        TabMaestroEmpleoLabor.Tabs("Empleo").Selected = True
        TabMaestroEmpleoLabor.Tabs("Empleo").Enabled = True
        Call SoloLinea()
    End Sub
#End Region

#End Region  'Funciones Públicas

#Region "Load"
    Private Sub FrmMaestroEmpleoLabor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarArea_General(CboArea)
        Call CargarTvLinea()
        Call CargarTvActivo()
        Call CargarCanteras()
        Call ListarEmpleoLabor()
        Call SoloLinea()

    End Sub
#End Region                'Load

    Private Sub TxtCodigoEmpleoLabor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoEmpleoLabor.ValueChanged

    End Sub
End Class