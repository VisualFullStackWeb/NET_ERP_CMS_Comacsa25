Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.IO
Imports System.Math
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows
Imports System.Threading
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.DrawPhase
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMProductos
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto
    Dim Accion As String

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Declaraciones"

    'Nuevas variables
    Private dtOrigen As DataTable
    Private dtNoConforme As DataTable
    Private dtClasificacion As DataTable
    Private dtUnidad As DataTable
    Private dtSuministro As DataTable
    Private dtVenta As DataTable

    Private Ope As Int32 = 0
    Private Ls_Producto As List(Of ETProducto)
    Private Ls_Origen As List(Of ETAlmacen)
    Private Ls_NoConforme As List(Of ETAlmacen)
    Private Ls_Clasificacion As List(Of ETAlmacen)
    Private Ls_Unidad As List(Of ETAlmacen)
    Private Ls_Suministro As List(Of ETSuministro)
    Private Ls_Venta As List(Of ETProducto)
    Private CodSuministro As String = String.Empty
    Private Proceso As Thread = Nothing
    Private OpenFile As OpenFileDialog
    Private ObjStreamImagen As Stream = Nothing
    Private StrRutaImagen As String = String.Empty
    Private StrExtImagen As String = String.Empty
    Private IntEditImagen As Int16 = Enum_Imagen.NoEditado
    Private FileImagen As FileInfo
    Private MdiOperaciones As List(Of String)
    Private Const StrImagen As String = "           Imagen           "
    Private Const StrFilter As String = "Archivos de mapa de bits (*.bmp,*.dib)|*.bmp;*.dib|" & _
                                        "JPEG (*.jpg,*.jpeg,*.jpe,*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" & _
                                        "GIF (*.gif)|*.gif|" & _
                                        "TIFF (*.tif,*.tiff)|*.tif;*.tiff|" & _
                                        "PNG (*.png)|*.png|" & _
                                        "ICO (*.ico)|*.ico|" & _
                                        "Todos los Archivos (*.*)|*.*"
    Private Enum Enum_Combo
        Unidad = 1
        Origen = 2
        NoConforme = 3
        Clasificacion = 4
    End Enum
    Private Enum Enum_Producto
        Descripcion = 1
        Suministro = 2
        CodVenta = 3
    End Enum
    Private Enum Enum_Imagen
        NoEditado = 0
        Vacio = 1
        Editado = 2
    End Enum

#End Region

#Region "Publicos"

    Public Sub Grabar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Dim datos As Int32


        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        _objEntidad_.CodProducto = Txt1.Text
        _objEntidad_.ID = cmbtipo.Value
        _objEntidad_.Accion = Accion
        _objEntidad_.Usuario = User_Sistema
        _objEntidad_.Terminal = Terminal

        datos = _objNegocio_.Costo_IngresaTipo(_objEntidad_)

        If (datos <> 1) Then
            MessageBox.Show("El registro no pudo guardarse", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Registro Guardado Exitosamente", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Accion = "U"
        End If




            'Entidad.Producto = New ETProducto
            'Negocio.Producto = New NGProducto

            'Entidad.Producto.CodProducto = IIf(Txt1.Value Is Nothing, String.Empty, Txt1.Value)
            'Entidad.Producto.Descripcion = IIf(Txt2.Value Is Nothing, String.Empty, Txt2.Value)
            'Entidad.Producto.Uso = IIf(Txt3.Value Is Nothing, String.Empty, Txt3.Value)

            'Entidad.Producto.TipoProducto = Cbo1.Value
            'Entidad.Producto.UnidadDesp = Mid(Cbo2.Text, 2, 3)
            'Entidad.Producto.UnidadProduccion = Cbo2.Value
            'Entidad.Producto.UnidadVentas = Cbo3.Value
            'Entidad.Producto.CodProdPDCObs = Txt4.Value

            'If Not VerificarControl(4, Cbo4) Then
            '    Entidad.Producto.Unidad = String.Empty
            'Else
            '    Entidad.Producto.Unidad = Cbo4.ActiveRow.Cells("Abrev").Value
            'End If

            'Entidad.Producto.Status = Cbo5.Value
            'Entidad.Producto.Clasificacion = Cbo6.Value
            'Entidad.Producto.NoConforme = Cbo7.Value
            'Entidad.Producto.ParteSemanal = Cbo8.Value

            'Entidad.Producto.Peso = Num1.Value
            'Entidad.Producto.FactorBolsa = Num2.Value * 0.01
            'Entidad.Producto.Factor = Num3.Value * 0.01
            'Entidad.Producto.Muestra = Chk1.Checked
            'Entidad.Producto.Ventas = Chk2.Checked
            'Entidad.Producto.ParteMensual = Chk3.Checked
            'Entidad.Producto.QuitarConsultaStock = Chk4.Checked


            'Entidad.Producto = Negocio.Producto.MantenimientoProducto(Entidad.Producto, Ls_Suministro)

            'If Entidad.Producto.Validacion Then

            '    Call Guardar_Imagen_Producto(Entidad.Objecto.ValorxTexto)

            '    If Ope = 1 Then
            '        Txt1.Value = Entidad.Producto.ValorxTexto
            '        Call Iniciar()
            '    End If

            '    Call Cancelar()

            'End If

            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Nuevo()

        Ope = 1
        Limpiar()
        Controles(Boolean.FalseString)

        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Tab2.Tabs("T01").Selected = Boolean.TrueString

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Buscar()

        If Not VerificarControl(1, Txt1) OrElse Tab2.Tabs("T01").Selected = True Then
            Exit Sub
        End If

        If Ope = 0 Then
            Exit Sub
        End If

        StrucForm.FxCxSuministro = New FrmCSuministro
        AddHandler StrucForm.FxCxSuministro.Closing, AddressOf BuscarSuministro
        StrucForm.FxCxSuministro.MdiParent = MdiParent
        StrucForm.FxCxSuministro.L = Boolean.TrueString
        StrucForm.FxCxSuministro.Show()
        StrucForm.FxCxSuministro = Nothing

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key = "T01" Then

            If IsDBNull(Grid1.ActiveRow.Cells("CodProducto").Value) Then
                MessageBox.Show("No existe Producto para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            'SubProceso_Producto(Grid1.ActiveRow)

        End If

        If Tab1.SelectedTab.Key = "T02" Then
            If Not VerificarControl(1, Txt1) Then
                MessageBox.Show("No existe Producto para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Tab1.Tabs("T02").Selected = Boolean.TrueString

        End If

        Ope = 2
        Controles(Boolean.FalseString)

    End Sub

    Public Sub Cancelar()

        Ope = 0
        Controles(Boolean.TrueString)

    End Sub

#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Nuevo)
    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Buscar)
    '    MdiOperaciones.Add(StrucOperaciones._Eliminar)
    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Producto IsNot Nothing Then Ls_Producto = Nothing
        If Ls_Origen IsNot Nothing Then Ls_Origen = Nothing
        If Ls_NoConforme IsNot Nothing Then Ls_NoConforme = Nothing
        If Ls_Clasificacion IsNot Nothing Then Ls_Clasificacion = Nothing
        If Ls_Unidad IsNot Nothing Then Ls_Unidad = Nothing
        If Ls_Suministro IsNot Nothing Then Ls_Suministro = Nothing
        If Ls_Venta IsNot Nothing Then Ls_Venta = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

        If Bgw1.WorkerSupportsCancellation Then Bgw1.CancelAsync()

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        'If sender Is Nothing OrElse e Is Nothing Then
        '    Return
        'End If
        Call Cargar_Combo()
        Call Iniciar()

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ScrollLabel(Lbl1)

        Call ScrollLabel(Lbl2)

        Lbl2.Text = StrImagen

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Cbo1.InitializeLayout, _
                                        Cbo2.InitializeLayout, Cbo3.InitializeLayout, _
                                         Cbo6.InitializeLayout, _
                                        Cbo7.InitializeLayout, Grid3.InitializeLayout, _
                                        Grid2.InitializeLayout, Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Cbo1 OrElse sender Is Cbo7 OrElse sender Is Cbo6 OrElse _
           sender Is Cbo2 OrElse sender Is Cbo3 OrElse sender Is cbo4 Then

            With sender.DisplayLayout.Bands(0)
                .ColHeadersVisible = Boolean.FalseString
                .Columns("Descripcion").Width = sender.Width
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

            End With

        End If

        If sender Is Grid1 Then

            With sender.DisplayLayout.Bands(0)

                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodProducto" Or uColumn.Key = "DesStatus" Or _
                            uColumn.Key = "Descripcion" Or uColumn.Key = "Uso" Or _
                            uColumn.Key = "Peso") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

            End With

        End If

        If sender Is Grid3 Then

            With sender.DisplayLayout.Bands(0)

                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodSuministro" Or uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

            End With

        End If

        If sender Is Grid2 Then

            With sender.DisplayLayout.Bands(0)

                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodVenta" Or uColumn.Key = "Descripcion" Or _
                            uColumn.Key = "FechaCreacion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

            End With


        End If

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Txt2.KeyDown, Cbo1.KeyDown, Cbo2.KeyDown, _
                               Cbo3.KeyDown, Num1.KeyDown, _
                               Num3.KeyDown, Cbo5.KeyDown, Cbo6.KeyDown, _
                               Cbo7.KeyDown, Txt3.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return

        If sender Is Txt2 Then
            Cbo1.Focus()
        End If
        If sender Is Cbo1 Then
            Cbo2.Focus()
        End If
        If sender Is Cbo2 Then
            Cbo3.Focus()
        End If
        If sender Is Cbo3 Then
            cbo4.Focus()
        End If
        If sender Is cbo4 Then
            Num1.Focus()
        End If
        If sender Is Num1 Then
            Cbo5.Focus()
        End If
        If sender Is Cbo5 Then
            Cbo6.Focus()
        End If
        If sender Is Cbo6 Then
            Cbo7.Focus()
        End If
        If sender Is Cbo7 Then
            Txt3.Focus()
        End If
        If sender Is Txt3 Then
            Cbo8.Focus()
        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) _
                             Handles Grid1.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            With e.Row
                If .Cells("Status").Value = "*" Then
                    .Cells("DesStatus").Value = "ANULADO"
                ElseIf .Cells("Status").Value = "I" Then
                    .Cells("DesStatus").Value = "INACTIVO"
                Else
                    .Cells("DesStatus").Value = "ACTIVO"
                End If
            End With
        End If

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        e.Row.Fixed = Boolean.TrueString

        SubProceso_Producto(e.Row)

    End Sub

    Sub Evento_AfterExitEditMode(ByVal sender As Object, ByVal e As EventArgs) Handles Num1.AfterExitEditMode

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            If sender Is Num1 Then

                If Num1.ReadOnly Then Exit Sub

                REM 01 TONELADAS
                REM 02 BOLSAS
                REM 03 KILOGRAMOS
                REM 05 UNIDADES

                Entidad.Objecto = New ETObjecto

                Entidad.Objecto.Tipo = 1
                Entidad.Objecto.FactorOriginal = Cbo4.ActiveRow.Cells("Abrev").Value
                Entidad.Objecto.FactorDestino = "TON"
                Entidad.Objecto.ValorxDecimal = Num1.Value

                Num3.Value = Fc_Conversion(Entidad.Objecto)

                If Cbo2.ActiveRow.Cells("Abrev").Value = "BLS" Then
                    If Cbo4.ActiveRow.Cells("Abrev").Value <> "KGS" Then
                        If Num3.Value <> 0 Then
                            Num2.Value = 1000 / (Num3.Value * 1000)
                        Else
                            Num2.Value = 0
                        End If
                    Else
                        If Num1.Value <> 0 Then
                            Num2.Value = 1000 / Num1.Value
                        Else
                            Num2.Value = 0
                        End If
                    End If
                End If
            End If
        Catch
        End Try
    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
                            Handles Cbo2.ValueChanged, Cbo3.ValueChanged, cbo4.ValueChanged


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender.value Is Nothing Then
            Exit Sub
        Else
            CargarError(Ep1, sender)
        End If

        If sender Is Cbo2 Then
            Cbo3.Value = sender.value
        End If



    End Sub

    Sub Evento_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles Num1.Enter

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Num1 Then

            If Not VerificarControl(4, Cbo2) Then
                CargarError(Ep1, Cbo2, "Ingrese la Unidad de Producción")
                Cbo2.Focus()
                Exit Sub
            End If
            If Not VerificarControl(4, Cbo3) Then
                CargarError(Ep1, Cbo3, "Ingrese la Unidad de Venta")
                Cbo3.Focus()
                Exit Sub
            End If
            If Not VerificarControl(4, Cbo4) Then
                CargarError(Ep1, Cbo4, "Ingrese la Unidad")
                Cbo4.Focus()
                Exit Sub
            End If

        End If

    End Sub


    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) _
                     Handles Btn2.Click, Btn3.Click, Btn1.Click, _
                             Btn4.Click, Btn5.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Btn1 Then

            If Not VerificarControl(5, Grid1) Then Return

            If Grid1.ActiveRow Is Nothing Then Return

            If Grid1.ActiveRow.IsFilterRow Then Return

            If Not Grid1.ActiveRow.IsActiveRow Then Return

            Grid1.ActiveRow.Fixed = Boolean.TrueString

            SubProceso_Producto(Grid1.ActiveRow)

        End If

        If sender Is Btn2 Then

            Buscar()

        End If

        If sender Is Btn3 Then

            If Not VerificarControl(5, Grid3) Then
                MessageBox.Show("No tiene Empaques para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If Grid3.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene un Empaques Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Grid3.ActiveRow.Delete()

        End If

        If sender Is Btn4 Then

            OpenFile = New OpenFileDialog()

            OpenFile.Filter = StrFilter
            OpenFile.FilterIndex = 7
            OpenFile.RestoreDirectory = Boolean.TrueString

            If OpenFile.ShowDialog() = DialogResult.OK Then
                ObjStreamImagen = OpenFile.OpenFile()
                If ObjStreamImagen IsNot Nothing Then

                    StrRutaImagen = OpenFile.FileName
                    FileImagen = New FileInfo(StrRutaImagen)
                    StrExtImagen = FileImagen.Extension

                    Select Case StrExtImagen
                        Case ".bmp", ".dib", ".jpg", ".jpeg", ".jpe", ".jfif", ".gif", ".tif", ".tiff", ".png", ".ico"
                            IntEditImagen = Enum_Imagen.Editado
                            Pic1.Image = Image.FromFile(StrRutaImagen)
                        Case Else
                            MessageBox.Show("Imagen Incorrecto", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Select
                    ObjStreamImagen = Nothing
                End If
            End If

        End If

        If sender Is Btn5 Then

            IntEditImagen = Enum_Imagen.Vacio
            Pic1.Image = Nothing

        End If

    End Sub

    Sub Evento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As BeforeRowsDeletedEventArgs) _
                                 Handles Grid3.BeforeRowsDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid3 Then Exit Sub

        e.DisplayPromptMsg = Boolean.FalseString

    End Sub

    Sub Evento_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) _
                      Handles Bgw1.DoWork

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Bgw1 Then Return

        If sender Is Bgw1 Then
            For i As Int16 = 1 To 4
                Consultar_Combo(i)
            Next
        End If

    End Sub

    Sub Evento_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
                                  Handles Bgw1.RunWorkerCompleted

        If sender Is Nothing OrElse e Is Nothing Then Return

        If e.Cancelled OrElse e.Error IsNot Nothing Then Return

        If sender IsNot Bgw1 Then Return

        If Ls_Unidad Is Nothing OrElse Ls_Origen Is Nothing OrElse _
           Ls_NoConforme Is Nothing OrElse Ls_Clasificacion Is Nothing Then
            Return
        End If

        Cargar_Combo()

    End Sub

#End Region

#Region "Funciones"

    Function Existe_CodSuministro(ByVal Rpt As ETSuministro) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodSuministro = CodSuministro Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Function Verificar_Datos() As Boolean

        Ep1.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt2, "Ingrese el Nombre del Producto")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Ingrese el Origen")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Ingrese la Unidad de Producción")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo3.Value) Then
            Ep1.SetError(Cbo3, "Ingrese la Unidad de Venta")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo4.Value) Then
            Ep1.SetError(Cbo4, "Ingrese la Unidad")
            lResult = Boolean.FalseString
        End If

        If Not (IsNumeric(Num1.Value) AndAlso Num1.Value > 0) Then
            Ep1.SetError(Num1, "Ingrese el Peso")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo5.Value) Then
            Ep1.SetError(Cbo5, "Ingrese el Estado")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(cmbtipo.Value) Then
            Ep1.SetError(cmbtipo, "Ingrese el Tipo de Producto")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function


#End Region

#Region "Procedimientos"

#Region "Cargar"

    Sub Cargar_ProductoPDC(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        Txt4.Value = sender.CodProducto

    End Sub

    Sub Cargar_Producto(ByVal Dt As DataTable)

        Txt1.Value = Dt.Rows(0)(0).ToString()
        Txt2.Value = Dt.Rows(0)(1).ToString()
        Txt3.Value = Dt.Rows(0)(28).ToString()

        Cbo1.Value = Dt.Rows(0)("Codorigen").ToString()
        Cbo2.Value = Dt.Rows(0)("UnidadProduccion").ToString()
        Cbo3.Value = Dt.Rows(0)("UnidadVentas").ToString()

        Dim uni As String
        uni = Dt.Rows(0)("IDGRUPO").ToString()

        cmbtipo.Value = uni

        If (uni = "") Then
            Accion = "I"
        Else
            Accion = "U"
        End If

        cbo4.Value = Dt.Rows(0)(26).ToString


        Cbo6.Value = Dt.Rows(0)("Clasificacion").ToString()
        Cbo7.Value = Dt.Rows(0)("NoConforme").ToString()
        Cbo8.Value = Dt.Rows(0)("ParteSemanal").ToString()
        Dt1.Value = Dt.Rows(0)("fechaCreacion")

        Num1.Value = Convert.ToDouble(Dt.Rows(0)("peso"))
        Num2.Value = Convert.ToDouble(Dt.Rows(0)("FactorBolsa")) * 100
        Num3.Value = Convert.ToDouble(Dt.Rows(0)("Factor")) * 100

        If Dt.Rows(0)("fechaActualizacion") = "01-01-1900" Then
            Dt2.Value = DBNull.Value
        Else
            Dt2.Value = Dt.Rows(0)("fechaActualizacion")
        End If

        If Dt.Rows(0)("Status").ToString() = "*" Then
            Cbo5.Value = "K3"
        ElseIf Entidad.Producto.Status = "I" Then
            Cbo5.Value = "K2"
        Else
            Cbo5.Value = "K1"
        End If

        Chk1.Checked = Dt.Rows(0)("Ventas").ToString()
        Chk2.Checked = Dt.Rows(0)("Muestra").ToString()
        Chk3.Checked = Dt.Rows(0)("ParteMensual").ToString()
        Chk4.Checked = Dt.Rows(0)("QuitarConsultaStock").ToString()

        REM Cargar Imagen

        If ExisteFichero(StrRutaProductos & Entidad.Producto.CodProducto & ".bmp") Then
            Pic1.Image = Image.FromFile(StrRutaProductos & Entidad.Producto.CodProducto & ".bmp")
        Else
            Pic1.Image = Nothing
        End If

        REM ---------------------------------------  Entidad.Producto

        'Ls_Suministro = New List(Of ETSuministro)
        'Ls_Suministro = Entidad.Producto.Ls_Lista1

        'CargarUltraGrid(Grid3, Ls_Suministro)

        'Ls_Venta = New List(Of ETProducto)
        'Ls_Venta = Entidad.Producto.Ls_Lista2

        'CargarUltraGrid(Grid2, Ls_Venta)

        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Tab2.Tabs("T01").Selected = Boolean.TrueString

    End Sub

    Sub Cargar_Combo()
        Consultar_Unidad()
        Consultar_Origen()
        Consultar_NoConforme()
        Consultar_Clasificacion()

        CargarUltraCombo(Cbo2, dtUnidad, "CodUnidad", "Descripcion")
        CargarUltraCombo(Cbo3, dtUnidad, "CodUnidad", "Descripcion")
        CargarUltraCombo(cbo4, dtUnidad, "Abrev", "Descripcion")
        CargarUltraCombo(Cbo1, dtOrigen, "CodAlmacen", "Descripcion")
        CargarUltraCombo(Cbo7, dtNoConforme, "CodAlmacen", "Descripcion")
        CargarUltraCombo(Cbo6, dtClasificacion, "CodAlmacen", "Descripcion")

    End Sub

#End Region

#Region "Consultar"

    Sub Consultar_Combo(ByVal i As Int16)
        Select Case i
            Case Enum_Combo.Unidad
                Proceso = New Thread(AddressOf Consultar_Unidad)
            Case Enum_Combo.Origen
                Proceso = New Thread(AddressOf Consultar_Origen)
            Case Enum_Combo.NoConforme
                Proceso = New Thread(AddressOf Consultar_NoConforme)
            Case Enum_Combo.Clasificacion
                Proceso = New Thread(AddressOf Consultar_Clasificacion)
        End Select
        Proceso.Start()
    End Sub

    Sub Consultar_Unidad()

        Negocio.Maestro = New NGMaestro
        Entidad.Almacen = New ETAlmacen

        'Ls_Unidad = New List(Of ETAlmacen)

        dtUnidad = Negocio.Maestro.ConsultasMaestros1

    End Sub

    Sub Consultar_Origen()

        Negocio.Almacen = New NGAlmacen
        Entidad.Almacen = New ETAlmacen

        dtOrigen = Negocio.Almacen.ConsultarAlmacen1

    End Sub

    Sub Consultar_NoConforme()

        Negocio.Almacen = New NGAlmacen
        Entidad.Almacen = New ETAlmacen

        dtNoConforme = Negocio.Almacen.ConsultarAlmacen6()

    End Sub

    Sub Consultar_Clasificacion()

        Negocio.Almacen = New NGAlmacen
        Entidad.Almacen = New ETAlmacen


        dtClasificacion = Negocio.Almacen.ConsultarAlmacen5()

    End Sub

#End Region

    Sub Iniciar()

        If Not Bgw1.IsBusy Then Bgw1.RunWorkerAsync()

        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dt As New DataTable

        _objEntidad_.Tipo = 4
        dt = _objNegocio_.ConsultarProducto(_objEntidad_)
        Call CargarUltraGridxBinding(Grid1, Source1, dt)
        'ConsultarProducto5
    End Sub

    Sub BuscarSuministro(ByVal sender As Object, ByVal e As EventArgs)

        If Not sender.vCargar Then Exit Sub

        If sender.Lista Is Nothing Then Exit Sub

        For Each W As ETSuministro In sender.Lista
            CodSuministro = String.Empty : CodSuministro = W.CodSuministro
            If Not Ls_Suministro.Exists(AddressOf Existe_CodSuministro) Then Ls_Suministro.Add(W)
        Next

        CargarUltraGrid(Grid3, Ls_Suministro)

    End Sub

    Sub Limpiar()

        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty

        Cbo1.Value = String.Empty
        Cbo2.Value = String.Empty
        Cbo3.Value = String.Empty
        Cbo4.Value = String.Empty
        Cbo6.Value = String.Empty
        Cbo7.Value = String.Empty

        Cbo5.Value = "K1"
        Cbo8.Value = String.Empty

        Num1.Value = 0
        Num2.Value = 0
        Num3.Value = 0

        Chk1.Checked = Boolean.FalseString
        Chk2.Checked = Boolean.FalseString
        Chk3.Checked = Boolean.FalseString
        Chk4.Checked = Boolean.FalseString

        Dt1.Value = Now
        Dt2.Value = DBNull.Value

        Pic1.Image = Nothing

        Ls_Venta = New List(Of ETProducto)
        CargarUltraGrid(Grid2, Ls_Venta)

        Ls_Suministro = New List(Of ETSuministro)
        CargarUltraGrid(Grid3, Ls_Suministro)

    End Sub

    Sub Controles(ByVal Val As Boolean)

        'Txt2.ReadOnly = Val
        'Txt3.ReadOnly = Val

        'Cbo1.ReadOnly = Val
        'Cbo2.ReadOnly = Val
        'Cbo3.ReadOnly = Val
        'Cbo4.ReadOnly = Val
        'Cbo6.ReadOnly = Val
        'Cbo7.ReadOnly = Val
        cmbtipo.ReadOnly = Val

        'Cbo5.ReadOnly = Val
        'Cbo8.ReadOnly = Val

        'Num1.ReadOnly = Val
        'Num2.ReadOnly = Val
        'Num3.ReadOnly = Val

        'Chk1.Enabled = Not Val
        'Chk2.Enabled = Not Val
        'Chk3.Enabled = Not Val
        'Chk4.Enabled = Not Val

        'Btn2.Enabled = Not Val
        'Btn3.Enabled = Not Val

        'Btn4.Enabled = Not Val
        'Btn5.Enabled = Not Val

        'btn6.Enabled = Not Val

        'If Not Val Then IntEditImagen = Enum_Imagen.NoEditado

        'With Grid3.DisplayLayout
        '    If Not Val Then
        '        .Override.AllowDelete = DefaultableBoolean.True
        '        .Bands(0).Columns("CodSuministro").CellAppearance.BackColor = Color.Honeydew
        '        .Bands(0).Columns("Descripcion").CellAppearance.BackColor = Color.LavenderBlush
        '    Else
        '        .Override.AllowDelete = DefaultableBoolean.False
        '        .Bands(0).Columns("CodSuministro").CellAppearance.BackColor = Color.White
        '        .Bands(0).Columns("Descripcion").CellAppearance.BackColor = Color.White
        '    End If
        'End With

    End Sub

    Sub SubProceso_Producto(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Dim Cod_ProdPDC As String = String.Empty

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto
        Dim Dt As DataTable
        Entidad.Producto.CodProducto = uRow.Cells("CodProducto").Value
        Cod_ProdPDC = uRow.Cells("CodProdPDCObs").Value
        Dt = Negocio.Producto.ConsultarProductoJS(Entidad.Producto)
        If (Dt.Rows.Count < 1) Then Exit Sub
        Call Cargar_Producto(Dt)
        Txt4.Value = Cod_ProdPDC
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Guardar_Imagen_Producto(ByVal Fichero As String)
        Try
            If IntEditImagen = Enum_Imagen.NoEditado Then
                Exit Sub
            End If

            If ExisteFichero(StrRutaProductos & Fichero & ".bmp") Then
                My.Computer.FileSystem.RenameFile(StrRutaProductos & Fichero & ".bmp", Fichero & "_" & Date.Now.Year.ToString & Date.Now.Month.ToString & Date.Now.Day.ToString & Date.Now.Hour.ToString & Date.Now.Minute & Date.Now.Second & ".bmp")
            End If

            If IntEditImagen = Enum_Imagen.Vacio Then Exit Sub

            Pic1.Image.Save(StrRutaProductos & Fichero & ".bmp", ImageFormat.Bmp)

        Catch
            MessageBox.Show("Error al Actualizar la Imagen", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

#End Region


    Private Sub Num3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num3.ValueChanged

    End Sub

    Private Sub Num2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num2.ValueChanged

    End Sub

    Private Sub Num1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num1.ValueChanged

    End Sub


    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click

        If Not Btn2.Enabled Then Return

        StrucForm.FxCxProductos = New FrmCProductos
        AddHandler StrucForm.FxCxProductos.Closing, AddressOf Cargar_ProductoPDC
        StrucForm.FxCxProductos.MdiParent = MdiParent
        StrucForm.FxCxProductos.L = Boolean.TrueString
        StrucForm.FxCxProductos.Show()
        StrucForm.FxCxProductos = Nothing


    End Sub
End Class