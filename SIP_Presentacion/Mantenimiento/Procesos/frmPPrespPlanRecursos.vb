Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmPPrespPlanRecursos

#Region "Declarar Variables"
    Private Ls_Periodo_Material As List(Of ETPresupuestoPlan) = Nothing
    Private Ls_Periodo_Equipo As List(Of ETPresupuestoPlan) = Nothing
    Private Ls_Periodo_ManoObra As List(Of ETPresupuestoPlan) = Nothing
    Private Ls_Periodo_Servicio As List(Of ETPresupuestoPlan) = Nothing
    Private Ls_Material As List(Of ETPresupuestoMaterial) = Nothing
    Private Ls_Equipo As List(Of ETPresupuestoEquipo) = Nothing
    Private Ls_ManoObra As List(Of ETPresupuestoManoObra) = Nothing
    Private Ls_Servicio As List(Of ETPresupuestoServicio) = Nothing

    Private Ls_PlanMaterialTemp As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private Ls_PlanEquipoTemp As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private Ls_PlanManoObraTemp As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private Ls_PlanServicioTemp As List(Of ETPresupuestoPlanRecursos) = Nothing

    Private _Ls_PlanMaterial As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private _Ls_PlanEquipo As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private _Ls_PlanManoObra As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private _Ls_PlanServicio As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private _Ls_PlanRecurso As List(Of ETPresupuestoPlanRecursos) = Nothing

    Private _Ls_PlanMaterial_Del As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private _Ls_PlanEquipo_Del As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private _Ls_PlanManoObra_Del As List(Of ETPresupuestoPlanRecursos) = Nothing
    Private _Ls_PlanServicio_Del As List(Of ETPresupuestoPlanRecursos) = Nothing

    Private _Ls_Plan_Equipo_Asignacion As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private _Ls_Plan_ManoObra_Asignacion As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private _Ls_Plan_Equipo_Asignacion_Del As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing
    Private _Ls_Plan_ManoObra_Asignacion_Del As List(Of ETPresupuestoPlanRecursosAsignacion) = Nothing

    Private _PresupuestoDet As Long = 0
    Private _Partida As String = String.Empty
    Private _Equipo As Long = 0

    Private Enum TipoRecurso
        sMaterial = 1
        sEquipo = 2
        sCargo = 3
        sServicio = 4
    End Enum

    Private _HabilitarDatos As Boolean = True

#End Region

#Region "Propiedades Publicas"
    Public Property HabilitarDatos() As Boolean
        Get
            Return _HabilitarDatos
        End Get
        Set(ByVal value As Boolean)
            _HabilitarDatos = value
        End Set
    End Property
    Public Property PresupuestoDet() As Long
        Get
            Return _PresupuestoDet
        End Get
        Set(ByVal value As Long)
            _PresupuestoDet = value
        End Set
    End Property
    Public Property Partida() As String
        Get
            Return _Partida
        End Get
        Set(ByVal value As String)
            _Partida = value
        End Set
    End Property
    Public Property Equipo() As Long
        Get
            Return _Equipo
        End Get
        Set(ByVal value As Long)
            _Equipo = value
        End Set
    End Property
    Public ReadOnly Property Ls_PlanMaterial() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanMaterial
        End Get
    End Property
    Public ReadOnly Property Ls_PlanEquipo() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanEquipo
        End Get
    End Property
    Public ReadOnly Property Ls_PlanManoObra() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanManoObra
        End Get
    End Property
    Public ReadOnly Property Ls_PlanServicio() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanServicio
        End Get
    End Property
    Public ReadOnly Property Ls_PlanMaterial_Del() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanMaterial_Del
        End Get
    End Property
    Public ReadOnly Property Ls_PlanEquipo_Del() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanEquipo_Del
        End Get
    End Property
    Public ReadOnly Property Ls_PlanManoObra_Del() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanManoObra_Del
        End Get
    End Property
    Public ReadOnly Property Ls_PlanServicio_Del() As List(Of ETPresupuestoPlanRecursos)
        Get
            Return _Ls_PlanServicio_Del
        End Get
    End Property
    Public ReadOnly Property Ls_PlanEquipo_Asignacion() As List(Of ETPresupuestoPlanRecursosAsignacion)
        Get
            Return _Ls_Plan_Equipo_Asignacion
        End Get
    End Property
    Public ReadOnly Property Ls_PlanEquipo_Asignacion_Del() As List(Of ETPresupuestoPlanRecursosAsignacion)
        Get
            Return _Ls_Plan_Equipo_Asignacion_Del
        End Get
    End Property
    Public ReadOnly Property Ls_PlanManoObra_Asignacion() As List(Of ETPresupuestoPlanRecursosAsignacion)
        Get
            Return _Ls_Plan_ManoObra_Asignacion
        End Get
    End Property
    Public ReadOnly Property Ls_PlanManoObra_Asignacion_Del() As List(Of ETPresupuestoPlanRecursosAsignacion)
        Get
            Return _Ls_Plan_ManoObra_Asignacion_Del
        End Get
    End Property
#End Region

#Region "Formulario"
    Private Sub frmPPrespPlanRecursos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Grb1.Text = Partida
        Call Inicio()
    End Sub
#End Region

#Region "Funciones Privadas"
    Private Function Calcular_Disponible(ByVal TipoReq As TipoRecurso, ByVal Recurso As String, ByVal Programado As Double, ByVal Valor_Ant As Double) As Boolean
        Calcular_Disponible = Boolean.TrueString
        Dim Disponible As Double

        Select Case TipoReq
            Case TipoRecurso.sMaterial
                For Each Row As ETPresupuestoMaterial In Ls_Material
                    If Row.Cod_Mat = Recurso Then
                        Disponible = Row.Disponible

                        If (Disponible - Programado) >= 0 Then
                            Disponible = Disponible - Programado + Valor_Ant
                            Row.Disponible = Disponible
                            Row.Planificado = Row.Planificado + Programado - Valor_Ant
                        Else
                            MsgBox("No hay Cantidad disponible" & Chr(13) & "para programar la Cantidad Solitada", MsgBoxStyle.Critical, msgComacsa)
                            Return False
                        End If

                        Exit For
                    End If
                Next

                Call CargarUltraGrid(Grid1, Ls_Material)

            Case TipoRecurso.sEquipo
                For Each Row As ETPresupuestoEquipo In Ls_Equipo
                    If Row.Cod_Eq = Recurso Then
                        Disponible = Row.Disponible

                        If (Disponible - Programado) >= 0 Then
                            Disponible = Disponible - Programado + Valor_Ant
                            Row.Disponible = Disponible
                            Row.Planificado = Row.Planificado + Programado - Valor_Ant
                        Else
                            MsgBox("No hay Cantidad disponible" & Chr(13) & "para programar la Cantidad Solitada", MsgBoxStyle.Critical, msgComacsa)
                            Return False
                        End If

                        Exit For
                    End If
                Next

                Call CargarUltraGrid(Grid4, Ls_Equipo)

            Case TipoRecurso.sCargo
                For Each Row As ETPresupuestoManoObra In Ls_ManoObra
                    If Row.Cod_Cargo = Recurso.Trim Then
                        Disponible = Row.Disponible

                        If (Disponible - Programado) >= 0 Then
                            Disponible = Disponible - Programado + Valor_Ant
                            Row.Disponible = Disponible
                            Row.Planificado = Row.Planificado + Programado - Valor_Ant
                        Else
                            MsgBox("No hay Cantidad disponible" & Chr(13) & "para programar la Cantidad Solitada", MsgBoxStyle.Critical, msgComacsa)
                            Return False
                        End If

                        Exit For
                    End If
                Next

                Call CargarUltraGrid(Grid7, Ls_ManoObra)

            Case TipoRecurso.sServicio
                For Each Row As ETPresupuestoServicio In Ls_Servicio
                    If Row.Cod_Ser = Recurso Then
                        Disponible = Row.Disponible

                        If (Disponible - Programado) >= 0 Then
                            Disponible = Disponible - Programado + Valor_Ant
                            Row.Disponible = Disponible
                            Row.Planificado = Row.Planificado + Programado - Valor_Ant
                        Else
                            MsgBox("No hay Cantidad disponible" & Chr(13) & "para programar la Cantidad Solitada", MsgBoxStyle.Critical, msgComacsa)
                            Return False
                        End If

                        Exit For
                    End If
                Next

                Call CargarUltraGrid(Grid10, Ls_Servicio)
        End Select

    End Function
#End Region

#Region "Procedimientos Privados"
    Private Sub Quitar_RecursoAsignado(ByVal Tipo As String, ByVal Borrar As Long)
        Dim i As Integer

        If Tipo = "EQ" Then
            i = 0
            While i < _Ls_Plan_Equipo_Asignacion.Count
                If _Ls_Plan_Equipo_Asignacion(i).PlanRecurso = Borrar Then
                    _Ls_Plan_Equipo_Asignacion.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While

            i = 0
            While i < _Ls_Plan_Equipo_Asignacion_Del.Count
                If _Ls_Plan_Equipo_Asignacion_Del(i).PlanRecurso = Borrar Then
                    _Ls_Plan_Equipo_Asignacion_Del.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        Else
            i = 0
            While i < _Ls_Plan_ManoObra_Asignacion.Count
                If _Ls_Plan_ManoObra_Asignacion(i).PlanRecurso = Borrar Then
                    _Ls_Plan_ManoObra_Asignacion.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While

            i = 0
            While i < _Ls_Plan_ManoObra_Asignacion_Del.Count
                If _Ls_Plan_ManoObra_Asignacion_Del(i).PlanRecurso = Borrar Then
                    _Ls_Plan_ManoObra_Asignacion_Del.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If

    End Sub

    Private Sub Agregar_RecursoAsignado(ByVal Tipo As String, ByVal Lista_ADD As List(Of ETPresupuestoPlanRecursosAsignacion), ByVal Lista_DEL As List(Of ETPresupuestoPlanRecursosAsignacion))

        Dim i As Integer = 0
        While i < Lista_ADD.Count
            If Tipo = "EQ" Then
                _Ls_Plan_Equipo_Asignacion.Add(Lista_ADD(i))
            Else
                _Ls_Plan_ManoObra_Asignacion.Add(Lista_ADD(i))
            End If
            i = i + 1
        End While
        i = 0
        While i < Lista_DEL.Count
            If Tipo = "EQ" Then
                _Ls_Plan_Equipo_Asignacion_Del.Add(Lista_DEL(i))
            Else
                _Ls_Plan_ManoObra_Asignacion_Del.Add(Lista_DEL(i))
            End If
            i = i + 1
        End While

    End Sub

    Private Sub Cargar_Periodo()
        Entidad.Presupuesto_Plan = New ETPresupuestoPlan
        Entidad.Presupuesto_Plan.PresupuestoDet = Me.PresupuestoDet
        Entidad.Presupuesto_Plan.Tipo = 4
        Entidad.MyLista = New ETMyLista
        Negocio.PresupuestoDet = New NGPresupuestoDet
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan(Entidad.Presupuesto_Plan)

        Ls_Periodo_Material = New List(Of ETPresupuestoPlan)
        Ls_Periodo_Equipo = New List(Of ETPresupuestoPlan)
        Ls_Periodo_ManoObra = New List(Of ETPresupuestoPlan)
        Ls_Periodo_Servicio = New List(Of ETPresupuestoPlan)

        If Entidad.MyLista.Validacion Then
            Ls_Periodo_Material = Entidad.MyLista.Ls_Presupuesto_Plan
            Ls_Periodo_Equipo = Entidad.MyLista.Ls_Presupuesto_Plan
            Ls_Periodo_ManoObra = Entidad.MyLista.Ls_Presupuesto_Plan
            Ls_Periodo_Servicio = Entidad.MyLista.Ls_Presupuesto_Plan
        End If

        Call CargarUltraGrid(Grid2, Ls_Periodo_Material)
        Call CargarUltraGrid(Grid5, Ls_Periodo_Equipo)
        Call CargarUltraGrid(Grid8, Ls_Periodo_ManoObra)
        Call CargarUltraGrid(Grid11, Ls_Periodo_Servicio)
    End Sub
    Private Sub Cargar_Recursos()
        Entidad.PresupuestoDet = New ETPresupuestoDetalle
        With Entidad.PresupuestoDet
            .Tipo = 5
            .PresupuestoDet = PresupuestoDet
        End With
        Negocio.PresupuestoDet = New NGPresupuestoDet
        Ls_Material = New List(Of ETPresupuestoMaterial)
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Material(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            Ls_Material = Entidad.MyLista.Ls_Presupuesto_Material
        End If

        Ls_Equipo = New List(Of ETPresupuestoEquipo)
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Equipo(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_Presupuesto_Equipo
        End If

        Ls_ManoObra = New List(Of ETPresupuestoManoObra)
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_ManoObra(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            Ls_ManoObra = Entidad.MyLista.Ls_Presupuesto_ManoObra
        End If

        Ls_Servicio = New List(Of ETPresupuestoServicio)
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Servicio(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            Ls_Servicio = Entidad.MyLista.Ls_Presupuesto_Servicio
        End If

        Call CargarUltraGrid(Grid1, Ls_Material)
        Call CargarUltraGrid(Grid4, Ls_Equipo)
        Call CargarUltraGrid(Grid7, Ls_ManoObra)
        Call CargarUltraGrid(Grid10, Ls_Servicio)

    End Sub

    Private Sub Cargar_PlanRecurso()
        _Ls_PlanMaterial = New List(Of ETPresupuestoPlanRecursos)
        _Ls_PlanEquipo = New List(Of ETPresupuestoPlanRecursos)
        _Ls_PlanManoObra = New List(Of ETPresupuestoPlanRecursos)
        _Ls_PlanServicio = New List(Of ETPresupuestoPlanRecursos)

        _Ls_PlanMaterial_Del = New List(Of ETPresupuestoPlanRecursos)
        _Ls_PlanEquipo_Del = New List(Of ETPresupuestoPlanRecursos)
        _Ls_PlanManoObra_Del = New List(Of ETPresupuestoPlanRecursos)
        _Ls_PlanServicio_Del = New List(Of ETPresupuestoPlanRecursos)
        _Ls_PlanRecurso = New List(Of ETPresupuestoPlanRecursos)

        _Ls_Plan_Equipo_Asignacion = New List(Of ETPresupuestoPlanRecursosAsignacion)
        _Ls_Plan_Equipo_Asignacion_Del = New List(Of ETPresupuestoPlanRecursosAsignacion)
        _Ls_Plan_ManoObra_Asignacion = New List(Of ETPresupuestoPlanRecursosAsignacion)
        _Ls_Plan_ManoObra_Asignacion_Del = New List(Of ETPresupuestoPlanRecursosAsignacion)


        Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
        Negocio.PresupuestoDet = New NGPresupuestoDet
        With Entidad.Presupuesto_Plan_Recurso
            .PresupuestoDet = PresupuestoDet
            .Tipo = 5
        End With

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_Material(Entidad.Presupuesto_Plan_Recurso)
        If Entidad.MyLista.Validacion Then
            Ls_PlanMaterialTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
        End If

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_Equipo(Entidad.Presupuesto_Plan_Recurso)
        If Entidad.MyLista.Validacion Then
            Ls_PlanEquipoTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
        End If

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_ManoObra(Entidad.Presupuesto_Plan_Recurso)
        If Entidad.MyLista.Validacion Then
            Ls_PlanManoObraTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
        End If

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_Servicio(Entidad.Presupuesto_Plan_Recurso)
        If Entidad.MyLista.Validacion Then
            Ls_PlanServicioTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
        End If

        Call CargarUltraGrid(Grid3, _Ls_PlanMaterial)
        Call CargarUltraGrid(Grid6, _Ls_PlanEquipo)
        Call CargarUltraGrid(Grid9, _Ls_PlanManoObra)
        Call CargarUltraGrid(Grid12, _Ls_PlanServicio)

        If Ls_PlanMaterialTemp IsNot Nothing Then
            _Ls_PlanMaterial = Ls_PlanMaterialTemp
        End If

        If Ls_PlanEquipoTemp IsNot Nothing Then
            _Ls_PlanEquipo = Ls_PlanEquipoTemp
        End If

        If Ls_PlanManoObraTemp IsNot Nothing Then
            _Ls_PlanManoObra = Ls_PlanManoObraTemp
        End If

        If Ls_PlanServicioTemp IsNot Nothing Then
            _Ls_PlanServicio = Ls_PlanServicioTemp
        End If
    End Sub

    Private Sub Actualizar_Grilla_PlanMat()
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        If Grid3.Rows.Count > 0 Then
            Periodo = Grid3.Rows(0).Cells("Periodo").Value
            i = 0
            While i < _Ls_PlanMaterial.Count
                If _Ls_PlanMaterial(i).Periodo = Periodo Then
                    _Ls_PlanMaterial.Remove(_Ls_PlanMaterial(i))
                Else
                    i = i + 1
                End If
            End While

            For i = 0 To Grid3.Rows.Count - 1
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Periodo = Grid3.Rows(i).Cells("Periodo").Value
                    .Codigo = Grid3.Rows(i).Cells("Codigo").Value
                    .Fecha = Grid3.Rows(i).Cells("Fecha").Value
                    .Dias = Grid3.Rows(i).Cells("Dias").Value
                    .Cantidad = Grid3.Rows(i).Cells("Cantidad").Value
                    If Val(Grid3.Rows(i).Cells("PlanRecurso").Value) > 0 Then
                        .Tipo = 2
                    Else
                        .Tipo = 1
                    End If

                    .Descripcion = Grid3.Rows(i).Cells("Descripcion").Value
                    .Und = Grid3.Rows(i).Cells("Und").Value
                    .Entero = Grid3.Rows(i).Cells("Entero").Value

                    .PresupuestoDet = Grid3.Rows(i).Cells("PresupuestoDet").Value
                    .PresupuestoPlan = Grid3.Rows(i).Cells("PresupuestoPlan").Value
                    .PlanRecurso = Grid3.Rows(i).Cells("PlanRecurso").Value
                    _Ls_PlanMaterial.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            Next

        End If
    End Sub

    Private Sub Actualizar_Grilla_PlanEq()
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        If Grid6.Rows.Count > 0 Then
            Periodo = Grid6.Rows(0).Cells("Periodo").Value
            i = 0
            While i < _Ls_PlanEquipo.Count
                If _Ls_PlanEquipo(i).Periodo = Periodo Then
                    _Ls_PlanEquipo.Remove(_Ls_PlanEquipo(i))
                Else
                    i = i + 1
                End If
            End While

            For i = 0 To Grid6.Rows.Count - 1
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Periodo = Grid6.Rows(i).Cells("Periodo").Value
                    .Codigo = Grid6.Rows(i).Cells("Codigo").Value
                    .Recurso = Grid6.Rows(i).Cells("Recurso").Value
                    .Fecha = Grid6.Rows(i).Cells("Fecha").Value
                    .Dias = Grid6.Rows(i).Cells("Dias").Value
                    .Cantidad = Grid6.Rows(i).Cells("Cantidad").Value
                    If Val(Grid6.Rows(i).Cells("PlanRecurso").Value) > 0 Then
                        .Tipo = 2
                    Else
                        .Tipo = 1
                    End If

                    .Descripcion = Grid6.Rows(i).Cells("Descripcion").Value
                    .Und = Grid6.Rows(i).Cells("Und").Value
                    .Entero = Grid6.Rows(i).Cells("Entero").Value

                    .PresupuestoDet = Grid6.Rows(i).Cells("PresupuestoDet").Value
                    .PresupuestoPlan = Grid6.Rows(i).Cells("PresupuestoPlan").Value
                    .PlanRecurso = Grid6.Rows(i).Cells("PlanRecurso").Value
                    _Ls_PlanEquipo.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            Next

        End If
    End Sub

    Private Sub Actualizar_Grilla_PlanMO()
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        If Grid9.Rows.Count > 0 Then
            Periodo = Grid9.Rows(0).Cells("Periodo").Value
            i = 0
            While i < _Ls_PlanManoObra.Count
                If _Ls_PlanManoObra(i).Periodo = Periodo Then
                    _Ls_PlanManoObra.Remove(_Ls_PlanManoObra(i))
                Else
                    i = i + 1
                End If
            End While

            For i = 0 To Grid9.Rows.Count - 1
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Periodo = Grid9.Rows(i).Cells("Periodo").Value
                    .Codigo = Grid9.Rows(i).Cells("Codigo").Value
                    .Fecha = Grid9.Rows(i).Cells("Fecha").Value
                    .Dias = Grid9.Rows(i).Cells("Dias").Value
                    .Cantidad = Grid9.Rows(i).Cells("Cantidad").Value
                    If Val(Grid9.Rows(i).Cells("PlanRecurso").Value) > 0 Then
                        .Tipo = 2
                    Else
                        .Tipo = 1
                    End If

                    .Descripcion = Grid9.Rows(i).Cells("Descripcion").Value
                    .Und = Grid9.Rows(i).Cells("Und").Value
                    .Entero = Grid9.Rows(i).Cells("Entero").Value

                    .PresupuestoDet = Grid9.Rows(i).Cells("PresupuestoDet").Value
                    .PresupuestoPlan = Grid9.Rows(i).Cells("PresupuestoPlan").Value
                    .PlanRecurso = Grid9.Rows(i).Cells("PlanRecurso").Value
                    _Ls_PlanManoObra.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            Next

        End If
    End Sub

    Private Sub Actualizar_Grilla_PlanSer()
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        If Grid12.Rows.Count > 0 Then
            Periodo = Grid12.Rows(0).Cells("Periodo").Value
            i = 0
            While i < _Ls_PlanServicio.Count
                If _Ls_PlanServicio(i).Periodo = Periodo Then
                    _Ls_PlanServicio.Remove(_Ls_PlanServicio(i))
                Else
                    i = i + 1
                End If
            End While

            For i = 0 To Grid12.Rows.Count - 1
                Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
                With Entidad.Presupuesto_Plan_Recurso
                    .Periodo = Grid12.Rows(i).Cells("Periodo").Value
                    .Codigo = Grid12.Rows(i).Cells("Codigo").Value
                    .Fecha = Grid12.Rows(i).Cells("Fecha").Value
                    .Dias = Grid12.Rows(i).Cells("Dias").Value
                    .Cantidad = Grid12.Rows(i).Cells("Cantidad").Value
                    If Val(Grid12.Rows(i).Cells("PlanRecurso").Value) > 0 Then
                        .Tipo = 2
                    Else
                        .Tipo = 1
                    End If

                    .Descripcion = Grid12.Rows(i).Cells("Descripcion").Value
                    .Und = Grid12.Rows(i).Cells("Und").Value
                    .Entero = Grid12.Rows(i).Cells("Entero").Value

                    .PresupuestoDet = Grid12.Rows(i).Cells("PresupuestoDet").Value
                    .PresupuestoPlan = Grid12.Rows(i).Cells("PresupuestoPlan").Value
                    .PlanRecurso = Grid12.Rows(i).Cells("PlanRecurso").Value
                    _Ls_PlanServicio.Add(Entidad.Presupuesto_Plan_Recurso)
                End With
            Next

        End If
    End Sub

    Private Sub Cargar_PlanMaterial(ByVal Codigo As String, ByVal Plan As Long, ByVal FechaInicio As Date, ByVal FechaTermino As Date)
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        Call Actualizar_Grilla_PlanMat()

        _Ls_PlanRecurso = New List(Of ETPresupuestoPlanRecursos)

        For Each eRow As ETPresupuestoPlanRecursos In _Ls_PlanMaterial
            If eRow.Periodo = Codigo Then
                _Ls_PlanRecurso.Add(eRow)
            End If
        Next

        If _Ls_PlanRecurso.Count > 0 Then
            Ls_PlanMaterialTemp = New List(Of ETPresupuestoPlanRecursos)
            Ls_PlanMaterialTemp = _Ls_PlanRecurso

            For Each Row As ETPresupuestoMaterial In Ls_Material
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanMaterialTemp
                    If Row.Cod_Mat = Fila.Codigo Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Material
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        Else
            Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
            Negocio.PresupuestoDet = New NGPresupuestoDet
            With Entidad.Presupuesto_Plan_Recurso
                .PresupuestoDet = PresupuestoDet
                .PresupuestoPlan = Plan
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Tipo = 4
            End With
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_Material(Entidad.Presupuesto_Plan_Recurso)
            If Entidad.MyLista.Validacion Then
                Ls_PlanMaterialTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
            End If

            For Each Row As ETPresupuestoMaterial In Ls_Material
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanMaterialTemp
                    If Row.Cod_Mat = Fila.Codigo Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Material
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        End If

        Call CargarUltraGrid(Grid3, Ls_PlanMaterialTemp)
    End Sub

    Private Sub Cargar_PlanEquipo(ByVal Codigo As String, ByVal Plan As Long, ByVal FechaInicio As Date, ByVal FechaTermino As Date)
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        Call Actualizar_Grilla_PlanEq()

        _Ls_PlanRecurso = New List(Of ETPresupuestoPlanRecursos)

        For Each eRow As ETPresupuestoPlanRecursos In _Ls_PlanEquipo
            If eRow.Periodo = Codigo Then
                _Ls_PlanRecurso.Add(eRow)
            End If
        Next

        If _Ls_PlanRecurso.Count > 0 Then
            Ls_PlanEquipoTemp = New List(Of ETPresupuestoPlanRecursos)
            Ls_PlanEquipoTemp = _Ls_PlanRecurso

            For Each Row As ETPresupuestoEquipo In Ls_Equipo
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanEquipoTemp
                    If Row.EquipoID = Fila.Recurso Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Equipo
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        Else
            Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
            Negocio.PresupuestoDet = New NGPresupuestoDet
            With Entidad.Presupuesto_Plan_Recurso
                .PresupuestoDet = PresupuestoDet
                .PresupuestoPlan = Plan
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Tipo = 4
            End With
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_Equipo(Entidad.Presupuesto_Plan_Recurso)
            If Entidad.MyLista.Validacion Then
                Ls_PlanEquipoTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
            End If

            For Each Row As ETPresupuestoEquipo In Ls_Equipo
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanEquipoTemp
                    If Row.EquipoID = Fila.Recurso Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Equipo
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        End If

        Call CargarUltraGrid(Grid6, Ls_PlanEquipoTemp)
    End Sub

    Private Sub Cargar_PlanManoObra(ByVal Codigo As String, ByVal Plan As Long, ByVal FechaInicio As Date, ByVal FechaTermino As Date)
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        Call Actualizar_Grilla_PlanMO()

        _Ls_PlanRecurso = New List(Of ETPresupuestoPlanRecursos)

        For Each eRow As ETPresupuestoPlanRecursos In _Ls_PlanManoObra
            If eRow.Periodo = Codigo Then
                _Ls_PlanRecurso.Add(eRow)
            End If
        Next

        If _Ls_PlanRecurso.Count > 0 Then
            Ls_PlanManoObraTemp = New List(Of ETPresupuestoPlanRecursos)
            Ls_PlanManoObraTemp = _Ls_PlanRecurso

            For Each Row As ETPresupuestoManoObra In Ls_ManoObra
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanManoObraTemp
                    If Row.Cod_Cargo = Fila.Codigo Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Cargo
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        Else
            Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
            Negocio.PresupuestoDet = New NGPresupuestoDet
            With Entidad.Presupuesto_Plan_Recurso
                .PresupuestoDet = PresupuestoDet
                .PresupuestoPlan = Plan
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Tipo = 4
            End With
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_ManoObra(Entidad.Presupuesto_Plan_Recurso)
            If Entidad.MyLista.Validacion Then
                Ls_PlanManoObraTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
            End If

            For Each Row As ETPresupuestoManoObra In Ls_ManoObra
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanManoObraTemp
                    If Row.Cod_Cargo = Fila.Codigo.Trim Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Cargo
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        End If

        Call CargarUltraGrid(Grid9, Ls_PlanManoObraTemp)
    End Sub

    Private Sub Cargar_PlanServicio(ByVal Codigo As String, ByVal Plan As Long, ByVal FechaInicio As Date, ByVal FechaTermino As Date)
        Dim Periodo As String = String.Empty
        Dim i As Integer = 0

        Call Actualizar_Grilla_PlanSer()

        _Ls_PlanRecurso = New List(Of ETPresupuestoPlanRecursos)

        For Each eRow As ETPresupuestoPlanRecursos In _Ls_PlanServicio
            If eRow.Periodo = Codigo Then
                _Ls_PlanRecurso.Add(eRow)
            End If
        Next

        If _Ls_PlanRecurso.Count > 0 Then
            Ls_PlanServicioTemp = New List(Of ETPresupuestoPlanRecursos)
            Ls_PlanServicioTemp = _Ls_PlanRecurso

            For Each Row As ETPresupuestoServicio In Ls_Servicio
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanServicioTemp
                    If Row.Cod_Ser = Fila.Codigo Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Servicio
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        Else
            Entidad.Presupuesto_Plan_Recurso = New ETPresupuestoPlanRecursos
            Negocio.PresupuestoDet = New NGPresupuestoDet
            With Entidad.Presupuesto_Plan_Recurso
                .PresupuestoDet = PresupuestoDet
                .PresupuestoPlan = Plan
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Tipo = 4
            End With
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Plan_Servicio(Entidad.Presupuesto_Plan_Recurso)
            If Entidad.MyLista.Validacion Then
                Ls_PlanServicioTemp = Entidad.MyLista.Ls_Presupuesto_Plan_Recurso
            End If

            For Each Row As ETPresupuestoServicio In Ls_Servicio
                For Each Fila As ETPresupuestoPlanRecursos In Ls_PlanServicioTemp
                    If Row.Cod_Ser = Fila.Codigo Then
                        Fila.Periodo = Codigo
                        Fila.Descripcion = Row.Servicio
                        Fila.Und = Row.UniMed
                        Fila.Entero = Row.Entero
                    End If
                Next
            Next
        End If

        Call CargarUltraGrid(Grid12, Ls_PlanServicioTemp)
    End Sub

    Private Sub Inicio()
        Call Cargar_Recursos()
        Call Cargar_Periodo()
        Call Cargar_PlanRecurso()
    End Sub


#End Region

#Region "Grillas"
    Private Sub Grila_PlanRecurso_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs)

        If e Is Nothing Then
            Return
        End If

        If String.IsNullOrEmpty(e.Cell.Value.ToString.Trim) Then
            MsgBox("La Celda esta Vacia", MsgBoxStyle.Critical, msgComacsa)
        End If

        Dim frm As New frmPTareoOS
        frm.MaximizeBox = False

        If sender Is Grid9 Then
            frm.WindowState = FormWindowState.Normal
            frm.Tag = "P09"
            frm.ShowDialog()
        ElseIf sender Is Grid6 Then
            frm.WindowState = FormWindowState.Normal
            frm.Tag = "P08"
            frm.ShowDialog()
        End If

    End Sub

    Private Sub Grilla_Periodo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid2.DoubleClickRow, Grid5.DoubleClickRow, Grid8.DoubleClickRow, Grid11.DoubleClickRow
        Dim PlanID As Long = 0
        Dim FechaInicio As Date = Date.Today
        Dim FechaTermino As Date = Date.Today
        Dim Codigo As String = String.Empty
        If sender Is Nothing Then Return
        If e Is Nothing Then Return
        If sender.Rows.Count <= 0 Then Return
        If sender.ActiveRow Is Nothing Then Return
        Codigo = sender.ActiveRow.Cells("Codigo").Value
        PlanID = sender.ActiveRow.Cells("PlanID").Value
        FechaInicio = sender.ActiveRow.Cells("FechaInicio").Value
        FechaTermino = sender.ActiveRow.Cells("FechaTerminacion").Value
        Select Case sender.name
            Case "Grid2"
                If Grid1.Rows.Count <= 0 Then Return
                Call Cargar_PlanMaterial(Codigo, PlanID, FechaInicio, FechaTermino)
                Grid3.Text = "Periodo: " & Codigo & ". Desde: " & FechaInicio & " Hasta: " & FechaTermino
            Case "Grid5"
                If Grid4.Rows.Count <= 0 Then Return
                Call Cargar_PlanEquipo(Codigo, PlanID, FechaInicio, FechaTermino)
                Grid6.Text = "Periodo: " & Codigo & ". Desde: " & FechaInicio & " Hasta: " & FechaTermino
            Case "Grid8"
                If Grid7.Rows.Count <= 0 Then Return
                Call Cargar_PlanManoObra(Codigo, PlanID, FechaInicio, FechaTermino)
                Grid9.Text = "Periodo: " & Codigo & ". Desde: " & FechaInicio & " Hasta: " & FechaTermino
            Case "Grid11"
                If Grid10.Rows.Count <= 0 Then Return
                Call Cargar_PlanServicio(Codigo, PlanID, FechaInicio, FechaTermino)
                Grid12.Text = "Periodo: " & Codigo & ". Desde: " & FechaInicio & " Hasta: " & FechaTermino
        End Select


    End Sub



    Private Sub Grilla_Periodo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout, Grid5.InitializeLayout, Grid8.InitializeLayout, Grid11.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns

            If Not (uColumn.Key = "Codigo" _
                OrElse uColumn.Key = "FechaInicio" OrElse uColumn.Key = "FechaTerminacion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
            uColumn.CellActivation = Activation.NoEdit
        Next
    End Sub
    Private Sub Grilla_Recurso_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid4.InitializeLayout, Grid7.InitializeLayout, Grid10.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns

            If Not (uColumn.Key = "Cod_Mat" OrElse uColumn.Key = "Cod_Eq" _
                    OrElse uColumn.Key = "Cod_Cargo" OrElse uColumn.Key = "Cod_Ser" _
                    OrElse uColumn.Key = "Material" OrElse uColumn.Key = "Equipo" _
                    OrElse uColumn.Key = "Cargo" OrElse uColumn.Key = "Servicio" _
                    OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                    OrElse uColumn.Key = "Planificado" OrElse uColumn.Key = "Disponible") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub Grilla_Plan_Recurso_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles Grid6.DoubleClickCell, Grid9.DoubleClickCell
        If e Is Nothing Then
            Return
        End If

        If e.Cell.Column.Key <> "Cantidad" Then
            Return
        End If

        If String.IsNullOrEmpty(e.Cell.Value.ToString.Trim) Then
            MsgBox("La Celda esta Vacia", MsgBoxStyle.Critical, msgComacsa)
            Return
        ElseIf Val(e.Cell.Value) <= 0 Then
            MsgBox("El valor de la celda debe ser mayor a Cero", MsgBoxStyle.Critical, msgComacsa)
            Return
        End If

        Dim frm As New frmPPrespPlanRecursoAsignacion
        frm.MaximizeBox = False
        frm.HabilitarDatos = HabilitarDatos
        If sender Is Grid9 Then
            frm.WindowState = FormWindowState.Normal
            frm.Tag = "P09"
            frm.Cargo = sender.ActiveCell.Row.Cells("Codigo").Value
            frm.Fecha = sender.ActiveCell.Row.Cells("Fecha").Value
            frm.Horas = sender.ActiveCell.Row.Cells("Cantidad").Value
            frm.PresupuestoDet = sender.ActiveCell.Row.Cells("PresupuestoDet").Value
            frm.PresupuestoPlan = sender.ActiveCell.Row.Cells("PresupuestoPlan").Value
            frm.PlanRecurso = sender.ActiveCell.Row.Cells("PlanRecurso").Value

            Call Quitar_RecursoAsignado("MO", sender.ActiveCell.Row.Cells("PlanRecurso").Value)
            frm.ShowDialog()
            Call Agregar_RecursoAsignado("MO", frm.PrespPlanRecursoAsignacion, frm.PrespPlanRecursoAsignacion_Del)
        ElseIf sender Is Grid6 Then
            frm.WindowState = FormWindowState.Normal
            frm.Tag = "P08"
            frm.Fecha = sender.ActiveCell.Row.Cells("Fecha").Value
            frm.Horas = sender.ActiveCell.Row.Cells("Cantidad").Value
            frm.EquipoInput = Me.Equipo
            frm.FamiliaEquipo = sender.ActiveCell.Row.Cells("Recurso").Value
            frm.PresupuestoDet = sender.ActiveCell.Row.Cells("PresupuestoDet").Value
            frm.PresupuestoPlan = sender.ActiveCell.Row.Cells("PresupuestoPlan").Value
            frm.PlanRecurso = sender.ActiveCell.Row.Cells("PlanRecurso").Value
            Call Quitar_RecursoAsignado("EQ", sender.ActiveCell.Row.Cells("PlanRecurso").Value)
            frm.ShowDialog()
            Call Agregar_RecursoAsignado("EQ", frm.PrespPlanRecursoAsignacion, frm.PrespPlanRecursoAsignacion_Del)
        End If
        frm = Nothing
    End Sub

    Private Sub Grilla_Plan_Recurso_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid3.InitializeLayout, Grid6.InitializeLayout, Grid9.InitializeLayout, Grid12.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If HabilitarDatos = False Then
                uColumn.CellActivation = Activation.NoEdit
            End If

            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "Und" OrElse uColumn.Key = "Dias" _
                    OrElse uColumn.Key = "Fecha" OrElse uColumn.Key = "Cantidad") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

        If sender Is Grid6 OrElse sender Is Grid9 Then
            For Each uRow As UltraGridRow In sender.Rows
                If Val(uRow.Cells("Contar").Value) > 0 Then
                    For Each ucolumn As UltraGridColumn In e.Layout.Bands(0).Columns
                        uRow.Cells(ucolumn.Key).Activation = Activation.NoEdit
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub Grilla_Plan_Recurso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid3.KeyDown, Grid6.KeyDown, Grid9.KeyDown, Grid12.KeyDown
        With sender
            Select Case e.KeyValue
                Case Keys.Up
                    .PerformAction(ExitEditMode, False, False)
                    .PerformAction(AboveCell, False, False)
                    e.Handled = True
                    .PerformAction(EnterEditMode, False, False)
                Case Keys.Down
                    .PerformAction(ExitEditMode, False, False)
                    .PerformAction(BelowCell, False, False)
                    e.Handled = True
                    .PerformAction(EnterEditMode, False, False)
            End Select
        End With
    End Sub

    Private Sub Grilla_Plan_Recurso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid3.KeyPress, Grid6.KeyPress, Grid9.KeyPress, Grid12.KeyPress
        Dim KeyAscii As Integer = 0
        Dim saltar As Boolean = Boolean.FalseString
        If sender Is Nothing Then Return
        If e Is Nothing Then Return
        If sender.ActiveRow Is Nothing Then Return
        If sender.Rows.Count <= 0 Then Return
        KeyAscii = Asc(e.KeyChar)
        With sender
            If KeyAscii = Keys.Enter Then

                If sender Is Grid3 Then
                    If Calcular_Disponible(TipoRecurso.sMaterial, sender.ActiveRow.cells("Codigo").value, Val(sender.ActiveRow.cells("Cantidad").Text), Val(sender.ActiveRow.cells("Cantidad").Value)) = False Then
                        e.KeyChar = Chr(0)
                        'sender.ActiveRow.Cells("Cantidad").Text = 0
                        sender.ActiveRow.Cells("Cantidad").value = 0
                    Else
                        saltar = Boolean.TrueString
                    End If
                ElseIf sender Is Grid6 Then
                    If Calcular_Disponible(TipoRecurso.sEquipo, sender.ActiveRow.cells("Codigo").value, Val(sender.ActiveRow.cells("Cantidad").Text), Val(sender.ActiveRow.cells("Cantidad").Value)) = False Then
                        e.KeyChar = Chr(0)
                        'sender.ActiveRow.Cells("Cantidad").Text = 0
                        sender.ActiveRow.Cells("Cantidad").value = 0
                    Else
                        saltar = Boolean.TrueString
                    End If

                ElseIf sender Is Grid9 Then
                    If Calcular_Disponible(TipoRecurso.sCargo, sender.ActiveRow.cells("Codigo").value, Val(sender.ActiveRow.cells("Cantidad").Text), Val(sender.ActiveRow.cells("Cantidad").Value)) = False Then
                        e.KeyChar = Chr(0)
                        ' sender.ActiveRow.Cells("Cantidad").Text = 0
                        sender.ActiveRow.Cells("Cantidad").value = 0
                    Else
                        saltar = Boolean.TrueString
                    End If

                ElseIf sender Is Grid12 Then
                    If Calcular_Disponible(TipoRecurso.sServicio, sender.ActiveRow.cells("Codigo").value, Val(sender.ActiveRow.cells("Cantidad").Text), Val(sender.ActiveRow.cells("Cantidad").Value)) = False Then
                        e.KeyChar = Chr(0)
                        'sender.ActiveRow.Cells("Cantidad").Text = 0
                        sender.ActiveRow.Cells("Cantidad").value = 0
                    Else
                        saltar = Boolean.TrueString
                    End If
                End If

                If saltar = Boolean.TrueString Then
                    .PerformAction(ExitEditMode, False, False)
                    .PerformAction(BelowCell, False, False)
                    .PerformAction(EnterEditMode, False, False)
                End If

            Else
                If .ActiveRow.Cells("Entero").Value = True Then
                    KeyAscii = ValidarEntero(KeyAscii)
                Else
                    KeyAscii = ValidarDecimal(KeyAscii, sender.ActiveRow.Cells("Cantidad").Text)
                End If
                e.KeyChar = Chr(KeyAscii)


            End If
        End With
    End Sub


#End Region

#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim Planificado As Decimal = Decimal.Zero
        Dim Msg_Error As String = String.Empty
        Dim PlanError As Integer = 0
        Dim Retornar As Integer = 0

        Call Actualizar_Grilla_PlanMat()
        Call Actualizar_Grilla_PlanEq()
        Call Actualizar_Grilla_PlanMO()
        Call Actualizar_Grilla_PlanSer()

        For Each mRow As ETPresupuestoMaterial In Ls_Material
            Planificado = 0
            For Each mpRow As ETPresupuestoPlanRecursos In _Ls_PlanMaterial
                If mRow.Cod_Mat = mpRow.Codigo Then
                    Planificado = Planificado + mpRow.Cantidad
                End If
                mpRow.Usuario = User_Sistema
            Next

            If mRow.Cantidad < Planificado Then
                mRow.Planificado = Planificado
                mRow.Disponible = mRow.Cantidad - Planificado
                PlanError = PlanError + 1
            End If
        Next

        If PlanError > 0 Then
            Retornar = Retornar + 1
            Msg_Error = "Material: Cantidad Presupuestada Excede a la Cantidad Planificada"
        End If

        PlanError = 0
        For Each mRow As ETPresupuestoEquipo In Ls_Equipo
            Planificado = 0
            For Each mpRow As ETPresupuestoPlanRecursos In _Ls_PlanEquipo
                If mRow.EquipoID = mpRow.Recurso Then
                    Planificado = Planificado + mpRow.Cantidad
                End If
                mpRow.Usuario = User_Sistema
            Next

            If mRow.Cantidad < Planificado Then
                mRow.Planificado = Planificado
                mRow.Disponible = mRow.Cantidad - Planificado
                PlanError = PlanError + 1
            End If
        Next
        If PlanError > 0 Then
            Retornar = Retornar + 1
            If Msg_Error.ToString.Length <= 0 Then
                Msg_Error = "Equipo: Cantidad Presupuestada Excede a la Cantidad Planificada"
            Else
                Msg_Error = Msg_Error & Chr(13) & "Equipo: Cantidad Presupuestada Excede a la Cantidad Planificada"
            End If
        End If

        PlanError = 0
        For Each mRow As ETPresupuestoManoObra In Ls_ManoObra
            Planificado = 0
            For Each mpRow As ETPresupuestoPlanRecursos In _Ls_PlanManoObra
                If mRow.Cod_Cargo = mpRow.Codigo Then
                    Planificado = Planificado + mpRow.Cantidad
                End If
                mpRow.Usuario = User_Sistema
            Next

            If mRow.Cantidad < Planificado Then
                mRow.Planificado = Planificado
                mRow.Disponible = mRow.Cantidad - Planificado
                PlanError = PlanError + 1
            End If
        Next
        If PlanError > 0 Then
            Retornar = Retornar + 1
            If Msg_Error.ToString.Length <= 0 Then
                Msg_Error = "Mano Obra: Cantidad Presupuestada Excede a la Cantidad Planificada"
            Else
                Msg_Error = Msg_Error & Chr(13) & "Mano Obra: Cantidad Presupuestada Excede a la Cantidad Planificada"
            End If
        End If

        PlanError = 0
        For Each mRow As ETPresupuestoServicio In Ls_Servicio
            Planificado = 0
            For Each mpRow As ETPresupuestoPlanRecursos In _Ls_PlanServicio
                If mRow.Cod_Ser = mpRow.Codigo Then
                    Planificado = Planificado + mpRow.Cantidad
                End If
                mpRow.Usuario = User_Sistema
            Next

            If mRow.Cantidad < Planificado Then
                mRow.Planificado = Planificado
                mRow.Disponible = mRow.Cantidad - Planificado
                PlanError = PlanError + 1
            End If
        Next

        If PlanError > 0 Then
            Retornar = Retornar + 1
            If Msg_Error.ToString.Length <= 0 Then
                Msg_Error = "Mano Obra: Cantidad Presupuestada Excede a la Cantidad Planificada"
            Else
                Msg_Error = Msg_Error & Chr(13) & "Mano Obra: Cantidad Presupuestada Excede a la Cantidad Planificada"
            End If
        End If

        If Retornar > 0 Then
            MsgBox(Msg_Error, MsgBoxStyle.Critical, msgComacsa)
        Else
            Me.Close()
        End If
    End Sub
#End Region


End Class