
Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmMPlantillaAPU
#Region "Declarar Variables Privadas"
    Public Ls_Permisos As New List(Of Integer)

    Private Enum eNivel
        ePlantillaAPU = 0
        eLinNeg = 1
        eTipoMantto = 2
        eMantenimiento = 3
        eEquipo = 4
        eParteEq = 5
    End Enum
    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
        eSave = 5
    End Enum
    Private Enum eBuscar
        eMaterial = 1
        eEquipo = 2
        eManoObra = 3
        eServicio = 4
    End Enum
    Private Enum ValorTipoDato
        vTexto = 1
        vEntero = 2
        vDecimal = 3
        vDate = 4
        vTime = 5
    End Enum

    Dim TipoDato As ValorTipoDato

    Private TipoG As eState
    Private TipoG_DetMat As eState
    Private TipoG_DetEq As eState
    Private TipoG_DetMO As eState
    Private TipoG_DetSer As eState
    Private Buscar_Part As eBuscar

    Private nNode As eNivel
    Private _NodoPadre As Long = 0
    Private _NodoRaiz As Long = 0
    Private _Nodo As Long = 0
    Private _LinNeg As String = String.Empty
    Private _TipoMantto As String = String.Empty
    Private _ManttoValor As Double = 0
    Private _ManttoAtributo As Long = 0
    Private _Equipo As Long = 0
    Private _General As Boolean = Boolean.FalseString
    Private _ParteEquipo As Long = 0
    Private _DescripNodePadre As String = String.Empty
    Private _DescripNode As String = String.Empty
    Private _FamiliaEq As Long = 0
    Private _TipoFactor As String = String.Empty
    Private _Factor As Double = 0
    Private _Jornada As Double = 0
    Private _UniMed As String = String.Empty
    Private _Descrip_UniMed As String = String.Empty
    Private _Total_Part As Double = 0
    Private _AddPartida As Boolean = Boolean.FalseString
    Private _Part_Descrip As String = String.Empty

    Private _Det_Mat As String = String.Empty
    Private _Det_Eq As Long = 0
    Private _Det_Eq_New As Long = 0
    Private _Det_MO As String = String.Empty
    Private _Det_Ser As String = String.Empty
    Private _Nro_OC_Mat As String = String.Empty
    Private _Nro_OC_Ser As String = String.Empty

    Private _Atributo_Input As Long = 0
    Private _Valor_Input As String = String.Empty
    Private _TipoMantto_Input As String = String.Empty

    Private _Atributo_Mantto As Long = 0
    Private _Valor_Mantto As String = String.Empty
    Private _TipoMantto_Mantto As String = String.Empty

    Private dataSetArbol As DataSet
    Private Ls_Material As List(Of ETPartidaMaterial) = Nothing
    Private Ls_Material_Del As List(Of ETPartidaMaterial) = Nothing
    Private Ls_Equipo As List(Of ETPartidaEquipo) = Nothing
    Private Ls_Equipo_Del As List(Of ETPartidaEquipo) = Nothing
    Private Ls_ManoObra As List(Of ETPartidaManoObra) = Nothing
    Private Ls_ManoObra_Del As List(Of ETPartidaManoObra) = Nothing
    Private Ls_Servicio As List(Of ETPartidaServicio) = Nothing
    Private Ls_Servicio_Del As List(Of ETPartidaServicio) = Nothing

    Private _Part_Presupuesto As Boolean = Boolean.FalseString

#End Region
#Region "Propiedades Publicas"
    Public Property Part_Presupuesto() As Boolean
        Get
            Return _Part_Presupuesto
        End Get
        Set(ByVal value As Boolean)
            _Part_Presupuesto = value
        End Set
    End Property
    Public ReadOnly Property Part_Descripcion() As String
        Get
            Return _Part_Descrip
        End Get
    End Property
    Public ReadOnly Property Partida() As Long
        Get
            Return _Nodo
        End Get
    End Property
    Public ReadOnly Property Part_TipoFactor()
        Get
            Return _TipoFactor
        End Get
    End Property
    Public ReadOnly Property Part_Factor() As Double
        Get
            Return _Factor
        End Get
    End Property
    Public ReadOnly Property Part_Jornada() As Double
        Get
            Return _Jornada
        End Get
    End Property
    Public ReadOnly Property Part_UniMed() As String
        Get
            Return _UniMed
        End Get
    End Property
    Public ReadOnly Property AddPartida() As Boolean
        Get
            Return _AddPartida
        End Get
    End Property
    Public Property Part_DescripUniMed() As String
        Get
            Return _Descrip_UniMed
        End Get
        Set(ByVal value As String)
            _Descrip_UniMed = value
        End Set
    End Property
    Public Property Part_Total() As Double
        Get
            Return _Total_Part
        End Get
        Set(ByVal value As Double)
            _Total_Part = value
        End Set
    End Property
    Public Property Atributo_Input() As Long
        Get
            Return _Atributo_Input
        End Get
        Set(ByVal value As Long)
            _Atributo_Input = value
        End Set
    End Property
    Public Property Valor_Input() As String
        Get
            Return _Valor_Input
        End Get
        Set(ByVal value As String)
            _Valor_Input = value
        End Set
    End Property
    Public Property TipoMantto_Input() As String
        Get
            Return _TipoMantto_Input
        End Get
        Set(ByVal value As String)
            _TipoMantto_Input = value
        End Set
    End Property
    Public Property Atributo_Mantto() As Long
        Get
            Return _Atributo_Mantto
        End Get
        Set(ByVal value As Long)
            _Atributo_Mantto = value
        End Set
    End Property
    Public Property Valor_Mantto() As String
        Get
            Return _Valor_Mantto
        End Get
        Set(ByVal value As String)
            _Valor_Mantto = value
        End Set
    End Property
    Public Property TipoMantto_Mantto() As String
        Get
            Return _TipoMantto_Mantto
        End Get
        Set(ByVal value As String)
            _TipoMantto_Mantto = value
        End Set
    End Property
#End Region

#Region "Propiedades"
    Private Property Nodo() As Long
        Get
            Return _Nodo
        End Get
        Set(ByVal value As Long)
            _Nodo = value
        End Set
    End Property
    Private Property NodoPadre() As Long
        Get
            Return _NodoPadre
        End Get
        Set(ByVal value As Long)
            _NodoPadre = value
        End Set
    End Property
    Private Property NodoRaiz() As Long
        Get
            Return _NodoRaiz
        End Get
        Set(ByVal value As Long)
            _NodoRaiz = value
        End Set
    End Property
    Private Property DescripNodoPadre() As String
        Get
            Return _DescripNodePadre
        End Get
        Set(ByVal value As String)
            _DescripNodePadre = value
        End Set
    End Property
    Private Property DescripNodo() As String
        Get
            Return _DescripNode
        End Get
        Set(ByVal value As String)
            _DescripNode = value
        End Set
    End Property
    Private Property FamiliaEq() As Long
        Get
            Return _FamiliaEq
        End Get
        Set(ByVal value As Long)
            _FamiliaEq = value
        End Set
    End Property
    Private Property Det_Mat() As String
        Get
            Return _Det_Mat
        End Get
        Set(ByVal value As String)
            _Det_Mat = value
        End Set
    End Property
    Private Property Det_Eq() As Long
        Get
            Return _Det_Eq
        End Get
        Set(ByVal value As Long)
            _Det_Eq = value
        End Set
    End Property
    Private Property Det_Eq_New() As Long
        Get
            Return _Det_Eq_New
        End Get
        Set(ByVal value As Long)
            _Det_Eq_New = value
        End Set
    End Property
    Private Property Det_MO() As String
        Get
            Return _Det_MO
        End Get
        Set(ByVal value As String)
            _Det_MO = value
        End Set
    End Property
    Private Property Det_Ser() As String
        Get
            Return _Det_Ser
        End Get
        Set(ByVal value As String)
            _Det_Ser = value
        End Set
    End Property
    Public Property Nro_OC_Mat() As String
        Get
            Return _Nro_OC_Mat
        End Get
        Set(ByVal value As String)
            _Nro_OC_Mat = value
        End Set
    End Property
    Public Property Nro_OC_Ser() As String
        Get
            Return _Nro_OC_Ser
        End Get
        Set(ByVal value As String)
            _Nro_OC_Ser = value
        End Set
    End Property
    Private Property TipoFactor() As String
        Get
            Return _TipoFactor
        End Get
        Set(ByVal value As String)
            _TipoFactor = value
        End Set
    End Property
    Private Property Factor() As Double
        Get
            Return _Factor
        End Get
        Set(ByVal value As Double)
            _Factor = value
        End Set
    End Property
    Private Property Jornada() As Double
        Get
            Return _Jornada
        End Get
        Set(ByVal value As Double)
            _Jornada = value
        End Set
    End Property
    Private Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
        End Set
    End Property
    Private Property TipoMantto() As String
        Get
            Return _TipoMantto
        End Get
        Set(ByVal value As String)
            _TipoMantto = value
        End Set
    End Property
#End Region
#Region "Procedimientos Privados"
    Private Sub InicializarValores()
        _LinNeg = String.Empty
        _ManttoValor = 0
        _ManttoAtributo = 0
        _Equipo = 0
        _General = Boolean.FalseString
        _ParteEquipo = 0
    End Sub
    Private Sub VisualizarNodo(ByVal Nivel As eNivel)
        UltraLabel33.Visible = Boolean.FalseString
        UltraLabel34.Visible = Boolean.FalseString
        UltraLabel35.Visible = Boolean.FalseString
        UltraLabel36.Visible = Boolean.FalseString
        TxtN2.Visible = Boolean.FalseString
        TxtN3.Visible = Boolean.FalseString
        Cbo1.Visible = Boolean.FalseString
        Cbo2.Visible = Boolean.FalseString
        Cbo3.Visible = Boolean.FalseString
        Cbo4.Visible = Boolean.FalseString
        Chk1.Visible = Boolean.FalseString
        Btn1.Visible = Boolean.FalseString
        TxtN4.Visible = Boolean.FalseString

        Select Case Nivel
            Case eNivel.eLinNeg
                UltraLabel33.Visible = Boolean.TrueString
                Cbo1.Visible = Boolean.TrueString
            Case eNivel.eTipoMantto
                UltraLabel34.Visible = Boolean.TrueString
                Cbo2.Visible = Boolean.TrueString
            Case eNivel.eMantenimiento
                UltraLabel35.Visible = Boolean.TrueString
                Cbo3.Visible = Boolean.TrueString
                TxtN2.Visible = Boolean.TrueString
            Case eNivel.eEquipo
                UltraLabel36.Visible = Boolean.TrueString
                TxtN3.Visible = Boolean.TrueString
                Btn1.Visible = Boolean.TrueString
            Case eNivel.eParteEq
                Chk1.Visible = Boolean.TrueString
                Cbo4.Visible = Boolean.TrueString
        End Select
    End Sub
    Private Sub HabilitarControlNodo(ByVal b As Boolean, ByVal Level As eNivel)
        TxtN2.ReadOnly = Boolean.TrueString
        TxtN3.ReadOnly = Boolean.TrueString
        Cbo1.ReadOnly = Boolean.TrueString
        Cbo2.ReadOnly = Boolean.TrueString
        Cbo3.ReadOnly = Boolean.TrueString
        Cbo4.ReadOnly = Boolean.TrueString
        Chk1.Enabled = Boolean.FalseString
        Btn1.Enabled = Boolean.FalseString
        Grb3.Enabled = False
        Select Case Level
            Case eNivel.eLinNeg
                Cbo1.ReadOnly = Not b
            Case eNivel.eTipoMantto
                Cbo2.ReadOnly = Not b
            Case eNivel.eMantenimiento
                Cbo3.ReadOnly = Not b
                TxtN2.ReadOnly = Not b
                TxtN4.ReadOnly = Not b
            Case eNivel.eEquipo
                Btn1.Enabled = b
            Case eNivel.eParteEq
                Chk1.Enabled = b
                Cbo4.ReadOnly = Not b
        End Select
    End Sub
    Private Sub Limpiar()
        Call InicializarValores()
        Me.TxtN1.Clear()
        Me.TxtN2.Clear()
        Me.TxtN3.Clear()
        Me.TxtN4.Text = ""
        If Cbo1.Rows.Count > 0 Then Me.Cbo1.Value = ""
        Me.Cbo2.Value = ""
        If Cbo1.Rows.Count > 0 Then Me.Cbo3.Value = ""
        If Cbo1.Rows.Count > 0 Then Me.Cbo4.Value = ""
        Me.Chk1.Checked = False
        Me.TxtF1.Text = ""
        Me.TxtF2.Text = ""
        Call LimpiarPartida()
    End Sub
    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As Infragistics.Win.UltraWinTree.UltraTreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.

        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New Infragistics.Win.UltraWinTree.UltraTreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.DataKey = dataRowCurrent("IdentificadorNodo").ToString().Trim()

            Select Case CInt(dataRowCurrent("Level").ToString)
                Case 0
                    nuevoNodo.LeftImages.Add(My.Resources.home)
                Case 1
                    nuevoNodo.LeftImages.Add(My.Resources.LinNeg)
                Case 2
                    nuevoNodo.LeftImages.Add(My.Resources.TipoMantto)
                Case 3
                    nuevoNodo.LeftImages.Add(My.Resources.Mantto)
                Case 4
                    nuevoNodo.LeftImages.Add(My.Resources.familiaEq)
                Case 5
                    nuevoNodo.LeftImages.Add(My.Resources.parte_equipo)
            End Select
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                Tree1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent

    End Sub

    Private Sub CargarDatos_Mantto(ByVal Level As eNivel, ByVal Node_Sel As Long)

        Dim dataViewHijos As DataView

        dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))
        dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorNodo").ColumnName + " = " + Node_Sel.ToString()

        For Each dataRowCurrent As DataRowView In dataViewHijos
            Call VisualizarNodo(Level)
            Select Case Level
                Case eNivel.eTipoMantto
                    TipoMantto_Mantto = dataRowCurrent("TipoProceso").ToString().Trim()
                Case eNivel.eMantenimiento
                    Atributo_Mantto = dataRowCurrent("AtributoControlador").ToString().Trim()
                    Valor_Mantto = dataRowCurrent("ValorControlador").ToString().Trim()
            End Select
        Next dataRowCurrent

    End Sub

    Private Sub CargarDatosNodo(ByVal Level As eNivel, ByVal Node_Sel As Long)

        Dim dataViewHijos As DataView
        Dim dataViewLevel4 As DataView

        dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))
        dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorNodo").ColumnName + " = " + Nodo.ToString()

        _TipoFactor = String.Empty
        _Factor = 0
        _Jornada = 0
        _UniMed = String.Empty
        _TipoMantto = String.Empty
        _Total_Part = 0

        For Each dataRowCurrent As DataRowView In dataViewHijos
            Call VisualizarNodo(Level)
            Select Case Level
                Case eNivel.eLinNeg
                    Call Cargar_LinNeg()
                    Me.Cbo1.Value = dataRowCurrent("CodLinNeg").ToString().Trim()
                Case eNivel.eTipoMantto
                    Me.Cbo2.Value = dataRowCurrent("TipoProceso").ToString().Trim()
                    TipoMantto = Cbo2.Value
                Case eNivel.eMantenimiento
                    Call CargarAtributo()

                    If Val(dataRowCurrent("AtributoControlador")) > 0 Then
                        Me.Cbo3.Visible = True
                        Me.Cbo3.Value = dataRowCurrent("AtributoControlador").ToString().Trim()
                        Me.TipoDato = Cbo3.ActiveRow.Cells("TipoDato").Value
                        Select Case TipoDato
                            Case ValorTipoDato.vDate, ValorTipoDato.vTime
                                Me.TxtN4.Text = dataRowCurrent("ValorControlador").ToString().Trim()
                            Case Else
                                Me.TxtN2.Text = dataRowCurrent("ValorControlador").ToString().Trim()
                        End Select
                        TxtN2.Width = 86
                        TipoMantto = "1"
                    Else
                        Me.Cbo3.Visible = False
                        Me.TxtN2.Text = dataRowCurrent("ValorControlador").ToString().Trim()
                        TxtN2.Width = 196
                        TipoMantto = "2"
                    End If

                Case eNivel.eEquipo
                    Me.TxtN3.Text = dataRowCurrent("Descripcion").ToString().Trim()
                    Me.FamiliaEq = dataRowCurrent("FamiliaEquipoID").ToString().Trim()
                Case eNivel.eParteEq
                    Me.Chk1.Checked = dataRowCurrent("ManttoGeneral")
                    TipoFactor = dataRowCurrent("TipoFactor").ToString.Trim
                    Factor = dataRowCurrent("Factor")
                    Jornada = dataRowCurrent("Jornada")
                    UniMed = dataRowCurrent("UnidadMedida")
                    _Part_Descrip = dataRowCurrent("Descripcion")

                    If Part_Presupuesto = False Then
                        Part_Total = dataRowCurrent("Total")
                    Else
                        Part_Total = Val(Txt27.Text)
                    End If
                    If Cbo5.Rows.Count > 0 Then
                        Cbo5.Value = UniMed
                        Part_DescripUniMed = Cbo5.Text
                    End If
                    If Me.Chk1.Checked = Boolean.FalseString Then
                        dataViewLevel4 = New DataView(dataSetArbol.Tables("TablaArbol"))
                        dataViewLevel4.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorNodo").ColumnName + " = " + dataRowCurrent("IdentificadorPadre").ToString().Trim()
                        For Each dataRowCurrent1 As DataRowView In dataViewLevel4
                            NodoRaiz = dataRowCurrent1("IdentificadorPadre")
                            Me.FamiliaEq = dataRowCurrent1("FamiliaEquipoID")
                        Next
                        'NodoRaiz = dataRowCurrent("IdentificadorPadre").ToString().Trim()

                        Call CargarParteEquipo()
                        Me.Cbo4.Value = dataRowCurrent("ParteEquipoID").ToString().Trim()
                    Else
                        If Cbo4.Rows.Count > 0 Then Cbo4.Value = ""
                    End If
            End Select
            Me.TxtN1.Text = DescripNodoPadre
        Next dataRowCurrent

    End Sub
    Private Sub CargarTree()
        Negocio.Partida_Mantto = New NGPartida
        dataSetArbol = Negocio.Partida_Mantto.Consultar_Partida
        Tree1.Nodes.Clear()
        Call CrearNodosDelPadre(-1, Nothing)
    End Sub
    Private Sub Cargar_LinNeg()
        Dim Ls_LinNeg As New List(Of ETLineaNegocio)
        Entidad.MyLista = New ETMyLista
        Negocio.LineaNegocio = New NGLineaNegocio
        Entidad.MyLista = Negocio.LineaNegocio.ConsultarLineaNegocio_Activos

        If Entidad.MyLista.Validacion Then
            Ls_LinNeg = Entidad.MyLista.Ls_LinNeg
        End If

        Call CargarUltraCombo(Me.Cbo1, Ls_LinNeg, "IDCatalogo", "Descripcion", String.Empty)

    End Sub
    Private Sub CargarAtributo()
        Dim ds As DataSet
        Entidad.Partida_Mantto = New ETPartida
        With Entidad.Partida_Mantto
            .Tipo = 6
            If TipoG = eState.eNew Then
                .Partida = NodoRaiz
            Else
                .Partida = Nodo
            End If
        End With
        Negocio.Partida_Mantto = New NGPartida
        ds = Negocio.Partida_Mantto.Consultar_Partida_Nodo(Entidad.Partida_Mantto)
        Call CargarUltraCombo(Cbo3, ds, "IDCatalogo", "descripcion")
    End Sub
    Private Sub CargarParteEquipo()
        Dim ds As DataSet
        Entidad.Partida_Mantto = New ETPartida
        With Entidad.Partida_Mantto
            .Tipo = 9
            If TipoG = eState.eNew Then
                .Partida = NodoPadre
            Else
                .Partida = NodoRaiz
            End If
            .FamiliaEquipo = Me.FamiliaEq
        End With
        Negocio.Partida_Mantto = New NGPartida
        ds = Negocio.Partida_Mantto.Consultar_Partida_Nodo(Entidad.Partida_Mantto)
        Call CargarUltraCombo(Cbo4, ds, "IDCatalogo", "Descripcion")
    End Sub
    Private Sub Iniciar()
        Call CargarUnidadMedida()
        Call Iniciar2()

    End Sub
    Private Sub Iniciar2()
        Me.Grb2.Expanded = False
        Call CargarTree()
        Tree1.ExpandAll()
        Cbo6.ReadOnly = True
        Cbo7.ReadOnly = True
        Cbo8.ReadOnly = True
        Cbo9.ReadOnly = True
    End Sub
    Private Sub GrabarNodo()
        Entidad.Partida_Mantto = New ETPartida
        With Entidad.Partida_Mantto
            .Tipo = TipoG
            Select Case nNode
                Case eNivel.eLinNeg
                    If Cbo1.Rows.Count > 0 Then
                        If Not (Cbo1.ActiveRow Is Nothing) Then
                            .LinNeg = Cbo1.Value
                            .Descripcion = Cbo1.ActiveRow.Cells("Codigo").Value & " - " & Cbo1.ActiveRow.Cells("Descripcion").Value
                        End If
                    End If
                Case eNivel.eTipoMantto
                    .TipoProceso = CInt(Val(Cbo2.Value))
                    .Descripcion = Cbo2.Text

                Case eNivel.eMantenimiento
                    If ValidarMantto() = False Then
                        Entidad.Partida_Mantto = Nothing
                        Return
                    End If
                    'If Cbo2.Value = "1" Then
                    If Cbo3.Visible = True Then
                        .AtributoControl = Cbo3.Value
                        .TipoProceso = "1"
                    Else
                        .TipoProceso = "2"
                    End If
                    Select Case TipoDato
                        Case ValorTipoDato.vDate, ValorTipoDato.vTime
                            .ValorControl = TxtN4.Text
                            .Descripcion = TxtN4.Text & " " & Cbo3.ActiveRow.Cells("UniMed").Value
                        Case Else
                            If Cbo3.Visible = True Then
                                .ValorControl = TxtN2.Text
                                .Descripcion = TxtN2.Text & " " & Cbo3.ActiveRow.Cells("UniMed").Value
                            Else
                                .ValorControl = TxtN2.Text
                                .Descripcion = TxtN2.Text
                            End If
                    End Select
                    'Else
                    '.ValorControl = TxtN2.Text
                    '.Descripcion = TxtN2.Text
                    'End If

                Case eNivel.eEquipo
                    .FamiliaEquipo = Me.FamiliaEq
                    .Descripcion = TxtN3.Text
                Case eNivel.eParteEq
                    .ManttoGeneral = Chk1.Checked
                    If Chk1.Checked = True Then
                        .Descripcion = Chk1.Text
                    Else
                        .ParteEquipo = Cbo4.Value
                        .Descripcion = Cbo4.ActiveRow.Cells("Codigo").Value & " " & Cbo4.ActiveRow.Cells("Descripcion").Value
                    End If
                    If Chk2.Checked = True Then
                        If Rbn1.Checked = True Then
                            .TipoFactor = "1"
                        Else
                            .TipoFactor = "2"
                        End If
                    Else
                        .TipoFactor = "0"
                        TxtF1.Text = 1
                        TxtF2.Text = 1
                    End If
                    .Total = Val(Me.Txt27.Text)
                    .Factor = Val(Me.TxtF1.Text)
                    .Jornada = Val(Me.TxtF2.Text)
                    .UniMed = Cbo5.Value
            End Select
            .Level = nNode
            If TipoG = eState.eNew Then
                .PartidaPadre = Nodo
            Else
                .Partida = Nodo
                .PartidaPadre = NodoPadre
            End If
            .Usuario = User_Sistema
            .Status = String.Empty
        End With

        Try
            Negocio.Partida_Mantto = New NGPartida
            If TipoG = eState.eNew Then
                Negocio.Partida_Mantto.Mantenedor_Partida(Entidad.Partida_Mantto)
            Else
                If Not (nNode = eNivel.eParteEq) Then
                    Negocio.Partida_Mantto.Mantenedor_Partida(Entidad.Partida_Mantto)
                Else
                    Negocio.Partida_Mantto.Mantenedor_Partida_Recursos(Entidad.Partida_Mantto, Ls_Material, Ls_Material_Del, _
                    Ls_Equipo, Ls_Equipo_Del, Ls_ManoObra, Ls_ManoObra_Del, Ls_Servicio, Ls_Servicio_Del)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try

        Call Iniciar2()

    End Sub
    Private Sub IniciliazarDetalle()
        _Det_Mat = String.Empty
        _Det_Eq = 0
        _Det_Eq_New = 0
        _Det_MO = String.Empty
        _Det_Ser = String.Empty
        _Nro_OC_Mat = String.Empty
        _Nro_OC_Ser = String.Empty
    End Sub
    Private Sub Limpiar_Listas_Recursos_Partida()
        Ls_Material = Nothing
        Ls_Material = New List(Of ETPartidaMaterial)
        Ls_Material_Del = Nothing
        Ls_Material_Del = New List(Of ETPartidaMaterial)

        Ls_Equipo = Nothing
        Ls_Equipo = New List(Of ETPartidaEquipo)
        Ls_Equipo = Nothing
        Ls_Equipo_Del = New List(Of ETPartidaEquipo)

        Ls_ManoObra = Nothing
        Ls_ManoObra = New List(Of ETPartidaManoObra)
        Ls_ManoObra_Del = Nothing
        Ls_ManoObra_Del = New List(Of ETPartidaManoObra)

        Ls_Servicio = Nothing
        Ls_Servicio = New List(Of ETPartidaServicio)
        Ls_Servicio_Del = Nothing
        Ls_Servicio_Del = New List(Of ETPartidaServicio)
    End Sub
    Private Sub LimpiarPartida()
        Call IniciliazarDetalle()

        Call Limpiar_Listas_Recursos_Partida()
        Call LimpiarMateriales()
        Call LimpiarEquipos()
        Call LimpiarManoObra()
        Call LimpiarServicios()

        Call CargarUltraGrid(Grid1, Ls_Material)
        Call CargarUltraGrid(Grid2, Ls_Equipo)
        Call CargarUltraGrid(Grid3, Ls_ManoObra)
        Call CargarUltraGrid(Grid4, Ls_Servicio)

        Me.Txt6.Text = "0.0000"
        Me.Txt13.Text = "0.0000"
        Me.Txt20.Text = "0.0000"
        Me.Txt26.Text = "0.0000"
        Me.Txt27.Text = "0.0000"
        TipoG_DetMat = eState.eView
        TipoG_DetEq = eState.eView
        TipoG_DetMO = eState.eView
        TipoG_DetSer = eState.eView

        _TipoMantto_Mantto = String.Empty
        _Valor_Mantto = String.Empty
        _Atributo_Mantto = 0
    End Sub
    Private Sub LimpiarMateriales()
        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Txt3.Clear()
        Me.Txt4.Clear()
        Me.Txt5.Clear()

        If Cbo6.Rows.Count > 0 Then Cbo6.Value = ""
    End Sub
    Private Sub LimpiarEquipos()
        Me.Txt7.Clear()
        Me.Txt8.Clear()
        Me.Txt9.Clear()
        Me.Txt10.Clear()
        Me.Txt11.Clear()
        Me.Txt12.Clear()
        If Cbo7.Rows.Count > 0 Then Cbo7.Value = ""
    End Sub
    Private Sub LimpiarManoObra()
        Me.Txt14.Clear()
        Me.Txt15.Clear()
        Me.Txt16.Clear()
        Me.Txt17.Clear()
        Me.Txt18.Clear()
        Me.Txt19.Clear()
        If Cbo8.Rows.Count > 0 Then Cbo8.Value = ""
    End Sub
    Private Sub LimpiarServicios()
        Me.Txt21.Clear()
        Me.Txt22.Clear()
        Me.Txt23.Clear()
        Me.Txt24.Clear()
        Me.Txt25.Clear()
        If Cbo9.Rows.Count > 0 Then Cbo9.Value = ""
    End Sub
    Private Sub CargarUnidadMedida()
        Dim Ls_Combo As List(Of ETUnidadMedida)
        Negocio.UnidadMedida = New NGUnidadMedida
        Entidad.MyLista = New ETMyLista

        Ls_Combo = New List(Of ETUnidadMedida)

        Entidad.MyLista = Negocio.UnidadMedida.ConsultarUnidadMedida

        If Entidad.MyLista.Validacion Then
            Ls_Combo = Entidad.MyLista.Ls_UnidadMedida
        End If

        Call CargarUltraCombo(Me.Cbo5, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo6, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo7, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo8, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo9, Ls_Combo, "Codigo", "Descripcion", String.Empty)

    End Sub
    Private Sub HabilitarBotonesDet(ByVal Recurso As eBuscar)
        Select Case Recurso
            Case eBuscar.eMaterial
                Det_Mat = String.Empty
                Select Case TipoG_DetMat
                    Case eState.eNew, eState.eEdit
                        Btn3.Enabled = True
                        Btn4.Enabled = True
                        Btn5.Enabled = True
                        Btn6.Enabled = False
                        Btn7.Enabled = False
                        Txt3.ReadOnly = False
                    Case Else
                        Btn3.Enabled = False
                        Btn4.Enabled = True
                        Btn5.Enabled = False
                        Btn6.Enabled = True
                        Btn7.Enabled = True
                        Txt3.ReadOnly = True
                End Select
            Case eBuscar.eEquipo
                Det_Eq = 0
                Select Case TipoG_DetEq
                    Case eState.eNew, eState.eEdit
                        Btn8.Enabled = True
                        Btn9.Enabled = True
                        Btn10.Enabled = True
                        Btn11.Enabled = False
                        Btn12.Enabled = False
                        Txt9.ReadOnly = False

                    Case Else
                        Btn8.Enabled = False
                        Btn9.Enabled = True
                        Btn10.Enabled = False
                        Btn11.Enabled = True
                        Btn12.Enabled = True
                        Txt9.ReadOnly = True

                End Select
            Case eBuscar.eManoObra
                Det_MO = String.Empty
                Select Case TipoG_DetMO
                    Case eState.eNew, eState.eEdit
                        Btn13.Enabled = True
                        Btn14.Enabled = True
                        Btn15.Enabled = True
                        Btn16.Enabled = False
                        Btn17.Enabled = False
                        Txt16.ReadOnly = False

                    Case Else
                        Btn13.Enabled = False
                        Btn14.Enabled = True
                        Btn15.Enabled = False
                        Btn16.Enabled = True
                        Btn17.Enabled = True
                        Txt16.ReadOnly = True

                End Select
            Case eBuscar.eServicio
                Det_Ser = String.Empty
                Select Case TipoG_DetSer
                    Case eState.eNew, eState.eEdit
                        Btn18.Enabled = True
                        Btn19.Enabled = True
                        Btn20.Enabled = True
                        Btn21.Enabled = False
                        Btn22.Enabled = False
                        Txt23.ReadOnly = False
                    Case Else
                        Btn18.Enabled = False
                        Btn19.Enabled = True
                        Btn20.Enabled = False
                        Btn21.Enabled = True
                        Btn22.Enabled = True
                        Txt23.ReadOnly = True
                End Select
        End Select

    End Sub
    Private Sub CalcularTotal()
        Dim SubTotal_Mat As Double = 0
        Dim SubTotal_Eq As Double = 0
        Dim SubTotal_MO As Double = 0
        Dim SubTotal_Ser As Double = 0

        If Not (Ls_Material Is Nothing) Then
            For Each Row As ETPartidaMaterial In Ls_Material
                SubTotal_Mat = SubTotal_Mat + Row.SubTotal
            Next
        End If
        If Not (Ls_Equipo Is Nothing) Then
            For Each Row As ETPartidaEquipo In Ls_Equipo
                SubTotal_Eq = SubTotal_Eq + Row.SubTotal
            Next
        End If
        If Not (Ls_ManoObra Is Nothing) Then
            For Each Row As ETPartidaManoObra In Ls_ManoObra
                SubTotal_MO = SubTotal_MO + Row.SubTotal
            Next
        End If
        If Not (Ls_Servicio Is Nothing) Then
            For Each Row As ETPartidaServicio In Ls_Servicio
                SubTotal_Ser = SubTotal_Ser + Row.SubTotal
            Next
        End If

        Me.Txt6.Text = SubTotal_Mat
        Me.Txt13.Text = SubTotal_Eq
        Me.Txt20.Text = SubTotal_MO
        Me.Txt26.Text = SubTotal_Ser
        Txt27.Text = SubTotal_Mat + SubTotal_Eq + SubTotal_MO + SubTotal_Ser
    End Sub
    Private Sub Cargar_Partida_Recursos()

        If TipoFactor = "0" Then
            Me.Chk2.Checked = False
            Me.TxtF1.Text = ""
            Me.TxtF2.Text = ""
        Else
            Me.Chk2.Checked = True
            If TipoFactor = "1" Then
                Me.Rbn1.Checked = True
            Else
                Me.Rbn2.Checked = True
            End If

            TxtF1.Text = Factor
            TxtF2.Text = Jornada
            Cbo5.Value = UniMed
        End If

        Ls_Material = Nothing
        Ls_Equipo = Nothing
        Ls_ManoObra = Nothing
        Ls_Servicio = Nothing

        Ls_Material_Del = Nothing
        Ls_Equipo_Del = Nothing
        Ls_ManoObra_Del = Nothing
        Ls_Servicio_Del = Nothing

        Entidad.Partida_Mantto = New ETPartida
        With Entidad.Partida_Mantto
            .Partida = Nodo
            .Tipo = 4
        End With

        Negocio.Partida_Mantto = New NGPartida
        Entidad.MyLista = New ETMyLista

        Ls_Material = New List(Of ETPartidaMaterial)
        Ls_Material_Del = New List(Of ETPartidaMaterial)

        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_Material(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_Material = Entidad.MyLista.Ls_Partida_Material
        End If

        Ls_Equipo = New List(Of ETPartidaEquipo)
        Ls_Equipo_Del = New List(Of ETPartidaEquipo)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_Equipo(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_Partida_Equipo
        End If

        Ls_ManoObra = New List(Of ETPartidaManoObra)
        Ls_ManoObra_Del = New List(Of ETPartidaManoObra)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_ManoObra(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_ManoObra = Entidad.MyLista.Ls_Partida_ManoObra
        End If

        Ls_Servicio = New List(Of ETPartidaServicio)
        Ls_Servicio_Del = New List(Of ETPartidaServicio)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_Servicio(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_Servicio = Entidad.MyLista.Ls_Partida_Servicio
        End If


        Call CargarUltraGrid(Me.Grid1, Ls_Material)
        Call CargarUltraGrid(Me.Grid2, Ls_Equipo)
        Call CargarUltraGrid(Me.Grid3, Ls_ManoObra)
        Call CargarUltraGrid(Me.Grid4, Ls_Servicio)
        Call CalcularTotal()
    End Sub
    Private Sub Cargar_Partida_Recursos_PrecioActual()

        If TipoFactor = "0" Then
            Me.Chk2.Checked = False
        Else
            Me.Chk2.Checked = True
            If TipoFactor = "1" Then
                Me.Rbn1.Checked = True
            Else
                Me.Rbn2.Checked = True
            End If

            TxtF1.Text = Factor
            TxtF2.Text = Jornada
            Cbo5.Value = UniMed
        End If

        Ls_Material = Nothing
        Ls_Equipo = Nothing
        Ls_ManoObra = Nothing
        Ls_Servicio = Nothing

        Ls_Material_Del = Nothing
        Ls_Equipo_Del = Nothing
        Ls_ManoObra_Del = Nothing
        Ls_Servicio_Del = Nothing

        Entidad.Partida_Mantto = New ETPartida
        With Entidad.Partida_Mantto
            .Partida = Nodo
            .Tipo = 5
        End With

        Negocio.Partida_Mantto = New NGPartida
        Entidad.MyLista = New ETMyLista

        Ls_Material = New List(Of ETPartidaMaterial)
        Ls_Material_Del = New List(Of ETPartidaMaterial)

        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_Material(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_Material = Entidad.MyLista.Ls_Partida_Material
        End If

        Ls_Equipo = New List(Of ETPartidaEquipo)
        Ls_Equipo_Del = New List(Of ETPartidaEquipo)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_Equipo(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_Partida_Equipo
        End If

        Ls_ManoObra = New List(Of ETPartidaManoObra)
        Ls_ManoObra_Del = New List(Of ETPartidaManoObra)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_ManoObra(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_ManoObra = Entidad.MyLista.Ls_Partida_ManoObra
        End If

        Ls_Servicio = New List(Of ETPartidaServicio)
        Ls_Servicio_Del = New List(Of ETPartidaServicio)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Partida_Servicio(Entidad.Partida_Mantto)
        If Entidad.MyLista.Validacion Then
            Ls_Servicio = Entidad.MyLista.Ls_Partida_Servicio
        End If


        Call CargarUltraGrid(Me.Grid1, Ls_Material)
        Call CargarUltraGrid(Me.Grid2, Ls_Equipo)
        Call CargarUltraGrid(Me.Grid3, Ls_ManoObra)
        Call CargarUltraGrid(Me.Grid4, Ls_Servicio)
        Call CalcularTotal()
    End Sub
#End Region
#Region "Funciones Privadas"
    Private Function ValidarMantto() As Boolean
        ValidarMantto = True

        Select Case TipoDato
            Case ValorTipoDato.vDate
                If IsDate(Me.TxtN4.Value) = False Then
                    MsgBox("Ingrese una Fecha Valida", MsgBoxStyle.Critical, msgComacsa)
                    ValidarMantto = False
                    Me.TxtN4.Focus()
                End If
            Case ValorTipoDato.vTime
                If Me.TxtN4.Value = "" Then
                    MsgBox("Ingrese una Hora Valida", MsgBoxStyle.Critical, msgComacsa)
                    ValidarMantto = False
                    Me.TxtN4.Focus()
                End If
            Case ValorTipoDato.vEntero, ValorTipoDato.vDecimal
                If IsNumeric(TxtN2.Text) = False Then
                    MsgBox("Ingrese un Valor Numérico", MsgBoxStyle.Critical, msgComacsa)
                    ValidarMantto = False
                    Me.TxtN2.Focus()
                End If
            Case Else
                If String.IsNullOrEmpty(TxtN2.Text.Trim) Then
                    MsgBox("Ingrese un Valor", MsgBoxStyle.Critical, msgComacsa)
                    ValidarMantto = False
                    Me.TxtN2.Focus()
                End If
        End Select
    End Function
    Private Function Validar_Material() As Boolean
        Validar_Material = True
        If String.IsNullOrEmpty(Me.Txt1.Text.Trim) Then
            MsgBox("Ingrese el Material", MsgBoxStyle.Critical, Companhia)
            If Btn3.Enabled = True Then Me.Btn3.Focus()
            Validar_Material = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo6.Value) Then
            MsgBox("El Material no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_Material = False
            Exit Function
        End If

        If Val(Me.Txt3.Text) = 0 Then
            MsgBox("Ingrese la Cantidad del Material", MsgBoxStyle.Critical, Companhia)
            Validar_Material = False
            Txt3.Focus()
            Exit Function
        End If

        If Val(Me.Txt4.Text) = 0 Then
            MsgBox("El Material no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_Material = False
            Exit Function
        End If
    End Function
    Private Function Validar_Equipo() As Boolean
        Validar_Equipo = True
        If String.IsNullOrEmpty(Me.Txt7.Text.Trim) Then
            MsgBox("Ingrese el Material", MsgBoxStyle.Critical, Companhia)
            If Btn8.Enabled = True Then Me.Btn8.Focus()
            Validar_Equipo = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo7.Value) Then
            MsgBox("El Material no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_Equipo = False
            Exit Function
        End If

        If Val(Me.Txt9.Text) = 0 Then
            MsgBox("Ingrese la Cuadrilla de Equipo", MsgBoxStyle.Critical, Companhia)
            Validar_Equipo = False
            Txt9.Focus()
            Exit Function
        End If

        If Val(Me.Txt11.Text) = 0 Then
            MsgBox("El Equipo no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_Equipo = False
            Exit Function
        End If
    End Function
    Private Function Validar_ManoObra() As Boolean
        Validar_ManoObra = True
        If String.IsNullOrEmpty(Me.Txt14.Text.Trim) Then
            MsgBox("Ingrese el Cargo", MsgBoxStyle.Critical, Companhia)
            If Btn13.Enabled = True Then Me.Btn13.Focus()
            Validar_ManoObra = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo8.Value) Then
            MsgBox("El Cargo no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_ManoObra = False
            Exit Function
        End If

        If Val(Me.Txt16.Text) = 0 Then
            MsgBox("Ingrese la Cuadrilla de la Mano de Obra", MsgBoxStyle.Critical, Companhia)
            Validar_ManoObra = False
            Txt3.Focus()
            Exit Function
        End If

        If Val(Me.Txt18.Text) = 0 Then
            MsgBox("El Cargo no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_ManoObra = False
            Exit Function
        End If
    End Function
    Private Function Validar_Servicio() As Boolean
        Validar_Servicio = True
        If String.IsNullOrEmpty(Me.Txt21.Text.Trim) Then
            MsgBox("Ingrese el Servicio", MsgBoxStyle.Critical, Companhia)
            If Btn18.Enabled = True Then Me.Btn18.Focus()
            Validar_Servicio = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo9.Value) Then
            MsgBox("El Servicio no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_Servicio = False
            Exit Function
        End If

        If Val(Me.Txt23.Text) = 0 Then
            MsgBox("Ingrese la Cantidad del Servicio", MsgBoxStyle.Critical, Companhia)
            Validar_Servicio = False
            Exit Function
        End If

        If Val(Me.Txt24.Text) = 0 Then
            MsgBox("El Servicio no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_Servicio = False
            Exit Function
        End If
    End Function
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        If Tree1.SelectedNodes.Count <= 0 Then
            Return
        End If
        If nNode > eNivel.eParteEq Then
            MsgBox("Ya no puede crear más Niveles", MsgBoxStyle.Critical, msgComacsa)
            Return
        End If
        TipoG = eState.eNew
        Me.Grb2.Expanded = Boolean.TrueString
        Call VisualizarNodo(nNode)
        Call Limpiar()
        Call HabilitarControlNodo(True, nNode)
        Grb2.Expanded = True
        Me.TxtN1.Text = Me.DescripNodo
        Select Case nNode
            Case eNivel.eLinNeg
                Call Cargar_LinNeg()
                If Cbo1.Rows.Count > 0 Then Cbo1.Value = ""
                Cbo1.Focus()
            Case eNivel.eTipoMantto
                Cbo2.Value = ""
                Cbo2.Focus()
            Case eNivel.eMantenimiento
                If TipoMantto = "1" Then
                    Cbo3.Visible = True
                    Call CargarAtributo()
                    If Cbo3.Rows.Count > 0 Then Cbo3.Value = ""
                    TxtN2.ReadOnly = True
                    TxtN2.Width = 86
                    Cbo3.Focus()
                Else
                    Cbo3.Visible = False
                    TxtN2.Width = 196
                    TxtN2.MaxLength = 0
                    TipoDato = ValorTipoDato.vTexto
                End If
            Case eNivel.eEquipo
                Btn1.Focus()
                Btn1.Enabled = True
            Case eNivel.eParteEq
                Call CargarParteEquipo()
                If Cbo4.Rows.Count > 0 Then Cbo4.Value = ""

        End Select
    End Sub
    Public Sub Grabar()
        Call GrabarNodo()
    End Sub
    Public Sub Modificar()
        If Tree1.SelectedNodes.Count <= 0 Then
            Return
        End If
        TipoG = eState.eEdit
        nNode = nNode - 1
        Call VisualizarNodo(nNode)
        Call HabilitarControlNodo(True, nNode)
        Grb2.Expanded = True
        Me.TxtN1.Text = Me.DescripNodo
        Call LimpiarPartida()
        If nNode = eNivel.eParteEq Then
            Grb2.Expanded = False
            Call HabilitarBotonesDet(eBuscar.eMaterial)
            Call HabilitarBotonesDet(eBuscar.eEquipo)
            Call HabilitarBotonesDet(eBuscar.eManoObra)
            Call HabilitarBotonesDet(eBuscar.eServicio)
            Call Cargar_Partida_Recursos()
            Grb3.Enabled = True
        Else
            Grb3.Enabled = False
        End If

    End Sub
    Public Sub Cancelar()
        TipoG = eState.eView
        TipoG_DetMat = eState.eView
        TipoG_DetEq = eState.eView
        TipoG_DetMO = eState.eView
        TipoG_DetSer = eState.eView
        Call HabilitarControlNodo(False, nNode)
        Call HabilitarBotonesDet(eBuscar.eMaterial)
        Call HabilitarBotonesDet(eBuscar.eEquipo)
        Call HabilitarBotonesDet(eBuscar.eManoObra)
        Call HabilitarBotonesDet(eBuscar.eServicio)
        Call CalcularTotal()
    End Sub
    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Cancelar()
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

#End Region
#Region "Arboles"
    Private Sub Tree1_AfterActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles Tree1.AfterActivate
        Call Limpiar()
        TipoG = eState.eView
        nNode = (e.TreeNode.Level + 1)
        Me.Nodo = e.TreeNode.DataKey
        Me.DescripNodo = e.TreeNode.Text
        Call LimpiarPartida()
        Me.Grb3.Text = DescripNodo
        Btn23.Visible = False
        If Not (e.TreeNode.Level = 0) Then

            Me.NodoPadre = e.TreeNode.Parent.DataKey
            Me.DescripNodoPadre = e.TreeNode.Parent.Text
            Select Case e.TreeNode.Level
                Case 2
                    NodoRaiz = NodoPadre
                Case 3
                    Me.NodoRaiz = e.TreeNode.Parent.Parent.DataKey
                Case 4
                    Me.NodoRaiz = e.TreeNode.Parent.Parent.Parent.DataKey
                Case 5
                    Me.NodoRaiz = e.TreeNode.Parent.Parent.Parent.Parent.DataKey
                    Btn23.Visible = Part_Presupuesto
                    Btn23.Enabled = Part_Presupuesto
                    If Part_Presupuesto = Boolean.TrueString Then
                        Call Cargar_Partida_Recursos_PrecioActual()
                        Call CargarDatos_Mantto(eNivel.eMantenimiento, e.TreeNode.Parent.Parent.DataKey)
                        Call CargarDatos_Mantto(eNivel.eTipoMantto, e.TreeNode.Parent.Parent.Parent.DataKey)
                    End If

            End Select
            Call HabilitarControlNodo(False, e.TreeNode.Level)
            Call CargarDatosNodo(e.TreeNode.Level, Nodo)
        Else
            Call HabilitarControlNodo(False, e.TreeNode.Level)
            Call VisualizarNodo(eNivel.ePlantillaAPU)
            DescripNodoPadre = ""
            NodoPadre = -1
        End If

    End Sub

#End Region
#Region "Formulario"

    Private Sub frmMPlantillaAPU_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmMPlantillaAPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Iniciar()
    End Sub
#End Region

#Region "Grillas"
    Private Sub Grid_Partida_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout, Grid4.InitializeLayout
        With e.Layout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                uColumn.CellActivation = Activation.NoEdit
                Select Case sender.Name
                    Case "Grid1"
                        If Not (uColumn.Key = "Cod_Mat" OrElse uColumn.Key = "Material" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal" _
                        OrElse uColumn.Key = "Nro_OC") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                    Case "Grid2"
                        If Not (uColumn.Key = "Cod_Eq" OrElse uColumn.Key = "Equipo" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                    Case "Grid3"
                        If Not (uColumn.Key = "Cod_Cargo" OrElse uColumn.Key = "Cargo" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                    Case "Grid4"
                        If Not (uColumn.Key = "Cod_Ser" OrElse uColumn.Key = "Servicio" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal" _
                        OrElse uColumn.Key = "Nro_OC") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                End Select


            Next
        End With
    End Sub
#End Region
#Region "Combos"
    Private Sub Combo_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout, Cbo3.InitializeLayout, Cbo4.InitializeLayout
        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
        sender.DisplayLayout.Bands(0).Columns("Codigo").Width = 60
        sender.DisplayLayout.Bands(0).Columns("Descripcion").Width = sender.Width + 60

    End Sub
    Private Sub Cbo3_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles Cbo3.RowSelected
        If e Is Nothing Then Return
        If Cbo3.Rows.Count <= 0 Then Return
        Try
            If e.Row.Selected = Boolean.FalseString Then Return
        Catch ex As Exception
            Return
        End Try

        TipoDato = e.Row.Cells("TipoDato").Value

        Me.TxtN2.Clear()
        Me.TxtN4.Text = ""
        Select Case TipoDato
            Case ValorTipoDato.vDate
                Me.TxtN4.ReadOnly = False
                Me.TxtN2.Visible = False
                Me.TxtN4.Visible = True
                Me.TxtN4.FormatString = "{LOC}dd/mm/yyyy"
                Me.TxtN4.Focus()
            Case ValorTipoDato.vTime
                Me.TxtN4.ReadOnly = False
                Me.TxtN2.Visible = False
                Me.TxtN4.Visible = True
                Me.TxtN4.FormatString = "{LOC}hh:mm"
                Me.TxtN4.Focus()
            Case ValorTipoDato.vEntero
                Me.TxtN2.ReadOnly = False
                Me.TxtN4.Visible = False
                Me.TxtN2.Visible = True
                Me.TxtN2.Focus()
            Case ValorTipoDato.vDecimal
                Me.TxtN2.ReadOnly = False
                Me.TxtN4.Visible = False
                Me.TxtN2.Visible = True
                Me.TxtN2.Focus()
            Case Else
                Me.TxtN2.ReadOnly = False
                Me.TxtN4.Visible = False
                Me.TxtN2.Visible = True
                Me.TxtN2.Focus()
        End Select

    End Sub
    Private Sub ComboPartida_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo5.InitializeLayout, Cbo6.InitializeLayout, Cbo7.InitializeLayout, Cbo8.InitializeLayout, Cbo9.InitializeLayout
        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            .Columns("Descripcion").Width = sender.Width - 40
            .Columns("Abrev").Width = 40
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Descripcion" OrElse uColumn.Key = "Abrev") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next

        End With
    End Sub
#End Region
#Region "Texto"


    Private Sub TxtN2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtN2.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)

        Select Case TipoDato
            Case ValorTipoDato.vEntero
                KeyAscii = ValidarEntero(KeyAscii)
            Case ValorTipoDato.vDecimal
                KeyAscii = ValidarDecimal(KeyAscii, Me.TxtN2.Text.Trim)
        End Select
        e.KeyChar = Chr(KeyAscii)

    End Sub

    Private Sub Txt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt3.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Me.Btn5.Enabled = True Then
                Btn5.Focus()
            End If
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt3.Text)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt3.ValueChanged
        Me.Txt5.Text = Val(Me.Txt3.Text) * Val(Me.Txt4.Text)
    End Sub
    Private Sub Txt4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt4.ValueChanged
        Me.Txt5.Text = Val(Me.Txt3.Text) * Val(Me.Txt4.Text)
    End Sub

    Private Sub Txt9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt9.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Txt11.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt9.Text)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt9_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt9.ValueChanged
        If Chk2.Checked = False Then
            Me.Txt10.Text = Txt9.Text
        Else
            If Rbn1.Checked = True Then
                Txt10.Text = Val(Txt9.Text) * Val(TxtF2.Text) / Val(TxtF1.Text)
            Else
                Txt10.Text = Val(Txt9.Text) * Val(TxtF2.Text) * Val(TxtF1.Text)
            End If
        End If
    End Sub
    Private Sub Txt10_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt10.ValueChanged
        Me.Txt12.Text = Val(Me.Txt10.Text) * Val(Me.Txt11.Text)
    End Sub
    Private Sub Txt11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt11.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Btn10.Enabled = True Then Btn10.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt11.Text)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt11_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt11.ValueChanged
        Me.Txt12.Text = Val(Me.Txt10.Text) * Val(Me.Txt11.Text)
    End Sub

    Private Sub Txt16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt16.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Txt18.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt16.Text)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt16_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt16.ValueChanged
        If Chk2.Checked = False Then
            Me.Txt17.Text = Txt16.Text
        Else
            If Rbn1.Checked = True Then
                Txt17.Text = Val(Txt16.Text) * Val(TxtF2.Text) / Val(TxtF1.Text)
            Else
                Txt17.Text = Val(Txt16.Text) * Val(TxtF2.Text) * Val(TxtF1.Text)
            End If
        End If
    End Sub
    Private Sub Txt17_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt17.ValueChanged
        Me.Txt19.Text = Val(Me.Txt17.Text) * Val(Me.Txt18.Text)
    End Sub
    Private Sub Txt18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt18.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Btn15.Enabled = True Then Btn15.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt18.Text)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt18_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt18.ValueChanged
        Me.Txt19.Text = Val(Me.Txt17.Text) * Val(Me.Txt18.Text)
    End Sub

    Private Sub Txt23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt23.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Btn20.Enabled = True Then Btn20.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt23.Text)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt23_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt23.ValueChanged
        Me.Txt25.Text = Val(Me.Txt23.Text) * Val(Me.Txt24.Text)
    End Sub
    Private Sub Txt24_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt24.ValueChanged
        Me.Txt25.Text = Val(Me.Txt23.Text) * Val(Me.Txt24.Text)
    End Sub
#End Region
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim frm As New frmBuscar
        frm.Formulario = frmBuscar.eState.frm_Partida_Mantto_Equipo
        If TipoMantto = "1" Then
            frm.TipoReporte = 7
        Else
            frm.TipoReporte = 10
        End If

        If TipoG = eState.eNew Then
            frm.ID_Input = Nodo
        ElseIf TipoG = eState.eEdit Then
            frm.ID_Input = NodoPadre
        End If

        frm.ShowDialog()
        Me.FamiliaEq = frm.ID
        Me.TxtN3.Text = frm.Descripcion
        frm = Nothing
    End Sub
    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        If Chk2.Checked = True Then
            If Val(TxtF1.Text) = 0 Then Return
            If Val(TxtF2.Text) = 0 Then Return
        End If

        If Not (Ls_Equipo Is Nothing) Then
            For Each Row As ETPartidaEquipo In Ls_Equipo
                If Chk2.Checked = False Then
                    Row.Cantidad = Row.Cuadrilla
                Else
                    If Rbn1.Checked = True Then
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Text) / Val(TxtF1.Text)
                    Else
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Text) * Val(TxtF1.Text)
                    End If
                End If
                Row.SubTotal = Row.Cantidad * Row.Precio
            Next

            Call CargarUltraGrid(Grid2, Ls_Equipo)
        End If

        If Not (Ls_ManoObra Is Nothing) Then
            For Each Row As ETPartidaManoObra In Ls_ManoObra
                If Chk2.Checked = False Then
                    Row.Cantidad = Row.Cuadrilla
                Else
                    If Rbn1.Checked = True Then
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Text) / Val(TxtF1.Text)
                    Else
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Text) * Val(TxtF1.Text)
                    End If
                End If
                Row.SubTotal = Row.Cantidad * Row.Precio
            Next

            Call CargarUltraGrid(Grid3, Ls_ManoObra)
        End If

        Call CalcularTotal()
    End Sub
    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 1
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt1.Text = frm.Flag2
        Txt2.Text = frm.Descripcion
        Txt4.Text = frm.Flag3
        Nro_OC_Mat = frm.Flag4
        Cbo6.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        Call LimpiarMateriales()
        TipoG_DetMat = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eMaterial)

    End Sub
    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        Dim Repetir As Integer = 0

        If Validar_Material() = False Then
            Exit Sub
        End If

        Entidad.Partida_Material = New ETPartidaMaterial
        With Entidad.Partida_Material
            .Cod_Mat = Me.Txt1.Text
            .Material = Me.Txt2.Text
            .Cod_UniMed = Me.Cbo6.Value
            .UniMed = Me.Cbo6.Text
            .Cantidad = Me.Txt3.Text
            .Precio = Me.Txt4.Text
            .SubTotal = Val(Me.Txt3.Text) * Val(Me.Txt4.Text)
            .Nro_OC = Nro_OC_Mat
            .Tipo = TipoG_DetMat
            .Partida = Nodo
            .Usuario = User_Sistema
        End With

        If TipoG_DetMat = eState.eNew Then
            For Each Row As ETPartidaMaterial In Ls_Material
                If Row.Cod_Mat = Entidad.Partida_Material.Cod_Mat Then
                    MsgBox("Material ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_Material.Add(Entidad.Partida_Material)
            Call CargarUltraGrid(Grid1, Ls_Material)
        ElseIf TipoG_DetMat = eState.eEdit Then
            If Det_Mat.Trim = Me.Txt1.Text.Trim Then
                Me.Grid1.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo6.Value
                Me.Grid1.ActiveRow.Cells("UniMed").Value = Me.Cbo6.Text
                Me.Grid1.ActiveRow.Cells("Cantidad").Value = Me.Txt3.Text
                Me.Grid1.ActiveRow.Cells("Precio").Value = Me.Txt4.Text
                Me.Grid1.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt3.Text) * Val(Me.Txt4.Text)
                Me.Grid1.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Mat
            Else

                For Each Row As ETPartidaMaterial In Ls_Material
                    If Row.Cod_Mat = Entidad.Partida_Material.Cod_Mat Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("Material ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid1.ActiveRow.Cells("Cod_Mat").Value = Me.Txt1.Text
                Me.Grid1.ActiveRow.Cells("Material").Value = Me.Txt2.Text
                Me.Grid1.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo6.Value
                Me.Grid1.ActiveRow.Cells("UniMed").Value = Me.Cbo6.Text
                Me.Grid1.ActiveRow.Cells("Cantidad").Value = Me.Txt3.Text
                Me.Grid1.ActiveRow.Cells("Precio").Value = Me.Txt4.Text
                Me.Grid1.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt3.Text) * Val(Me.Txt4.Text)
                Me.Grid1.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Mat
                Me.Grid1.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid1.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid1.ActiveRow.Cells("Material_Ant").Value = Det_Mat
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarMateriales()
        TipoG_DetMat = eState.eView
        Call HabilitarBotonesDet(eBuscar.eMaterial)

    End Sub
    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        If Me.Grid1.Rows.Count <= 0 Then Return
        If Me.Grid1.ActiveRow Is Nothing Then Return

        TipoG_DetMat = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eMaterial)

        Txt1.Text = Grid1.ActiveRow.Cells("Cod_Mat").Value
        Txt2.Text = Grid1.ActiveRow.Cells("Material").Value
        Txt3.Text = Grid1.ActiveRow.Cells("Cantidad").Value
        Txt4.Text = Grid1.ActiveRow.Cells("Precio").Value
        Txt5.Text = Grid1.ActiveRow.Cells("SubTotal").Value
        Cbo6.Value = Grid1.ActiveRow.Cells("Cod_UniMed").Value
        Det_Mat = Txt1.Text
        Nro_OC_Mat = Grid1.ActiveRow.Cells("Nro_OC").Value

    End Sub
    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click

        If Me.Grid1.Rows.Count <= 0 Then Return
        If Me.Grid1.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Material: " & Grid1.ActiveRow.Cells("Cod_Mat").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


        If Grid1.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_Material.RemoveAt(Grid1.ActiveRow.Index)
            Call CargarUltraGrid(Grid1, Ls_Material)
            Exit Sub
        End If

        Entidad.Partida_Material = New ETPartidaMaterial
        With Entidad.Partida_Material
            .Cod_Mat = Grid1.ActiveRow.Cells("Cod_Mat").Value
            .Partida = Grid1.ActiveRow.Cells("Partida").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        Ls_Material_Del.Add(Entidad.Partida_Material)

        Ls_Material.RemoveAt(Grid1.ActiveRow.Index)
        Call CargarUltraGrid(Grid1, Ls_Material)
        Call CalcularTotal()


    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 2
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt7.Text = frm.Flag2
        Txt8.Text = frm.Descripcion
        Txt11.Text = frm.Flag3
        Det_Eq_New = frm.ID
        Cbo7.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        Call LimpiarEquipos()
        TipoG_DetEq = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eEquipo)
    End Sub
    Private Sub Btn10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn10.Click
        Dim Repetir As Integer = 0

        If Validar_Equipo() = False Then
            Exit Sub
        End If

        Entidad.Partida_Equipo = New ETPartidaEquipo
        With Entidad.Partida_Equipo
            .Cod_Eq = Me.Txt7.Text
            .Equipo = Me.Txt8.Text
            .EquipoID = Me.Det_Eq_New
            .Cod_UniMed = Me.Cbo7.Value
            .UniMed = Me.Cbo7.Text
            .Cuadrilla = Me.Txt9.Text
            .Cantidad = Me.Txt10.Text
            .Precio = Me.Txt11.Text
            .SubTotal = Val(Me.Txt10.Text) * Val(Me.Txt11.Text)
            .Tipo = TipoG_DetEq
            .Partida = Nodo
            .Usuario = User_Sistema
        End With

        If TipoG_DetEq = eState.eNew Then
            For Each Row As ETPartidaEquipo In Ls_Equipo
                If Row.EquipoID = Entidad.Partida_Equipo.EquipoID Then
                    MsgBox("Equipo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_Equipo.Add(Entidad.Partida_Equipo)
            Call CargarUltraGrid(Grid2, Ls_Equipo)
        ElseIf TipoG_DetEq = eState.eEdit Then
            If Det_Eq = Me.Det_Eq_New Then
                Me.Grid2.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo7.Value
                Me.Grid2.ActiveRow.Cells("UniMed").Value = Me.Cbo7.Text
                Me.Grid2.ActiveRow.Cells("Cuadrilla").Value = Me.Txt9.Text
                Me.Grid2.ActiveRow.Cells("Cantidad").Value = Me.Txt10.Text
                Me.Grid2.ActiveRow.Cells("Precio").Value = Me.Txt11.Text
                Me.Grid2.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt10.Text) * Val(Me.Txt11.Text)
            Else

                For Each Row As ETPartidaEquipo In Ls_Equipo
                    If Row.EquipoID = Entidad.Partida_Equipo.EquipoID Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("Equipo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid2.ActiveRow.Cells("Cod_Eq").Value = Me.Txt7.Text
                Me.Grid2.ActiveRow.Cells("Equipo").Value = Me.Txt8.Text
                Me.Grid2.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo7.Value
                Me.Grid2.ActiveRow.Cells("UniMed").Value = Me.Cbo7.Text
                Me.Grid2.ActiveRow.Cells("Cuadrilla").Value = Me.Txt9.Text
                Me.Grid2.ActiveRow.Cells("Cantidad").Value = Me.Txt10.Text
                Me.Grid2.ActiveRow.Cells("Precio").Value = Me.Txt11.Text
                Me.Grid2.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt10.Text) * Val(Me.Txt11.Text)
                Me.Grid2.ActiveRow.Cells("EquipoID").Value = Det_Eq_New
                Me.Grid2.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid2.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid2.ActiveRow.Cells("Equipo_Ant").Value = Det_Eq
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarEquipos()
        TipoG_DetEq = eState.eView
        Call HabilitarBotonesDet(eBuscar.eEquipo)
    End Sub
    Private Sub Btn11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn11.Click
        If Me.Grid2.Rows.Count <= 0 Then Return
        If Me.Grid2.ActiveRow Is Nothing Then Return

        TipoG_DetEq = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eEquipo)

        Txt7.Text = Grid2.ActiveRow.Cells("Cod_Eq").Value
        Txt8.Text = Grid2.ActiveRow.Cells("Equipo").Value
        Txt9.Text = Grid2.ActiveRow.Cells("Cuadrilla").Value
        Txt10.Text = Grid2.ActiveRow.Cells("Cantidad").Value
        Txt11.Text = Grid2.ActiveRow.Cells("Precio").Value
        Txt12.Text = Grid2.ActiveRow.Cells("SubTotal").Value
        Cbo7.Value = Grid2.ActiveRow.Cells("Cod_UniMed").Value
        Det_Eq = Grid2.ActiveRow.Cells("EquipoID").Value
        Det_Eq_New = Grid2.ActiveRow.Cells("EquipoID").Value
    End Sub
    Private Sub Btn12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn12.Click
        If Me.Grid2.Rows.Count <= 0 Then Return
        If Me.Grid2.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Equipo: " & Grid2.ActiveRow.Cells("Cod_Eq").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        If Grid2.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_Equipo.RemoveAt(Grid2.ActiveRow.Index)
            Call CargarUltraGrid(Grid2, Ls_Equipo)
            Exit Sub
        End If

        Entidad.Partida_Equipo = New ETPartidaEquipo
        With Entidad.Partida_Equipo
            .Cod_Eq = Grid2.ActiveRow.Cells("EquipoID").Value
            .Partida = Grid2.ActiveRow.Cells("Partida").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        Ls_Equipo_Del.Add(Entidad.Partida_Equipo)

        Ls_Equipo.RemoveAt(Grid2.ActiveRow.Index)
        Call CargarUltraGrid(Grid2, Ls_Equipo)
        Call CalcularTotal()
    End Sub

    Private Sub Btn13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn13.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 3
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt14.Text = frm.Flag2
        Txt15.Text = frm.Descripcion
        Txt18.Text = frm.Flag3
        Cbo8.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn14.Click
        Call LimpiarManoObra()
        TipoG_DetMO = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eManoObra)
    End Sub
    Private Sub Btn15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn15.Click
        Dim Repetir As Integer = 0

        If Validar_ManoObra() = False Then
            Exit Sub
        End If

        Entidad.Partida_ManoObra = New ETPartidaManoObra
        With Entidad.Partida_ManoObra
            .Cod_Cargo = Me.Txt14.Text
            .Cargo = Me.Txt15.Text
            .Cod_UniMed = Me.Cbo8.Value
            .UniMed = Me.Cbo8.Text
            .Cuadrilla = Me.Txt16.Text
            .Cantidad = Me.Txt17.Text
            .Precio = Me.Txt18.Text
            .SubTotal = Val(Me.Txt17.Text) * Val(Me.Txt18.Text)
            .Tipo = TipoG_DetMO
            .Partida = Nodo
            .Usuario = User_Sistema
        End With

        If TipoG_DetMO = eState.eNew Then
            For Each Row As ETPartidaManoObra In Ls_ManoObra
                If Row.Cod_Cargo = Entidad.Partida_ManoObra.Cod_Cargo Then
                    MsgBox("El Cargo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_ManoObra.Add(Entidad.Partida_ManoObra)
            Call CargarUltraGrid(Grid3, Ls_ManoObra)
        ElseIf TipoG_DetMO = eState.eEdit Then
            If Det_MO.Trim = Me.Txt14.Text.Trim Then
                Me.Grid3.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo8.Value
                Me.Grid3.ActiveRow.Cells("UniMed").Value = Me.Cbo8.Text
                Me.Grid3.ActiveRow.Cells("Cuadrilla").Value = Me.Txt16.Text
                Me.Grid3.ActiveRow.Cells("Cantidad").Value = Me.Txt17.Text
                Me.Grid3.ActiveRow.Cells("Precio").Value = Me.Txt18.Text
                Me.Grid3.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt17.Text) * Val(Me.Txt18.Text)
            Else

                For Each Row As ETPartidaManoObra In Ls_ManoObra
                    If Row.Cod_Cargo = Entidad.Partida_ManoObra.Cod_Cargo Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("El Cargo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid3.ActiveRow.Cells("Cod_Cargo").Value = Me.Txt14.Text
                Me.Grid3.ActiveRow.Cells("Cargo").Value = Me.Txt15.Text
                Me.Grid3.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo8.Value
                Me.Grid3.ActiveRow.Cells("UniMed").Value = Me.Cbo8.Text
                Me.Grid3.ActiveRow.Cells("Cuadrilla").Value = Me.Txt16.Text
                Me.Grid3.ActiveRow.Cells("Cantidad").Value = Me.Txt17.Text
                Me.Grid3.ActiveRow.Cells("Precio").Value = Me.Txt18.Text
                Me.Grid3.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt17.Text) * Val(Me.Txt18.Text)
                Me.Grid3.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid3.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid3.ActiveRow.Cells("Cargo_Ant").Value = Det_MO
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarManoObra()
        TipoG_DetMO = eState.eView
        Call HabilitarBotonesDet(eBuscar.eManoObra)
    End Sub
    Private Sub Btn16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn16.Click
        If Me.Grid3.Rows.Count <= 0 Then Return
        If Me.Grid3.ActiveRow Is Nothing Then Return

        TipoG_DetMO = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eManoObra)

        Txt14.Text = Grid3.ActiveRow.Cells("Cod_Cargo").Value
        Txt15.Text = Grid3.ActiveRow.Cells("Cargo").Value
        Txt16.Text = Grid3.ActiveRow.Cells("Cuadrilla").Value
        Txt17.Text = Grid3.ActiveRow.Cells("Cantidad").Value
        Txt18.Text = Grid3.ActiveRow.Cells("Precio").Value
        Txt19.Text = Grid3.ActiveRow.Cells("SubTotal").Value
        Cbo8.Value = Grid3.ActiveRow.Cells("Cod_UniMed").Value
        Det_MO = Grid3.ActiveRow.Cells("Cod_Cargo").Value
    End Sub
    Private Sub Btn17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn17.Click
        If Me.Grid3.Rows.Count <= 0 Then Return
        If Me.Grid3.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Cargo: " & Grid3.ActiveRow.Cells("Cod_Cargo").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


        If Grid3.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_ManoObra.RemoveAt(Grid3.ActiveRow.Index)
            Call CargarUltraGrid(Grid3, Ls_ManoObra)
            Exit Sub
        End If

        Entidad.Partida_ManoObra = New ETPartidaManoObra
        With Entidad.Partida_ManoObra
            .Cod_Cargo = Grid3.ActiveRow.Cells("Cargo").Value
            .Partida = Grid3.ActiveRow.Cells("Partida").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        Ls_ManoObra_Del.Add(Entidad.Partida_ManoObra)

        Ls_ManoObra.RemoveAt(Grid3.ActiveRow.Index)
        Call CargarUltraGrid(Grid3, Ls_ManoObra)
        Call CalcularTotal()
    End Sub

    Private Sub Btn18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn18.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 4
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt21.Text = frm.Flag2
        Txt22.Text = frm.Descripcion
        Txt24.Text = frm.Flag3
        Nro_OC_Ser = frm.Flag4
        Cbo9.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn19.Click
        Call LimpiarServicios()
        TipoG_DetSer = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eServicio)

    End Sub
    Private Sub Btn20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn20.Click
        Dim Repetir As Integer = 0

        If Validar_Servicio() = False Then
            Exit Sub
        End If

        Entidad.Partida_Servicio = New ETPartidaServicio
        With Entidad.Partida_Servicio
            .Cod_Ser = Me.Txt21.Text
            .Servicio = Me.Txt22.Text
            .Cod_UniMed = Me.Cbo9.Value
            .UniMed = Me.Cbo9.Text
            .Cantidad = Me.Txt23.Text
            .Precio = Me.Txt24.Text
            .SubTotal = Val(Me.Txt23.Text) * Val(Me.Txt24.Text)
            .Nro_OC = Nro_OC_Ser
            .Tipo = TipoG_DetSer
            .Partida = Nodo
            .Usuario = User_Sistema
        End With

        If TipoG_DetSer = eState.eNew Then
            For Each Row As ETPartidaServicio In Ls_Servicio
                If Row.Cod_Ser = Entidad.Partida_Servicio.Cod_Ser Then
                    MsgBox("Servicio ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_Servicio.Add(Entidad.Partida_Servicio)
            Call CargarUltraGrid(Grid4, Ls_Servicio)
        ElseIf TipoG_DetSer = eState.eEdit Then
            If Det_Ser.Trim = Me.Txt21.Text.Trim Then
                Me.Grid4.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo9.Value
                Me.Grid4.ActiveRow.Cells("UniMed").Value = Me.Cbo9.Text
                Me.Grid4.ActiveRow.Cells("Cantidad").Value = Me.Txt23.Text
                Me.Grid4.ActiveRow.Cells("Precio").Value = Me.Txt24.Text
                Me.Grid4.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt23.Text) * Val(Me.Txt24.Text)
                Me.Grid4.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Ser
            Else

                For Each Row As ETPartidaServicio In Ls_Servicio
                    If Row.Cod_Ser = Entidad.Partida_Servicio.Cod_Ser Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("Servicio ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid4.ActiveRow.Cells("Cod_Ser").Value = Me.Txt21.Text
                Me.Grid4.ActiveRow.Cells("Servicio").Value = Me.Txt22.Text
                Me.Grid4.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo9.Value
                Me.Grid4.ActiveRow.Cells("UniMed").Value = Me.Cbo9.Text
                Me.Grid4.ActiveRow.Cells("Cantidad").Value = Me.Txt23.Text
                Me.Grid4.ActiveRow.Cells("Precio").Value = Me.Txt24.Text
                Me.Grid4.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt23.Text) * Val(Me.Txt24.Text)
                Me.Grid4.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Ser
                Me.Grid4.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid4.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid4.ActiveRow.Cells("Servicio_Ant").Value = Det_Ser
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarServicios()
        TipoG_DetSer = eState.eView
        Call HabilitarBotonesDet(eBuscar.eServicio)
    End Sub
    Private Sub Btn21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn21.Click
        If Me.Grid4.Rows.Count <= 0 Then Return
        If Me.Grid4.ActiveRow Is Nothing Then Return

        TipoG_DetSer = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eServicio)

        Txt21.Text = Grid4.ActiveRow.Cells("Cod_Ser").Value
        Txt22.Text = Grid4.ActiveRow.Cells("Servicio").Value
        Txt23.Text = Grid4.ActiveRow.Cells("Cantidad").Value
        Txt24.Text = Grid4.ActiveRow.Cells("Precio").Value
        Txt25.Text = Grid4.ActiveRow.Cells("SubTotal").Value
        Cbo9.Value = Grid4.ActiveRow.Cells("Cod_UniMed").Value
        Det_Ser = Txt1.Text
        Nro_OC_Ser = Grid4.ActiveRow.Cells("Nro_OC").Value
    End Sub
    Private Sub Btn22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn22.Click
        If Me.Grid4.Rows.Count <= 0 Then Return
        If Me.Grid4.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Material: " & Grid1.ActiveRow.Cells("Cod_Mat").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


        If Grid4.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_Servicio.RemoveAt(Grid4.ActiveRow.Index)
            Call CargarUltraGrid(Grid4, Ls_Servicio)
            Exit Sub
        End If

        Entidad.Partida_Servicio = New ETPartidaServicio
        With Entidad.Partida_Servicio
            .Cod_Ser = Grid4.ActiveRow.Cells("Cod_Ser").Value
            .Partida = Grid4.ActiveRow.Cells("Partida").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        Ls_Servicio_Del.Add(Entidad.Partida_Servicio)

        Ls_Servicio.RemoveAt(Grid4.ActiveRow.Index)
        Call CargarUltraGrid(Grid4, Ls_Servicio)
        Call CalcularTotal()

    End Sub

    Private Sub Btn23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn23.Click

        If TipoMantto_Input = "2" Then
            If TipoMantto_Input = TipoMantto_Mantto Then
                _AddPartida = True
                Me.Close()
            Else
                MsgBox("La partida a seleccionar tiene que guardar relación con el presupuesto", MsgBoxStyle.Critical, msgComacsa)
            End If
        Else
            If TipoMantto_Input = TipoMantto_Mantto And Atributo_Input = Atributo_Mantto And Valor_Input.Trim = Valor_Mantto.Trim Then
                _AddPartida = True
                Me.Close()
            Else
                MsgBox("La partida a seleccionar tiene que guardar relación con el presupuesto", MsgBoxStyle.Critical, msgComacsa)
            End If
        End If
        
    End Sub
#End Region
#Region "Checkear"
    Private Sub Chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged
        Me.Cbo4.ReadOnly = Chk1.Checked
    End Sub

    Private Sub Chk2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk2.CheckedChanged
        Me.TxtF1.ReadOnly = Not Chk2.Checked
        Me.TxtF2.ReadOnly = Not Chk2.Checked
        Me.Btn2.Enabled = Chk2.Checked
        Me.Rbn1.Enabled = Chk2.Checked
        Me.Rbn2.Enabled = Chk2.Checked
        Me.TxtF1.Clear()
        Me.TxtF2.Clear()
        If Me.Chk2.Checked = True Then
            Me.Rbn1.Checked = True
            Cbo5.Value = "35"
        End If
    End Sub
#End Region

End Class