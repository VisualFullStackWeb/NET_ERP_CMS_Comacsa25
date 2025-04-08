Imports System.Text
Imports System.Net.Mail
Imports System.ComponentModel
Imports SIP_Entidad
Imports SIP_Negocio

Imports Infragistics.Win.UltraWinGrid
Imports CrystalDecisions.CrystalReports.Engine
Imports Microsoft.Office.Interop
Imports System.IO

'Imports System.Security.Authentication
'Imports System.Net

Public Class frmReclamos

    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Public LISTA_SOURCE As New List(Of ETReclamo)
    Public SOURCE As New ETReclamo
    Private UsuarioRegistra As ETReclamoPersona

    Public EditMode As Boolean = False
    Public Laboratorio As Boolean = False

    Public ROL As String

    Protected LabFase1 As Boolean = False
    Protected LabFase2 As Boolean = False

    Public AprobadorComercial As Boolean = False
    Public AprobadorProduccion As Boolean = False

    Protected NReclamo As New NGReclamo

    Dim rutaArchivosEvidencia As String = "\\10.10.10.35\reclamo$\EVIDENCIAS\" 'Application.StartupPath & "\ArchivosReclamos\Evidencias\"
    Dim rutaArchivosMuestra As String = "\\10.10.10.35\reclamo$\MUESTRAS\" 'Application.StartupPath & "\ArchivosReclamos\Muestras\"
    Dim rutaArchivosLab As String = "\\10.10.10.35\reclamo$\LABORATORIO\" 'Application.StartupPath & "\ArchivosReclamos\Laboratorio\"
    Dim rutaReportes As String = "\\10.10.10.33\siscomacsa$\Reportes\ERP_Comacsa\"
    Dim rutaArchivosGenerados As String = Application.StartupPath & "\ArchivosReclamos\Pdfs\"
    Dim rutaArchivosTemp As String = Application.StartupPath & "\ArchivosReclamos\Temp\"
    Dim rutaArchivosCorreo As String = "\\10.10.10.35\reclamo$\CORREO CLIENTE\" 'Application.StartupPath & "\ArchivosReclamos\Laboratorio\"

    Dim Correo_Servidor As String = "smtp.gmail.com"
    Dim Correo_Puerto As Integer = 587
    Dim Correo_SSL As Boolean = True
    Dim Correo_Remitente As New MailAddress("noreplysistemas2018@gmail.com", "Sistema de Quejas")
    Dim Correo_Credencial_User As String = "noreplysistemas2018@gmail.com"
    Dim Correo_Credencial_Pass As String = "lunaazul" '"ffnkzwxpfcjkhoyn"

    Dim envioMail As Boolean = True

    'Dim Correo_Credencial_User As String = "jtorres@roda.com.pe"
    'Dim Correo_Credencial_Pass As String = "JTRDS@si12"

    Public Const ESTLAB_CONFORMIDAD As String = "LABORATORIO.CONFORME"
    Public Const ESTLAB_INFORME As String = "LABORATORIO.INFORME"
    Public Const ESTMUESTRA As String = "MUESTRA"

    Public Const EST_LAB_RECHAZO As String = "MUESTRA RECHAZADA"

    Public Const E_PRODUCTO As String = "PRODUCTO"
    Public Const E_SERVICIO As String = "SERVICIO"
    Public Const E_MUESTRA As String = "MUESTRA"
    Public Const E_EVIDENCIA As String = "EVIDENCIA"
    Public Const E_LABCONFORME As String = "LABORATORIO.CONFORME"
    Public Const E_LABINFORME As String = "LABORATORIO.INFORME"
    Public Const E_APROBPROD As String = "APROB.PRODUCCION"
    Public Const E_APROBLAB As String = "APROB.LABORATORIO"
    Public Const E_APROBCOM As String = "APROB.COMERCIAL"
    Public Const E_APROBGER As String = "APROB.GERENCIA"
    Public Const E_REUNION As String = "REUNION"
    Public Const E_ANALISIS As String = "ANALISIS"
    Public Const E_PLANACCION As String = "PLAN DE ACCION"

    Public Const R_APROBPROD As String = "ROL_APROBPROD"
    Public Const R_APROBLAB As String = "ROL_APROBLAB"
    Public Const R_APROBCOM As String = "ROL_APROBCOM"

    Dim dtConfiguracion As New DataTable
    Dim dia_muestra As Int32
    Dim dia_lab As Int32
    Dim dia_prod As Int32
    Dim dia_com As Int32

    Dim dia_muestra_serv As Int32 = 0
    Dim dia_lab_serv As Int32 = 0
    Dim dia_prod_serv As Int32 = 0
    Dim dia_com_serv As Int32 = 0

    Sub ConfigurarGridFormato()
        Dim bandComentarios As UltraGridBand = gridFormatoPLanAccion.DisplayLayout.Bands(0)
        bandComentarios.Layout.Override.RowSizing = RowSizing.AutoFree
        bandComentarios.Layout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True

        Dim band_Planes As UltraGridBand = gridFormatoPLanAccion.DisplayLayout.Bands(0)
        band_Planes.Layout.Override.RowSizing = RowSizing.AutoFree
        band_Planes.Layout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
    End Sub
    Sub ConfigurarGridMuestrasLab()
        Dim band As UltraGridBand = ugLaboratorioInformes.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2

        band.Columns("FECHA_INICIO").Width = 130
        band.Columns("FECHA_INICIO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("FECHA_INICIO").Header.Caption = "FECHA ENTREGA" & Environment.NewLine & "MUESTRA"

        band.Columns("FECHA_CONFORME").Width = 150
        band.Columns("FECHA_CONFORME").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("FECHA_CONFORME").Header.Caption = "CONFORMIDAD" & Environment.NewLine & "FECHA ENTREGA"

        band.Columns("MUESTRA_CONFORME").Width = 150
        band.Columns("MUESTRA_CONFORME").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("MUESTRA_CONFORME").Header.Caption = "CONFORMIDAD" & Environment.NewLine & "MUESTRA"

        band.Columns("CONFORMIDAD").Width = 150
        band.Columns("CONFORMIDAD").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("CONFORMIDAD").Header.Caption = "CONFORMIDAD" & Environment.NewLine & "MUESTRA"

        band.Columns("CONFORMIDAD_FECHA").Width = 150
        band.Columns("CONFORMIDAD_FECHA").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("CONFORMIDAD_FECHA").Header.Caption = "CONFORMIDAD" & Environment.NewLine & "FECHA ENTREGA"

        band.Columns("FECHA_FIN").Width = 130
        band.Columns("FECHA_FIN").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("FECHA_FIN").Header.Caption = "FECHA ENTREGA" & Environment.NewLine & "INFORME"

        band.Columns("ARCHIVOM").Width = 100
        band.Columns("ARCHIVOM").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("ARCHIVOM").Header.Caption = "ANEXOS" & Environment.NewLine & "MUESTRA"

        band.Columns("ARCHIVO").Width = 100
        band.Columns("ARCHIVO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("ARCHIVO").Header.Caption = "ANEXOS" & Environment.NewLine & "LABORATORIO"

        band.Columns("NROBOLSA").Width = 130
        band.Columns("NROBOLSA").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NROBOLSA").Header.Caption = "CANTIDAD BOLSAS" & Environment.NewLine & "VENDIDAS"

        band.Columns("NROBOLSARECLAMADAS").Width = 130
        band.Columns("NROBOLSARECLAMADAS").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NROBOLSARECLAMADAS").Header.Caption = "CANTIDAD BOLSAS" & Environment.NewLine & "RECLAMADAS"

    End Sub
    Sub ConfigurarGridMuestras()
        Dim band As UltraGridBand = ugMuestras.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2

        band.Columns("COD_PRODUCTO").Width = 100
        band.Columns("COD_PRODUCTO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("COD_PRODUCTO").Header.Caption = "CODIGO." & Environment.NewLine & "PRODUCTO"

        band.Columns("OBSERVACION").Hidden = True        

        band.Columns("PRODUCTO").Width = 250
        band.Columns("PRODUCTO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("PRODUCTO").Header.Caption = "PRODUCTO"

        band.Columns("NROBOLSA").Width = 130
        band.Columns("NROBOLSA").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NROBOLSA").Header.Caption = "CANTIDAD BOLSAS" & Environment.NewLine & "VENDIDAS"

        band.Columns("NROBOLSARECLAMADAS").Width = 130
        band.Columns("NROBOLSARECLAMADAS").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NROBOLSARECLAMADAS").Header.Caption = "CANTIDAD BOLSAS" & Environment.NewLine & "RECLAMADAS"

        band.Columns("FECHA_INICIO").Width = 150
        band.Columns("FECHA_INICIO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("FECHA_INICIO").Header.Caption = "FECHA ENTREGA" & Environment.NewLine & "MUESTRA"

        band.Columns("ESTADO_OBS").Width = 150
        band.Columns("ESTADO_OBS").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("ESTADO_OBS").Header.Caption = "COMENTARIO" & Environment.NewLine & "ESTADO"

    End Sub
    Sub ConfigurarGridGuias()

        Dim band As UltraGridBand = ugDetGuia.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2

        band.Columns("NRO_FACT").Width = 70
        band.Columns("NRO_FACT").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NRO_FACT").Header.Caption = "NRO." & Environment.NewLine & "FACTURA"

        band.Columns("NRO_GUIA").Width = 70
        band.Columns("NRO_GUIA").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NRO_GUIA").Header.Caption = "NRO." & Environment.NewLine & "GUIA"


        band.Columns("PRODUCTO").Width = 250
        band.Columns("PRODUCTO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("PRODUCTO").Header.Caption = "PRODUCTO"

        band.Columns("NRO_BOLSAS").Width = 130
        band.Columns("NRO_BOLSAS").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NRO_BOLSAS").Header.Caption = "CANTIDAD BOLSAS" & Environment.NewLine & "VENDIDAS"

        band.Columns("NRO_BOLSAS_RECLAMADAS").Width = 130
        band.Columns("NRO_BOLSAS_RECLAMADAS").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("NRO_BOLSAS_RECLAMADAS").Header.Caption = "CANTIDAD BOLSAS" & Environment.NewLine & "RECLAMADAS"

        band.Columns("COD_PRODUCTO").Width = 100
        band.Columns("COD_PRODUCTO").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("COD_PRODUCTO").Header.Caption = "CODIGO" & Environment.NewLine & "PRODUCTO"

        band.Columns("CANT_FACTURADA").Width = 100
        band.Columns("CANT_FACTURADA").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        band.Columns("CANT_FACTURADA").Header.Caption = "CANTIDAD" & Environment.NewLine & "FACTURADA"
    End Sub

    Sub DesBloquearDatosMuestra(ByVal desbloquear As Boolean)
        grpMuestra.Enabled = desbloquear
        DesBloquearGrilla(ugMuestras, desbloquear)
    End Sub
    Sub DesBloquearGrilla(ByVal grid As UltraGrid, ByVal desbloquear As Boolean)
        If desbloquear Then
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True            
        Else
            grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        End If
    End Sub

    Function GrillaHabilitada(ByVal grid As UltraGrid) As Boolean

        If grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub DesbloquearPanelSuperior(ByVal desbloquear As Boolean)
        grpTipoReclamo.Enabled = desbloquear
        grpOrigenReclamo.Enabled = desbloquear
        grpCabeceraReclamo.Enabled = desbloquear
        grpPareto.Enabled = desbloquear

    End Sub

    Private Sub frmReclamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'BuscarListadoReclamos()
            'Const _Tls12 As SslProtocols = DirectCast(&HC00, SslProtocols)
            'Const Tls12 As SecurityProtocolType = DirectCast(_Tls12, SecurityProtocolType)
            'ServicePointManager.SecurityProtocol = Tls12

            Dim band As UltraGridBand = ugPrincipal.DisplayLayout.Bands(0)
            band.ColHeaderLines = 2
            band.Columns("ALERTA").Width = 30
            band.Columns("ALERTA").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            band.Columns("ALERTA").Header.Caption = "Tiempo" & Environment.NewLine & "SIG"

            band.Columns("ALERTA_SIG").Width = 30
            band.Columns("ALERTA_SIG").Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center
            band.Columns("ALERTA_SIG").Header.Caption = "Tiempo" & Environment.NewLine & "Cliente"

            'Dim band As UltraGridBand = ugPrincipal.DisplayLayout.Bands(0)

            ConfigurarGridFormato()
            ConfigurarGridGuias()
            ConfigurarGridMuestras()
            ConfigurarGridMuestrasLab()
            ValidarRutasTemporales()
            CargarUsuarioSistema()
            CargarComboGerentesAprobacion()
            CargarComboLugarReunion()
            CargarPersonalPorArea()
            InicializarFechas()
            BindearGrillas()
            Nuevo()
            BuscarListadoReclamos()
            tabReclamo.SelectedTab = tabReclamo.Tabs("T04")
            ROL = ObtenerRolPorUsuario(User_Sistema)
            'ahora estableceremos cual de todos los paneles se habilita si corresponde

            If ROL = "ADMINISTRADOR" Then
                tabReclamo.Tabs("T05").Visible = True
            End If
            tabReclamo.Tabs("T05").Visible = True
            'If User_Sistema = "BHERBOZO" Or User_Sistema = "KFLOREZ" Or User_Sistema = "DCACERES" Or User_Sistema = "FEJ" Or User_Sistema = "SA" Then
            '    tabReclamo.Tabs("T05").Visible = True
            'End If
            'If User_Sistema = "FLOPEZ" Or User_Sistema = "SA" Then
            '    tabReclamo.Tabs("T02").Visible = True
            'End If

            If User_Sistema = "SA" Then
                btnAlerta.Visible = True
                btnReenvioCorreo.Visible = True
            End If


        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Sub ValidarRutasTemporales()
        Try
            If Not System.IO.Directory.Exists(rutaArchivosGenerados) Then
                System.IO.Directory.CreateDirectory(rutaArchivosGenerados)
            End If
            If Not System.IO.Directory.Exists(rutaArchivosTemp) Then
                System.IO.Directory.CreateDirectory(rutaArchivosTemp)
            End If
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub
    Sub CargarComboGerentesAprobacion()

        Dim lstProd As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("GERENCIA_PROD", "", True)

        cboAprobProduccion.ValueMember = "Codigo"
        cboAprobProduccion.DisplayMember = "Nombre"
        cboAprobProduccion.DataSource = lstProd

        Dim lstCom As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("GERENCIA_COM", "", True)

        cboAprobComercial.ValueMember = "Codigo"
        cboAprobComercial.DisplayMember = "Nombre"
        cboAprobComercial.DataSource = lstCom

        Dim lstLab As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("GERENCIA_LAB", "", True)
        cboAprobacionLaboratorio.ValueMember = "Codigo"
        cboAprobacionLaboratorio.DisplayMember = "Nombre"
        cboAprobacionLaboratorio.DataSource = lstLab

        Dim lstSolucion As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("GERENCIA_COM", "", True)

        cboSolucionAprobadoPor.ValueMember = "Codigo"
        cboSolucionAprobadoPor.DisplayMember = "Nombre"
        cboSolucionAprobadoPor.DataSource = lstSolucion
    End Sub
    Sub CargarUsuarioSistema()
        Try
            Dim obj As New SIP_Negocio.NGPersonal
            Dim item As New SIP_Entidad.ETPersonal
            item.Tipo = 6

            Dim lista As SIP_Entidad.ETMyLista = obj.ConsultarPersonal3(item)

            item = lista.Ls_Personal.FirstOrDefault(Function(p) p.CodPersonal = codTrabajadorInicio)

            If item IsNot Nothing Then
                SOURCE.UsuarioRegistra.Codigo = User_Sistema
                SOURCE.UsuarioRegistra.Nombre = item.DesPersonal
                SOURCE.UsuarioRegistra.Correo = item.Email
                SOURCE.UsuarioRegistra.Area = item.Area
            End If

            txtPersonaRegistra.Text = SOURCE.UsuarioRegistra.Nombre
            txtFormatoUser.Text = SOURCE.UsuarioRegistra.Nombre

            UsuarioRegistra = SOURCE.UsuarioRegistra

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try

    End Sub

    Sub BindearGrillas()

        ugAcciones.DataSource = SOURCE.ListaPlanes
        ugAcciones.DataBind()

        ugMuestras.DataSource = SOURCE.ListaMuestras
        ugMuestras.DataBind()

        ugLaboratorioInformes.DataSource = SOURCE.ListaMuestrasLab
        ugLaboratorioInformes.DataBind()

        ugInvolucrados.DataSource = SOURCE.ListaParticipantes
        ugInvolucrados.DataBind()

        ugDetGuia.DataSource = SOURCE.Producto.ListaDetalles
        ugDetGuia.DataBind()

        ugEvidenciaGuia.DataSource = SOURCE.Producto.ListaDetalles
        ugEvidenciaGuia.DataBind()

        ugCausaOrigen.DataSource = SOURCE.Causas
        ugCausaOrigen.DataBind()

        gridFormatoComentarios.DataSource = SOURCE.FormatoComentarios
        gridFormatoComentarios.DataBind()

        gridFormatoPLanAccion.DataSource = SOURCE.FormatoPlanes
        gridFormatoPLanAccion.DataBind()

    End Sub
    Sub CargarComboLugarReunion()
        Try
            Dim lista As New List(Of ETMaestos2)

            Dim item As New ETMaestos2()
            item.Codigo = "0"
            item.Descripcion = "OTROS"

            lista.Add(item)

            item = New ETMaestos2()
            item.Codigo = "01"
            item.Descripcion = "SALA DE VENTAS"

            lista.Add(item)

            item = New ETMaestos2()
            item.Codigo = "02"
            item.Descripcion = "SALA DE USOS MULTIPLES"

            lista.Add(item)

            cboLugarReunion.DisplayMember = "Descripcion"
            cboLugarReunion.ValueMember = "Codigo"
            cboLugarReunion.DataSource = lista


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "COMACSA")
        End Try
    End Sub

    Sub CargarPersonalPorAreaPorGrupo(ByRef index As Integer, ByVal dt As DataTable, ByVal pnl As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel)
        Dim chk As CheckBox = Nothing

        For pos As Integer = 0 To dt.Rows.Count - 1
            chk = New CheckBox
            chk.Name = "chk000" & index.ToString 'nombre aleatorio
            chk.Text = dt.Rows(pos)("PERSONA").ToString()
            chk.Tag = dt.Rows(pos)("CORREO").ToString()
            chk.AutoSize = True
            chk.BackColor = Color.Transparent
            chk.Location = New Point(3, 3 + pos * 17)

            AddHandler chk.Click, AddressOf chk1_CheckedChanged

            pnl.Controls.Add(chk)
            index += 1
        Next

    End Sub
    Sub CargarPersonalPorArea()
        Try
            Dim ds As DataSet = NReclamo.ObtenerPersonalPorArea()

            Dim index As Integer = 1

            'Despacho
            CargarPersonalPorAreaPorGrupo(index, ds.Tables("DESPACHO"), grpDespachoControls)
            'Venta Nacional
            CargarPersonalPorAreaPorGrupo(index, ds.Tables("VENTANAC"), grpVentasNacControls)
            'Venta Exportacion
            CargarPersonalPorAreaPorGrupo(index, ds.Tables("VENTAEXP"), grpVentasExpControls)
            'Transporte
            CargarPersonalPorAreaPorGrupo(index, ds.Tables("TRANSPORTE"), grpTransporteControls)
            'Laboratorio
            CargarPersonalPorAreaPorGrupo(index, ds.Tables("LABORATORIO"), grpLaboratorioControls)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try
    End Sub

#Region "ALERTAS"

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlerta.Click
        Try
            Dim key As String = tabTipoReclamo.SelectedTab.Key
            Dim destinatarios As New List(Of MailAddress)
            Dim destinatarios_aux As New List(Of MailAddress)

            If key = "TT01" Or key = "TT02" Then

                destinatarios.Clear()

                destinatarios = Correo_ObtenerCorreosRegistroReclamo_1(SOURCE)

                If rbtTipoNacional.Checked And rbtTipoProducto.Checked Then
                    destinatarios.Add(New MailAddress("kbravo@comacsa.com.pe", "Kathy Bravo"))
                End If
                If rbtTipoExportacion.Checked Then
                    destinatarios.Add(New MailAddress("jvicente@comacsa.com.pe", "Jhon Vicente"))
                    destinatarios.Add(New MailAddress("flopez@comacsa.com.pe", "Fiorela Lopez"))
                End If

                EnviarMail(destinatarios, _
                           "RECORDATORIO - REGISTRO | QUEJA NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"), _
                            GenerarContenidoReclamo("Se requiere registrar las muestras o evidencias de la queja"), _
                           MailPriority.High, "")

                MsgBox("Se envió la alerta de Entrega de Muestras")
            End If

            If key = "TT03" Then ' Muestras

                destinatarios.Clear()
                destinatarios.Add(New MailAddress("jtorres@roda.com.pe", UsuarioRegistra.Nombre))
                destinatarios.Add(New MailAddress("jmedina@comacsa.com.pe", "Juan Pablo Medina"))
                destinatarios.Add(New MailAddress("laboratorio@comacsa.com.pe", "Gladys Palomino"))
                destinatarios.Add(New MailAddress("wlizarraga@comacsa.com.pe", "Walter Lizarraga"))

                EnviarMail(destinatarios, _
                           "RECORDATORIO - REVISION DE MUESTRAS |QUEJA NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"), _
                            GenerarContenidoReclamo("Se han registrado las muestras , pero aun estan pendiente de revisiòn"), _
                           MailPriority.High, "")

                MsgBox("Se envió la alerta de Revisiòn de Laboratorio")

            End If
            If key = "TT09" Then ' Evidencias
                'los destinatarios dependen del req 
                destinatarios_aux.Clear()

                destinatarios_aux = Correo_ObtenerRepresentanteCuentaYJefe(SOURCE)
                For Each mail As MailAddress In destinatarios_aux
                    Dim str_mail As String = mail.Address
                    If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                        destinatarios.Add(mail)
                    End If
                Next

                If SOURCE.RequiereAprobProd Then
                    destinatarios_aux = Correo_ObtenerCorreosRevision_3_Prod(SOURCE)
                    For Each mail As MailAddress In destinatarios_aux
                        Dim str_mail As String = mail.Address
                        If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                            destinatarios.Add(mail)
                        End If
                    Next

                End If
                If SOURCE.RequiereAprobLab Then
                    destinatarios_aux = Correo_ObtenerCorreosRevision_3_Lab(SOURCE)
                    For Each mail As MailAddress In destinatarios_aux
                        Dim str_mail As String = mail.Address
                        If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                            destinatarios.Add(mail)
                        End If
                    Next
                End If
                If SOURCE.RequiereAprobCom Then
                    destinatarios_aux = Correo_ObtenerCorreosRevision_3_Com(SOURCE)
                    For Each mail As MailAddress In destinatarios_aux
                        Dim str_mail As String = mail.Address
                        If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                            destinatarios.Add(mail)
                        End If
                    Next
                End If

                'destinatarios = Correo_ObtenerCorreosRevisionLaboratorio_3(SOURCE)

                EnviarMail(destinatarios, _
                            "RECORDATORIO - REVISION DE EVIDENCIAS | QUEJA NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy") _
                           , GenerarContenidoReclamo("Se han adjuntado las evidencias a la queja, pero aún no han sido revisadas"), MailPriority.High, "")

            End If
            If key = "TT04" Then 'Laboratorio

                destinatarios.Clear()
                destinatarios.Add(New MailAddress("jtorres@roda.com.pe", UsuarioRegistra.Nombre))
                destinatarios.Add(New MailAddress("jmarroquin@comacsa.com.pe", "Jorge Marroquin"))
                destinatarios.Add(New MailAddress("vcarlin@comacsa.com.pe", "Victor Carlin"))

                EnviarMail(destinatarios, _
                           "RECORDATORIO - APROBACION DE INFORMES DE LABORATORIO | NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"), _
                            GenerarContenidoReclamo("EL informe de Laboratorio se ha registrado , pero no se ha revisado aun"), _
                           MailPriority.High, "")

                MsgBox("Se envió la alerta de Aprobaciòn de Informes")

            End If
            If key = "TT08" Then 'Aprobacion

                destinatarios.Clear()
                destinatarios.Add(New MailAddress("jtorres@roda.com.pe", UsuarioRegistra.Nombre))

                Dim jefe As ETReclamoPersona = ObtenerJefeResponsable(txtClienteCodigo.Text.Trim())

                destinatarios.Add(jefe.GetEmail())

                EnviarMail(destinatarios, _
                           "RECORDATORIO - APROBACION DE GERENCIA | NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"), _
                            GenerarContenidoReclamo("Se han aprobado los informes de laboratorio, se requiere la revision del formato para el cliente"), _
                           MailPriority.High, "")

                MsgBox("Se envió la alerta de Programaciòn de Reuniòn")

            End If
            If key = "TT05" Then ' Reunion
                destinatarios.Clear()
                destinatarios.Add(New MailAddress("jtorres@roda.com.pe", UsuarioRegistra.Nombre))

                Dim jefe As ETReclamoPersona = ObtenerJefeResponsable(txtClienteCodigo.Text.Trim())

                destinatarios.Add(jefe.GetEmail())

                EnviarMail(destinatarios, _
                           "RECORDATORIO - ANALISIS RESULTADO DE LA REUNIÒN | NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"), _
                             GenerarContenidoReclamo("Se han programado una reuniòn , pero aun no se registra el anàlisis de las causas de la queja"), _
                           MailPriority.High, "")

                MsgBox("Se envió la alerta de Anàlisis de Causas")
            End If
            If key = "TT07" Then
                destinatarios.Clear()
                destinatarios.Add(New MailAddress("jtorres@roda.com.pe", UsuarioRegistra.Nombre))

                Dim jefe As ETReclamoPersona = ObtenerJefeResponsable(txtClienteCodigo.Text.Trim())

                destinatarios.Add(jefe.GetEmail())

                EnviarMail(destinatarios, _
                           "RECORDATORIO - REGISTRO DE PLANES DE ACCION | NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"), _
                            GenerarContenidoReclamo("Se ha registrado el anàlisis de las causas de la queja, pero aun no se registran los planes de acciòn"), _
                           MailPriority.High, "")

                MsgBox("Se envió la alerta de Anàlisis de Causas")
            End If
            If key = "TT08" Then
                destinatarios.Clear()
                destinatarios.Add(New MailAddress("jtorres@roda.com.pe", UsuarioRegistra.Nombre))

                Dim jefe As ETReclamoPersona = ObtenerJefeResponsable(txtClienteCodigo.Text.Trim())
                If jefe.GetEmail() IsNot Nothing Then
                    destinatarios.Add(jefe.GetEmail())
                End If

                EnviarMail(destinatarios, _
                           "RECORDATORIO - REGISTRO DE FECHA DE EJECUCION PARA PLANES DE ACCION | NRO: " & txtNro.Text & " | Cliente: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"), _
                            GenerarContenidoReclamo("Se ha registrado los planes de acciòn, pero aun no se registran la fecha de ejecuciòn"), _
                           MailPriority.High, "")

                MsgBox("Se envió la alerta de Planes de Acciòn")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "REMITENTES EN CADA PASO"
    Function Correo_ObtenerCopia() As List(Of MailAddress)
        Dim listaPersonas As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("COPIA", "", False)

        Dim lista As New List(Of MailAddress)

        For Each oPersona As ETReclamoPersona In listaPersonas
            If oPersona.GetEmail() IsNot Nothing Then
                lista.Add(oPersona.GetEmail())
            End If
        Next

        Return lista
    End Function
    Function Correo_ObtenerCC() As List(Of MailAddress)
        'DAO

        Dim listaPersonas As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("COPIA_CC", "", False)

        Dim lista As New List(Of MailAddress)

        For Each oPersona As ETReclamoPersona In listaPersonas
            If oPersona.GetEmail IsNot Nothing Then
                lista.Add(oPersona.GetEmail())
            End If
        Next

        Return lista
    End Function
    Function Correo_ObtenerCorreosRegistroReclamo_1(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)

        Dim representanteVenta As ETReclamoPersona = NReclamo.ObtenerRepresentamtePorCLiente(txtClienteCodigo.Text.Trim())

        If representanteVenta.GetEmail IsNot Nothing Then
            lista.Add(representanteVenta.GetEmail())
        End If

        Dim JefesArea As New List(Of ETReclamoPersona)

        If rbtTipoExportacion.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFEEXP", "", False)
        End If

        If rbtTipoNacional.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFENAC", "", False)
        End If

        For Each persona As ETReclamoPersona In JefesArea
            If persona.GetEmail IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next

        Return lista
    End Function

    Function Correo_ObtenerRepresentanteCuentaYJefe(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        Dim lista As New List(Of MailAddress)

        Dim representanteVenta As ETReclamoPersona = NReclamo.ObtenerRepresentamtePorCLiente(txtClienteCodigo.Text.Trim())

        If representanteVenta.GetEmail IsNot Nothing Then
            lista.Add(representanteVenta.GetEmail())
        End If

        Dim JefesArea As New List(Of ETReclamoPersona)

        If rbtTipoExportacion.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFEEXP", "", False)
        End If

        If rbtTipoNacional.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFENAC", "", False)
        End If

        For Each persona As ETReclamoPersona In JefesArea
            If persona.GetEmail IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next
        Return lista

    End Function

    Function Correo_ObtenerCorreosEntregaMuestra_2(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)

        Dim listaPersonas As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("ENTREGA_MUESTRA", "", False)

        For Each persona As ETReclamoPersona In listaPersonas
            If persona.GetEmail() IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next

        Dim representanteVenta As ETReclamoPersona = NReclamo.ObtenerRepresentamtePorCLiente(txtClienteCodigo.Text.Trim())

        If representanteVenta.GetEmail IsNot Nothing Then
            lista.Add(representanteVenta.GetEmail())
        End If

        Dim JefesArea As New List(Of ETReclamoPersona)

        If rbtTipoExportacion.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFEEXP", "", False)
        End If

        If rbtTipoNacional.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFENAC", "", False)
        End If

        For Each persona As ETReclamoPersona In JefesArea
            If persona.GetEmail IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next
        Return lista
    End Function
    Function Correo_ObtenerCorreosRevisionLaboratorio_3(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)
        Dim listaPersonas As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("REVISION_LAB", "", False)

        For Each persona As ETReclamoPersona In listaPersonas
            If persona.GetEmail() IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next
        Return lista
    End Function
    Function Correo_ObtenerCorreosRevision_3_Prod(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)
        Dim listaPersonas As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("REV.LAB.REQ.APROB.PROD", "", False)

        For Each persona As ETReclamoPersona In listaPersonas
            If persona.GetEmail() IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next
        Return lista
    End Function
    Function Correo_ObtenerCorreosRevision_3_Lab(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)
        Dim listaPersonas As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("REV.LAB.REQ.APROB.LAB", "", False)

        For Each persona As ETReclamoPersona In listaPersonas
            If persona.GetEmail() IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next
        Return lista
    End Function
    Function Correo_ObtenerCorreosRevision_3_Com(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)
        Dim listaPersonas As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("REV.LAB.REQ.APROB.COM", "", False)

        For Each persona As ETReclamoPersona In listaPersonas
            If persona.GetEmail() IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next
        Return lista
    End Function
    Function Correo_ObtenerCorreosAprobacion_4(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)
        Dim representanteVenta As ETReclamoPersona = NReclamo.ObtenerRepresentamtePorCLiente(txtClienteCodigo.Text.Trim())

        If representanteVenta.GetEmail() IsNot Nothing Then
            lista.Add(representanteVenta.GetEmail())
        End If

        Dim JefesArea As New List(Of ETReclamoPersona)

        If rbtTipoExportacion.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFEEXP", "", False)
        End If

        If rbtTipoNacional.Checked Then
            JefesArea = NReclamo.ObtenerPersonalPorGrupo("JEFENAC", "", False)
        End If

        For Each persona As ETReclamoPersona In JefesArea
            If persona.GetEmail() IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next

        Dim gerencia As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("GERENCIA", "", False)

        For Each persona As ETReclamoPersona In gerencia
            If persona.GetEmail() IsNot Nothing Then
                lista.Add(persona.GetEmail())
            End If
        Next

        Return lista
    End Function
    Function Correo_ObtenerCorreosReunion_5(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)

        For Each participante In SOURCE.ListaParticipantes
            If participante.GetEmail() IsNot Nothing Then
                lista.Add(participante.GetEmail())
            End If
        Next

        Return lista
    End Function
    Function Correo_ObtenerCorreosAnalisis_6(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)

        Dim representanteVenta As ETReclamoPersona = NReclamo.ObtenerRepresentamtePorCLiente(txtClienteCodigo.Text.Trim())
        If representanteVenta.GetEmail() IsNot Nothing Then
            lista.Add(representanteVenta.GetEmail())
        End If

        Return lista
    End Function
    Function Correo_ObtenerCorreosPlanAccion_7(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)

        Dim representanteVenta As ETReclamoPersona = NReclamo.ObtenerRepresentamtePorCLiente(txtClienteCodigo.Text.Trim())

        lista.Add(representanteVenta.GetEmail())

        lista.AddRange(NReclamo.ObtenerPersonalPorGrupo("GERENCIA_COM", "", False))

        Return lista
    End Function
    Function Correo_ObtenerCorreosAprobacionFinal_8(ByVal pReclamo As ETReclamo) As List(Of MailAddress)
        'DAO
        Dim lista As New List(Of MailAddress)

        For Each oPersonas As ETReclamoPersona In SOURCE.ListaEmailsCliente
            lista.Add(oPersonas.GetEmail())
        Next

        Dim listaaux As List(Of ETReclamoPersona) = NReclamo.ObtenerPersonalPorGrupo("GERENCIA_COM", "", False)

        For Each xPer As ETReclamoPersona In listaaux
            lista.Add(xPer.GetEmail())
        Next

        If pReclamo.Tipo = "1" Then
            listaaux = NReclamo.ObtenerPersonalPorGrupo("JEFEEXP", "", False)
            For Each xPer As ETReclamoPersona In listaaux
                lista.Add(xPer.GetEmail())
            Next
        End If

        If pReclamo.Tipo = "2" Then
            listaaux = NReclamo.ObtenerPersonalPorGrupo("JEFENAC", "", False)
            For Each xPer As ETReclamoPersona In listaaux
                lista.Add(xPer.GetEmail())
            Next
        End If

        Dim representanteVenta As ETReclamoPersona = NReclamo.ObtenerRepresentamtePorCLiente(txtClienteCodigo.Text.Trim())

        If representanteVenta.GetEmail() IsNot Nothing Then
            lista.Add(representanteVenta.GetEmail())
        End If

        Return lista
    End Function
#End Region

#Region "TIPO RECLAMO"

    Private Sub rbtTipoProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoProducto.CheckedChanged

        tabTipoReclamo.Tabs("TT01").Enabled = rbtTipoProducto.Checked
        tabTipoReclamo.Tabs("TT03").Enabled = rbtTipoProducto.Checked
        tabTipoReclamo.Tabs("TT02").Enabled = Not rbtTipoProducto.Checked
        tabTipoReclamo.Tabs("TT09").Enabled = Not rbtTipoProducto.Checked

        'grpAprobComercial.Enabled = False

        If rbtTipoProducto.Checked Then
            SOURCE.JefeResponsable = ObtenerJefeResponsable(SOURCE.ClienteCodigo)
            tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT01")
            DesBloquearPanelProductos(True)
        End If

    End Sub

    Private Sub rbtTipoServicio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoServicio.CheckedChanged, RadioButton1.CheckedChanged

        tabTipoReclamo.Tabs("TT02").Enabled = rbtTipoServicio.Checked

        tabTipoReclamo.Tabs("TT01").Enabled = Not rbtTipoServicio.Checked
        tabTipoReclamo.Tabs("TT03").Enabled = Not rbtTipoServicio.Checked
        tabTipoReclamo.Tabs("TT04").Enabled = Not rbtTipoServicio.Checked

        'grpAprobComercial.Enabled = True

        If rbtTipoServicio.Checked Then
            'SOURCE.JefeResponsable = ObtenerJefeResponsable(SOURCE.ClienteCodigo)
            tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT02")
            DesbloquearPanelServicios(True)
        End If
    End Sub

    Private Sub rbtTipoNacional_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoNacional.CheckedChanged
        ValidarOrigenTipoReclamo()
    End Sub

    Private Sub rbtTipoExportacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtTipoExportacion.CheckedChanged
        ValidarOrigenTipoReclamo()
    End Sub

    Public Sub ValidarOrigenTipoReclamo()

        grpVentasExp.Visible = rbtTipoExportacion.Checked
        grpVentasNac.Visible = rbtTipoNacional.Checked

    End Sub

#End Region

#Region "CORREOS"

    Sub EnviarMail(ByVal destinatarios As List(Of MailAddress), ByVal asunto As String, ByVal contenido As String, ByVal prioridad As MailPriority, ByVal ruta_adjunto As String)
        Try
            Dim SMTP As New System.Net.Mail.SmtpClient(Correo_Servidor, Correo_Puerto)
            SMTP.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            SMTP.EnableSsl = Correo_SSL
            SMTP.UseDefaultCredentials = False
            SMTP.Credentials = New System.Net.NetworkCredential(Correo_Credencial_User, Correo_Credencial_Pass)

            Dim mail As New System.Net.Mail.MailMessage
            mail.From = Correo_Remitente

            If User_Sistema = "SA" Then

                Dim r As DialogResult = MessageBox.Show("Desea reenviarlo (SI) o hacer una prueba de envio(NO)", "Reenvio de Correo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

                If r = Windows.Forms.DialogResult.Yes Then

                    For Each destinatario As MailAddress In destinatarios
                        mail.To.Add(destinatario)
                    Next

                    For Each copia As MailAddress In Correo_ObtenerCopia()
                        mail.To.Add(copia)
                    Next

                    For Each correo As MailAddress In Correo_ObtenerCC()
                        mail.Bcc.Add(correo)
                    Next

                ElseIf r = Windows.Forms.DialogResult.No Then

                    mail.To.Add(New MailAddress("jtorres@roda.com.pe", "Jesus Torres"))

                Else
                    Exit Sub
                End If

            Else
                For Each destinatario As MailAddress In destinatarios
                    mail.To.Add(destinatario)
                Next

                For Each copia As MailAddress In Correo_ObtenerCopia()
                    mail.To.Add(copia)
                Next

                For Each correo As MailAddress In Correo_ObtenerCC()
                    mail.Bcc.Add(correo)
                Next
            End If

            mail.Subject = asunto
            mail.Priority = prioridad
            mail.Body = contenido
            mail.IsBodyHtml = True

            If ruta_adjunto.Length > 0 Then
                mail.Attachments.Add(New System.Net.Mail.Attachment(ruta_adjunto))
            End If

            If envioMail Then
                SMTP.Send(mail)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EnviarMailReunion()
        Try
            Dim SMTP As New System.Net.Mail.SmtpClient(Correo_Servidor, Correo_Puerto)
            SMTP.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            SMTP.EnableSsl = Correo_SSL
            SMTP.UseDefaultCredentials = False
            SMTP.Credentials = New System.Net.NetworkCredential(Correo_Credencial_User, Correo_Credencial_Pass)
            'SMTP.Credentials = New System.Net.NetworkCredential("jtorres@roda.com.pe", "JTRDS@si12")

            Dim mail As New System.Net.Mail.MailMessage
            mail.From = Correo_Remitente

            For Each copia As MailAddress In Correo_ObtenerCopia()
                mail.CC.Add(copia)
            Next

            For Each correo As MailAddress In Correo_ObtenerCC()
                mail.Bcc.Add(correo)
            Next

            Dim sbParticipantes As New StringBuilder()
            sbParticipantes.AppendLine()
            sbParticipantes.AppendLine("Participantes:")

            For Each PARTICIPANTE As ETReclamoPersona In SOURCE.ListaParticipantes
                mail.To.Add(New MailAddress(PARTICIPANTE.Correo, PARTICIPANTE.Nombre))
                sbParticipantes.AppendLine(PARTICIPANTE.Nombre & " - " & PARTICIPANTE.Area)
            Next

            'mail.To.Add(New MailAddress("jtorres@roda.com.pe", "Jesus Torres RODA"))
            'mail.To.Add(New MailAddress("jesus_henri@outlook.com", "Jesus Torres Outlook"))
            'mail.To.Add(New MailAddress("ventas02@company.com", "Ejecutivo Ventas"))

            mail.Subject = "Queja" & " NRO: " & txtNro.Text.Trim() & " | Cliente: " & txtClienteRazonSocial.Text.Trim()
            mail.Body = "Por favor atender la reunión para la fecha: " & dtpFechaReunion.Value.ToString() & sbParticipantes.ToString()

            Dim contype As New System.Net.Mime.ContentType("text/calendar")
            contype.Parameters.Add("method", "REQUEST")
            contype.Parameters.Add("name", "Meeting.ics")

            Dim avCal As AlternateView = AlternateView.CreateAlternateViewFromString( _
                GenerarAdjunto(mail, _
                               dtpFechaRegistro.DateTime.Date, _
                               dtpFechaReunion.DateTime.TimeOfDay.TotalMinutes, _
                               dtpFechaReunion.DateTime.TimeOfDay.TotalMinutes + 60 _
                               , IIf(txtLugarReunion.Text.Length = 0, "SIN ESPECIFICAR", txtLugarReunion.Text.Trim())), contype)

            mail.AlternateViews.Add(avCal)
            mail.Headers.Add("Content-class", "urn:content-classes:calendarmessage")

            If envioMail Then
                SMTP.Send(mail)
            End If


            MostrarMensaje("Reunion Programada")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Function GenerarAdjunto(ByVal mail As MailMessage, ByVal fecha As DateTime, ByVal inicio As Integer, ByVal fin As Integer, ByVal lugarReunion As String) As String
        Dim sb As New StringBuilder
        Dim fechaInicio As DateTime = fecha.AddMinutes(inicio)
        Dim fechaFin As DateTime = fecha.AddMinutes(fin)

        sb.AppendLine("BEGIN:VCALENDAR")
        sb.AppendLine("PRODID:-//Schedule a Meeting")
        sb.AppendLine("VERSION:2.0")
        sb.AppendLine("METHOD:REQUEST")
        sb.AppendLine("BEGIN:VEVENT")
        sb.AppendLine(String.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", fechaInicio))
        sb.AppendLine(String.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", fechaInicio.ToUniversalTime))
        sb.AppendLine(String.Format("DTEND:{0:yyyyMMddTHHmmssZ}", fechaFin))
        sb.AppendLine("LOCATION: " + lugarReunion)
        sb.AppendLine(String.Format("UID:{0}", Guid.NewGuid()))
        sb.AppendLine(String.Format("DESCRIPTION:{0}", mail.Body))
        sb.AppendLine(String.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", mail.Body))
        sb.AppendLine(String.Format("SUMMARY:{0}", mail.Subject))
        sb.AppendLine(String.Format("ORGANIZER:MAILTO:{0}", mail.From))

        For Each participante As MailAddress In mail.To
            sb.AppendLine(String.Format("ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=REQ-PARTICIPANT;CN=""{0}"";RSVP=TRUE:mailto:{1}", participante.DisplayName, participante.Address))
        Next

        'sb.AppendLine(String.Format("ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=REQ-PARTICIPANT;CN=""{0}"";RSVP=TRUE:mailto:{1}", "Jesus Torres", "jtorres@roda.com.pe"))
        'sb.AppendLine(String.Format("ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=REQ-PARTICIPANT;CN=""{0}"";RSVP=TRUE:mailto:{1}", "EJECUTIVO DE VENTAS 01", "jesus_henri@outlook.com"))
        'sb.AppendLine(String.Format("ATTENDEE;CUTYPE=INDIVIDUAL;ROLE=REQ-PARTICIPANT;CN=""{0}"";RSVP=TRUE:mailto:{1}", "EJECUTIVO DE VENTAS 02", "ventas02@company.com"))

        sb.AppendLine("BEGIN:VALARM")
        sb.AppendLine("TRIGGER:-PT15M")
        sb.AppendLine("ACTION:DISPLAY")
        sb.AppendLine("DESCRIPTION:Reminder")
        sb.AppendLine("END:VALARM")
        sb.AppendLine("END:VEVENT")
        sb.AppendLine("END:VCALENDAR")

        Return sb.ToString()
    End Function
    Function GenerarContenidoFormato() As String
        Dim sb As New StringBuilder
        sb.Append("<html><head></head>")
        sb.Append("<body><table align=""left"" border=""0"" cellpadding=""4"" cellspacing=""0"" style=""width:500px;font-size:12px;font-family:Arial;"">")
        sb.Append("<tbody>")
        sb.Append("<tr><td colspan=""3"" style=""text-align:left;font-weight:bold;font-size:12px;"">Estimado " & SOURCE.Cliente & "</td></tr>")
        sb.Append("<tr><td colspan=""3"" style=""text-align:left;font-size:12px;"">Emitimos respuesta a su queja generada el dia: " & SOURCE.Fecha.ToString("dd-MM-yyyy") & " para los fines que disponga" & "</td></tr>")
        sb.Append("<tr><td colspan=""3"" style=""text-align:left;font-size:12px;"">Saludos cordiales</td></tr>")
        sb.Append("<tr><td colspan=""3"" style=""text-align:left;font-weight:bold;font-size:12px;"">Gerencia Comercial</td></tr>")
        sb.Append("<tr><td colspan=""3"" style=""text-align:left;font-weight:bold;font-size:12px;"">COMACSA</td></tr>")
        sb.Append("<tr><td colspan=""3""><hr></td></tr>")
        sb.Append("</tbody></table>")
        sb.Append("</body></html>")
        Return sb.ToString()
    End Function
    Function GenerarContenidoReclamo(ByVal Contenido As String) As String
        Dim sb As New StringBuilder

        Try
            sb.Append("<html><head></head>")
            sb.Append("<body><table align=""left"" border=""0"" cellpadding=""4"" cellspacing=""0"" style=""width:500px;font-size:12px;font-family:Arial;"">")
            sb.Append("<tbody><tr><td colspan=""3"" style=""text-align:left;font-weight:bold;font-size:12px;"">" & Contenido & "</td></tr>")
            sb.Append("<tr><td colspan=""3""><hr></td></tr>")
            sb.Append("<tr><td colspan=""3"" style=""text-align:center;font-weight:bold;font-size:16px;"">")
            If rbtTipoProducto.Checked Then
                sb.Append("QUEJA POR PRODUCTO NRO: " & txtNro.Text)
            Else
                sb.Append("QUEJA POR SERVICIO NRO: " & txtNro.Text)
            End If
            sb.Append("</td></tr>")
            sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">CLIENTE:</td><td>")
            sb.Append(txtClienteCodigo.Text.Trim() & " - " & txtClienteRazonSocial.Text.Trim())
            sb.Append("</td><td></td></tr>")
            sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">FECHA:</td><td>" & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy") & "</td><td></td></tr>")
            sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">REGISTRADO POR:</td><td>" & txtPersonaRegistra.Text.Trim() & "</td><td></td></tr>")
            sb.Append("<tr><td colspan=""3""><hr></td></tr>")

            If rbtTipoProducto.Checked Then
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">MOTIVO:</td><td>" & txtProductoMotivo.Text.Trim() & "</td><td></td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">COMENTARIO::</td><td>" & txtProductoObservacion.Text.Trim() & "</td><td></td></tr>")
                sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">PRODUCTOS INVOLUCRADOS:</td></tr><tr><td colspan=""3"">")
                sb.Append("<table border=""1"" style=""font-size:12px;width:498px;"" cellpadding=""4"" cellspacing=""0"">")
                sb.Append("<thead><tr><th style=""width:298px;text-align:left;font-weight:bold;"">PRODUCTO</th>")
                sb.Append("<th style=""width:100px;text-align:left;font-weight:bold;"">CANTIDAD</th>")
                sb.Append("<th style=""width:100px;text-align:left;font-weight:bold;"">LOTE</th></tr></thead><tbody>")

                For Each oGuia As ETReclamoProductoDetalle In SOURCE.Producto.ListaDetalles
                    sb.Append("<tr><td>" & oGuia.COD_PRODUCTO & " - " & oGuia.PRODUCTO & "</td>")
                    sb.Append("<td>" & oGuia.CANT_FACTURADA & " " & oGuia.UNIDAD & "</td>")
                    sb.Append("<td>" & oGuia.LOTE & "</td></tr>")
                Next
                sb.Append("</tbody></table></td></tr>")

                If SOURCE.ListaMuestras.Count > 0 Then
                    sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">MUESTRAS:</td></tr>")
                    sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">FECHA:</td><td>" & dtpMuestraFechaEntrega.DateTime.ToString("dd-MM-yyyy") & "</td><td></td></tr>")
                    sb.Append("<tr><td colspan=""3"">" & txtMuestraObservacion.Text.Trim() & "</td></tr>")

                    sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">INFORMES LABORATORIO:</td></tr>")
                    sb.Append("<tr><td colspan=""3"">")
                    sb.Append("<table border=""1"" style=""font-size:12px;width:498px;"" cellpadding=""4"" cellspacing=""0"">")
                    sb.Append("<thead><tr>")
                    sb.Append("<th style=""width:298px;text-align:left;font-weight:bold;"">PRODUCTO</th>")
                    sb.Append("<th style=""width:50px;text-align:left;font-weight:bold;"">FECHA INFORME</th>")
                    sb.Append("<th style=""width:100px;text-align:left;font-weight:bold;"">COMENTARIO MUESTRA</th>")
                    sb.Append("<th style=""width:50px;text-align:left;font-weight:bold;"">ESTADO</th>")
                    sb.Append("</tr></thead><tbody>")

                    For Each item As ETReclamoMuestra In SOURCE.ListaMuestrasLab
                        sb.Append("<tr><td>" & item.PRODUCTO & "</td><td>")

                        If item.FECHA_FIN.HasValue Then
                            sb.Append(item.FECHA_FIN.Value.ToString("dd-MM-yyyy"))
                        End If

                        sb.Append("</td><td>" & item.OBSERVACION & "</td>")
                        sb.Append("<td>" & item.ESTADO & "</td></tr>")
                    Next
                    sb.Append("</tbody></table></td></tr><tr><td colspan=""3""><hr></td></tr>")
                End If

            End If

            If rbtTipoServicio.Checked Then
                sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">SERVICIOS INVOLUCRADOS:</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">COMENTARIO:</td><td colspan=""2"">" & txtServicioComentarios.Text.Trim() & "</td></tr>")
                sb.Append("<tr><td colspan=""3"">")
                sb.Append("<table border=""1"" style=""font-size:12px;width:498px;"" cellpadding=""4"" cellspacing=""0"">")
                sb.Append("<thead><tr>")
                sb.Append("<th style=""width:248px;text-align:left;font-weight:bold;"">SERVICIO</th>")
                sb.Append("<th style=""width:150px;text-align:left;font-weight:bold;"">MOTIVO</th>")
                sb.Append("</tr></thead><tbody>")

                Dim rbtServicioVar2 As RadioButton = Nothing

                For Each ctrl As Control In grpServicio01.Controls
                    rbtServicioVar2 = TryCast(ctrl, RadioButton)
                    If rbtServicioVar2 IsNot Nothing AndAlso rbtServicioVar2.Checked Then
                        If rbtServicioVar2.Tag = "11" Then
                            sb.Append("<tr><td>" & grpServicio01.Text & "</td><td>" & txtServOtros01.Text & "</td></tr>")
                        Else
                            sb.Append("<tr><td>" & grpServicio01.Text & "</td><td>" & rbtServicioVar2.Text & "</td></tr>")
                        End If
                    End If
                Next
                For Each ctrl As Control In grpServicio02.Controls
                    rbtServicioVar2 = TryCast(ctrl, RadioButton)
                    If rbtServicioVar2 IsNot Nothing AndAlso rbtServicioVar2.Checked Then
                        If rbtServicioVar2.Tag = "22" Then
                            sb.Append("<tr><td>" & grpServicio02.Text & "</td><td>" & txtServOtros02.Text & "</td></tr>")
                        Else
                            sb.Append("<tr><td>" & grpServicio02.Text & "</td><td>" & rbtServicioVar2.Text & "</td></tr>")
                        End If
                    End If
                Next
                For Each ctrl As Control In grpServicio03.Controls
                    rbtServicioVar2 = TryCast(ctrl, RadioButton)
                    If rbtServicioVar2 IsNot Nothing AndAlso rbtServicioVar2.Checked Then
                        If rbtServicioVar2.Tag = "33" Then
                            sb.Append("<tr><td>" & grpServicio03.Text & "</td><td>" & txtServOtros03.Text & "</td></tr>")
                        Else
                            sb.Append("<tr><td>" & grpServicio03.Text & "</td><td>" & rbtServicioVar2.Text & "</td></tr>")
                        End If
                    End If
                Next
                For Each ctrl As Control In grpServicio04.Controls
                    rbtServicioVar2 = TryCast(ctrl, RadioButton)
                    If rbtServicioVar2 IsNot Nothing AndAlso rbtServicioVar2.Checked Then
                        If rbtServicioVar2.Tag = "44" Then
                            sb.Append("<tr><td>" & grpServicio04.Text & "</td><td>" & txtServOtros04.Text & "</td></tr>")
                        Else
                            sb.Append("<tr><td>" & grpServicio04.Text & "</td><td>" & rbtServicioVar2.Text & "</td></tr>")
                        End If
                    End If
                Next
                For Each ctrl As Control In grpServicio05.Controls
                    rbtServicioVar2 = TryCast(ctrl, RadioButton)
                    If rbtServicioVar2 IsNot Nothing AndAlso rbtServicioVar2.Checked Then
                        If rbtServicioVar2.Tag = "55" Then
                            sb.Append("<tr><td>" & grpServicio05.Text & "</td><td>" & txtServOtros01.Text & "</td></tr>")
                        Else
                            sb.Append("<tr><td>" & grpServicio05.Text & "</td><td>" & rbtServicioVar2.Text & "</td></tr>")
                        End If
                    End If
                Next
                For Each ctrl As Control In grpServicio06.Controls
                    rbtServicioVar2 = TryCast(ctrl, RadioButton)
                    If rbtServicioVar2 IsNot Nothing AndAlso rbtServicioVar2.Checked Then
                        If rbtServicioVar2.Tag = "66" Then
                            sb.Append("<tr><td>" & grpServicio06.Text & "</td><td>" & txtServOtros06.Text & "</td></tr>")
                        Else
                            sb.Append("<tr><td>" & grpServicio06.Text & "</td><td>" & rbtServicioVar2.Text & "</td></tr>")
                        End If
                    End If
                Next

                sb.Append("</tbody></table></td></tr>")

                If SOURCE.ListaEvidencias.Count > 0 Then
                    sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">EVIDENCIAS:</td></tr>")
                    sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">FECHA:</td><td>" & dtpEvidenciaFecha.DateTime.ToString("dd-MM-yyyy") & "</td><td></td></tr>")
                    sb.Append("<tr><td colspan=""3"">" & txtEvidenciaComentario.Text.Trim() & "</td></tr>")
                    sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">ARCHIVO:</td><td>" & txtEvidenciaArchivo.Text.Trim() & "</td><td></td></tr>")
                    sb.Append("<tr><td colspan=""3""><hr></td></tr>")
                End If

            End If

            If SOURCE.AprobacionProduccion.Observacion.Trim().Length > 0 Then
                sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">APROBACION DEL ÁREA DE PRODUCCIÓN:</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">FECHA:</td><td>")
                sb.Append(SOURCE.AprobacionProduccion.FechaAprobacion.ToString("dd-MM-yyyy HH:mm:ss"))
                sb.Append("</td><td>" & IIf(SOURCE.AprobacionProduccion.Aprobado, "ACEPTADO", "NO ACEPTADO") & "</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">REGISTRADO POR:</td><td colspan=""2"">")
                sb.Append(cboAprobProduccion.Text & "</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">OBSERVACIONES:</td><td colspan=""2"">")
                sb.Append(SOURCE.AprobacionProduccion.Observacion)
                sb.Append("</td></tr>")
                sb.Append("<tr><td colspan=""3""><hr></td></tr>")
            End If

            If SOURCE.AprobacionComercial.Observacion.Trim().Length > 0 Then
                sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">APROBACION DEL ÁREA COMERCIAL:</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">FECHA:</td><td>")
                sb.Append(SOURCE.AprobacionComercial.FechaAprobacion.ToString("dd-MM-yyyy HH:mm:ss"))
                sb.Append("</td><td>" & IIf(SOURCE.AprobacionComercial.Aprobado, "ACEPTADO", "NO ACEPTADO") & "</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">REGISTRADO POR:</td><td colspan=""2"">")
                sb.Append(cboAprobComercial.Text & "</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">OBSERVACIONES:</td><td colspan=""2"">")
                sb.Append(SOURCE.AprobacionComercial.Observacion)
                sb.Append("</td></tr>")
                sb.Append("<tr><td colspan=""3""><hr></td></tr>")
            End If

            If SOURCE.AprobacionLaboratorio.Observacion.Trim().Length > 0 Then
                sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">APROBACION DEL ÁREA DE LABORATORIO:</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">FECHA:</td><td>")
                sb.Append(SOURCE.AprobacionLaboratorio.FechaAprobacion.ToString("dd-MM-yyyy HH:mm:ss"))
                sb.Append("</td><td>" & IIf(SOURCE.AprobacionLaboratorio.Aprobado, "ACEPTADO", "NO ACEPTADO") & "</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">REGISTRADO POR:</td><td colspan=""2"">")
                sb.Append(cboAprobacionLaboratorio.Text & "</td></tr>")
                sb.Append("<tr><td style=""width:120px;text-align:left;font-weight:bold;"">OBSERVACIONES:</td><td colspan=""2"">")
                sb.Append(SOURCE.AprobacionLaboratorio.Observacion)
                sb.Append("</td></tr>")
                sb.Append("<tr><td colspan=""3""><hr></td></tr>")
            End If

            If SOURCE.Causas.Count > 0 Then
                sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">CAUSAS:</td></tr>")
                sb.Append("<tr><td colspan=""3"">")
                sb.Append("<table border=""1"" style=""font-size:12px;width:498px;"" cellpadding=""4"" cellspacing=""0"">")
                sb.Append("<thead><tr><th style=""width:20px;text-align:left;font-weight:bold;"">NRO.</th>")
                sb.Append("<th style=""width:200px;text-align:left;font-weight:bold;"">CAUSA INMEDIATA</th>")
                sb.Append("<th style=""width:270px;text-align:left;font-weight:bold;"">CAUSA RAIZ</th></tr>")
                sb.Append("</thead><tbody>")

                For Each item As ETReclamoCausa In SOURCE.Causas
                    For Each itemDet As ETReclamoCausaDetalle In item.Detalles
                        sb.Append("<tr><td>" & item.Item.ToString() & "</td><td>" & item.CausaOrigen & "</td>")
                        sb.Append("<td>" & itemDet.Item & " - " & itemDet.Descripcion & "</td></tr>")
                    Next
                Next

                sb.Append("</tbody></table></td></tr>")
                sb.Append("<tr><td colspan=""3""><hr></td></tr>")
                sb.Append("")
            End If

            If SOURCE.ListaPlanes.Count > 0 Then
                sb.Append("<tr><td colspan=""3"" style=""width:120px;text-align:left;font-weight:bold;"">PLAN DE ACCION:</td></tr>")
                sb.Append("<tr><td colspan=""3"">")
                sb.Append("<table border=""1"" style=""font-size:12px;width:498px;"" cellpadding=""4"" cellspacing=""0"">")
                sb.Append("<thead><tr>")
                sb.Append("<th style=""width:150px;text-align:left;font-weight:bold;"">ENCARGADO.</th>")
                sb.Append("<th style=""width:40px;text-align:left;font-weight:bold;"">FECHA</th>")
                sb.Append("<th style=""width:170px;text-align:left;font-weight:bold;"">ACCION A REALIZAR</th>")
                sb.Append("<th style=""width:30px;text-align:left;font-weight:bold;"">CLIENTE</th>")
                sb.Append("</tr></thead><tbody>")

                For Each plan As ETReclamoPlanAccion In SOURCE.ListaPlanes
                    sb.Append("<tr><td>" & plan.Encargado & "</td>")
                    sb.Append("<td>")
                    If plan.FechaEjecucion.HasValue Then
                        sb.Append(plan.FechaEjecucion.Value.ToString("dd-MM-yyyy"))
                    End If
                    sb.Append("<td>" & plan.AccionPorRealizar & "</td>")
                    sb.Append("<td>" & IIf(plan.Notifica, "SI", "NO") & "</td>")
                Next
                sb.AppendLine("</td>")
                sb.Append("</tbody></table>")
                sb.Append("</td></tr>")

            End If

            sb.Append("</tbody></table>")
            sb.Append("</body></html>")

            'sb.AppendLine("")
            'sb.AppendLine("NRO: " & txtNro.Text.Trim())
            'sb.AppendLine("CLIENTE: " & txtClienteCodigo.Text.Trim() & " - " & txtClienteRazonSocial.Text.Trim())
            'sb.AppendLine("FECHA: " & dtpFechaRegistro.DateTime.ToString("dd-MM-yyyy"))
            'sb.AppendLine("REGISTRADO POR: " & txtPersonaRegistra.Text.Trim())

            'sb.AppendLine("")
            'sb.AppendLine("------------------------------------")
            'sb.AppendLine("")

            'If rbtTipoProducto.Checked Then

            '    sb.AppendLine("MOTIVO: " & txtProductoMotivo.Text.Trim())
            '    sb.AppendLine("COMENTARIO: " & txtProductoObservacion.Text.Trim())

            '    For Each oGuia As ETReclamoProductoDetalle In SOURCE.Producto.ListaDetalles
            '        sb.AppendLine("PRODUCTO: " & oGuia.COD_PRODUCTO & " - " & oGuia.PRODUCTO)
            '        sb.AppendLine("CANTIDAD: " & oGuia.CANT_FACTURADA & " " & oGuia.UNIDAD)
            '        sb.AppendLine("LOTE:" & oGuia.LOTE)
            '    Next

            'End If

            'Dim rbtServicioVar As RadioButton = Nothing

            'If rbtTipoServicio.Checked Then
            '    For Each ctrl As Control In grpServicio01.Controls
            '        rbtServicioVar = TryCast(ctrl, RadioButton)
            '        If rbtServicioVar IsNot Nothing Then
            '            If rbtServicioVar.Tag = "11" Then
            '            Else
            '                sb.AppendLine(grpServicio01.Text & " Por " & rbtServicioVar.Text)
            '            End If
            '        End If
            '    Next
            '    For Each ctrl As Control In grpServicio02.Controls
            '        rbtServicioVar = TryCast(ctrl, RadioButton)
            '        If rbtServicioVar IsNot Nothing Then
            '            If rbtServicioVar.Tag = "22" Then
            '                sb.AppendLine(grpServicio02.Text & " Por " & txtServOtros02.Text)
            '            Else
            '                sb.AppendLine(grpServicio02.Text & " Por " & rbtServicioVar.Text)
            '            End If
            '        End If
            '    Next
            '    For Each ctrl As Control In grpServicio03.Controls
            '        rbtServicioVar = TryCast(ctrl, RadioButton)
            '        If rbtServicioVar IsNot Nothing Then
            '            If rbtServicioVar.Tag = "33" Then
            '                sb.AppendLine(grpServicio03.Text & " Por " & txtServOtros03.Text)
            '            Else
            '                sb.AppendLine(grpServicio03.Text & " Por " & rbtServicioVar.Text)
            '            End If
            '        End If
            '    Next
            '    For Each ctrl As Control In grpServicio04.Controls
            '        rbtServicioVar = TryCast(ctrl, RadioButton)
            '        If rbtServicioVar IsNot Nothing Then
            '            If rbtServicioVar.Tag = "44" Then
            '                sb.AppendLine(grpServicio04.Text & " Por " & txtServOtros04.Text)
            '            Else
            '                sb.AppendLine(grpServicio04.Text & " Por " & rbtServicioVar.Text)
            '            End If
            '        End If
            '    Next
            '    For Each ctrl As Control In grpServicio05.Controls
            '        rbtServicioVar = TryCast(ctrl, RadioButton)
            '        If rbtServicioVar IsNot Nothing Then
            '            If rbtServicioVar.Tag = "55" Then
            '                sb.AppendLine(grpServicio05.Text & " Por " & txtServOtros05.Text)
            '            Else
            '                sb.AppendLine(grpServicio05.Text & " Por " & rbtServicioVar.Text)
            '            End If
            '        End If
            '    Next
            '    For Each ctrl As Control In grpServicio06.Controls
            '        rbtServicioVar = TryCast(ctrl, RadioButton)
            '        If rbtServicioVar IsNot Nothing Then
            '            If rbtServicioVar.Tag = "66" Then
            '                sb.AppendLine(grpServicio06.Text & " Por " & txtServOtros06.Text)
            '            Else
            '                sb.AppendLine(grpServicio06.Text & " Por " & rbtServicioVar.Text)
            '            End If
            '        End If
            '    Next
            'End If
            'If SOURCE.ListaEvidencias.Count > 0 Then
            '    sb.AppendLine("")
            '    sb.AppendLine("------------------------------------")
            '    sb.AppendLine("")
            '    sb.AppendLine("EVIDENCIAS")
            '    For Each item As ETReclamoEvidencia In SOURCE.ListaEvidencias
            '        sb.AppendLine(item.Fecha.ToString("dd-MM-yyyy"))
            '        sb.AppendLine(item.Comentario)
            '        sb.AppendLine(item.Archivo)
            '    Next
            'End If
            'If SOURCE.ListaMuestras.Count > 0 Then

            '    sb.AppendLine("")
            '    sb.AppendLine("------------------------------------")
            '    sb.AppendLine("")

            '    sb.AppendLine("MUESTRAS")

            '    For Each item As ETReclamoMuestra In SOURCE.ListaMuestras
            '        sb.AppendLine("PRODUCTO: " & item.PRODUCTO & " " & item.LOTE & " " & item.NROBOLSA)
            '    Next

            'End If

            'If SOURCE.ListaMuestrasLab.Count > 0 Then

            '    sb.AppendLine("")
            '    sb.AppendLine("------------------------------------")
            '    sb.AppendLine("")

            '    sb.AppendLine("INFORMES LABORATORIO")

            '    For Each item As EtReclamoMuestraLab In SOURCE.ListaMuestrasLab
            '        sb.AppendLine("PRODUCTO: " & item.PRODUCTO & " " & item.LOTE & " " & item.NROBOLSA & " INFORME ENTREGADO:")
            '    Next

            'End If

            'If SOURCE.Causas.Count > 0 Then

            '    sb.AppendLine("")
            '    sb.AppendLine("------------------------------------")
            '    sb.AppendLine("")

            '    sb.AppendLine("CAUSA ORIGEN DEL RECLAMO")

            '    For Each item As ETReclamoCausa In SOURCE.Causas
            '        sb.AppendLine("")
            '        sb.AppendLine("CAUSA: " & item.CausaOrigen)

            '        For Each itemDet As ETReclamoCausaDetalle In item.Detalles
            '            sb.AppendLine(vbTab & itemDet.Item & ". " & itemDet.Descripcion)
            '        Next

            '    Next

            'End If

            'If SOURCE.ListaPlanes.Count > 0 Then

            '    Dim oPlanAccion As ETReclamoPlanAccion = SOURCE.ListaPlanes.FirstOrDefault(Function(p) p.Notifica = True)

            '    If oPlanAccion IsNot Nothing Then
            '        sb.AppendLine("")
            '        sb.AppendLine("------------------------------------")
            '        sb.AppendLine("")

            '        sb.AppendLine("PLAN DE ACCION")

            '        For Each plan As ETReclamoPlanAccion In SOURCE.ListaPlanes

            '            sb.AppendLine("ENCARGADO: " & plan.Encargado & " - ACCION: " & plan.AccionPorRealizar)

            '        Next

            '    End If

            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try



        Return sb.ToString
    End Function

#End Region

#Region "METODOS"

    Sub Grabar() 'MANTENIMIENTO

        CargarUsuarioSistema()

        If User_Sistema = "DCACERES" Then
            MostrarMensaje("No cuenta con permisos para registrar información")
            Exit Sub
        End If

        Dim key As String = String.Empty
        Dim Asunto As String = String.Empty
        Dim AsuntoSufix As String = " |QUEJA NRO: " & txtNro.Text & " | CLIENTE: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.Value.ToString()
        Dim Contenido As String = String.Empty
        Dim Importancia As MailPriority = MailPriority.Normal
        Dim RutaAdjunto As String = String.Empty
        Dim destinatarios As New List(Of MailAddress)
        Dim destinatarios_aux As New List(Of MailAddress)

        If tabReclamo.SelectedTab Is Nothing Then Return

        If tabReclamo.SelectedTab.Key = "T01" Then 'Registro de Reclamos

            If Me.tabTipoReclamo.SelectedTab Is Nothing Then Return

            key = tabTipoReclamo.SelectedTab.Key

            If key = "TT01" OrElse key = "TT02" Then ' producto - servicio

                If GrabarDatosReclamo() Then
                    destinatarios = Correo_ObtenerCorreosRegistroReclamo_1(SOURCE)
                    Asunto = "REGISTRO QUEJA" & " |QUEJA NRO: " & txtNro.Text & " | CLIENTE: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.Value.ToString()
                    Contenido = GenerarContenidoReclamo("Se registró la siguiente queja. Recuerde que tiene 3 días para registrar la entrega de muestras a laboratorio")

                    CargarDatos(SOURCE)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If

            End If
            If key = "TT09" Then ' Evidencias
                If GrabarDatosEvidencia() Then

                    destinatarios_aux = Correo_ObtenerRepresentanteCuentaYJefe(SOURCE)
                    For Each mail As MailAddress In destinatarios_aux
                        Dim str_mail As String = mail.Address
                        If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                            destinatarios.Add(mail)
                        End If
                    Next

                    'los destinatarios dependen del req 
                    If SOURCE.RequiereAprobProd Then
                        destinatarios_aux = Correo_ObtenerCorreosRevision_3_Prod(SOURCE)
                        For Each mail As MailAddress In destinatarios_aux
                            Dim str_mail As String = mail.Address
                            If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                destinatarios.Add(mail)
                            End If
                        Next
                    End If

                    If SOURCE.RequiereAprobLab Then
                        destinatarios_aux = Correo_ObtenerCorreosRevision_3_Lab(SOURCE)
                        For Each mail As MailAddress In destinatarios_aux
                            Dim str_mail As String = mail.Address
                            If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                destinatarios.Add(mail)
                            End If
                        Next
                    End If

                    If SOURCE.RequiereAprobCom Then
                        destinatarios_aux = Correo_ObtenerCorreosRevision_3_Com(SOURCE)
                        For Each mail As MailAddress In destinatarios_aux
                            Dim str_mail As String = mail.Address
                            If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                destinatarios.Add(mail)
                            End If
                        Next
                    End If

                    'destinatarios = Correo_ObtenerCorreosRevisionLaboratorio_3(SOURCE)
                    Asunto = "REGISTRO DE EVIDENCIA" & AsuntoSufix
                    Contenido = GenerarContenidoReclamo("Se han adjuntado las evidencias a la queja, Recuerde que tiene 1 día para aprobar o rechazar las evidencias enviadas")

                    CargarDatos(SOURCE)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

                End If
            End If
            If key = "TT03" Then ' Muestra

                If GrabarDatosMuestra() Then
                    destinatarios = Correo_ObtenerCorreosEntregaMuestra_2(SOURCE)
                    Asunto = "ENTREGA DE MUESTRAS" & AsuntoSufix
                    Contenido = GenerarContenidoReclamo("Se entregaron las siguientes muestras a laboratorio , Recuerde que tiene 1 día para registrar la conformidad de las muestras")

                    CargarDatos(SOURCE)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If

            End If

            If key = "TT04" Then ' Laboratorio

                If GrabarDatosLaboratorio() Then
                    If SOURCE.Estado = "PRODUCTO" Or SOURCE.Estado = "SERVICIO" Then
                        destinatarios = Correo_ObtenerCorreosRegistroReclamo_1(SOURCE)
                        Asunto = "INCONFORMIDAD DE MUESTRAS" & AsuntoSufix
                        Contenido = GenerarContenidoReclamo("El area de Laboratorio ha rechazado las muestras enviadas , debe volver a generarlas")
                        'EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

                        CargarDatos(SOURCE)

                        EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

                    End If
                    If SOURCE.Estado = ESTLAB_INFORME Then
                        destinatarios = Correo_ObtenerCorreosRevisionLaboratorio_3(SOURCE)
                        Asunto = "INFORME DE LABORATORIO" & AsuntoSufix
                        Contenido = GenerarContenidoReclamo("El area de Laboratorio ha entregado el Informe de Muestras, Recuerde que tiene 1 día para aprobar o rechazar los informes")

                        CargarDatos(SOURCE)

                        EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

                    End If

                    If SOURCE.Estado = ESTLAB_CONFORMIDAD Then
                        destinatarios = Correo_ObtenerCorreosEntregaMuestra_2(SOURCE)
                        Asunto = "CONFORMIDAD DE LABORATORIO" & AsuntoSufix
                        Contenido = GenerarContenidoReclamo("El area de Laboratorio ha dado conformidad a la recepción de muestras, Recuerde que tiene 3 día para registrar los informes")

                        CargarDatos(SOURCE)

                        EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

                    End If
                End If

            End If

            If key = "TT08" Then ' Aprobacion Informes

                If GrabarDatosAprobacionInformesLaboratorio() Then

                    Dim EstadoReclamo As ETReclamoPermisos = NReclamo.ObtenerEstadoReclamo(SOURCE)
                    Dim areas As String = ""
                    Dim req As Integer = 0
                    Dim aprob As Integer = 0

                    If SOURCE.RequiereAprobProd Then
                        req += 1
                        If EstadoReclamo.AprobProduccion Then
                            aprob += 1
                            areas += "Gerencia de Producción"
                        Else
                            destinatarios_aux = Correo_ObtenerCorreosRevision_3_Prod(SOURCE)
                            For Each mail As MailAddress In destinatarios_aux
                                Dim str_mail As String = mail.Address
                                If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                    destinatarios.Add(mail)
                                End If
                            Next
                        End If
                    End If
                    If SOURCE.RequiereAprobLab Then
                        req += 1
                        If EstadoReclamo.AprobLaboratorio Then
                            aprob += 1
                            areas += IIf(areas.Length = 0, "Gerencia de Laboratorio", ",Gerencia de Laboratorio")
                        Else
                            destinatarios_aux = Correo_ObtenerCorreosRevision_3_Lab(SOURCE)
                            For Each mail As MailAddress In destinatarios_aux
                                Dim str_mail As String = mail.Address
                                If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                    destinatarios.Add(mail)
                                End If
                            Next
                        End If

                    End If
                    If SOURCE.RequiereAprobCom Then
                        req += 1
                        If EstadoReclamo.AprobacionComercial Then
                            aprob += 1
                            areas += IIf(areas.Length = 0, "Gerencia Comercial", ",Gerencia Comercial")
                        Else
                            destinatarios_aux = Correo_ObtenerCorreosRevision_3_Com(SOURCE)
                            For Each mail As MailAddress In destinatarios_aux
                                Dim str_mail As String = mail.Address
                                If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                    destinatarios.Add(mail)
                                End If
                            Next
                        End If

                    End If
                    destinatarios = Correo_ObtenerCorreosAprobacion_4(SOURCE)

                    If SOURCE.Tipo = "1" Then
                        Asunto = "APROBACION INFORMES LABORATORIO" & AsuntoSufix
                        Contenido = GenerarContenidoReclamo("Gerencia de Producción ha revisado los informes de Laboratorio , Se requiere la revision del formato que se enviará al cliente")

                    Else
                        If req = aprob Then
                            Asunto = "REVISIÓN COMPLETA DE EVIDENCIAS DE LA QUEJA" & AsuntoSufix
                            Contenido = GenerarContenidoReclamo(areas & " ha revisado las evidencias , Se requiere la revision del formato que se enviará al cliente")
                        Else
                            Asunto = "REVISIÓN PARCIAL DE EVIDENCIAS DE LA QUEJA" & AsuntoSufix
                            Contenido = GenerarContenidoReclamo(areas & " ha revisado las evidencias , Se requiere la aprobación de las otras gerencias")
                        End If
                    End If

                    CargarDatos(SOURCE)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If

            End If

            If key = "TT10" Then ' Correo Evidencia

                If GrabarDatosEvidenciaCorreo() Then
                    destinatarios = Correo_ObtenerCorreosEntregaMuestra_2(SOURCE)
                    Asunto = "EVIDENCIA DE CORREO" & AsuntoSufix
                    'Contenido = GenerarContenidoReclamo("Se entregaron las siguientes muestras a laboratorio , Recuerde que tiene 1 día para registrar la conformidad de las muestras")

                    CargarDatos(SOURCE)

                    'EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If

            End If

            If key = "TT05" Then ' Areas a Solucionar

                If GrabarDatosReunion() Then
                    destinatarios = Correo_ObtenerCorreosReunion_5(SOURCE)
                    Asunto = "PROGRAMACION REUNIÓN" & AsuntoSufix
                    Contenido = GenerarContenidoReclamo("Se ha agendado una reunión para la siguiente queja")

                    EnviarMailReunion()

                    CargarDatos(SOURCE)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If

            End If

            If key = "TT07" Then ' Analisis del Problema

                If GrabarAnalisisProblema() Then
                    destinatarios = Correo_ObtenerCorreosAnalisis_6(SOURCE)
                    Asunto = "ANALISIS DE CAUSA" & AsuntoSufix
                    Contenido = GenerarContenidoReclamo("Se han registrado las causas inmediatas y raiz de la queja, recuerde que debe generar los planes de acción en un plazo no mayor a 1 día.")

                    CargarDatos(SOURCE)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If

            End If
            If key = "TT06" Then ' Planes de Accion
                If GrabarPlanesAccion() Then
                    destinatarios = Correo_ObtenerCorreosPlanAccion_7(SOURCE)
                    Asunto = "PLAN DE ACCION" & AsuntoSufix
                    Contenido = GenerarContenidoReclamo("Se han elaborado los planes de accion.Recuerde que debe aprobar su envio al cliente en un plazo de 1 día.")
                    'El envio del plan de acción requiere que sea aprobado por gerencia comercial
                    'RutaAdjunto = "RECLAMO_" & SOURCE.Nro & ".pdf"

                    CargarDatos(SOURCE)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If

            End If

        End If

        If tabReclamo.SelectedTab.Key = "TFORMATO" Then

            If GrabarFormatoCliente() Then

                Dim rutaFormato As String = GenerarFormatoCliente()

                If MessageBox.Show("Desea enviar el reporte al cliente?", "Sistema de Quejas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Contenido = GenerarContenidoFormato()
                    EnviarMail(Correo_ObtenerCorreosAprobacionFinal_8(SOURCE), "QUEJA " & AsuntoSufix, Contenido & SOURCE.Nro, MailPriority.Normal, rutaFormato)
                    SOURCE.Estado = E_APROBGER
                    NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                End If

                System.Diagnostics.Process.Start(rutaFormato)
            End If


            'If GrabarAprobacionReclamo() Then

            'Dim rutaArchivo As String = GenerarArchivoReporte()

            '    Contenido = "Estimado :" & SOURCE.Cliente & Environment.NewLine & "Se adjunta informe sobre el reclamo" & SOURCE.Nro
            '    EnviarMail(Correo_ObtenerCorreosAprobacionFinal_8(SOURCE), Contenido, "  " & SOURCE.Nro, MailPriority.Normal, rutaArchivo)
            'End If
        End If


    End Sub

    Function GrabarDatosEvidenciaCorreo() As Boolean
        'DAO
        Dim resp As Boolean = False

        If SOURCE.Id = 0 Then
            MsgBox("Registre la queja primero", MsgBoxStyle.OkOnly, msgComacsa)
            Return False
        End If

        If txtruta.Text.Trim.Length = 0 Then
            MsgBox("Ingrese archivo de la evidencia de envio de correo", MsgBoxStyle.OkOnly, msgComacsa)
            Return False
        End If

        If chkReqNotaCredito.Checked Then
            If txtRegNotaCredito.Text.Trim.Length = 0 Then
                MsgBox("Ingrese el numero de Nota de Credito, Comercial indica que es necesario.", MsgBoxStyle.OkOnly, msgComacsa)
                txtRegNotaCredito.Enabled = True
                txtRegNotaCredito.BackColor = Color.White
                Return False
            End If
        Else
            txtRegNotaCredito.Enabled = False
            txtRegNotaCredito.BackColor = SystemColors.Control
            txtRegNotaCredito.Text = ""
        End If


        SOURCE.RutaCorreo = txtruta.Text.Trim()
        SOURCE.RequiereAprobProd = True
        SOURCE.RequiereAprobCom = True
        SOURCE.RequiereAprobLab = False

        SOURCE.NroNCredito = txtRegNotaCredito.Text.Trim()
        SOURCE.RegNotaCredito = chkReqNotaCredito.Checked

        'validamos los cambios de estado

        'ugMuestras.UpdateData()

        'Dim FaltaAdjunto As Boolean = False

        'For Each oMuestras As ETReclamoMuestra In SOURCE.ListaMuestras
        '    If oMuestras.ESTADO <> "EN CURSO" AndAlso oMuestras.ESTADO_OBS.Trim().Length = 0 Then
        '        MsgBox("Si cambia el estado de la muestra , debe ingresar el motivo", MsgBoxStyle.OkOnly, msgComacsa)
        '        Return False
        '    End If
        '    If oMuestras.ESTADO = "EN CURSO" AndAlso oMuestras.ARCHIVOM.Length = 0 Then
        '        FaltaAdjunto = True
        '    End If
        'Next

        'If FaltaAdjunto Then
        '    If MsgBox("Recuerde adjuntar un archivo que sustente la queja en caso aplique", MsgBoxStyle.OkOnly, msgComacsa) Then

        '    End If
        'End If

        If mostrarMensajeConfirmacion("EVIDENCIA DE CORREO") Then
            Return False
        End If

        Dim oResultado As ETResultado = Nothing
        oResultado = NReclamo.RegistrarEvidenciaCorreo(SOURCE)
        If oResultado.Realizo Then
            SOURCE.Estado = "EVIDENCIA DE CORREO"
            NReclamo.ActualizarEstado(SOURCE, User_Sistema)
            MostrarMensaje("Registro de Evidencia de Correo Completo")
            resp = True
        Else
            MostrarError("Ocurrio un Error en el Registro de Evidencia de Correo")
        End If

        Return resp
    End Function

    Sub CargarDatosFormatoReporte()

        txtFormatoCliente.Text = txtClienteRazonSocial.Text

        If SOURCE.ListaEmailsCliente.Count > 0 Then
            txtFormatoContacto.Text = SOURCE.ListaEmailsCliente(0).Correo
        End If

        txtFormatoFecha.Text = SOURCE.Fecha.ToString("dd/MM/yyyy HH:mm:ss")
        txtFormatoUser.Text = SOURCE.UsuarioResponsable.Nombre

        Dim lst As New List(Of ETReclamoPlanAccion)
        Dim lstPlanes As New List(Of ETReclamoPlanAccion)

        If SOURCE.Tipo = "1" Then
            txtFormatoComentarios.Text = SOURCE.Producto.Observacion
        Else
            txtFormatoComentarios.Text = SOURCE.ServicioObservacion
        End If

        Dim oFormato As New ETReclamoFormato

        oFormato.id = SOURCE.Id

        oFormato = NReclamo.ObtenerFormato(oFormato)

        If oFormato.id = 0 Then
            CargarDatosFormatoReporteSinGrabar()
        Else
            txtFormatoComentarios.Text = oFormato.comentarios

            SOURCE.FormatoComentarios.Clear()
            Dim oComentario As ETReclamoPlanAccion

            For Each comentario As ETReclamoFormatoComentarios In oFormato.ListaComentarios
                oComentario = New ETReclamoPlanAccion
                oComentario.ETEncargado.Codigo = comentario.user
                oComentario.ETEncargado.Nombre = comentario.user
                oComentario.AccionPorRealizar = comentario.comentarios
                oComentario.Estado = comentario.estado
                SOURCE.FormatoComentarios.Add(oComentario)
            Next

            SOURCE.FormatoPlanes.Clear()
            Dim oPlan As ETReclamoPlanAccion

            For Each plan As ETReclamoFormatoPlan In oFormato.ListaPlanes
                oPlan = New ETReclamoPlanAccion
                oPlan.AccionPorRealizar = plan.acciones
                oPlan.ETEncargado.Codigo = plan.user
                oPlan.ETEncargado.Nombre = plan.user
                SOURCE.FormatoPlanes.Add(oPlan)
            Next
        End If
    End Sub
    Sub CargarDatosFormatoReporteSinGrabar()
        Try

            SOURCE.FormatoComentarios.Clear()
            SOURCE.FormatoPlanes.Clear()

            If SOURCE.Tipo = "1" Or (SOURCE.Tipo = "2" And SOURCE.RequiereAprobProd) Then

                Dim itemAprobProd As New ETReclamoPlanAccion
                itemAprobProd.ETEncargado = SOURCE.AprobacionProduccion.Gerente
                itemAprobProd.AccionPorRealizar = SOURCE.AprobacionProduccion.Observacion
                itemAprobProd.Estado = IIf(SOURCE.AprobacionProduccion.Aprobado, "ACEPTADO", "NO ACEPTADO")
                itemAprobProd.Notifica = SOURCE.AprobacionProduccion.Aprobado

                SOURCE.FormatoComentarios.Add(itemAprobProd)

                If SOURCE.AprobacionProduccion.Aprobado Then
                    Dim itemPlan As New ETReclamoPlanAccion
                    itemPlan.ETEncargado = SOURCE.AprobacionProduccion.Gerente
                    itemPlan.AccionPorRealizar = SOURCE.AprobacionProduccion.AccionesPorTomar
                    itemPlan.Notifica = SOURCE.AprobacionProduccion.Aprobado

                    SOURCE.FormatoPlanes.Add(itemPlan)
                End If

            End If
            If SOURCE.Tipo = "2" And SOURCE.RequiereAprobLab Then
                Dim itemAprobLab As New ETReclamoPlanAccion
                itemAprobLab.ETEncargado = SOURCE.AprobacionLaboratorio.Gerente
                itemAprobLab.AccionPorRealizar = SOURCE.AprobacionLaboratorio.Observacion
                itemAprobLab.Estado = IIf(SOURCE.AprobacionLaboratorio.Aprobado, "ACEPTADO", "NO ACEPTADO")
                itemAprobLab.Notifica = SOURCE.AprobacionLaboratorio.Aprobado

                SOURCE.FormatoComentarios.Add(itemAprobLab)

                If SOURCE.AprobacionLaboratorio.Aprobado Then
                    Dim itemPlan As New ETReclamoPlanAccion
                    itemPlan.ETEncargado = SOURCE.AprobacionLaboratorio.Gerente
                    itemPlan.AccionPorRealizar = SOURCE.AprobacionLaboratorio.AccionesPorTomar
                    itemPlan.Notifica = SOURCE.AprobacionLaboratorio.Aprobado

                    SOURCE.FormatoPlanes.Add(itemPlan)
                End If
            End If
            If SOURCE.Tipo = "2" And SOURCE.RequiereAprobCom Then
                Dim itemAprobCom As New ETReclamoPlanAccion
                itemAprobCom.ETEncargado = SOURCE.AprobacionComercial.Gerente
                itemAprobCom.AccionPorRealizar = SOURCE.AprobacionComercial.Observacion
                itemAprobCom.Estado = IIf(SOURCE.AprobacionComercial.Aprobado, "ACEPTADO", "NO ACEPTADO")
                itemAprobCom.Notifica = SOURCE.AprobacionComercial.Aprobado

                SOURCE.FormatoComentarios.Add(itemAprobCom)

                If SOURCE.AprobacionComercial.Aprobado Then
                    Dim itemPlan As New ETReclamoPlanAccion
                    itemPlan.ETEncargado = SOURCE.AprobacionComercial.Gerente
                    itemPlan.AccionPorRealizar = SOURCE.AprobacionComercial.AccionesPorTomar
                    itemPlan.Notifica = SOURCE.AprobacionComercial.Aprobado

                    SOURCE.FormatoPlanes.Add(itemPlan)
                End If
            End If

        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub
    Function GrabarFormatoCliente() As Boolean

        Dim resultado As Boolean = False

        Try
            Dim pFormato As New ETReclamoFormato
            pFormato.id = SOURCE.Id
            pFormato.fecha = SOURCE.Fecha
            pFormato.comentarios = txtFormatoComentarios.Text.Trim()
            pFormato.user = User_Sistema

            gridFormatoComentarios.UpdateData()

            Dim oComentario As ETReclamoFormatoComentarios
            For Each comentario As ETReclamoPlanAccion In SOURCE.FormatoComentarios
                oComentario = New ETReclamoFormatoComentarios
                oComentario.id = pFormato.id
                oComentario.comentarios = comentario.AccionPorRealizar
                oComentario.user = comentario.EncargadoCodigo
                oComentario.estado = comentario.Estado
                pFormato.ListaComentarios.Add(oComentario)
            Next

            gridFormatoPLanAccion.UpdateData()

            Dim oPlan As ETReclamoFormatoPlan
            For Each plan As ETReclamoPlanAccion In SOURCE.FormatoPlanes
                oPlan = New ETReclamoFormatoPlan
                oPlan.id = pFormato.id
                oPlan.acciones = plan.AccionPorRealizar
                oPlan.user = plan.EncargadoCodigo
                pFormato.ListaPlanes.Add(oPlan)
            Next

            Dim r As ETResultado = NReclamo.RegistrarFormato(pFormato)

            resultado = True

        Catch ex As Exception
            MostrarError(ex.Message)
        End Try

        Return resultado
    End Function

    Function GenerarFormatoCliente() As String

        Dim rutaArchivo As String = ""

        Try
            Dim rpt As New ReportDocument
            rpt.Load(rutaReportes & "rptFormatoCliente.rpt")

            Dim ds As DataSet = NReclamo.ReporteFormato(SOURCE)

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then

                    rpt.SetDataSource(ds)

                    rutaArchivo = rutaArchivosGenerados & "\RECLAMO_FORMATO_" & SOURCE.Nro & ".pdf"

                    rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaArchivo)

                End If
            End If

        Catch ex As Exception
            MostrarError(ex.Message)
        End Try

        Return rutaArchivo

    End Function

    Public Overridable Sub BuscarListadoReclamos()

        Try
            dtConfiguracion = NReclamo.ListarConfiguracion()
            dia_muestra = dtConfiguracion.Rows(0)("DIAS")
            dia_muestra_serv = dtConfiguracion.Rows(1)("DIAS")
            dia_lab = dtConfiguracion.Rows(2)("DIAS")
            dia_lab_serv = dtConfiguracion.Rows(3)("DIAS")
            dia_prod = dtConfiguracion.Rows(4)("DIAS")
            dia_prod_serv = dtConfiguracion.Rows(5)("DIAS")
            dia_com = dtConfiguracion.Rows(6)("DIAS")
            dia_com_serv = dtConfiguracion.Rows(7)("DIAS")


            Dim pReclamo As New ETReclamo

            pReclamo.ClienteCodigo = txtBusquedaCliente.Text.Trim()
            pReclamo.FechaFin = dtpBusFechaFin.Value
            pReclamo.Fecha = dtpBusFechaInicio.Value

            If chkFiltroFechas.Checked Then
                If dtpBusFechaInicio.Value Is Nothing OrElse dtpBusFechaFin.Value Is Nothing Then
                    MsgBox("Fechas Inválidas para la búsqueda", MsgBoxStyle.OkOnly, msgComacsa)
                    Return
                Else
                    LISTA_SOURCE = NReclamo.ListarReclamos(pReclamo, "FECHAS")
                End If
            Else
                LISTA_SOURCE = NReclamo.ListarReclamos(pReclamo, "TODOS")
            End If

            ugPrincipal.DataSource = LISTA_SOURCE

            ' Obtiene la banda principal
            Dim band As UltraGridBand = ugPrincipal.DisplayLayout.Bands(0)

            ' Configura las columnas
            band.Columns("Fecha").Header.Caption = "Fecha"
            band.Columns("Nro").Header.Caption = "Nro"
            band.Columns("Cliente").Header.Caption = "Cliente"
            band.Columns("Responsable").Header.Caption = "Responsable"
            band.Columns("EstadoComentado").Header.Caption = "Estado Obs"

            ' Hide the "RequiereAprobNc" column
            band.Columns("RequiereAprobNc").Hidden = True
            ' Hide the "Pareto" column
            band.Columns("Pareto").Hidden = True
            ' Hide the "RegNotaCredito" column
            band.Columns("RegNotaCredito").Hidden = True
            ' Hide the "NroNCredito" column
            band.Columns("NroNCredito").Hidden = True

        Catch ex As Exception
            MostrarError(ex.Message)
        End Try

    End Sub
    Sub BuscarClienteListado()
        Dim frm As New FrmListaClientes()
        frm.ShowDialog()

        txtBusquedaCliente.Text = Cliente
        txtBusquedaClienteCodigo.Text = codCliente

    End Sub

    Sub AsignarClienteSeleccionado(ByVal pCodCliente As String, ByVal pCliente As String)
        If Not rbtTipoExportacion.Checked And Not rbtTipoNacional.Checked Then
            MostrarAdvertencia("Seleccione si la queja es de tipo nacional o de exportación")
            Exit Sub
        End If

        SOURCE.ClienteCodigo = pCodCliente
        SOURCE.Cliente = pCliente

        SOURCE.UsuarioResponsable = NReclamo.ObtenerRepresentamtePorCLiente(pCodCliente)

        txtResponsableVenta.Text = SOURCE.Responsable
        txtOrganizador.Text = SOURCE.Responsable
        txtAnalisisResponsable.Text = SOURCE.Responsable

        txtClienteCodigo.Text = pCodCliente
        txtClienteRazonSocial.Text = pCliente
        txtClienteEmail.Text = ""

        txtSolucionClienteCodigo.Text = pCodCliente
        txtSolucionClienteRazonSocial.Text = pCliente
        Dim tipo As String = ""
        Dim pareto As String = ""
        If rbtTipoNacional.Checked Then
            tipo = "N"
        End If
        If rbtTipoExportacion.Checked Then
            tipo = "E"
        End If

        If rbtParetoSI.Checked Then
            pareto = "S"
        End If

        If rbtParetoNO.Checked Then
            pareto = "N"
        End If


        SOURCE.ListaEmailsCliente = New BindingList(Of ETReclamoPersona)(NReclamo.CorreoEjecutivo(pCodCliente, tipo, pareto, User_Sistema))

        'If SOURCE.ListaEmailsCliente.Count > 0 Then
        '    txtClienteEmail.Text = SOURCE.ListaEmailsCliente(0).Correo
        '    txtSolucionEmail.Text = SOURCE.ListaEmailsCliente(0).Correo
        'End If

        If txtResponsableVenta.Text <> "" Then

            Dim xResponsableVenta As String = txtResponsableVenta.Text

            Dim oResponsableVenta As ETResponsableVenta = NReclamo.ObtenerCorreoPorNombre("01", xResponsableVenta)

            AsignarCorreoResponsableVenta(oResponsableVenta.Codigo, oResponsableVenta.Nombre, oResponsableVenta.Correo)




        End If



    End Sub

    ' AsignarCorreoResponsableVenta
    ' Hvilela 
    Sub AsignarCorreoResponsableVenta(ByVal pCodigo As String, ByVal pNombre As String, ByVal pCorreo As String)

        txtClienteEmail.Text = pCorreo

        '--txtResponsableVenta
        Dim frmCorreos As New frmReclamoCorreo()
        frmCorreos.PermitirAgregar = True

        ' Crear una nueva instancia de ETReclamoPersona y asignar valores
        Dim nuevoCorreoResponsableVenta As New ETReclamoPersona()
        nuevoCorreoResponsableVenta.Codigo = pCodigo
        nuevoCorreoResponsableVenta.Nombre = pNombre
        nuevoCorreoResponsableVenta.Correo = pCorreo
        nuevoCorreoResponsableVenta.Area = "CORREOCLIENTE"

        ' Añadir la nueva persona a la lista de correos del formulario frmReclamoCorreo

        SOURCE.ListaEmailsCliente.Add(nuevoCorreoResponsableVenta)

        'frmCorreos.RegistraListaCorreos(nuevoCorreoResponsableVenta)


    End Sub


    Sub BuscarClienteReclamo()
        Dim frm As New FrmListaClientes()
        frm.ShowDialog()

        AsignarClienteSeleccionado(codCliente, Cliente)

    End Sub
    Sub Buscar()

        If tabReclamo.SelectedTab Is Nothing Then Return

        If tabReclamo.SelectedTab.Key = "T04" Then
            BuscarListadoReclamos()
        End If

        If txtClienteCodigo.Focused Or txtClienteRazonSocial.Focused Then
            If Not rbtTipoExportacion.Checked And Not rbtTipoNacional.Checked Then
                MostrarAdvertencia("Seleccione si la queja es de tipo nacional o de exportación")
                Exit Sub
            End If
            BuscarClienteReclamo()
        End If
        If txtBusquedaClienteCodigo.Focused Or txtBusquedaCliente.Focused Then
            BuscarClienteListado()
        End If

    End Sub

    Sub InicializarFechas()
        Dim hoy As DateTime = DateTime.Now

        dtpAnalisisFecha.Value = hoy
        dtpAprobacionComFecha.Value = hoy
        dtpAprobacionProdFecha.Value = hoy
        dtpFechaRegistro.Value = hoy
        dtpFechaReunion.Value = hoy
        dtpMuestraFechaEntrega.Value = hoy

        dtpFechaFinSeg.Value = hoy.Date.AddDays(1)
        dtpFechaInicioSeg.Value = hoy.Date

        dtpBusFechaFin.Value = hoy.Date.AddDays(1)
        dtpBusFechaInicio.Value = hoy.Date.AddDays(-7)

        dtpSolucionFecha.Value = hoy.Date
        dtpSolucionHora.Value = hoy

    End Sub

    Sub Nuevo()

        tabReclamo.SelectedTab = tabReclamo.Tabs("T01")

        SOURCE = New ETReclamo

        InicializarFechas()

        BindearGrillas()

        CargarUsuarioSistema()

        '--- HV 22.05.24
        RemoveHandler rbtParetoSI.CheckedChanged, AddressOf rbtParetoSI_CheckedChanged
        RemoveHandler rbtParetoNO.CheckedChanged, AddressOf rbtParetoNO_CheckedChanged
        '---
        RemoveHandler rbtTipoNacional.CheckedChanged, AddressOf rbtTipoNacional_CheckedChanged
        RemoveHandler rbtTipoProducto.CheckedChanged, AddressOf rbtTipoProducto_CheckedChanged
        RemoveHandler rbtTipoExportacion.CheckedChanged, AddressOf rbtTipoExportacion_CheckedChanged
        RemoveHandler rbtTipoServicio.CheckedChanged, AddressOf rbtTipoServicio_CheckedChanged

        rbtParetoSI.Checked = False
        rbtParetoNO.Checked = False

        rbtTipoNacional.Checked = False
        rbtTipoProducto.Checked = False
        rbtTipoExportacion.Checked = False
        rbtTipoServicio.Checked = False

        AddHandler rbtParetoSI.CheckedChanged, AddressOf rbtParetoSI_CheckedChanged
        AddHandler rbtParetoNO.CheckedChanged, AddressOf rbtParetoNO_CheckedChanged

        AddHandler rbtTipoNacional.CheckedChanged, AddressOf rbtTipoNacional_CheckedChanged
        AddHandler rbtTipoProducto.CheckedChanged, AddressOf rbtTipoProducto_CheckedChanged
        AddHandler rbtTipoExportacion.CheckedChanged, AddressOf rbtTipoExportacion_CheckedChanged
        AddHandler rbtTipoServicio.CheckedChanged, AddressOf rbtTipoServicio_CheckedChanged

        grpTipoReclamo.Enabled = True
        grpOrigenReclamo.Enabled = True
        grpPareto.Enabled = True

        DesbloquearPanelSuperior(True)

        txtNro.Text = String.Empty
        dtpFechaRegistro.Value = DateTime.Now
        lblEstado.Text = String.Empty

        txtClienteCodigo.Text = String.Empty
        txtClienteRazonSocial.Text = String.Empty
        txtClienteEmail.Text = String.Empty

        txtResponsableVenta.Text = String.Empty
        'txtPersonaRegistra.Text = String.Empty

        'Producto
        txtProductoMotivo.Text = String.Empty
        txtProductoObservacion.Text = String.Empty

        DesHabilitarRadiosServicio(grpProducto01)
        DesHabilitarRadiosServicio(grpProducto02)
        DesHabilitarRadiosServicio(grpProducto03)

        txtProdOtros01.ReadOnly = True
        txtProdOtros01.Text = String.Empty
        txtProdOtros02.ReadOnly = True
        txtProdOtros02.Text = String.Empty
        txtProdOtros03.ReadOnly = True
        txtProdOtros03.Text = String.Empty

        'Servicios
        txtServicioComentarios.Text = String.Empty

        DesHabilitarRadiosServicio(grpServicio01)
        DesHabilitarRadiosServicio(grpServicio02)
        DesHabilitarRadiosServicio(grpServicio03)
        DesHabilitarRadiosServicio(grpServicio04)
        DesHabilitarRadiosServicio(grpServicio05)
        DesHabilitarRadiosServicio(grpServicio06)

        txtServOtros02.ReadOnly = True
        txtServOtros02.Text = String.Empty
        txtServOtros03.ReadOnly = True
        txtServOtros03.Text = String.Empty
        txtServOtros04.ReadOnly = True
        txtServOtros04.Text = String.Empty
        txtServOtros01.ReadOnly = True
        txtServOtros01.Text = String.Empty
        txtServOtros06.ReadOnly = True
        txtServOtros06.Text = String.Empty

        'Muestras
        txtMuestrasComentario1.Text = String.Empty
        txtMuestraObservacion.Text = String.Empty

        RemoveHandler rbtMuestraSI.CheckedChanged, AddressOf rbtMuestraSI_CheckedChanged
        RemoveHandler rbtMuestraNo.CheckedChanged, AddressOf RadioButton2_CheckedChanged

        rbtMuestraNo.Checked = True

        AddHandler rbtMuestraSI.CheckedChanged, AddressOf rbtMuestraSI_CheckedChanged
        AddHandler rbtMuestraNo.CheckedChanged, AddressOf RadioButton2_CheckedChanged

        'Laboratorio
        txtLabComentarioMuestra.Text = String.Empty
        txtLabComentarioProducto.Text = String.Empty

        'Evidencia
        dtpEvidenciaFecha.Value = DateTime.Now
        txtEvidenciaArchivo.Text = String.Empty
        txtEvidenciaComentario.Text = String.Empty
        txtEvidenciaComentario1.Text = String.Empty

        'Aprobacion
        txtAprobacionComObs.Text = String.Empty
        txtAprobacionProdObs.Text = String.Empty
        txtAprobacionLabObs.Text = String.Empty
        chkReqNotaCredito.Checked = False

        cboAprobComercial.SelectedValue = "0"
        cboAprobProduccion.SelectedValue = "0"
        cboAprobacionLaboratorio.SelectedValue = "0"

        txtAprobacionComPlan.Text = String.Empty
        txtAprobacionComPlan.Enabled = False

        txtAprobacionProdPlan.Text = String.Empty
        txtAprobacionProdPlan.Enabled = False

        txtAprobacionLabPlan.Text = String.Empty
        txtAprobacionLabPlan.Enabled = False

        RemoveHandler rbtnAprobacionProdAcepta.CheckedChanged, AddressOf rbtnAprobacionProdAcepta_CheckedChanged
        RemoveHandler rbtnAprobacionComAcepta.CheckedChanged, AddressOf rbtnAprobacionComAcepta_CheckedChanged
        RemoveHandler rbtnAprobacionLabAcepta.CheckedChanged, AddressOf rbtnAprobacionLabAcepta_CheckedChanged

        'Produccion
        rbtnAprobacionProdAcepta.Checked = False
        rbtnAprobacionProdNoAcepta.Checked = True
        'Comercial 
        rbtnAprobacionComAcepta.Checked = False
        rbtnAprobacionComNoAcepta.Checked = True

        chkReqNotaCredito.Checked = False
        txtRegNotaCredito.Enabled = False
        txtRegNotaCredito.BackColor = SystemColors.Control
        txtRegNotaCredito.Text = ""

        'Laboratorio 
        rbtnAprobacionLabAcepta.Checked = False
        rbtAprobacionLabNoAcepta.Checked = True

        AddHandler rbtnAprobacionProdAcepta.CheckedChanged, AddressOf rbtnAprobacionProdAcepta_CheckedChanged
        AddHandler rbtnAprobacionComAcepta.CheckedChanged, AddressOf rbtnAprobacionComAcepta_CheckedChanged
        AddHandler rbtnAprobacionLabAcepta.CheckedChanged, AddressOf rbtnAprobacionLabAcepta_CheckedChanged

        'Reunion
        txtResponsableOtros.Text = String.Empty
        txtResponsableOtrosNombre.Text = String.Empty
        txtOrganizador.Text = String.Empty

        'Analisis
        txtAnalisisResponsable.Text = String.Empty

        txtCausaItem.Text = "1"
        txtCausaDescripcion.Text = String.Empty
        txtCausa1.Text = String.Empty
        txtCausa2.Text = String.Empty
        txtCausa3.Text = String.Empty
        txtCausa4.Text = String.Empty
        txtCausa5.Text = String.Empty

        'Planes de Accion
        txtPlanResponsable.Text = String.Empty

        'Solucion
        cboSolucionAprobadoPor.SelectedValue = "0"
        txtSolucionClienteCodigo.Text = ""
        txtSolucionClienteRazonSocial.Text = ""
        txtSolucionEmail.Text = ""
        txtruta.Text = ""

        'botones en el tab tipo de reclamo
        tabTipoReclamo.Tabs("TT01").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT02").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT03").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT04").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT05").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT06").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT07").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT08").Appearance.Image = Nothing
        tabTipoReclamo.Tabs("TT09").Appearance.Image = Nothing
        tabReclamo.Tabs("TFORMATO").Appearance.Image = Nothing

        tabTipoReclamo.Tabs("TT01").Enabled = False
        tabTipoReclamo.Tabs("TT02").Enabled = False
        tabTipoReclamo.Tabs("TT03").Enabled = False
        tabTipoReclamo.Tabs("TT04").Enabled = False
        tabTipoReclamo.Tabs("TT05").Enabled = False
        tabTipoReclamo.Tabs("TT06").Enabled = False
        tabTipoReclamo.Tabs("TT07").Enabled = False
        'tabTipoReclamo.Tabs("TT08").Enabled = False
        tabTipoReclamo.Tabs("TT09").Enabled = False
        tabReclamo.Tabs("TFORMATO").Enabled = False

        InicializarFechas()

        'DesBloquearPaneles(True)

        DesBloquearPanelProductos(False)
        DesbloquearPanelMuestras(False)
        DesbloquearPanelServicios(False)
        DesbloquearPanelEvidencias(False)
        DesBloquearPanelLaboratorio(False)
        DesbloquearPanelAprobAreaProduccion(False)
        DesbloquearPanelAprobAreaComercial(False)
        DesbloquearPanelAprobAreaLaboratorio(False)
        DesbloquearPanelProgramacionReunion(False)
        DesbloquearPanelAnalisis(False)
        DesbloquearPlanesAccion(False)
        DesbloquearPanelFormatoReclamo(False)

    End Sub

    Public Sub DesBloquearPaneles(ByVal Bloquear As Boolean)
        grpOrigenReclamo.Enabled = Bloquear
        grpTipoReclamo.Enabled = Bloquear
        grpCabeceraReclamo.Enabled = Bloquear
        grpServicio.Enabled = Bloquear
        grpPareto.Enabled = Bloquear

        DesBloquearPanelProductos(Bloquear)
        DesBloquearPanelLaboratorio(Bloquear)
        DesBloquearDatosMuestra(Bloquear)

        grpReunion.Enabled = Bloquear
        grpServicio.Enabled = Bloquear

        grpAnalisisProblema.Enabled = Bloquear
        grpPlanAccion.Enabled = Bloquear

        'tabTipoReclamo.Tabs("TT01").Enabled = True
        'tabTipoReclamo.Tabs("TT02").Enabled = True
        'tabTipoReclamo.Tabs("TT03").Enabled = True
        'tabTipoReclamo.Tabs("TT04").Enabled = True
        'tabTipoReclamo.Tabs("TT09").Enabled = True

    End Sub

    Sub DesBloquearPanelLaboratorio(ByVal Desbloquear As Boolean)
        DesBloquearGrilla(ugLaboratorioInformes, Desbloquear)
    End Sub

    Sub DesBloquearPanelProductos(ByVal Desbloquear As Boolean)
        txtProductoMotivo.Enabled = Desbloquear
        txtProductoObservacion.Enabled = Desbloquear
        btnProductoNroGuia.Enabled = Desbloquear
        DesBloquearGrilla(ugDetGuia, Desbloquear)

        grpProducto01.Enabled = Desbloquear
        grpProducto02.Enabled = Desbloquear
        grpProducto03.Enabled = Desbloquear


    End Sub

    Sub DesbloquearPanelServicios(ByVal desbloquear As Boolean)

        txtServicioComentarios.Enabled = desbloquear

        grpServicio01.Enabled = desbloquear
        grpServicio02.Enabled = desbloquear
        grpServicio03.Enabled = desbloquear
        grpServicio04.Enabled = desbloquear
        grpServicio05.Enabled = desbloquear
        grpServicio06.Enabled = desbloquear

    End Sub

    Sub DesbloquearPanelMuestras(ByVal desbloquear As Boolean)
        dtpMuestraFechaEntrega.Enabled = desbloquear

        rbtMuestraSI.Enabled = desbloquear
        rbtMuestraNo.Enabled = desbloquear

        txtMuestraObservacion.Enabled = desbloquear

        DesBloquearGrilla(ugMuestras, desbloquear)

    End Sub

    Sub DesbloquearPanelEvidencias(ByVal desbloquear As Boolean)
        rbtEvidenciaSI.Enabled = desbloquear
        rbtEvidenciaNO.Enabled = desbloquear

        chkEvidenciaReqAprobProd.Enabled = desbloquear
        chkEvidenciaReqAprobLab.Enabled = desbloquear
        chkEvidenciaReqAprobCom.Enabled = desbloquear

        dtpEvidenciaFecha.Enabled = desbloquear
        txtEvidenciaComentario.Enabled = desbloquear

        btnEliminarEvidencias.Enabled = desbloquear
        btnEvidenciaUpload.Enabled = desbloquear
        btnEvidenciaDownload.Enabled = desbloquear

    End Sub

    Sub DesbloquearPanelFormatoReclamo(ByVal desbloquear As Boolean)

    End Sub

    Sub DesbloquearPanelAprobAreaLaboratorio(ByVal desbloquear As Boolean)

        cboAprobacionLaboratorio.Enabled = desbloquear
        txtAprobacionLabObs.Enabled = desbloquear
        dtpAprobacionLabFecha.Enabled = desbloquear
        dtpAprobacionLabHora.Enabled = desbloquear
        txtAprobacionLabPlan.Enabled = desbloquear

        rbtnAprobacionLabAcepta.Enabled = desbloquear
        rbtAprobacionLabNoAcepta.Enabled = desbloquear
    End Sub

    Sub DesbloquearPanelAprobAreaProduccion(ByVal desbloquear As Boolean)

        cboAprobProduccion.Enabled = desbloquear
        txtAprobacionProdObs.Enabled = desbloquear
        dtpAprobacionProdFecha.Enabled = desbloquear
        dtpAprobacionProdHora.Enabled = desbloquear
        txtAprobacionProdPlan.Enabled = desbloquear

        rbtnAprobacionProdAcepta.Enabled = desbloquear
        rbtnAprobacionProdNoAcepta.Enabled = desbloquear

    End Sub

    Sub DesbloquearPanelAprobAreaComercial(ByVal desbloquear As Boolean)

        cboAprobComercial.Enabled = desbloquear
        txtAprobacionComObs.Enabled = desbloquear
        dtpAprobacionComFecha.Enabled = desbloquear
        dtpAprobacionComHora.Enabled = desbloquear
        txtAprobacionComPlan.Enabled = desbloquear

        rbtnAprobacionComAcepta.Enabled = desbloquear
        rbtnAprobacionComNoAcepta.Enabled = desbloquear
        chkReqNotaCredito.Enabled = desbloquear

    End Sub

    Sub DesbloquearPanelProgramacionReunion(ByVal desbloquear As Boolean)

        dtpFechaReunion.Enabled = desbloquear
        cboLugarReunion.Enabled = desbloquear

        grpDespachoControls.Enabled = desbloquear
        grpVentasNacControls.Enabled = desbloquear
        grpVentasExpControls.Enabled = desbloquear
        grpTransporteControls.Enabled = desbloquear
        grpLaboratorioControls.Enabled = desbloquear
        grpOtros.Enabled = desbloquear

        ugInvolucrados.Enabled = desbloquear

        btnProgramarReunion.Enabled = desbloquear
    End Sub

    Sub DesbloquearPanelAnalisis(ByVal desbloquear As Boolean)

        dtpAnalisisFecha.Enabled = desbloquear
        txtCausaDescripcion.Enabled = desbloquear
        btnAgregarCausa.Enabled = desbloquear
        DesBloquearGrilla(ugCausaOrigen, desbloquear)

        txtCausa1.Enabled = desbloquear
        txtCausa2.Enabled = desbloquear
        txtCausa3.Enabled = desbloquear
        txtCausa4.Enabled = desbloquear
        txtCausa5.Enabled = desbloquear

        btnCausa1.Visible = desbloquear

        btnCausa2.Visible = desbloquear
        btnCerrarCausar2.Visible = desbloquear

        btnCausa3.Visible = desbloquear
        btnCerrarCausar3.Visible = desbloquear

        btnCausa4.Visible = desbloquear
        btnCerrarCausar4.Visible = desbloquear

        btnCerrarCausar5.Visible = desbloquear

    End Sub

    Sub DesbloquearPlanesAccion(ByVal desbloquear As Boolean)

        btnPlanAgregar.Enabled = desbloquear
        DesBloquearGrilla(ugAcciones, desbloquear)

    End Sub

    Sub BloquearGrillaLabSegunEstadoLab(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        'FECHA_CONFORME
        'MUESTRA_CONFORME
        For Each columna As UltraGridColumn In ugLaboratorioInformes.DisplayLayout.Bands(0).Columns
            If objReclamo.Estado = E_MUESTRA Then
                If columna.Key = "FECHA_CONFORME" Or columna.Key = "MUESTRA_CONFORME" Or columna.Key = "FECHA_INICIO" Or columna.Key = "CONFORMIDAD" Or columna.Key = "CONFORMIDAD_FECHA" Then
                    columna.CellActivation = Activation.AllowEdit
                Else
                    columna.CellActivation = Activation.NoEdit
                End If
            End If
            If objReclamo.Estado = E_LABCONFORME Then
                If columna.Key = "FECHA_CONFORME" Or columna.Key = "MUESTRA_CONFORME" Or columna.Key = "FECHA_INICIO" Or columna.Key = "CONFORMIDAD" Or columna.Key = "CONFORMIDAD_FECHA" Then
                    columna.CellActivation = Activation.NoEdit
                Else
                    columna.CellActivation = Activation.AllowEdit
                End If
            End If
            If objReclamo.Estado = E_LABINFORME Then
                columna.CellActivation = Activation.NoEdit
            End If
        Next
    End Sub

    Public Function EsEmailValido(ByVal cadena As String) As Boolean
        Try
            Dim mail As New System.Net.Mail.MailAddress(cadena)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Overridable Sub CargarDatos(ByVal pReclamo As ETReclamo)

        Try

            Dim oReclamo As New ETReclamo
            oReclamo.Id = pReclamo.Id

            Nuevo()

            SOURCE = NReclamo.ObtenerReclamo(oReclamo)

            Dim EstadoReclamo As ETReclamoPermisos = NReclamo.ObtenerEstadoReclamo(SOURCE)

            SOURCE.UsuarioResponsable = NReclamo.ObtenerRepresentamtePorCLiente(SOURCE.ClienteCodigo)

            SOURCE.ListaEvidencias = NReclamo.ObtenerListaEvidencias(SOURCE)
            txtruta.Text = pReclamo.RutaCorreo
            SOURCE.ListaEmailsCliente = New BindingList(Of ETReclamoPersona)(NReclamo.ObtenerCorreosClientes(SOURCE))

            RemoveHandler rbtTipoNacional.CheckedChanged, AddressOf rbtTipoNacional_CheckedChanged
            RemoveHandler rbtTipoProducto.CheckedChanged, AddressOf rbtTipoProducto_CheckedChanged
            RemoveHandler rbtTipoExportacion.CheckedChanged, AddressOf rbtTipoExportacion_CheckedChanged
            RemoveHandler rbtTipoServicio.CheckedChanged, AddressOf rbtTipoServicio_CheckedChanged

            RemoveHandler rbtParetoSI.CheckedChanged, AddressOf rbtParetoSI_CheckedChanged
            RemoveHandler rbtParetoNO.CheckedChanged, AddressOf rbtParetoNO_CheckedChanged

            If SOURCE.Origen = "1" Then
                rbtTipoNacional.Checked = True
            End If
            If SOURCE.Origen = "2" Then
                rbtTipoExportacion.Checked = True
            End If
            If SOURCE.Tipo = "1" Then
                rbtTipoProducto.Checked = True
            End If
            If SOURCE.Tipo = "2" Then
                rbtTipoServicio.Checked = True
            End If

            If SOURCE.Pareto = "S" Then
                rbtParetoSI.Checked = True
            End If

            If SOURCE.Pareto = "N" Then
                rbtParetoNO.Checked = True
            End If

            '-------------------------------------

            '-------------------------------------
            AddHandler rbtTipoNacional.CheckedChanged, AddressOf rbtTipoNacional_CheckedChanged
            AddHandler rbtTipoProducto.CheckedChanged, AddressOf rbtTipoProducto_CheckedChanged
            AddHandler rbtTipoExportacion.CheckedChanged, AddressOf rbtTipoExportacion_CheckedChanged
            AddHandler rbtTipoServicio.CheckedChanged, AddressOf rbtTipoServicio_CheckedChanged

            ' CABECERA
            txtNro.Text = SOURCE.Nro
            dtpFechaRegistro.Value = SOURCE.Fecha

            lblEstado.Text = SOURCE.EstadoComentado

            txtClienteCodigo.Text = SOURCE.ClienteCodigo
            txtClienteRazonSocial.Text = SOURCE.Cliente

            If SOURCE.ListaEmailsCliente.Count > 0 Then
                txtClienteEmail.Text = SOURCE.ListaEmailsCliente(0).Correo
                txtSolucionEmail.Text = SOURCE.ListaEmailsCliente(0).Correo
            End If

            DesbloquearPanelSuperior(False)

            txtResponsableVenta.Text = SOURCE.Responsable
            txtAnalisisResponsable.Text = SOURCE.Responsable
            txtPersonaRegistra.Text = SOURCE.UsuarioRegistra.Codigo

            'PRODUCTO
            txtProductoMotivo.Text = SOURCE.Producto.Motivo
            txtProductoObservacion.Text = SOURCE.Producto.Observacion

            If SOURCE.Tipo = "1" Then

                If EstadoReclamo.Producto Then
                    tabTipoReclamo.Tabs("TT01").Enabled = True
                    tabTipoReclamo.Tabs("TT01").Appearance.Image = My.Resources.mark
                    If EditMode Then
                        DesBloquearPanelProductos(True)
                    End If
                End If


                ' Espera llenar el detalle de Producto (opciones)
                ' hvilela 2024-05-31
                Dim rbtnp As RadioButton = Nothing
                Dim txtp As TextBox = Nothing

                For Each oProductoOpcion As ETReclamoProductoOpcion In SOURCE.ProductosOpcion

                    If oProductoOpcion.Codigo = "01" Then
                        For Each ctrl As Control In grpProducto01.Controls
                            rbtnp = TryCast(ctrl, RadioButton)
                            If rbtnp IsNot Nothing AndAlso rbtnp.Tag = oProductoOpcion.Opcion Then
                                rbtnp.Checked = True
                            End If
                            If ctrl.Text.ToUpper() = "OTROS" Then
                                If oProductoOpcion.Opcion = "03" Then
                                    rbtnp.Checked = True
                                    txtProdOtros01.ReadOnly = False
                                    txtProdOtros01.Text = oProductoOpcion.Observacion
                                End If
                            End If
                        Next
                    End If

                    If oProductoOpcion.Codigo = "02" Then
                        For Each ctrl As Control In grpProducto02.Controls
                            rbtnp = TryCast(ctrl, RadioButton)
                            If rbtnp IsNot Nothing AndAlso rbtnp.Tag = oProductoOpcion.Opcion Then
                                rbtnp.Checked = True
                            End If
                            If ctrl.Text.ToUpper() = "OTROS" Then
                                If oProductoOpcion.Opcion = "08" Then
                                    rbtnp.Checked = True
                                    txtProdOtros02.ReadOnly = False
                                    txtProdOtros02.Text = oProductoOpcion.Observacion
                                End If
                            End If
                        Next
                    End If

                    If oProductoOpcion.Codigo = "03" Then
                        For Each ctrl As Control In grpProducto03.Controls
                            rbtnp = TryCast(ctrl, RadioButton)
                            If rbtnp IsNot Nothing AndAlso rbtnp.Tag = oProductoOpcion.Opcion Then
                                rbtnp.Checked = True
                            End If
                            If ctrl.Text.ToUpper() = "OTROS" Then
                                If oProductoOpcion.Opcion = "11" Then
                                    rbtnp.Checked = True
                                    txtProdOtros03.ReadOnly = False
                                    txtProdOtros03.Text = oProductoOpcion.Observacion
                                End If
                            End If
                        Next
                    End If
                Next
            End If

            'If SOURCE.oProductoOpcion.Count > 0 Then

            'End If


            'SERVICIO

            Dim rbtn As RadioButton = Nothing
            Dim txt As TextBox = Nothing

            For Each oServicio As ETReclamoServicio In SOURCE.Servicios

                If oServicio.Codigo = "01" Then
                    For Each ctrl As Control In grpServicio01.Controls
                        rbtn = TryCast(ctrl, RadioButton)
                        If rbtn IsNot Nothing AndAlso rbtn.Tag = oServicio.Opcion Then
                            rbtn.Checked = True
                            If oServicio.Opcion = "11" Then
                                txtServOtros01.ReadOnly = False
                                txtServOtros01.Text = oServicio.Observacion
                            End If
                        End If
                    Next
                End If

                If oServicio.Codigo = "02" Then
                    For Each ctrl As Control In grpServicio02.Controls
                        rbtn = TryCast(ctrl, RadioButton)
                        If rbtn IsNot Nothing AndAlso rbtn.Tag = oServicio.Opcion Then
                            rbtn.Checked = True
                            If oServicio.Opcion = "22" Then
                                txtServOtros02.ReadOnly = False
                                txtServOtros02.Text = oServicio.Observacion
                            End If
                        End If
                    Next
                    txtServOtros02.Text = oServicio.Observacion
                End If
                If oServicio.Codigo = "03" Then
                    For Each ctrl As Control In grpServicio03.Controls
                        rbtn = TryCast(ctrl, RadioButton)
                        If rbtn IsNot Nothing AndAlso rbtn.Tag = oServicio.Opcion Then
                            rbtn.Checked = True
                            If oServicio.Opcion = "33" Then
                                txtServOtros03.ReadOnly = False
                                txtServOtros03.Text = oServicio.Observacion
                            End If
                        End If
                    Next
                    txtServOtros03.Text = oServicio.Observacion
                End If
                If oServicio.Codigo = "04" Then
                    For Each ctrl As Control In grpServicio04.Controls
                        rbtn = TryCast(ctrl, RadioButton)
                        If rbtn IsNot Nothing AndAlso rbtn.Tag = oServicio.Opcion Then
                            rbtn.Checked = True
                            If oServicio.Opcion = "44" Then
                                txtServOtros04.ReadOnly = False
                                txtServOtros04.Text = oServicio.Observacion
                            End If
                        End If
                    Next
                    txtServOtros04.Text = oServicio.Observacion
                End If
                If oServicio.Codigo = "05" Then
                    For Each ctrl As Control In grpServicio05.Controls
                        rbtn = TryCast(ctrl, RadioButton)
                        If rbtn IsNot Nothing AndAlso rbtn.Tag = oServicio.Opcion Then
                            rbtn.Checked = True
                            If oServicio.Opcion = "55" Then
                                txtServOtros01.ReadOnly = False
                                txtServOtros01.Text = oServicio.Observacion
                            End If
                        End If
                    Next
                    txtServOtros01.Text = oServicio.Observacion
                End If
                If oServicio.Codigo = "06" Then
                    For Each ctrl As Control In grpServicio06.Controls
                        rbtn = TryCast(ctrl, RadioButton)
                        If rbtn IsNot Nothing AndAlso rbtn.Tag = oServicio.Opcion Then
                            rbtn.Checked = True
                            If oServicio.Opcion = "66" Then
                                txtServOtros06.ReadOnly = False
                                txtServOtros06.Text = oServicio.Observacion
                            End If
                        End If
                    Next
                    txtServOtros06.Text = oServicio.Observacion
                End If
            Next

            txtEvidenciaComentario1.Text = SOURCE.ServicioObservacion
            txtServicioComentarios.Text = SOURCE.ServicioObservacion

            If SOURCE.Tipo = "2" Then
                If EstadoReclamo.Servicio Then
                    tabTipoReclamo.Tabs("TT02").Enabled = True
                    tabTipoReclamo.Tabs("TT02").Appearance.Image = My.Resources.mark
                    If EditMode Then
                        DesbloquearPanelServicios(True)
                    End If
                End If
            End If



            'If SOURCE.Servicios.Count > 0 Then

            'End If

            'MUESTRA
            RemoveHandler rbtMuestraSI.CheckedChanged, AddressOf rbtMuestraSI_CheckedChanged
            RemoveHandler rbtMuestraNo.CheckedChanged, AddressOf RadioButton2_CheckedChanged

            rbtMuestraSI.Checked = (SOURCE.ListaMuestras.Count > 0)

            AddHandler rbtMuestraSI.CheckedChanged, AddressOf rbtMuestraSI_CheckedChanged
            AddHandler rbtMuestraNo.CheckedChanged, AddressOf RadioButton2_CheckedChanged

            txtMuestraObservacion.Text = SOURCE.MuestraComentario
            dtpMuestraFechaEntrega.Value = SOURCE.MuestraFecha
            'rbtMuestraNo.Checked = Not pReclamo.EntregaMuestra
            Dim countMuestras As Integer = 0

            For Each muestra As ETReclamoMuestra In SOURCE.ListaMuestras
                If muestra.ESTADO = "EN CURSO" Then
                    countMuestras += 1
                End If
            Next
            'If SOURCE.ListaMuestras.Count > 0 Then
            If countMuestras > 0 Then
                tabTipoReclamo.Tabs("TT03").Enabled = True
                tabTipoReclamo.Tabs("TT03").Appearance.Image = My.Resources.mark

                If EditMode Then
                    DesBloquearDatosMuestra(True)
                End If
            End If

            txtMuestrasComentario1.Text = SOURCE.Producto.Observacion & Environment.NewLine & SOURCE.ServicioObservacion

            'For Each oEvidencia As ETReclamoEvidencia In SOURCE.ListaEvidencias
            '    txtMuestraComentrario2.Text = oEvidencia.Comentario & Environment.NewLine
            'Next

            'EVIDENCIAS

            chkEvidenciaReqAprobLab.Checked = SOURCE.RequiereAprobLab
            chkEvidenciaReqAprobProd.Checked = SOURCE.RequiereAprobProd
            chkEvidenciaReqAprobCom.Checked = SOURCE.RequiereAprobCom

            RemoveHandler rbtEvidenciaSI.CheckedChanged, AddressOf rbtEvidenciaSI_CheckedChanged
            RemoveHandler rbtEvidenciaNO.CheckedChanged, AddressOf rbtEvidenciaNO_CheckedChanged

            rbtEvidenciaSI.Checked = (SOURCE.ListaEvidencias.Count)

            AddHandler rbtEvidenciaSI.CheckedChanged, AddressOf rbtEvidenciaSI_CheckedChanged
            AddHandler rbtEvidenciaNO.CheckedChanged, AddressOf rbtEvidenciaNO_CheckedChanged

            If SOURCE.ListaEvidencias.Count > 0 Then

                txtEvidenciaComentario.Text = SOURCE.ListaEvidencias(0).Comentario
                txtEvidenciaArchivo.Text = SOURCE.ListaEvidencias(0).Archivo
                dtpEvidenciaFecha.Value = SOURCE.ListaEvidencias(0).Fecha

            End If

            If SOURCE.Tipo = "2" Then
                If EstadoReclamo.Evidencia Then
                    tabTipoReclamo.Tabs("TT09").Enabled = True
                    tabTipoReclamo.Tabs("TT09").Appearance.Image = My.Resources.mark

                    If EditMode Then
                        DesbloquearPanelEvidencias(True)
                    End If
                    btnEvidenciaDownload.Enabled = True
                End If
            End If

            'LABORATORIO
            'solo tiene data de la grilla
            If SOURCE.Tipo = "1" Then
                If EstadoReclamo.InformeLab Then
                    tabTipoReclamo.Tabs("TT04").Enabled = True
                    tabTipoReclamo.Tabs("TT04").Appearance.Image = My.Resources.mark
                    DesBloquearPanelLaboratorio(True)
                    If EditMode Then
                        DesBloquearPanelLaboratorio(True)
                    End If
                End If
            End If

            'comentarios de los registros anteriores
            txtLabComentarioProducto.Text = SOURCE.Producto.Observacion
            txtLabComentarioMuestra.Text = SOURCE.MuestraComentario

            'APROBACION
            'grpAprobProduccion.Enabled = (SOURCE.Tipo = "2")       

            'If SOURCE.Estado = ESTMUESTRA And SOURCE.Estado = ESTLAB_CONFORMIDAD Then

            'Else
            '    If SOURCE.Estado <> "REGISTRADO" And SOURCE.Estado <> "PRODUCTO" And SOURCE.Estado <> "SERVICIO" Then
            '        tabTipoReclamo.Tabs("TT04").Appearance.Image = My.Resources.mark
            '    End If

            'End If

            chkReqAprobCom.Checked = SOURCE.RequiereAprobCom
            chkReqAprobLab.Checked = SOURCE.RequiereAprobLab
            chkReqAprobProd.Checked = SOURCE.RequiereAprobProd

            If SOURCE.Tipo = "1" Then 'TIPO PRODUCTO
                If EstadoReclamo.AprobProduccion Then
                    tabTipoReclamo.Tabs("TT08").Enabled = True
                    tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark
                    If EditMode Then
                        DesbloquearPanelAprobAreaProduccion(True)
                    End If
                End If
            End If

            Dim inconsistencias As Integer

            If SOURCE.Tipo = "2" Then 'TIPO SERVICIO

                If EstadoReclamo.AprobProduccion Or EstadoReclamo.AprobLaboratorio Or EstadoReclamo.AprobacionComercial Then
                    tabTipoReclamo.Tabs("TT08").Enabled = True
                End If

                inconsistencias = 0
                If SOURCE.RequiereAprobProd And Not EstadoReclamo.AprobProduccion Then
                    inconsistencias += 1
                End If
                If SOURCE.RequiereAprobCom And Not EstadoReclamo.AprobacionComercial Then
                    inconsistencias += 1
                End If
                If SOURCE.RequiereAprobLab And Not EstadoReclamo.AprobLaboratorio Then
                    inconsistencias += 1
                End If

                If inconsistencias = 0 And EstadoReclamo.Evidencia Then
                    tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark
                End If

                If EditMode Then
                    If SOURCE.RequiereAprobProd Then
                        DesbloquearPanelAprobAreaProduccion(True)
                    End If
                    If SOURCE.RequiereAprobCom Then
                        DesbloquearPanelAprobAreaComercial(True)
                    End If
                    If SOURCE.RequiereAprobLab Then
                        DesbloquearPanelAprobAreaLaboratorio(True)
                    End If
                End If
            End If


            'If SOURCE.Estado = E_LABINFORME Then

            '    If User_Sistema = "VCARLIN" Or User_Sistema = "MARROQUIN" Or User_Sistema = "SA" Then
            '        grpAprobProduccion.Enabled = True
            '    End If
            '    If User_Sistema = "JPMEDINA" Or User_Sistema = "SA" Then
            '        grpAprobComercial.Enabled = True
            '    End If
            'ElseIf SOURCE.Estado = "EVIDENCIA" Then
            '    If SOURCE.RequiereAprobProd Then
            '        If User_Sistema = "VCARLIN" Or User_Sistema = "MARROQUIN" Or User_Sistema = "SA" Then
            '            grpAprobProduccion.Enabled = True
            '        End If
            '    End If
            '    If SOURCE.RequiereAprobLab Then
            '        If User_Sistema = "JPMEDINA" Or User_Sistema = "SA" Then
            '            grpAprobComercial.Enabled = True
            '        End If
            '    End If
            'Else
            '    grpAprobProduccion.Enabled = False
            '    grpAprobComercial.Enabled = False
            'End If

            'If SOURCE.Tipo = "1" Then ' producto
            '    If SOURCE.AprobacionProduccion.Observacion.Length > 0 Then
            '        tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark
            '        grpAprobProduccion.Enabled = False
            '    End If
            'End If
            'If SOURCE.Tipo = "2" Then ' servicio
            '    If SOURCE.AprobacionProduccion.Observacion.Length > 0 AndAlso _
            '        SOURCE.AprobacionComercial.Observacion.Length > 0 Then
            '        tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark
            '        grpAprobComercial.Enabled = False
            '    End If
            'End If

            'If Me.Laboratorio Then
            '    grpAprobProduccion.Enabled = False
            '    grpAprobComercial.Enabled = True
            'End If

            txtSolucionComentarios.Text = SOURCE.AprobacionGerencia.Observacion
            cboSolucionAprobadoPor.SelectedValue = SOURCE.AprobacionGerencia.Gerente.Codigo
            If SOURCE.AprobacionGerencia.FechaAprobacion <> Nothing Then
                dtpSolucionFecha.Value = SOURCE.AprobacionGerencia.FechaAprobacion.Date
            End If

            RemoveHandler rbtnAprobacionProdAcepta.CheckedChanged, AddressOf rbtnAprobacionProdAcepta_CheckedChanged
            RemoveHandler rbtnAprobacionComAcepta.CheckedChanged, AddressOf rbtnAprobacionComAcepta_CheckedChanged
            RemoveHandler rbtnAprobacionLabAcepta.CheckedChanged, AddressOf rbtnAprobacionLabAcepta_CheckedChanged

            txtAprobacionProdObs.Text = SOURCE.AprobacionProduccion.Observacion
            txtAprobacionProdPlan.Text = SOURCE.AprobacionProduccion.AccionesPorTomar
            cboAprobProduccion.SelectedValue = SOURCE.AprobacionProduccion.Gerente.Codigo

            If SOURCE.AprobacionProduccion.FechaAprobacion <> Nothing Then
                dtpAprobacionProdFecha.Value = SOURCE.AprobacionProduccion.FechaAprobacion
            End If

            rbtnAprobacionProdAcepta.Checked = SOURCE.AprobacionProduccion.Aprobado
            rbtnAprobacionProdNoAcepta.Checked = Not SOURCE.AprobacionProduccion.Aprobado

            txtAprobacionComObs.Text = SOURCE.AprobacionComercial.Observacion
            txtAprobacionComPlan.Text = SOURCE.AprobacionComercial.AccionesPorTomar
            cboAprobComercial.SelectedValue = SOURCE.AprobacionComercial.Gerente.Codigo

            If SOURCE.AprobacionComercial.FechaAprobacion <> Nothing Then
                dtpAprobacionComFecha.Value = SOURCE.AprobacionComercial.FechaAprobacion
            End If

            rbtnAprobacionComAcepta.Checked = SOURCE.AprobacionComercial.Aprobado
            rbtnAprobacionComNoAcepta.Checked = Not SOURCE.AprobacionComercial.Aprobado

            chkReqNotaCredito.Checked = SOURCE.AprobacionComercial.RegNotaCredito

            txtRegNotaCredito.Text = SOURCE.NroNCredito
            If chkReqNotaCredito.Checked Then
                txtRegNotaCredito.Enabled = True
                txtRegNotaCredito.BackColor = Color.White
            Else
                txtRegNotaCredito.Enabled = False
                txtRegNotaCredito.BackColor = SystemColors.Control
            End If


            txtAprobacionLabObs.Text = SOURCE.AprobacionLaboratorio.Observacion
            txtAprobacionLabPlan.Text = SOURCE.AprobacionLaboratorio.AccionesPorTomar
            cboAprobacionLaboratorio.SelectedValue = SOURCE.AprobacionLaboratorio.Gerente.Codigo

            If SOURCE.AprobacionLaboratorio.FechaAprobacion <> Nothing Then
                dtpAprobacionLabFecha.Value = SOURCE.AprobacionLaboratorio.FechaAprobacion
            End If


            rbtnAprobacionLabAcepta.Checked = SOURCE.AprobacionLaboratorio.Aprobado
            rbtAprobacionLabNoAcepta.Checked = Not SOURCE.AprobacionLaboratorio.Aprobado

            AddHandler rbtnAprobacionProdAcepta.CheckedChanged, AddressOf rbtnAprobacionProdAcepta_CheckedChanged
            AddHandler rbtnAprobacionComAcepta.CheckedChanged, AddressOf rbtnAprobacionComAcepta_CheckedChanged
            AddHandler rbtnAprobacionLabAcepta.CheckedChanged, AddressOf rbtnAprobacionLabAcepta_CheckedChanged

            'Reunion
            txtOrganizador.Text = SOURCE.Responsable
            cboLugarReunion.SelectedText = SOURCE.LugarReunion

            If SOURCE.FechaReunion.HasValue Then
                dtpFechaReunion.Value = SOURCE.FechaReunion.Value
            End If

            If EstadoReclamo.Reunion Then
                tabTipoReclamo.Tabs("TT05").Enabled = True
                tabTipoReclamo.Tabs("TT05").Appearance.Image = My.Resources.mark
                If EditMode Then
                    DesbloquearPanelProgramacionReunion(True)
                End If
            End If

            'Participantes
            Dim chkParticipante As CheckBox = Nothing
            For Each oPersona As ETReclamoPersona In SOURCE.ListaParticipantes
                For Each ctrl As Control In grpDespachoControls.Controls
                    chkParticipante = TryCast(ctrl, CheckBox)
                    If chkParticipante IsNot Nothing Then
                        If chkParticipante.Tag = oPersona.Correo Then
                            chkParticipante.Checked = True
                        End If
                    End If
                Next
                For Each ctrl As Control In grpVentasNacControls.Controls
                    chkParticipante = TryCast(ctrl, CheckBox)
                    If chkParticipante IsNot Nothing Then
                        If chkParticipante.Tag = oPersona.Correo Then
                            chkParticipante.Checked = True
                        End If
                    End If
                Next
                For Each ctrl As Control In grpVentasExpControls.Controls
                    chkParticipante = TryCast(ctrl, CheckBox)
                    If chkParticipante IsNot Nothing Then
                        If chkParticipante.Tag = oPersona.Correo Then
                            chkParticipante.Checked = True
                        End If
                    End If
                Next
                For Each ctrl As Control In grpTransporteControls.Controls
                    chkParticipante = TryCast(ctrl, CheckBox)
                    If chkParticipante IsNot Nothing Then
                        If chkParticipante.Tag = oPersona.Correo Then
                            chkParticipante.Checked = True
                        End If
                    End If
                Next
                For Each ctrl As Control In grpLaboratorioControls.Controls
                    chkParticipante = TryCast(ctrl, CheckBox)
                    If chkParticipante IsNot Nothing Then
                        If chkParticipante.Tag = oPersona.Correo Then
                            chkParticipante.Checked = True
                        End If
                    End If
                Next
            Next

            If EstadoReclamo.AnalisisProblema Then
                tabTipoReclamo.Tabs("TT07").Enabled = True
                tabTipoReclamo.Tabs("TT07").Appearance.Image = My.Resources.mark
                If EditMode Then
                    DesbloquearPanelAnalisis(True)
                End If
            End If

            'Analisis
            If SOURCE.FechaAnalisis.HasValue Then
                dtpAnalisisFecha.Value = SOURCE.FechaAnalisis.Value
            End If

            'Dim oCausa As ETReclamoCausa = Nothing

            'If SOURCE.Causas.Count > 0 Then
            '    'tabTipoReclamo.Tabs("TT07").Appearance.Image = My.Resources.mark
            '    'grpAnalisisProblema.Enabled = False

            '    oCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = 1)
            '    If oCausa IsNot Nothing Then
            '        txtCausa1.Text = oCausa.CausaOrigen
            '    End If
            '    oCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = 2)
            '    If oCausa IsNot Nothing Then
            '        txtCausa2.Text = oCausa.CausaOrigen
            '    End If
            '    oCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = 3)
            '    If oCausa IsNot Nothing Then
            '        txtCausa3.Text = oCausa.CausaOrigen
            '    End If
            '    oCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = 4)
            '    If oCausa IsNot Nothing Then
            '        txtCausa4.Text = oCausa.CausaOrigen
            '    End If
            '    oCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = 5)
            '    If oCausa IsNot Nothing Then
            '        txtCausa5.Text = oCausa.CausaOrigen
            '    End If
            'End If

            'Analisis
            SOURCE.Causas = New BindingList(Of ETReclamoCausa)(NReclamo.ObtenerAnalisis(SOURCE))

            If EstadoReclamo.PlanesAccion Then
                tabTipoReclamo.Tabs("TT06").Enabled = True
                tabTipoReclamo.Tabs("TT06").Appearance.Image = My.Resources.mark
                If EditMode Then
                    DesbloquearPlanesAccion(True)
                End If
            End If

            txtPlanResponsable.Text = SOURCE.UsuarioRegistra.Nombre

            If EstadoReclamo.AprobacionGerencial Then
                tabReclamo.Tabs("TFORMATO").Enabled = True
                tabReclamo.Tabs("TFORMATO").Appearance.Image = My.Resources.mark
                If EditMode Then
                    DesbloquearPanelFormatoReclamo(True)
                End If
            End If


            BindearGrillas()

            CargarDatosFormatoReporte()

            ROL = ObtenerRolPorUsuario(User_Sistema)
            'ahora estableceremos cual de todos los paneles se habilita si corresponde

            If SOURCE.Estado = "CANCELADO" Then
                Exit Sub
            End If

            If ROL = "ADMINISTRADOR" Then
                HabilitarPestañaMuestra(EstadoReclamo, SOURCE)
                HabilitarPestañaEvidencia(EstadoReclamo, SOURCE)

                HabilitarPestañaLaboratorio(EstadoReclamo, SOURCE)

                HabilitarPestañaAprobacionProduccion(EstadoReclamo, SOURCE)
                HabilitarPestañaAprobacionLaboratorio(EstadoReclamo, SOURCE)
                HabilitarPestañaAprobacionGerencial(EstadoReclamo, SOURCE)

                HabilitarPestanaReunion(EstadoReclamo, SOURCE)
                HabilitarPestanaAnalisis(EstadoReclamo, SOURCE)
                HabilitarPestanaPlanAccion(EstadoReclamo, SOURCE)

                HabilitarPestañaAprobacionComercial(EstadoReclamo, SOURCE)

            End If
            If ROL = "REGISTRADOR" Then
                HabilitarPestañaMuestra(EstadoReclamo, SOURCE)
                HabilitarPestañaEvidencia(EstadoReclamo, SOURCE)
            End If

            If ROL = "LABORATORIO" Then
                HabilitarPestañaLaboratorio(EstadoReclamo, SOURCE)
                'HabilitarPestañaAprobacionLaboratorio(EstadoReclamo, SOURCE)
            End If

            If ROL = "JEFE_LABORATORIO" Then
                HabilitarPestañaLaboratorio(EstadoReclamo, SOURCE)
                HabilitarPestañaAprobacionLaboratorio(EstadoReclamo, SOURCE)
            End If

            If ROL = "EJECUTIVO" Then
                HabilitarPestañaMuestra(EstadoReclamo, SOURCE)
                HabilitarPestañaEvidencia(EstadoReclamo, SOURCE)
                HabilitarPestanaReunion(EstadoReclamo, SOURCE)
                HabilitarPestanaAnalisis(EstadoReclamo, SOURCE)
                HabilitarPestanaPlanAccion(EstadoReclamo, SOURCE)
            End If

            If ROL = "JEFE_AREA" Then
                HabilitarPestañaMuestra(EstadoReclamo, SOURCE)
                HabilitarPestañaEvidencia(EstadoReclamo, SOURCE)
                HabilitarPestanaReunion(EstadoReclamo, SOURCE)
                HabilitarPestanaAnalisis(EstadoReclamo, SOURCE)
                HabilitarPestanaPlanAccion(EstadoReclamo, SOURCE)

                'el formato al cliente esta disponible si es de tipo servicio
                If SOURCE.Tipo = "2" Then
                    HabilitarPestañaAprobacionComercial(EstadoReclamo, SOURCE)
                End If
            End If

            If ROL = "PRODUCCION" Then
                HabilitarPestañaAprobacionProduccion(EstadoReclamo, SOURCE)
            End If

            If ROL = "COMERCIAL" Then
                HabilitarPestañaAprobacionComercial(EstadoReclamo, SOURCE)
            End If

            If ROL = "GERENCIA" Then
                HabilitarPestañaMuestra(EstadoReclamo, SOURCE)
                HabilitarPestañaEvidencia(EstadoReclamo, SOURCE)
                HabilitarPestañaAprobacionComercial(EstadoReclamo, SOURCE)
                HabilitarPestañaAprobacionGerencial(EstadoReclamo, SOURCE)
            End If

            Exit Sub

            'If Laboratorio Then
            '    DesBloquearPaneles(False)
            '    DesBloquearPanelLaboratorio(True)
            '    BloquearGrillaLabSegunEstadoLab(2)
            'End If

            'If User_Sistema = "VCARLIN" Or User_Sistema = "MARROQUI" Then
            '    tabTipoReclamo.Tabs("TT08").Visible = True
            '    'grpAprobProduccion.Enabled = True
            '    'grpAprobComercial.Enabled = True

            '    DesBloquearPanelProductos(False)
            '    DesBloquearDatosMuestra(False)
            '    DesBloquearDatosMuestra(False)
            'End If
            'If User_Sistema = "JPMEDINA" Then
            '    tabTipoReclamo.Tabs("TT08").Visible = True
            '    grpAprobProduccion.Enabled = False
            '    grpAprobComercial.Enabled = True

            '    DesBloquearPanelProductos(False)
            '    DesBloquearDatosMuestra(False)
            '    DesBloquearDatosMuestra(False)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try

    End Sub
    Function ObtenerRolPorUsuario(ByVal usuario As String) As String
        Return NReclamo.ObtenerRol(usuario)
    End Function
    'Sub HabilitarPestañaServicio(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
    '    If objPermisos.Servicio And Not objPermisos.Muestra Then
    '        tabTipoReclamo.Tabs("TT03").Appearance.Image = My.Resources.mark_red
    '        tabTipoReclamo.Tabs("TT03").Enabled = True
    '        DesbloquearPanelMuestras(True)
    '        tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT03")
    '    End If
    'End Sub
    Sub HabilitarPestañaMuestra(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objPermisos.Producto And Not objPermisos.Muestra Then
            tabTipoReclamo.Tabs("TT03").Appearance.Image = My.Resources.mark_red
            tabTipoReclamo.Tabs("TT03").Enabled = True
            DesbloquearPanelMuestras(True)
            tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT03")
        End If
    End Sub
    Sub HabilitarPestañaEvidencia(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objPermisos.Servicio And Not objPermisos.Evidencia Then
            tabTipoReclamo.Tabs("TT09").Appearance.Image = My.Resources.mark_red
            tabTipoReclamo.Tabs("TT09").Enabled = True
            DesbloquearPanelEvidencias(True)
        End If
    End Sub
    Sub HabilitarPestañaLaboratorio(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objReclamo.Tipo = "1" Then
            If objPermisos.Muestra And Not objPermisos.InformeLab Then
                tabTipoReclamo.Tabs("TT04").Appearance.Image = My.Resources.mark_red
                tabTipoReclamo.Tabs("TT04").Enabled = True
                DesBloquearPanelLaboratorio(True)
                BloquearGrillaLabSegunEstadoLab(objPermisos, objReclamo)
            End If
        End If
    End Sub
    Sub HabilitarPestañaAprobacionLaboratorio(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objReclamo.Tipo = "2" Then
            If objReclamo.RequiereAprobLab And Not objPermisos.AprobLaboratorio Then
                tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark_red
                tabTipoReclamo.Tabs("TT08").Enabled = True
                DesbloquearPanelAprobAreaLaboratorio(True)
            End If
        End If
    End Sub
    Sub HabilitarPestañaAprobacionProduccion(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objReclamo.Tipo = "2" Then
            If objReclamo.RequiereAprobProd And Not objPermisos.AprobProduccion Then
                tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark_red
                tabTipoReclamo.Tabs("TT08").Enabled = True
                DesbloquearPanelAprobAreaProduccion(True)
            End If
        End If
        If objReclamo.Tipo = "1" And objPermisos.Muestra And Not objPermisos.AprobProduccion Then
            tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark_red
            tabTipoReclamo.Tabs("TT08").Enabled = True
            DesbloquearPanelAprobAreaProduccion(True)
        End If
    End Sub
    Sub HabilitarPestañaAprobacionComercial(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objReclamo.Tipo = "2" Or objReclamo.Tipo = "1" Then
            If objReclamo.RequiereAprobCom And Not objPermisos.AprobacionComercial Then
                tabTipoReclamo.Tabs("TT08").Appearance.Image = My.Resources.mark_red
                tabTipoReclamo.Tabs("TT08").Enabled = True
                DesbloquearPanelAprobAreaComercial(True)
                tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT08")
            End If
        End If
    End Sub
    Sub HabilitarPestanaReunion(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objPermisos.AprobacionGerencial And Not objPermisos.Reunion Then
            tabTipoReclamo.Tabs("TT05").Appearance.Image = My.Resources.mark_red
            tabTipoReclamo.Tabs("TT05").Enabled = True
            DesbloquearPanelProgramacionReunion(True)
        End If
    End Sub
    Sub HabilitarPestanaAnalisis(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objPermisos.Reunion And Not objPermisos.AnalisisProblema Then
            tabTipoReclamo.Tabs("TT07").Appearance.Image = My.Resources.mark_red
            tabTipoReclamo.Tabs("TT07").Enabled = True
            DesbloquearPanelAnalisis(True)
        End If
    End Sub
    Sub HabilitarPestanaPlanAccion(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)
        If objPermisos.AnalisisProblema And Not objPermisos.PlanesAccion Then
            tabTipoReclamo.Tabs("TT06").Appearance.Image = My.Resources.mark_red
            tabTipoReclamo.Tabs("TT06").Enabled = True
            DesbloquearPlanesAccion(True)
        End If
    End Sub
    Sub HabilitarPestañaAprobacionGerencial(ByVal objPermisos As ETReclamoPermisos, ByVal objReclamo As ETReclamo)

        Dim inconsistencias As Integer = 0

        If objReclamo.Tipo = "1" Then
            If objPermisos.AprobProduccion And Not objPermisos.AprobacionGerencial Then
                tabReclamo.Tabs("TFORMATO").Enabled = True
                tabReclamo.Tabs("TFORMATO").Appearance.Image = My.Resources.mark_red
                DesbloquearPanelFormatoReclamo(True)
            End If
        End If

        If objReclamo.Tipo = "2" Then
            inconsistencias = 0
            If objReclamo.RequiereAprobProd And Not objPermisos.AprobProduccion Then
                inconsistencias += 1
            End If
            If objReclamo.RequiereAprobLab And Not objPermisos.AprobLaboratorio Then
                inconsistencias += 1
            End If
            If objReclamo.RequiereAprobCom And Not objPermisos.AprobacionComercial Then
                inconsistencias += 1
            End If

            If inconsistencias = 0 Then
                tabReclamo.Tabs("TFORMATO").Enabled = True
                If Not objPermisos.AprobacionGerencial Then
                    tabReclamo.Tabs("TFORMATO").Appearance.Image = My.Resources.mark_red
                Else
                    tabReclamo.Tabs("TFORMATO").Appearance.Image = My.Resources.mark
                End If

                DesbloquearPanelFormatoReclamo(True)
            End If

        End If
    End Sub

    Function mostrarMensajeConfirmacion(ByVal NombrePestaña As String) As Boolean
        Dim r As DialogResult = MessageBox.Show("¿Desea grabar la informaciòn ingresada? (" & NombrePestaña & "), una vez registrada esta informaciòn no es editable", _
                    "Sistema de Quejas", _
                    MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question, _
                    MessageBoxDefaultButton.Button1, _
                    MessageBoxOptions.DefaultDesktopOnly, False)

        Return Not (r = Windows.Forms.DialogResult.Yes)
    End Function

    Function GrabarDatosReclamo() As Boolean

        ActualizarDatosReclamo()

        'If txtNro.Text.Trim.Length = 0 Then
        '    MsgBox("Ingrese el Nro de Reclamo", MsgBoxStyle.Critical, msgComacsa)
        '    Return False
        'End If

        If txtClienteCodigo.Text.Trim.Length = 0 Then
            MostrarAdvertencia("Seleccione el cliente")
            Return False
        End If

        If Not rbtTipoExportacion.Checked And Not rbtTipoNacional.Checked Then
            MostrarAdvertencia("Seleccione si la queja es de tipo nacional o de exportación")
            Return False
        End If

        If Not rbtTipoProducto.Checked And Not rbtTipoServicio.Checked Then
            MostrarAdvertencia("Seleccione si la queja es de tipo producto o de servicio")
            Return False
        End If

        If SOURCE.Tipo = "1" Then
            If SOURCE.Producto.ListaDetalles.Count = 0 Then
                MostrarAdvertencia("No ha seleccionado ninguna guia de remisión")
                Return False
            End If
        End If

        If SOURCE.ListaEmailsCliente.Count = 0 Then
            MostrarAdvertencia("Debe ingresar por lo menos un correo del cliente")
            Return False
        End If

        ' Producto 
        If rbtTipoProducto.Checked Then

            If txtProductoMotivo.Text.Trim.Length = 0 Then
                MostrarAdvertencia("Ingrese el motivo de la queja")
                Return False
            End If

            If txtProductoObservacion.Text.Trim.Length = 0 Then
                MostrarAdvertencia("Ingrese un comentario sobre la queja")
                Return False
            End If

            'If SOURCE.Servicios.Count = 0 Then
            ' MostrarAdvertencia("Debe seleccionar que servicios involucran la queja")
            ' Return False
            'End If

            If SOURCE.ProductosOpcion.Count = 0 Then
                MostrarAdvertencia("Debe seleccionar que motivos (Propiedades) involucran la queja en los productos ")
                Return False
            End If

            Dim lst As List(Of ETReclamoProductoDetalle) = SOURCE.Producto.ListaDetalles.ToList()

            If lst.Exists(Function(p) p.LOTE.Trim.Length = 0) Then
                MostrarAdvertencia("Ingrese el lote del producto")
                Return False
            End If

            'validamos el nro de bolsas reclamadas
            Dim nrobolsas As Double = 0
            For Each oDetalle As ETReclamoProductoDetalle In lst
                If IsNumeric(nrobolsas) Then
                    nrobolsas = Convert.ToDouble(oDetalle.NRO_BOLSAS_RECLAMADAS)

                    If nrobolsas <= 0 Then
                        MostrarAdvertencia("El Nro. de Bolsas Reclamadas debe ser mayor que cero")
                        Return False
                    End If

                Else
                    MostrarAdvertencia("Ingrese el nro de bolsas reclamadas del producto")
                    Return False
                End If
            Next

            'If lst.Exists(Function(p) p.NRO_BOLSAS_RECLAMADAS.Trim.Length = 0) _
            '    Or lst.Exists(Function(p) IsNumeric(p.NRO_BOLSAS_RECLAMADAS) = False _
            '    Or lst.Exists(Function(s) IsNumeric(p.NRO_BOLSAS_RECLAMADAS) = True _
            '            AndAlso Convert.ToDouble(p.NRO_BOLSAS_RECLAMADAS) > 0)) Then

            '    MostrarAdvertencia("Ingrese el nro de bolsas reclamadas del producto")
            '    Return False
            'End If

        End If


        If rbtTipoServicio.Checked Then

            If txtServicioComentarios.Text.Trim.Length = 0 Then
                MostrarAdvertencia("Ingrese un comentario sobre la queja")
                Return False
            End If

            If SOURCE.Servicios.Count = 0 Then
                MostrarAdvertencia("Debe seleccionar que servicios involucran la queja")
                Return False
            End If

            'If rbtEvidenciaSI.Checked Then
            '    If txtEvidenciaComentario.Text.Trim.Length = 0 Then
            '        MostrarAdvertencia("Ingrese un comentario sobre la evidencia")
            '        Return False
            '    End If
            'End If
        End If

        If mostrarMensajeConfirmacion("QUEJA") Then
            Return False
        End If

        Dim oResultado As ETResultado = NReclamo.GrabarCabeceraReclamo(SOURCE, 1)

        If oResultado.Realizo Then

            SOURCE.Nro = oResultado.Mensaje
            SOURCE.Id = oResultado.Valor

            txtNro.Text = SOURCE.Nro

            'registramos los correos
            NReclamo.RegistrarCorreosCliente(SOURCE, "CORREOCLIENTE")

            If rbtTipoProducto.Checked Then
                SOURCE.Estado = E_PRODUCTO
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)
            End If
            If rbtTipoServicio.Checked Then
                SOURCE.Estado = E_SERVICIO
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)
            End If

            MostrarMensaje("Queja Generada con el Nro: " & oResultado.Mensaje)

            Return True
        Else
            MostrarError(oResultado.Mensaje)

            Return False
        End If

    End Function
    Function GrabarDatosEvidencia() As Boolean
        ' DAO
        Dim resp As Boolean = False

        If rbtEvidenciaSI.Checked Then

            If SOURCE.Id = 0 Then
                MostrarAdvertencia("Registre la queja antes de registrar evidencias")
                Return resp
            End If
            If txtEvidenciaComentario.Text.Trim.Length = 0 Then
                MostrarAdvertencia("Ingrese un comentario para las evidencias")
                Return resp
            End If

            If Not chkEvidenciaReqAprobLab.Checked And Not chkEvidenciaReqAprobProd.Checked _
                And Not chkEvidenciaReqAprobCom.Checked Then
                MostrarAdvertencia("Debe indicar que aprobaciones se requieren para la queja")
                Return resp
            End If

            If txtEvidenciaArchivo.Text.Trim().Length = 0 Then

                Dim r As DialogResult = MessageBox.Show("No ha adjuntado ningun archivo de evidencia. ¿Está seguro de registrar solo los comentarios?", _
                    msgComacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If r = Windows.Forms.DialogResult.No Then
                    Return resp
                End If

            End If

            If mostrarMensajeConfirmacion("EVIDENCIA") Then
                Return resp
            End If

            Dim oEvidencia As New ETReclamoEvidencia
            oEvidencia.Fecha = dtpEvidenciaFecha.Value
            oEvidencia.Comentario = txtEvidenciaComentario.Text.Trim()
            oEvidencia.Archivo = txtEvidenciaArchivo.Text.Trim()

            SOURCE.RequiereAprobCom = chkEvidenciaReqAprobCom.Checked
            SOURCE.RequiereAprobLab = chkEvidenciaReqAprobLab.Checked
            SOURCE.RequiereAprobProd = chkEvidenciaReqAprobProd.Checked

            SOURCE.ListaEvidencias.Clear()
            SOURCE.ListaEvidencias.Add(oEvidencia)

            Try
                Dim oResultado As ETResultado = NReclamo.RegistrarEvidencia(SOURCE)

                If oResultado.Realizo Then

                    SOURCE.Estado = E_EVIDENCIA
                    NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                    MostrarMensaje("Se registraron las evidencias para la queja " & SOURCE.Nro)
                    NReclamo.RegistrarGuias(SOURCE)

                    resp = True
                Else
                    MostrarAdvertencia(oResultado.Mensaje)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
            End Try
        Else
            MostrarMensaje("Seleccione si se entregaron evidencias")
        End If

        Return resp
    End Function
    Function GrabarDatosMuestra() As Boolean
        'DAO
        Dim resp As Boolean = False

        If SOURCE.Id = 0 Then
            MsgBox("Registre la queja primero", MsgBoxStyle.OkOnly, msgComacsa)
            Return False
        End If

        If txtMuestraObservacion.Text.Trim.Length = 0 Then
            MsgBox("Ingrese un comentario para el registro de muestras", MsgBoxStyle.OkOnly, msgComacsa)
            Return False
        End If

        SOURCE.MuestraFecha = dtpMuestraFechaEntrega.Value
        SOURCE.MuestraComentario = txtMuestraObservacion.Text.Trim()
        SOURCE.RequiereAprobProd = True
        SOURCE.RequiereAprobCom = True
        SOURCE.RequiereAprobLab = False
        'validamos los cambios de estado

        ugMuestras.UpdateData()

        Dim FaltaAdjunto As Boolean = False

        For Each oMuestras As ETReclamoMuestra In SOURCE.ListaMuestras
            If oMuestras.ESTADO <> "EN CURSO" AndAlso oMuestras.ESTADO_OBS.Trim().Length = 0 Then
                MsgBox("Si cambia el estado de la muestra , debe ingresar el motivo", MsgBoxStyle.OkOnly, msgComacsa)
                Return False
            End If
            If oMuestras.ESTADO = "EN CURSO" AndAlso oMuestras.ARCHIVOM.Length = 0 Then
                FaltaAdjunto = True
            End If
        Next

        If FaltaAdjunto Then
            If MsgBox("Recuerde adjuntar un archivo que sustente la queja en caso aplique", MsgBoxStyle.OkOnly, msgComacsa) Then

            End If
        End If

        If mostrarMensajeConfirmacion("MUESTRAS") Then
            Return False
        End If

        Dim oResultado As ETResultado = Nothing

        If rbtMuestraSI.Checked Then

            oResultado = NReclamo.RegistrarMuestras(SOURCE)

            If oResultado.Realizo Then

                SOURCE.Estado = "MUESTRA"

                NReclamo.ActualizarEstado(SOURCE, User_Sistema)

                MostrarMensaje("Registro de Muestras Completo")

                resp = True
            Else
                MostrarError("Ocurrio un Error en el Registro de Muestras")
            End If
        Else
            'El reclamo se cancela porque las muestras no llegaron

            Dim r As DialogResult = MessageBox.Show("No se entregaron muestras. ¿Desea cancelar la queja?", _
                "Sistema de Quejas", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question, _
                MessageBoxDefaultButton.Button1, _
                MessageBoxOptions.DefaultDesktopOnly, False)

            If r = Windows.Forms.DialogResult.Yes Then
                SOURCE.Estado = "CANCELADO"

                NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                MostrarMensaje("La queja ha sido cancelado")

                resp = True
            End If
        End If

        Return resp
    End Function
    Function GrabarDatosLaboratorio() As Boolean
        'DAO
        ugLaboratorioInformes.UpdateData()

        Dim SiguienteFase As Boolean = True
        Dim oResultado As ETResultado = New ETResultado

        Dim lista As List(Of EtReclamoMuestraLab) = SOURCE.ListaMuestrasLab.ToList()

        If SOURCE.Estado = ESTMUESTRA Then

            If lista.Exists(Function(p) p.FECHA_CONFORME = False And p.ESTADO = "EN CURSO") Then

                Dim rm As DialogResult = MessageBox.Show("No ha dado conformidad a las fechas de entrega de muestras, La queja retornará a la fase de entrega de muestras ¿Desea continuar?", _
                                   msgComacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If rm = Windows.Forms.DialogResult.Yes Then

                    SiguienteFase = False

                End If

                If rm = Windows.Forms.DialogResult.No Then
                    Return False
                End If
            End If

            'If Not SiguienteFase Then
            '    Return False
            'End If

            If lista.Exists(Function(p) p.MUESTRA_CONFORME = False And p.ESTADO = "EN CURSO") Then
                Dim rf As DialogResult = MessageBox.Show("No ha dado conformidad a las muestras recibidas, La queja retornará a la fase de entrega de muestras ¿Desea continuar?", _
                                   msgComacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If rf = Windows.Forms.DialogResult.Yes Then

                    SiguienteFase = False

                End If

                If rf = Windows.Forms.DialogResult.No Then
                    Return False
                End If
            End If

            'If Not SiguienteFase Then
            '    Return False
            'End If

            If mostrarMensajeConfirmacion("LABORATORIO") Then
                Return False
            End If

            oResultado = NReclamo.RegistrarLaboratorioConformidad(SOURCE)

            If oResultado.Realizo Then
                If Not SiguienteFase Then
                    If rbtTipoProducto.Checked Then
                        SOURCE.Estado = "PRODUCTO"
                    Else
                        SOURCE.Estado = "SERVICIO"
                    End If
                    NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                    NReclamo.RegistrarRechazoMuestra(SOURCE, User_Sistema)
                    MostrarMensaje("Rechazo de Comformidad de Muestras Completo")
                Else
                    SOURCE.Estado = ESTLAB_CONFORMIDAD
                    NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                    MostrarMensaje("Registro de Comformidad de Muestras Completo")
                End If

            End If

        ElseIf SOURCE.Estado = ESTLAB_CONFORMIDAD Then


            If lista.Exists(Function(p) p.FECHA_FIN.HasValue = False) Then
                MostrarAdvertencia("Debe registrar las fechas de entrega de informes")
                Return False
            End If
            If lista.Exists(Function(p) p.OBSERVACION.Trim().Length = 0) Then
                MostrarAdvertencia("Debe registrar las observaciones de la muestra")
                Return False
            End If

            If mostrarMensajeConfirmacion("LABORATORIO") Then
                Return False
            End If

            oResultado = NReclamo.RegistrarLaboratorioInforme(SOURCE)

            If oResultado.Realizo Then

                SOURCE.Estado = ESTLAB_INFORME
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)

                MostrarMensaje("Registro de Informes de Laboratorio Completo")
            End If

        ElseIf SOURCE.Estado = ESTLAB_INFORME Then

            MostrarError("Los informes ya fueron entregados por laboratorio")

            If MessageBox.Show("Los datos de laboratorio fueron modificados ¿Desea grabar?", _
                                  msgComacsa, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                oResultado = NReclamo.RegistrarLaboratorioInforme(SOURCE)
                If oResultado.Realizo Then

                    SOURCE.Estado = ESTLAB_INFORME
                    NReclamo.ActualizarEstado(SOURCE, User_Sistema)

                    MostrarMensaje("Registro de Informes de Laboratorio Completo")
                End If

            Else

            End If


            ElseIf SOURCE.Estado = "PRODUCTO" Or SOURCE.Estado = "SERVICIO" Then

                MostrarError("Aún no se han entregado las muestras para esta queja")

            Else

                MostrarError("La queja esta bloqueada por otra área")

            End If

        Return oResultado.Realizo
        'If lista.Exists(Function(p) p.FECHA_CONFORME = False) Then
        '    If MessageBox.Show("No ha dado conformidad a las fechas entrega de muestras, El reclamo retornará a la fase de entrega de muestras ¿Desea continuar?", _
        '                       msgComacsa, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '        Return False
        '    Else
        '        SiguienteFase = False
        '    End If
        'End If
        'If lista.Exists(Function(p) p.MUESTRA_CONFORME = False) Then
        '    If MessageBox.Show("No ha dado conformidad a las muestras recibidas, El reclamo retornará a la fase de entrega de muestras ¿Desea continuar?", _
        '                       msgComacsa, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '        Return False
        '    Else
        '        SiguienteFase = False
        '    End If
        'End If


        'If SOURCE.Estado = ESTMUESTRA Then
        '    oResultado = NReclamo.RegistrarLaboratorioConformidad(SOURCE)
        'Else
        '    oResultado = NReclamo.RegistrarLaboratorioInforme(SOURCE)
        'End If

        'If oResultado.Realizo Then

        '    If SiguienteFase Then
        '        If SOURCE.Estado = ESTMUESTRA Then
        '            SOURCE.Estado = ESTLAB_CONFORMIDAD
        '        ElseIf SOURCE.Estado = ESTLAB_CONFORMIDAD Then
        '            SOURCE.Estado = ESTLAB_INFORME
        '        End If
        '    Else
        '        SOURCE.Estado = ESTMUESTRA
        '    End If

        '    NReclamo.ActualizarEstado(SOURCE)

        '    MostrarMensaje("Registro de Informes Completo")
        'Else
        '    MostrarError("Ocurrió un error al registrar los informes de laboratorio")
        'End If

        Return True

    End Function

    Sub MostrarAdvertencia(ByVal msj As String)

        MessageBox.Show(Me, msj, msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    Sub MostrarMensaje(ByVal msj As String)

        MessageBox.Show(Me, msj, msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Sub MostrarError(ByVal msj As String)

        MessageBox.Show(Me, msj, msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Function ObtenerFechaHora(ByVal dtpFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor, _
                              ByVal dtpHora As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor) As DateTime
        Return dtpFecha.DateTime.Date.AddMinutes(dtpHora.DateTime.TimeOfDay.TotalMinutes)
    End Function

    Function GrabarDatosAprobacionInformesLaboratorio() As Boolean
        'DAO
        Dim oResultado As ETResultado = New ETResultado
        If ROL = "PRODUCCION" And (SOURCE.Tipo = "1" Or SOURCE.RequiereAprobProd) Then
            If cboAprobProduccion.SelectedValue = "0" Then
                MsgBox("Seleccione el responsable del área de producción")
                Return False
            End If
            If txtAprobacionProdObs.Text.Trim.Length = 0 Then
                MsgBox("Ingrese la observación para la aprobación de Producción")
                Return False
            End If
            If Not rbtnAprobacionProdAcepta.Checked And Not rbtnAprobacionProdNoAcepta.Checked Then
                MsgBox("Seleccione Aceptado o No Aceptado")
                Return False
            End If
            If rbtnAprobacionProdAcepta.Checked And Len(txtAprobacionProdPlan.Text.Trim()) = 0 Then
                MsgBox("Ingrese el plan de accion a tomar para la aprobación")
                Return False
            End If

            If mostrarMensajeConfirmacion("APROBACION PRODUCCIÓN") Then
                Return False
            End If

            SOURCE.AprobacionProduccion.Gerente.Codigo = cboAprobProduccion.SelectedValue
            SOURCE.AprobacionProduccion.Gerente.Nombre = cboAprobProduccion.Text
            SOURCE.AprobacionProduccion.Observacion = txtAprobacionProdObs.Text.Trim()
            SOURCE.AprobacionProduccion.FechaAprobacion = ObtenerFechaHora(dtpAprobacionProdFecha, dtpAprobacionProdHora)
            SOURCE.AprobacionProduccion.AccionesPorTomar = txtAprobacionProdPlan.Text.Trim()
            SOURCE.AprobacionProduccion.Aprobado = rbtnAprobacionProdAcepta.Checked
            SOURCE.Estado = E_APROBPROD

            oResultado = NReclamo.RegistrarAprobacion(SOURCE, "PRODUCCION", User_Sistema)

            If oResultado.Realizo Then
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                MostrarMensaje("Aprobacion de Informes Completo")
            Else
                MostrarError("Ocurrió un error en la Aprobacion de Informes de Producción")
            End If

        End If
        If ROL = "GERENCIA" And (SOURCE.RequiereAprobCom) Or User_Sistema = "SA" Then
            If cboAprobComercial.SelectedValue = "0" Then
                MsgBox("Seleccione el responsable del área comercial")
                Return False
            End If
            If txtAprobacionComObs.Text.Trim.Length = 0 Then
                MsgBox("Ingrese la observación para la aprobación de comercial")
                Return False
            End If
            If Not rbtnAprobacionComAcepta.Checked And Not rbtnAprobacionComNoAcepta.Checked Then
                MsgBox("Seleccione Aceptado o No Aceptado")
                Return False
            End If
            If rbtnAprobacionComAcepta.Checked And Len(txtAprobacionComPlan.Text.Trim()) = 0 Then
                MsgBox("Ingrese el plan de accion a tomar para la aprobación")
                Return False
            End If

            If mostrarMensajeConfirmacion("APROBACION COMERCIAL") Then
                Return False
            End If

            SOURCE.AprobacionComercial.Gerente.Codigo = cboAprobComercial.SelectedValue
            SOURCE.AprobacionComercial.Gerente.Nombre = cboAprobComercial.Text
            SOURCE.AprobacionComercial.Observacion = txtAprobacionComObs.Text.Trim()
            SOURCE.AprobacionComercial.FechaAprobacion = ObtenerFechaHora(dtpAprobacionComFecha, dtpAprobacionComHora)
            SOURCE.AprobacionComercial.AccionesPorTomar = txtAprobacionComPlan.Text.Trim()
            SOURCE.AprobacionComercial.Aprobado = rbtnAprobacionComAcepta.Checked
            SOURCE.AprobacionComercial.RegNotaCredito = chkReqNotaCredito.Checked

            SOURCE.Estado = E_APROBCOM

            oResultado = NReclamo.RegistrarAprobacion(SOURCE, "COMERCIAL", User_Sistema)

            If oResultado.Realizo Then
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                MostrarMensaje("Aprobacion de Informes Completo")
            Else
                MostrarError("Ocurrió un error en la Aprobación de Informes de Laboratorio")
            End If
        End If
        If (ROL = "LABORATORIO" Or ROL = "JEFE_LABORATORIO") And (SOURCE.RequiereAprobLab) Then
            If cboAprobacionLaboratorio.SelectedValue = "0" Then
                MsgBox("Seleccione el responsable del área de laboratorio")
                Return False
            End If
            If txtAprobacionLabObs.Text.Trim.Length = 0 Then
                MsgBox("Ingrese la observación para la aprobación del área de laboratorio")
                Return False
            End If
            If Not rbtnAprobacionLabAcepta.Checked And Not rbtAprobacionLabNoAcepta.Checked Then
                MsgBox("Seleccione Aceptado o No Aceptado")
                Return False
            End If
            If rbtnAprobacionLabAcepta.Checked And Len(txtAprobacionLabPlan.Text.Trim()) = 0 Then
                MsgBox("Ingrese el plan de accion a tomar para la aprobación")
                Return False
            End If

            If mostrarMensajeConfirmacion("APROBACION LABORATORIO") Then
                Return False
            End If

            SOURCE.AprobacionLaboratorio.Gerente.Codigo = cboAprobacionLaboratorio.SelectedValue
            SOURCE.AprobacionLaboratorio.Gerente.Nombre = cboAprobacionLaboratorio.Text
            SOURCE.AprobacionLaboratorio.Observacion = txtAprobacionLabObs.Text.Trim()
            SOURCE.AprobacionLaboratorio.FechaAprobacion = ObtenerFechaHora(dtpAprobacionLabFecha, dtpAprobacionLabHora)
            SOURCE.AprobacionLaboratorio.AccionesPorTomar = txtAprobacionLabPlan.Text.Trim()
            SOURCE.AprobacionLaboratorio.Aprobado = rbtnAprobacionLabAcepta.Checked
            SOURCE.Estado = E_APROBLAB

            oResultado = NReclamo.RegistrarAprobacion(SOURCE, "LABORATORIO", User_Sistema)

            If oResultado.Realizo Then
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                MostrarMensaje("Aprobacion de Informes Completo")
            Else
                MostrarError("Ocurrió un error en la Aprobación de Informes de Laboratorio")
            End If
        End If
        If User_Sistema = "SA" Then
            Return True
        End If
        Return oResultado.Realizo
    End Function
    Function GrabarDatosReunion() As Boolean
        'DAO

        If SOURCE.ListaParticipantes.Count = 0 Then
            MsgBox("No ha seleccionado ningun participante en la reunión")
            Return False
        End If
        If mostrarMensajeConfirmacion("REUNIÓN") Then
            Return False
        End If

        SOURCE.Organizador.Codigo = SOURCE.UsuarioResponsable.Codigo
        SOURCE.Organizador.Nombre = SOURCE.UsuarioResponsable.Nombre
        SOURCE.FechaReunion = dtpFechaReunion.Value

        If cboLugarReunion.SelectedValue = "0" Then
            SOURCE.LugarReunion = txtLugarReunion.Text.Trim()
        Else
            SOURCE.LugarReunion = cboLugarReunion.Text
        End If

        Dim oResultado As ETResultado = NReclamo.RegistrarProgramacionReunion(SOURCE)

        If oResultado.Realizo Then
            SOURCE.Estado = "REUNION"
            NReclamo.ActualizarEstado(SOURCE, User_Sistema)

            MsgBox("Registro de la Reunion Completado", MsgBoxStyle.OkOnly, msgComacsa)

            Return True
        Else
            MsgBox(oResultado.Mensaje, MsgBoxStyle.OkOnly, msgComacsa)

            Return False
        End If

    End Function
    Function GrabarAnalisisProblema() As Boolean
        'DAO

        If SOURCE.Id = 0 Then
            MsgBox("Debe registrar la queja primero")
        End If
        If mostrarMensajeConfirmacion("ANALISIS") Then
            Return False
        End If

        SOURCE.PersonaAnalisis.Codigo = UsuarioRegistra.Codigo
        SOURCE.PersonaAnalisis.Nombre = UsuarioRegistra.Nombre
        SOURCE.FechaAnalisis = dtpAnalisisFecha.Value

        Dim oResultado As ETResultado = NReclamo.RegistrarAnalisis(SOURCE)

        If oResultado.Realizo Then
            SOURCE.Estado = "ANALISIS"
            NReclamo.ActualizarEstado(SOURCE, User_Sistema)

            MsgBox("Registro de Análisis de Causa Completo", MsgBoxStyle.OkOnly, msgComacsa)

            Return True
        Else
            MsgBox(oResultado.Mensaje, MsgBoxStyle.OkOnly, msgComacsa)

            Return False
        End If


    End Function
    Function GrabarPlanesAccion() As Boolean
        'DAO

        If SOURCE.ListaEmailsCliente.Count = 0 Then
            MsgBox("Ingrese por lo menos un email del cliente")
            Return False
        End If

        If SOURCE.ListaPlanes.Count = 0 Then
            MsgBox("Debe registrar los planes de acción")
            Return False
        End If
        If mostrarMensajeConfirmacion("PLANES DE ACCIÖN") Then
            Return False
        End If

        Dim oResultado As ETResultado = NReclamo.RegistrarPlanesAccion(SOURCE)

        If oResultado.Realizo Then
            SOURCE.Estado = "PLAN DE ACCION"
            NReclamo.ActualizarEstado(SOURCE, User_Sistema)

            MsgBox("Registro de Planes de Acción Completo", MsgBoxStyle.OkOnly, msgComacsa)

            Return True
        Else
            MsgBox(oResultado.Mensaje, MsgBoxStyle.OkOnly, msgComacsa)

            Return False
        End If

        Return True
    End Function
    Function GrabarAprobacionReclamo() As Boolean

        'DAO
        If cboSolucionAprobadoPor.SelectedValue = "0" Then
            MsgBox("Debe seleccionar la persona que aprueba el informe al cliente")
            Return False
        End If
        If txtSolucionComentarios.Text.Trim.Length = 0 Then
            MsgBox("Ingrese un comentario")
            Return False
        End If
        If Not rbtSolucionNO.Checked AndAlso Not rbtSolucionSI.Checked Then
            MsgBox("Debe seleccionar el estado")
            Return False
        End If
        If SOURCE.ListaEmailsCliente.Count = 0 Then
            MsgBox("Debe registrar por lo menos un correo de referencia para el cliente")
            Return False
        End If
        If ugAccionesClienteProducto.Rows.Count = 0 Then
            MsgBox("No ha registrado ninguna acción para comunicar al cliente")
            Return False
        End If

        If MessageBox.Show("¿Desea aprobar y enviar el informe al cliente?", _
                   msgComacsa, MessageBoxButtons.YesNo, _
                   MessageBoxIcon.Question, _
                   MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return False
        End If

        SOURCE.AprobacionGerencia.Gerente.Codigo = cboSolucionAprobadoPor.SelectedValue
        SOURCE.AprobacionGerencia.Gerente.Nombre = cboSolucionAprobadoPor.Text
        SOURCE.AprobacionGerencia.FechaAprobacion = ObtenerFechaHora(dtpSolucionFecha, dtpSolucionHora)
        SOURCE.AprobacionGerencia.Observacion = txtSolucionComentarios.Text.Trim()
        SOURCE.AprobacionGerencia.Aprobado = rbtSolucionSI.Checked

        Dim oResultado As ETResultado = NReclamo.RegistrarAprobacion(SOURCE, "GERENCIA", User_Sistema)

        If oResultado.Realizo Then
            SOURCE.Estado = "APROBACION.GERENCIA"
            NReclamo.ActualizarEstado(SOURCE, User_Sistema)
            MsgBox("Se aprobó el informe para el cliente", MsgBoxStyle.OkOnly, msgComacsa)

            Return True
        Else
            MsgBox("Ocurrió un error en la Aprobación del Informe al cliente")

            Return False
        End If

    End Function

    Sub ActualizarDatosReclamo()

        'Cabecera
        SOURCE.Fecha = dtpFechaRegistro.Value
        SOURCE.Cliente = txtClienteRazonSocial.Text.Trim()
        SOURCE.ClienteCodigo = txtClienteCodigo.Text.Trim()

        SOURCE.UsuarioRegistra = UsuarioRegistra
        SOURCE.UsuarioResponsable = ObtenerJefeResponsable(SOURCE.ClienteCodigo)

        SOURCE.Nro = String.Empty

        If rbtTipoNacional.Checked Then
            SOURCE.Origen = "1"
        End If
        If rbtTipoExportacion.Checked Then
            SOURCE.Origen = "2"
        End If
        If rbtTipoProducto.Checked Then
            SOURCE.Tipo = "1"
        End If
        If rbtTipoServicio.Checked Then
            SOURCE.Tipo = "2"
        End If

        'Pareto
        If rbtParetoSI.Checked Then
            SOURCE.Pareto = "S"
        End If
        If rbtParetoNO.Checked Then
            SOURCE.Pareto = "N"
        End If

        'Producto
        ugDetGuia.UpdateData()

        SOURCE.Producto.Motivo = txtProductoMotivo.Text.Trim()
        SOURCE.Producto.Observacion = txtProductoObservacion.Text.Trim()
        SOURCE.ServicioObservacion = txtServicioComentarios.Text.Trim()

        SOURCE.EntregaEvidencia = rbtEvidenciaSI.Checked
        SOURCE.EntregaMuestra = rbtMuestraSI.Checked

        '---------------------------------------------------------------------------------------------
        ' Productos - Controles - HV 2024-05-30
        '---------------------------------------------------------------------------------------------
        '  Limpia Productos Opcion
        SOURCE.ProductosOpcion.Clear()

        Dim oReclamoProductoOpcion As ETReclamoProductoOpcion = Nothing

        ' Initialize the counter for counting checked RadioButtons
        Dim contador As Integer = 0

        ' Process RadioButtons in grpProducto01
        ProcessRadioButtonsProducto(grpProducto01, contador, SOURCE)

        ' Process RadioButtons in grpProducto02
        ProcessRadioButtonsProducto(grpProducto02, contador, SOURCE)

        ' Process RadioButtons in grpProducto03
        ProcessRadioButtonsProducto(grpProducto03, contador, SOURCE)


        '' Declara un contador para contar los RadioButtons marcados.
        'Dim contador As Integer = 0

        '' Itera a través de cada control en el contenedor grpProducto01.Controls.
        'For Each ctrl As Control In grpProducto01.Controls
        '    ' Intenta convertir el control actual a un RadioButton.
        '    Dim rbtnOpc As RadioButton = TryCast(ctrl, RadioButton)
        '    ' Verifica si la conversión fue exitosa antes de intentar acceder a la propiedad Checked.
        '    If rbtnOpc IsNot Nothing AndAlso rbtnOpc.Checked Then
        '        ' Incrementa el contador si el RadioButton está marcado.
        '        contador += 1
        '        ' Encuentra el GroupBox padre del RadioButton.
        '        Dim GrpBoxOpc As GroupBox = TryCast(ctrl.Parent, GroupBox)
        '        ' Si se encuentra el GroupBox, asigna sus valores a oReclamoProductoOpcion.
        '        If GrpBoxOpc IsNot Nothing Then
        '            ' Asigna el código del GroupBox a oReclamoProductoOpcion.Codigo.
        '            oReclamoProductoOpcion = New ETReclamoProductoOpcion
        '            oReclamoProductoOpcion.Codigo = GrpBoxOpc.Tag
        '            ' Asigna la opción del RadioButton a oReclamoProductoOpcion.Opcion.
        '            oReclamoProductoOpcion.Opcion = rbtnOpc.Tag
        '        End If
        '    End If
        'Next

        'If contador > 1 Then
        '    SOURCE.ProductosOpcion.Add(oReclamoProductoOpcion)
        '    contador = 0
        'End If

        '' Itera a través de cada control en el contenedor grpProducto01.Controls.
        'For Each ctrl As Control In grpProducto02.Controls
        '    ' Intenta convertir el control actual a un RadioButton.
        '    Dim rbtnOpc As RadioButton = TryCast(ctrl, RadioButton)
        '    ' Verifica si la conversión fue exitosa antes de intentar acceder a la propiedad Checked.
        '    If rbtnOpc IsNot Nothing AndAlso rbtnOpc.Checked Then
        '        ' Incrementa el contador si el RadioButton está marcado.
        '        contador += 1
        '        ' Encuentra el GroupBox padre del RadioButton.
        '        Dim GrpBoxOpc As GroupBox = TryCast(ctrl.Parent, GroupBox)
        '        ' Si se encuentra el GroupBox, asigna sus valores a oReclamoProductoOpcion.
        '        If GrpBoxOpc IsNot Nothing Then
        '            ' Asigna el código del GroupBox a oReclamoProductoOpcion.Codigo.
        '            oReclamoProductoOpcion = New ETReclamoProductoOpcion
        '            oReclamoProductoOpcion.Codigo = GrpBoxOpc.Tag
        '            ' Asigna la opción del RadioButton a oReclamoProductoOpcion.Opcion.
        '            oReclamoProductoOpcion.Opcion = rbtnOpc.Tag
        '        End If
        '    End If
        'Next

        'If contador > 1 Then
        '    SOURCE.ProductosOpcion.Add(oReclamoProductoOpcion)
        '    contador = 0
        'End If


        '' Itera a través de cada control en el contenedor grpProducto01.Controls.
        'For Each ctrl As Control In grpProducto02.Controls
        '    ' Intenta convertir el control actual a un RadioButton.
        '    Dim rbtnOpc As RadioButton = TryCast(ctrl, RadioButton)
        '    ' Verifica si la conversión fue exitosa antes de intentar acceder a la propiedad Checked.
        '    If rbtnOpc IsNot Nothing AndAlso rbtnOpc.Checked Then
        '        ' Incrementa el contador si el RadioButton está marcado.
        '        contador += 1
        '        ' Encuentra el GroupBox padre del RadioButton.
        '        Dim GrpBoxOpc As GroupBox = TryCast(ctrl.Parent, GroupBox)
        '        ' Si se encuentra el GroupBox, asigna sus valores a oReclamoProductoOpcion.
        '        If GrpBoxOpc IsNot Nothing Then
        '            ' Asigna el código del GroupBox a oReclamoProductoOpcion.Codigo.
        '            oReclamoProductoOpcion = New ETReclamoProductoOpcion
        '            oReclamoProductoOpcion.Codigo = GrpBoxOpc.Tag
        '            ' Asigna la opción del RadioButton a oReclamoProductoOpcion.Opcion.
        '            oReclamoProductoOpcion.Opcion = rbtnOpc.Tag
        '        End If
        '    End If
        'Next

        'If contador > 1 Then
        '    SOURCE.ProductosOpcion.Add(oReclamoProductoOpcion)
        '    contador = 0
        'End If


        'Servicio
        SOURCE.Servicios.Clear()

        Dim rbtn As RadioButton = Nothing
        Dim GrpBox As GroupBox = Nothing
        Dim oReclamoServicio As ETReclamoServicio = Nothing

        For Each Container As Control In grpServicio.Controls
            GrpBox = TryCast(Container, GroupBox)
            If GrpBox IsNot Nothing Then

                For Each ctrl As Control In GrpBox.Controls
                    rbtn = TryCast(ctrl, RadioButton)
                    If rbtn IsNot Nothing AndAlso rbtn.Checked Then
                        oReclamoServicio = New ETReclamoServicio
                        oReclamoServicio.Codigo = GrpBox.Tag
                        oReclamoServicio.Opcion = rbtn.Tag

                        Select Case GrpBox.Tag
                            Case "01"
                                oReclamoServicio.Observacion = txtServOtros01.Text.Trim()
                            Case "02"
                                oReclamoServicio.Observacion = txtServOtros02.Text.Trim()
                            Case "03"
                                oReclamoServicio.Observacion = txtServOtros03.Text.Trim()
                            Case "04"
                                oReclamoServicio.Observacion = txtServOtros04.Text.Trim()
                                'Case "05"
                                'oReclamoServicio.Observacion = txtServOtros05.Text.Trim()
                            Case "06"
                                oReclamoServicio.Observacion = txtServOtros06.Text.Trim()
                        End Select

                        SOURCE.Servicios.Add(oReclamoServicio)
                    End If
                Next

            End If
        Next

    End Sub



    ' Define a method to process RadioButtons in a given GroupBox
    Private Sub ProcessRadioButtonsProducto(ByVal grpProducto As GroupBox, ByRef contador As Integer, ByVal SOURCE As ETReclamo)
        ' Iterate through each control in the GroupBox
        'Dim contador As Int
        Dim oReclamoProductoOpcion As New ETReclamoProductoOpcion
        contador = 0

        For Each ctrl As Control In grpProducto01.Controls
            Dim rbtnOpc As RadioButton = TryCast(ctrl, RadioButton)
            If rbtnOpc IsNot Nothing AndAlso rbtnOpc.Checked Then
                contador += 1
                oReclamoProductoOpcion = New ETReclamoProductoOpcion
                ' Set the Codigo and Opcion properties
                oReclamoProductoOpcion.Codigo = grpProducto01.Tag
                oReclamoProductoOpcion.Opcion = rbtnOpc.Tag
                If ctrl.Text.ToUpper() = "OTROS" And rbtnOpc.Tag = "03" Then
                    oReclamoProductoOpcion.Observacion = txtProdOtros01.Text
                End If
            End If
        Next
        ' Add to the ProductosOpcion list if more than one RadioButton is checked
        If contador > 0 Then
            SOURCE.ProductosOpcion.Add(oReclamoProductoOpcion)
            contador = 0 ' Reset the counter
        End If

        For Each ctrl As Control In grpProducto02.Controls
            Dim rbtnOpc As RadioButton = TryCast(ctrl, RadioButton)
            If rbtnOpc IsNot Nothing AndAlso rbtnOpc.Checked Then
                contador += 1
                oReclamoProductoOpcion = New ETReclamoProductoOpcion
                ' Set the Codigo and Opcion properties
                oReclamoProductoOpcion.Codigo = grpProducto02.Tag
                oReclamoProductoOpcion.Opcion = rbtnOpc.Tag
                If ctrl.Text.ToUpper() = "OTROS" And rbtnOpc.Tag = "08" Then
                    oReclamoProductoOpcion.Observacion = txtProdOtros02.Text
                End If
            End If
        Next
        ' Add to the ProductosOpcion list if more than one RadioButton is checked
        If contador > 0 Then
            SOURCE.ProductosOpcion.Add(oReclamoProductoOpcion)
            contador = 0 ' Reset the counter
        End If

        For Each ctrl As Control In grpProducto03.Controls
            Dim rbtnOpc As RadioButton = TryCast(ctrl, RadioButton)
            If rbtnOpc IsNot Nothing AndAlso rbtnOpc.Checked Then
                contador += 1
                oReclamoProductoOpcion = New ETReclamoProductoOpcion
                ' Set the Codigo and Opcion properties
                oReclamoProductoOpcion.Codigo = grpProducto03.Tag
                oReclamoProductoOpcion.Opcion = rbtnOpc.Tag
                If ctrl.Text.ToUpper() = "OTROS" And rbtnOpc.Tag = "11" Then
                    oReclamoProductoOpcion.Observacion = txtProdOtros03.Text
                End If
            End If
        Next

        ' Add to the ProductosOpcion list if more than one RadioButton is checked
        If contador > 0 Then
            SOURCE.ProductosOpcion.Add(oReclamoProductoOpcion)
            contador = 0 ' Reset the counter
        End If

    End Sub



    Function ObtenerFechaLimite(ByVal fechaInicio As DateTime, ByVal nroDias As Integer) As DateTime
        Dim contador As Integer = 0
        While contador < nroDias
            If Not fechaInicio.DayOfWeek = DayOfWeek.Saturday AndAlso _
                Not fechaInicio.DayOfWeek = DayOfWeek.Sunday Then
                contador += 1
            End If
            fechaInicio.AddDays(1)
        End While
    End Function
#End Region

#Region "PESTAÑA PRODUCTO"

    Private Sub btnProductoNroGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductoNroGuia.Click
        Try
            Dim oFrmSeleccionGuia As New frmSeleccionGuia
            oFrmSeleccionGuia.Cliente = txtClienteRazonSocial.Text
            oFrmSeleccionGuia.ClienteCodigo = txtClienteCodigo.Text

            If oFrmSeleccionGuia.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim oGuia As ETReclamoProductoDetalle = Nothing

                For Each oNuevaGuia As ETReclamoProductoDetalle In oFrmSeleccionGuia.ListaDetallesProducto

                    Dim oGuiaComparar As ETReclamoProductoDetalle = oNuevaGuia

                    oGuia = SOURCE.Producto.ListaDetalles.FirstOrDefault(Function(p) p.NRO_GUIA = oGuiaComparar.NRO_GUIA _
                                                                             AndAlso p.NRO_FACT = oGuiaComparar.NRO_FACT _
                                                                             AndAlso p.COD_PRODUCTO = oGuiaComparar.COD_PRODUCTO)
                    If oGuia Is Nothing Then
                        SOURCE.Producto.ListaDetalles.Add(oNuevaGuia)
                    End If
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "COMACSA")
        End Try
    End Sub

#End Region

#Region "PESTAÑA SERVICIO"

    Private Sub CheckedOtros(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnServOtros12.CheckedChanged, rbtnServOtros21.CheckedChanged, rbtnServOtros28.CheckedChanged, rbtnServOtros24.CheckedChanged
        Dim rbtn As RadioButton = TryCast(sender, RadioButton)
        Dim GrpBox As GroupBox = Nothing
        Dim txt() As Control = Nothing

        If rbtn IsNot Nothing Then
            GrpBox = CType(rbtn.Parent, GroupBox)
            txt = GrpBox.Controls.Find("txtServOtros" & GrpBox.Tag, False)
            If txt.Length > 0 Then
                DirectCast(txt(0), TextBox).ReadOnly = Not rbtn.Checked
            End If
        End If
    End Sub

#End Region

#Region "MUESTRAS"

    Private Sub btnAgregarMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarMuestra.Click

        'Try
        '    If txtMuestraProducto.Text.Trim.Length = 0 Then
        '        MsgBox("Ingrese el Producto", MsgBoxStyle.OkOnly, msgComacsa)
        '        Return
        '    End If
        '    If txtMuestraProducto.Text.Trim.Length = 0 Then
        '        MsgBox("Ingrese el Lote", MsgBoxStyle.OkOnly, msgComacsa)
        '        Return
        '    End If
        '    If txtMuestraProducto.Text.Trim.Length = 0 Then
        '        MsgBox("Ingrese el nùmero de bolsas", MsgBoxStyle.OkOnly, msgComacsa)
        '        Return
        '    End If
        '    If txtMuestraProducto.Text.Trim.Length = 0 Then
        '        MsgBox("Ingrese un comentario", MsgBoxStyle.OkOnly, msgComacsa)
        '        Return
        '    End If

        '    Dim NroDias As Integer = 3
        '    If rbtTipoExportacion.Checked Then
        '        NroDias = 10
        '    End If

        '    Dim oItem As ETReclamoMuestra = SOURCE.ListaMuestras.FirstOrDefault(Function(p) p.PRODUCTO = txtMuestraProducto.Text.Trim())

        '    If oItem Is Nothing Then

        '        oItem = New ETReclamoMuestra()
        '        oItem.PRODUCTO = txtMuestraProducto.Text.Trim()
        '        oItem.LOTE = txtMuestraLote.Text.Trim()
        '        oItem.NROBOLSA = txtMuestraNroBolsa.Text.Trim()
        '        oItem.FECHA_INICIO = dtpMuestraFechaEntrega.Value
        '        oItem.FECHA_FIN = DirectCast(dtpMuestraFechaEntrega.Value, DateTime).AddDays(NroDias)
        '        oItem.OBSERVACION = txtMuestraObservacion.Text.Trim()

        '        SOURCE.ListaMuestras.Add(oItem)

        '        'Dim oItem2 As New EtReclamoMuestraLab(oItem)
        '        'SOURCE.ListaMuestrasLab.Add(oItem2)

        '    Else
        '        MsgBox("El producto ya se encuentra agregado")
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


    End Sub

    Private Sub ugMuestras_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugMuestras.ClickCellButton

        Try

            'Dim producto As String = ugMuestras.ActiveRow.Cells("PRODUCTO").Value
            Dim producto As String = e.Cell.Row.Cells("PRODUCTO").Value
            Dim lote As String = e.Cell.Row.Cells("LOTE").Value
            Dim nrobolsa As String = e.Cell.Row.Cells("NROBOLSA").Value

            Dim oMuestra As ETReclamoMuestra = SOURCE.ListaMuestras.FirstOrDefault(Function(p) p.PRODUCTO = producto And p.LOTE = lote And p.NROBOLSA = nrobolsa)

            If e.Cell.Column.Key = "ELIMINAR" Then

                If GrillaHabilitada(ugMuestras) Then
                    If oMuestra IsNot Nothing Then
                        If MsgBox("Desea eliminar el registro de la muestra", MsgBoxStyle.OkOnly, "COMACSA") = MsgBoxResult.Ok Then
                            SOURCE.ListaMuestras.Remove(oMuestra)
                        End If
                    End If
                Else
                    MostrarAdvertencia("No puede eliminar la muestra cuando ya ha salido del estado de registro de muestras")
                End If

            End If


            Dim NombreArchivo As String = ""

            Dim oItem As ETReclamoMuestra = SOURCE.ListaMuestras.FirstOrDefault(Function(p) p.PRODUCTO = producto)

            If e.Cell.Column.Key = "ARCHIVOM" Then

                If GrillaHabilitada(ugMuestras) Then
                    OpenFIle.ShowDialog()
                    If OpenFIle.FileName.Length > 0 Then
                        NombreArchivo = ObtenerNombreReporte(rutaArchivosMuestra, OpenFIle.SafeFileName)
                        System.IO.File.Copy(OpenFIle.FileName, NombreArchivo, True)
                        oItem.ARCHIVOM = OpenFIle.SafeFileName
                    End If
                Else
                    MostrarAdvertencia("No puede agregar muestras cuando ya ha salido del estado de registro de muestras")
                End If

            End If

            If e.Cell.Column.Key = "LIMPIAR" Then

                If GrillaHabilitada(ugMuestras) Then
                    If MsgBox("Desea retirar el archivo subido", MsgBoxStyle.YesNo, "COMACSA") = MsgBoxResult.Yes Then
                        oItem.ARCHIVOM = ""
                    End If
                End If

            End If

            If e.Cell.Column.Key = "VER" And e.Cell.Row.Cells("ARCHIVOM").Text.Trim().Length > 0 Then
                NombreArchivo = ObtenerNombreReporte(rutaArchivosMuestra, e.Cell.Row.Cells("ARCHIVOM").Value)
                'System.IO.File.Copy(NombreArchivo, oItem.ARCHIVOM, True)
                System.Diagnostics.Process.Start(NombreArchivo)
            End If
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Private Sub rbtMuestraSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMuestraSI.CheckedChanged

        DesBloquearGrilla(ugMuestras, rbtMuestraSI.Checked)
        If rbtMuestraSI.Checked Then

            Dim muestras_inconformes As New List(Of ETReclamoMuestra)
            Dim muestra_inconforme As New ETReclamoMuestra

            For Each muestra As ETReclamoMuestra In SOURCE.ListaMuestras
                If muestra.ESTADO <> "EN CURSO" Then
                    muestra_inconforme = New ETReclamoMuestra
                    muestra_inconforme.COD_PRODUCTO = muestra.COD_PRODUCTO
                    muestra_inconforme.PRODUCTO = muestra.PRODUCTO
                    muestra_inconforme.LOTE = muestra.LOTE
                    muestra_inconforme.NROBOLSA = muestra.NROBOLSA
                    muestra_inconforme.NROBOLSARECLAMADAS = muestra.NROBOLSARECLAMADAS
                    muestra_inconforme.FECHA_INICIO = muestra.FECHA_INICIO
                    muestra_inconforme.OBSERVACION = muestra.OBSERVACION
                    muestra_inconforme.ESTADO = muestra.ESTADO
                    muestra_inconforme.ESTADO_OBS = muestra.ESTADO_OBS
                    muestras_inconformes.Add(muestra_inconforme)
                End If
            Next

            SOURCE.ListaMuestras.Clear()

            For Each item As ETReclamoMuestra In muestras_inconformes
                muestra_inconforme = New ETReclamoMuestra
                muestra_inconforme.COD_PRODUCTO = item.COD_PRODUCTO
                muestra_inconforme.PRODUCTO = item.PRODUCTO
                muestra_inconforme.LOTE = item.LOTE
                muestra_inconforme.NROBOLSA = item.NROBOLSA
                muestra_inconforme.NROBOLSARECLAMADAS = item.NROBOLSARECLAMADAS
                muestra_inconforme.FECHA_INICIO = item.FECHA_INICIO
                muestra_inconforme.OBSERVACION = item.OBSERVACION
                muestra_inconforme.ESTADO = item.ESTADO
                muestra_inconforme.ESTADO_OBS = item.ESTADO_OBS
                SOURCE.ListaMuestras.Add(muestra_inconforme)
            Next


            For Each Entidad As ETReclamoProductoDetalle In SOURCE.Producto.ListaDetalles
                Dim muestra As New ETReclamoMuestra
                muestra.COD_PRODUCTO = Entidad.COD_PRODUCTO
                muestra.PRODUCTO = Entidad.PRODUCTO
                muestra.LOTE = Entidad.LOTE
                muestra.NROBOLSA = Entidad.NRO_BOLSAS
                muestra.NROBOLSARECLAMADAS = Entidad.NRO_BOLSAS_RECLAMADAS
                muestra.FECHA_INICIO = dtpMuestraFechaEntrega.DateTime.Date
                muestra.OBSERVACION = txtMuestraObservacion.Text.Trim
                SOURCE.ListaMuestras.Add(muestra)
            Next
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMuestraNo.CheckedChanged
        'gbDatosMuestra.Enabled = rbtMuestraSI.Checked
        DesBloquearGrilla(ugMuestras, rbtMuestraSI.Checked)
        If rbtMuestraNo.Checked Then
            SOURCE.ListaMuestras.Clear()
        End If
    End Sub

#End Region

#Region "LABORATORIO"

    Private Sub ugLaboratorioInformes_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugLaboratorioInformes.ClickCellButton

        Try

            Dim producto As String = e.Cell.Row.Cells("PRODUCTO").Value
            Dim path As String = rutaArchivosLab

            Dim oItem As EtReclamoMuestraLab = SOURCE.ListaMuestrasLab.FirstOrDefault(Function(p) p.PRODUCTO = producto)

            If e.Cell.Column.Key = "ARCHIVO" Then

                '  Verifica que marque SI o No se visializa como True o False 

                Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = ugLaboratorioInformes.ActiveRow
                Dim selectedMC As Boolean = False
                If activeRow IsNot Nothing Then
                    selectedMC = activeRow.Cells("MUESTRA_CONFORME").Value
                End If

                'HV -  2024-06-19
                If selectedMC Then
                    OpenFIle.ShowDialog()
                    If OpenFIle.FileName.Length > 0 Then
                        System.IO.File.Copy(OpenFIle.FileName, ObtenerNombreReporte(path, OpenFIle.SafeFileName), True)
                        oItem.ARCHIVO = OpenFIle.SafeFileName
                    End If
                Else
                    MostrarAdvertencia("Para registrar el informe de laboratorio , primero debe registrar la conformidad de muestras")
                End If

            End If
            If e.Cell.Column.Key = "VER" And oItem.ARCHIVO.Length > 0 Then
                System.Diagnostics.Process.Start(ObtenerNombreReporte(rutaArchivosLab, oItem.ARCHIVO))
            End If
            If e.Cell.Column.Key = "DEL" And oItem.ARCHIVO.Length > 0 Then
                If MessageBox.Show("Desea retirar el archivo seleccionado?", "Sistema de Quejas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    oItem.ARCHIVO = ""
                End If
            End If
            If e.Cell.Column.Key = "VERM" And oItem.ARCHIVOM.Length > 0 Then
                System.Diagnostics.Process.Start(ObtenerNombreReporte(rutaArchivosMuestra, oItem.ARCHIVOM))
            End If
            If e.Cell.Column.Key = "OBSERVACION" Then
                Dim frm As New frmReclamoInputBox
                frm.Titulo = "Ingrese el resultado para " & oItem.PRODUCTO
                frm.Comentario = oItem.OBSERVACION
                If frm.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                    oItem.OBSERVACION = frm.Comentario
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ugLaboratorioInformes_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugLaboratorioInformes.CellChange
        'Try
        '    If e.Cell.Column.Key = "FECHA_FIN" Then
        '        Dim fechaEntrega As DateTime = e.Cell.Row.Cells("FECHA_INICIO").Value
        '        Dim FechaResultados As DateTime = e.Cell.Value

        '        If Math.Abs(DateDiff(DateInterval.Day, fechaEntrega, FechaResultados)) > 4 _
        '        AndAlso e.Cell.Row.Cells("APROBADO_POR").Value.ToString().Length = 0 Then
        '            MsgBox("Si el plazo para entregar resultados supera 4 dias , se requiere indicar a la persona que aprueba el plazo")
        '            e.Cell.CancelUpdate()
        '        End If

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub ugLaboratorioInformes_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugLaboratorioInformes.InitializeLayout
        If Not ugLaboratorioInformes.DisplayLayout.ValueLists.Exists("ENCARGADOS") Then
            ugLaboratorioInformes.DisplayLayout.Bands(0).Columns("APROBADO_POR").ValueList = ObtenerListaEncargadosLaboratorio()
        End If

        If Not ugLaboratorioInformes.DisplayLayout.ValueLists.Exists("ESTADO_CONFORMIDAD") Then
            ugLaboratorioInformes.DisplayLayout.Bands(0).Columns("CONFORMIDAD").ValueList = ObtenerListaEstadoConformidadLab()
        End If

        If Not ugLaboratorioInformes.DisplayLayout.ValueLists.Exists("ESTADO_FECHA") Then
            ugLaboratorioInformes.DisplayLayout.Bands(0).Columns("CONFORMIDAD_FECHA").ValueList = ObtenerListaEstadoConfFechaLab()
        End If
    End Sub

    Private Sub ugMuestras_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugMuestras.InitializeLayout
        If Not ugMuestras.DisplayLayout.ValueLists.Exists("RESPONSABLE") Then
            ugMuestras.DisplayLayout.Bands(0).Columns("RESPONSABLE").ValueList = ObtenerListaResponsablesLaboratorio()
        End If
        If Not ugMuestras.DisplayLayout.ValueLists.Exists("ESTADO") Then
            ugMuestras.DisplayLayout.Bands(0).Columns("ESTADO").ValueList = ObtenerListaEstadoMuestra()
        End If
    End Sub


    Private Sub ugLaboratorioInformes_BeforeExitEditMode(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs) Handles ugLaboratorioInformes.BeforeExitEditMode

    End Sub
    Private Sub ugLaboratorioInformes_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugLaboratorioInformes.AfterCellUpdate
        Try
            Dim cell As UltraGridCell = e.Cell ' DirectCast(sender, UltraGrid).ActiveCell

            If cell.Column.Key = "FECHA_FIN" Then

                Dim FechaRevision As DateTime = Convert.ToDateTime(cell.Row.Cells("FECHA_INICIO").Value)
                Dim FechaEntrega As DateTime = Convert.ToDateTime(cell.Value)

                Dim NumeroDiasParaRevision As Integer = IIf(rbtTipoNacional.Checked, 3, 10)

                If DateDiff(DateInterval.Day, FechaRevision, FechaEntrega) > NumeroDiasParaRevision Then
                    'se requiere seleccionar a la persona que autoriza la extension de tiempo
                    If cell.Row.Cells("APROBADO_POR").Value.ToString().Length = 0 Then
                        MsgBox("Si la fecha de informe supera los " & NumeroDiasParaRevision.ToString() & " dias, se requiere seleccionar a la persona que autoriza la extension del plazo", MsgBoxStyle.OkOnly, "COMACSA")
                        cell.Value = FechaRevision.AddDays(NumeroDiasParaRevision).Date
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "COMACSA")
        End Try
    End Sub
    Function ObtenerListaEstadoAprobacion() As Infragistics.Win.ValueList
        Dim valueList As Infragistics.Win.ValueList = gridFormatoComentarios.DisplayLayout.ValueLists.Add("ESTADO_APROB")
        valueList.ValueListItems.Add("ACEPTADO")
        valueList.ValueListItems.Add("NO ACEPTADO")

        Return valueList
    End Function
    Function ObtenerListaEstadoConformidadLab() As Infragistics.Win.ValueList
        Dim valueList As Infragistics.Win.ValueList = ugLaboratorioInformes.DisplayLayout.ValueLists.Add("ESTADO_CONFORMIDAD")
        valueList.ValueListItems.Add("SI")
        valueList.ValueListItems.Add("NO")
        Return valueList
    End Function
    Function ObtenerListaEstadoConfFechaLab() As Infragistics.Win.ValueList
        Dim valueList As Infragistics.Win.ValueList = ugLaboratorioInformes.DisplayLayout.ValueLists.Add("ESTADO_FECHA")
        valueList.ValueListItems.Add("SI")
        valueList.ValueListItems.Add("NO")
        Return valueList
    End Function
    Function ObtenerListaEncargadosLaboratorio() As Infragistics.Win.ValueList

        Dim valueList As Infragistics.Win.ValueList = ugLaboratorioInformes.DisplayLayout.ValueLists.Add("ENCARGADOS")
        valueList.ValueListItems.Add("Walter Lizarraga")
        valueList.ValueListItems.Add("Javier Ruiz")

        Return valueList
    End Function
    Function ObtenerListaResponsablesLaboratorio() As Infragistics.Win.ValueList

        Dim valueList As Infragistics.Win.ValueList = ugMuestras.DisplayLayout.ValueLists.Add("RESPONSABLE")
        'valueList.ValueListItems.Add("Nancy Torres")
        valueList.ValueListItems.Add("Walter Lizaragua")
        valueList.ValueListItems.Add("Javier Ruiz")
        Return valueList
    End Function

    Function ObtenerListaEstadoMuestra() As Infragistics.Win.ValueList
        Dim valueList As Infragistics.Win.ValueList = ugMuestras.DisplayLayout.ValueLists.Add("ESTADO")
        valueList.ValueListItems.Add("EN CURSO")
        valueList.ValueListItems.Add("CANCELADO")
        valueList.ValueListItems.Add("RECHAZADO")
        valueList.ValueListItems.Add("CONGELADO")
        Return valueList
    End Function
#End Region

#Region "PESTAÑA REUNION"

    Public Function ObtenerJefeResponsable(ByVal CodigoCliente As String) As ETReclamoPersona
        'DAO
        Dim oJefeResponsable As New ETReclamoPersona
        Try

            If rbtTipoNacional.Checked Then
                oJefeResponsable.Correo = "kbravo@comacsa.com.pe"
                oJefeResponsable.Nombre = "BRAVO VICENTE KATHERINE MAYTE"
                oJefeResponsable.Codigo = "00000001"
            End If
            If rbtTipoExportacion.Checked Then
                oJefeResponsable.Correo = "flopez@comacsa.com.pe"
                oJefeResponsable.Nombre = "LOPEZ DAMIAN FIORELLA JAQUELINE"
                oJefeResponsable.Codigo = "00019112" '"00001346"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return oJefeResponsable
    End Function

    Private Sub btnAgregarOtroResponsable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarOtroResponsable.Click

        If Len(txtResponsableOtros.Text.Trim()) = 0 Then Return

        Dim oParticipante As ETReclamoPersona = SOURCE.ListaParticipantes.FirstOrDefault(Function(p) p.Nombre = txtResponsableOtrosNombre.Text.Trim())

        If oParticipante Is Nothing Then

            If EsEmailValido(txtResponsableOtros.Text.Trim()) Then

                oParticipante = New ETReclamoPersona()
                oParticipante.Nombre = txtResponsableOtrosNombre.Text
                oParticipante.Correo = txtResponsableOtros.Text
                oParticipante.Area = "OTROS"

                SOURCE.ListaParticipantes.Add(oParticipante)
            Else
                MostrarAdvertencia("EL correo no es válido")
            End If

        Else
            MostrarMensaje("El participante ya esta agregado")
        End If
    End Sub

    Private Sub chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim chk As CheckBox = TryCast(sender, CheckBox)

        If chk IsNot Nothing Then

            Dim oParticipante As ETReclamoPersona = SOURCE.ListaParticipantes.FirstOrDefault(Function(p) p.Nombre = chk.Text)

            If oParticipante Is Nothing Then
                oParticipante = New ETReclamoPersona
                oParticipante.Nombre = chk.Text
                oParticipante.Correo = chk.Tag
                oParticipante.Area = chk.Parent.Parent.Text

                If chk.Checked Then
                    SOURCE.ListaParticipantes.Add(oParticipante)
                End If

            Else
                If Not chk.Checked Then
                    SOURCE.ListaParticipantes.Remove(oParticipante)
                End If
            End If

        End If
    End Sub

    Private Sub btnProgramarReunion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgramarReunion.Click

        If MessageBox.Show("Desea programar la reunión?", "Confirmar Generar Reunion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            EnviarMailReunion()
        End If

    End Sub

    Private Sub cboLugarReunion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLugarReunion.SelectedIndexChanged
        txtLugarReunion.Visible = (cboLugarReunion.SelectedValue = "00")
    End Sub

#End Region

#Region "PESTAÑA ANALISIS"

    Sub IngresarPorqueCausa(ByVal txt As TextBox)

        If cboCausaOrigen.SelectedValue = "0" Then
            MsgBox("Debe seleccionar la causa inmediata", MsgBoxStyle.OkOnly, msgComacsa)
            cboCausaOrigen.Focus()
            Return
        End If
        If txt.Text.Trim.Length = 0 Then
            MsgBox("Ingrese el porqué", MsgBoxStyle.OkOnly, msgComacsa)
            txt.Focus()
            Return
        End If
        If SOURCE.Id = 0 Then
            MsgBox("Debe registrar la queja primero", MsgBoxStyle.OkOnly, msgComacsa)
            Return
        End If

        Dim ItemCausaOrigen As Integer = Convert.ToInt32(cboCausaOrigen.SelectedValue)
        Dim ItemCausaOrigenDet As Integer = Convert.ToInt32(txt.Tag)
        Dim oCausaOrigen As ETReclamoCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = ItemCausaOrigen)

        If oCausaOrigen IsNot Nothing Then

            Dim oCausaOrigenDet As ETReclamoCausaDetalle = oCausaOrigen.Detalles.FirstOrDefault(Function(r) r.Item = ItemCausaOrigenDet)

            If oCausaOrigenDet Is Nothing Then
                oCausaOrigenDet = New ETReclamoCausaDetalle
                oCausaOrigen.Detalles.Add(oCausaOrigenDet)
            End If

            oCausaOrigenDet.Descripcion = txt.Text.Trim()
            oCausaOrigenDet.IdCausa = ItemCausaOrigen
            oCausaOrigenDet.Item = Convert.ToInt32(txt.Tag)

        End If

    End Sub

    Private Sub btnCausa1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCausa1.Click

        IngresarPorqueCausa(txtCausa1)

        grpCausa2.Enabled = True
    End Sub

    Private Sub btnCausa2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCausa2.Click

        IngresarPorqueCausa(txtCausa2)

        grpCausa3.Enabled = True
    End Sub

    Private Sub btnCausa3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCausa3.Click

        IngresarPorqueCausa(txtCausa3)

        grpCausa4.Enabled = True
    End Sub

    Private Sub btnCausa4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCausa4.Click

        IngresarPorqueCausa(txtCausa4)

        grpCausa5.Enabled = True
    End Sub

    Private Sub btnCerrarCausar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCausar2.Click
        txtCausa2.Text = ""
        grpCausa2.Enabled = False
    End Sub

    Private Sub btnCerrarCausar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCausar3.Click
        txtCausa3.Text = ""
        grpCausa3.Enabled = False
    End Sub

    Private Sub btnCerrarCausar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCausar4.Click
        txtCausa4.Text = ""
        grpCausa4.Enabled = False
    End Sub

    Private Sub btnCerrarCausar5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarCausar5.Click
        txtCausa5.Text = ""
        grpCausa5.Enabled = False
    End Sub

#End Region

#Region "PLAN DE ACCION"

    Private Sub btnPlanAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlanAgregar.Click
        Try
            Dim frm As New frmReclamoPlanAccion

            frm.LstCausasOrigen = SOURCE.Causas.ToList()
            frm.LstParticipantes = SOURCE.ListaParticipantes.ToList()

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim oPlanAccion As ETReclamoPlanAccion = frm.oPlanAccion
                SOURCE.ListaPlanes.Add(oPlanAccion)
            End If

        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Private Sub ugAcciones_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugAcciones.ClickCellButton
        Try
            If GrillaHabilitada(ugAcciones) Then
                If e.Cell.Column.Key.ToUpper = "ELIMINAR" Then

                    Dim oItem As Integer = e.Cell.Row.Cells("ITEM").Value
                    Dim oPlanAccion As ETReclamoPlanAccion = SOURCE.ListaPlanes.FirstOrDefault(Function(i) i.Item = oItem)

                    If oPlanAccion IsNot Nothing Then

                        If MessageBox.Show("¿Desea eliminar el plan de acción registrado?", "COMACSA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            SOURCE.ListaPlanes.Remove(oPlanAccion)
                        End If

                    End If
                End If
            Else
                MostrarAdvertencia("No puede eliminar las acciones , la queja ya no esta en la fase de registro de planes de acción")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ugAcciones_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugAcciones.InitializeLayout

    End Sub

#End Region

#Region "LISTA RECLAMOS"

    Private Sub ugPrincipal_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles ugPrincipal.DoubleClickRow

        Dim Nro As String = ugPrincipal.ActiveRow.Cells("NRO").Text

        Dim pReclamo As ETReclamo = LISTA_SOURCE.FirstOrDefault(Function(p) p.Nro = Nro)

        If pReclamo IsNot Nothing Then

            CargarDatos(pReclamo)

            tabReclamo.SelectedTab = tabReclamo.Tabs("T01")

        End If

    End Sub

    Private Sub tabTipoReclamo_TabIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabTipoReclamo.TabIndexChanged

    End Sub

    Private Sub tabTipoReclamo_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabTipoReclamo.SelectedTabChanged

        If tabReclamo.SelectedTab Is Nothing Then Return

        If Laboratorio Then Return

        If tabReclamo.SelectedTab.Key = "TT04" Then 'Laboratorio

        End If

        If rbtTipoProducto.Checked Then

            If tabTipoReclamo.SelectedTab IsNot Nothing Then
                If tabTipoReclamo.SelectedTab.Key = "TT03" Then 'Muestras
                    If SOURCE.Producto.ListaDetalles.Count = 0 Then
                        MsgBox("Para registrar las muestras debe grabar los detalles del producto primero")
                        tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT01")
                    End If
                End If
            End If

        End If

        If rbtTipoServicio.Checked Then
            If tabTipoReclamo.SelectedTab IsNot Nothing Then
                If tabTipoReclamo.SelectedTab.Key = "TT09" Then 'Evidencias
                    If SOURCE.Servicios.Count() = 0 Then
                        MsgBox("Para registrar las evidencias debe grabar los detalles del servicio primero")
                        tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT02")
                    End If
                End If
            End If
        End If

        If tabTipoReclamo.SelectedTab IsNot Nothing Then
            If tabTipoReclamo.SelectedTab.Key = "TT06" Then 'Planes de Accion

                If SOURCE.Causas.Count = 0 Then
                    MsgBox("Para elaborar los planes de Accion es necesario realizar el Análisis de la queja primero")

                    tabTipoReclamo.SelectedTab = tabTipoReclamo.Tabs("TT07")
                End If

                GuardarDetallesCausa(cboCausaOrigen.SelectedValue)

                txtPlanResponsable.Text = txtOrganizador.Text.Trim()

            End If
        End If
    End Sub

    Private Sub tabReclamo_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabReclamo.SelectedTabChanged
        Try
            If tabReclamo.SelectedTab.Key = "T02" Then
                txtSolucionClienteCodigo.Text = txtClienteCodigo.Text
                txtSolucionClienteRazonSocial.Text = txtClienteRazonSocial.Text
                txtSolucionEmail.Text = txtClienteEmail.Text

                ugAccionesClienteProducto.DataSource = New List(Of ETReclamoPlanAccion)

                If SOURCE.ListaPlanes.Count > 0 Then

                    ugAccionesClienteProducto.DataSource = SOURCE.ListaPlanes.ToList().FindAll(Function(p) p.Notifica = True)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

    Private Sub UltraTabPageControl11_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UTPCAnalisis.Paint
    End Sub

    Private Sub UltraTabPageControl10_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
    End Sub

    Private Sub grpAprobProduccion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpAprobProduccion.Enter

    End Sub


    Private Sub btnSolucionEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolucionEnviar.Click
        'Generar Archivo y enviar al cliente
        Try
            If SOURCE.Estado <> "APROBADO" Then
                MsgBox("Debe registrar la aprobación de la queja antes de poder reenviar el correo", MsgBoxStyle.OkOnly, msgComacsa)
                Return
            End If

            If cboSolucionAprobadoPor.SelectedValue = "0" Then
                MsgBox("Seleccione el Gerente que Aprueba el informe", MsgBoxStyle.OkOnly, msgComacsa)
                Return
            End If
            If txtSolucionEmail.Text.Trim.Length = 0 Then
                MsgBox("Debe ingresar por lo menos un correo de cliente", MsgBoxStyle.OkOnly, msgComacsa)
                Return
            End If


            EnviarMail(Correo_ObtenerCorreosAprobacionFinal_8(SOURCE), "QUEJA NRO: " & SOURCE.Nro, "Se ha generado el siguiente informe sobre la queja " & SOURCE.Nro, MailPriority.Normal, rutaArchivosGenerados & GenerarArchivoReporte())

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try
    End Sub


    Private Sub grpCausa3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpCausa3.Enter

    End Sub

    Private Sub grpAnalisisProblema_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpAnalisisProblema.Enter

    End Sub

    Private Sub btnAgregarCausa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCausa.Click
        AgregarCausaOrigen()
    End Sub

    Sub AgregarCausaOrigen()
        Try
            If SOURCE.Causas.ToList().Exists(Function(p) p.CausaOrigen = txtCausaDescripcion.Text.Trim()) Then
                MostrarAdvertencia("La causa origen ya esta registrada")
                Return
            End If
            If txtCausaDescripcion.Text.Trim().Length = 0 Then
                MostrarAdvertencia("Ingrese la descripción")
                Return
            End If
            If SOURCE.Id = 0 Then
                MostrarAdvertencia("Registre los datos de la queja")
                Return
            End If

            Dim oCausaOrigen As New ETReclamoCausa

            oCausaOrigen.Item = SOURCE.Causas.Count + 1
            oCausaOrigen.CausaOrigen = txtCausaDescripcion.Text.Trim()
            oCausaOrigen.Registrador.Codigo = User_Sistema ' UsuarioRegistra.Codigo
            'oCausaOrigen.Registrador.Nombre = UsuarioRegistra.Nombre

            SOURCE.Causas.Add(oCausaOrigen)

            txtCausaItem.Text = SOURCE.Causas.Count + 1
            txtCausaDescripcion.Text = String.Empty

        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub


    Private Sub tabCausas_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabCausas.SelectedTabChanged
        If tabCausas.SelectedTab.Key = "C02" Then
            Dim listaCausas As List(Of ETReclamoCausa) = SOURCE.Causas.ToList()

            Dim oCausaOrigenDummy As New ETReclamoCausa
            oCausaOrigenDummy.Item = 0
            oCausaOrigenDummy.CausaOrigen = "-- Seleccion --"

            listaCausas.Insert(0, oCausaOrigenDummy)

            cboCausaOrigen.DisplayMember = "CausaOrigen"
            cboCausaOrigen.ValueMember = "Item"
            cboCausaOrigen.DataSource = listaCausas

        End If
    End Sub
    Sub ReiniciarDetallesCausa()
        grpCausa2.Enabled = False
        grpCausa3.Enabled = False
        grpCausa4.Enabled = False
        grpCausa5.Enabled = False

        txtCausa1.Text = String.Empty
        txtCausa2.Text = String.Empty
        txtCausa3.Text = String.Empty
        txtCausa4.Text = String.Empty
        txtCausa5.Text = String.Empty
    End Sub
    Sub CargarDetallesCausa()

        Dim item As Integer = Convert.ToInt32(cboCausaOrigen.SelectedValue)
        Dim oCausaOrigen As ETReclamoCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = item)

        ReiniciarDetallesCausa()

        If oCausaOrigen IsNot Nothing Then

            Dim oCausaDetalle As ETReclamoCausaDetalle = Nothing

            'Porque 1
            oCausaDetalle = oCausaOrigen.Detalles.FirstOrDefault(Function(d) d.Item = 1)
            If oCausaDetalle IsNot Nothing Then
                txtCausa1.Text = oCausaDetalle.Descripcion
            End If
            'Porque 2
            oCausaDetalle = oCausaOrigen.Detalles.FirstOrDefault(Function(d) d.Item = 2)
            If oCausaDetalle IsNot Nothing Then
                txtCausa2.Text = oCausaDetalle.Descripcion
                grpCausa2.Enabled = True
            End If
            'Porque 3
            oCausaDetalle = oCausaOrigen.Detalles.FirstOrDefault(Function(d) d.Item = 3)
            If oCausaDetalle IsNot Nothing Then
                txtCausa3.Text = oCausaDetalle.Descripcion
                grpCausa3.Enabled = True
            End If
            'Porque 4
            oCausaDetalle = oCausaOrigen.Detalles.FirstOrDefault(Function(d) d.Item = 4)
            If oCausaDetalle IsNot Nothing Then
                txtCausa4.Text = oCausaDetalle.Descripcion
                grpCausa4.Enabled = True
            End If
            'Porque 5
            oCausaDetalle = oCausaOrigen.Detalles.FirstOrDefault(Function(d) d.Item = 5)
            If oCausaDetalle IsNot Nothing Then
                txtCausa5.Text = oCausaDetalle.Descripcion
                grpCausa5.Enabled = True
            End If
        End If

    End Sub

    Dim CausaOrigenPrevio As Integer = 0

    Sub GuardarDetallesCausa(ByVal id As Integer)
        Try

            Dim oCausaOrigen As ETReclamoCausa = SOURCE.Causas.FirstOrDefault(Function(p) p.Item = id)
            Dim oCausaOrigenDet As ETReclamoCausaDetalle = Nothing

            If oCausaOrigen IsNot Nothing Then

                oCausaOrigen.Detalles.Clear()

                If txtCausa1.Text.Trim.Length > 0 Then
                    oCausaOrigenDet = New ETReclamoCausaDetalle()
                    oCausaOrigenDet.Descripcion = txtCausa1.Text.Trim()
                    oCausaOrigenDet.IdCausa = oCausaOrigen.Item
                    oCausaOrigenDet.Item = 1

                    oCausaOrigen.Detalles.Add(oCausaOrigenDet)
                End If
                If txtCausa2.Text.Trim.Length > 0 Then
                    oCausaOrigenDet = New ETReclamoCausaDetalle()
                    oCausaOrigenDet.Descripcion = txtCausa2.Text.Trim()
                    oCausaOrigenDet.IdCausa = oCausaOrigen.Item
                    oCausaOrigenDet.Item = 2

                    oCausaOrigen.Detalles.Add(oCausaOrigenDet)
                End If
                If txtCausa3.Text.Trim.Length > 0 Then
                    oCausaOrigenDet = New ETReclamoCausaDetalle()
                    oCausaOrigenDet.Descripcion = txtCausa3.Text.Trim()
                    oCausaOrigenDet.IdCausa = oCausaOrigen.Item
                    oCausaOrigenDet.Item = 3

                    oCausaOrigen.Detalles.Add(oCausaOrigenDet)
                End If
                If txtCausa4.Text.Trim.Length > 0 Then
                    oCausaOrigenDet = New ETReclamoCausaDetalle()
                    oCausaOrigenDet.Descripcion = txtCausa4.Text.Trim()
                    oCausaOrigenDet.IdCausa = oCausaOrigen.Item
                    oCausaOrigenDet.Item = 4

                    oCausaOrigen.Detalles.Add(oCausaOrigenDet)
                End If
                If txtCausa5.Text.Trim.Length > 0 Then
                    oCausaOrigenDet = New ETReclamoCausaDetalle()
                    oCausaOrigenDet.Descripcion = txtCausa4.Text.Trim()
                    oCausaOrigenDet.IdCausa = oCausaOrigen.Item
                    oCausaOrigenDet.Item = 5

                    oCausaOrigen.Detalles.Add(oCausaOrigenDet)
                End If


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try
    End Sub

    Private Sub cboCausaOrigen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCausaOrigen.SelectedIndexChanged

        If cboCausaOrigen.SelectedValue Is Nothing Then Return

        If CausaOrigenPrevio <> 0 Then

            GuardarDetallesCausa(CausaOrigenPrevio)

        End If

        CausaOrigenPrevio = Convert.ToInt32(cboCausaOrigen.SelectedValue)

        CargarDetallesCausa()
    End Sub

    Private Sub ugCausaOrigen_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugCausaOrigen.ClickCellButton

        If GrillaHabilitada(ugCausaOrigen) Then
            If MsgBox("¿Desea eliminar la causa seleccionada?", MsgBoxStyle.OkCancel, msgComacsa) = MsgBoxResult.Ok Then
                Dim Item As Integer = ugCausaOrigen.ActiveRow.Cells("Item").Value

                Dim oCausaOrigen As ETReclamoCausa = SOURCE.Causas.FirstOrDefault(Function(c) c.Item = Item)
                If oCausaOrigen IsNot Nothing Then
                    SOURCE.Causas.Remove(oCausaOrigen)
                End If


                For index As Integer = 0 To SOURCE.Causas.Count - 1
                    SOURCE.Causas(index).Item = index + 1
                Next

                txtCausaItem.Text = SOURCE.Causas.Count + 1
            End If
        Else
            MostrarAdvertencia("No puede eliminar las causas de la queja , la queja ya no esta en fase de registro")
        End If
    End Sub

    Private Sub btnGenerarSeguimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarSeguimiento.Click
        gridReclamoExportacion.DataSource = NReclamo.Reclamo_Seguimiento(dtpFechaInicioSeg.Value, dtpFechaFinSeg.Value)
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If SaveFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ugExporter.Export(gridReclamoExportacion, SaveFile.FileName)
        End If
    End Sub

    Function GenerarArchivoReporte() As String
        Dim rpt As New ReportDocument
        rpt.Load(rutaReportes & "rptReclamo.rpt")

        Dim ds As DataSet = NReclamo.ReporteReclamo(SOURCE)
        rpt.SetDataSource(ds)

        Dim rutaArchivo As String = rutaArchivosGenerados & "\QUEJA_" & SOURCE.Nro & ".pdf"

        rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaArchivo)

        Return rutaArchivo
    End Function

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Try

            Dim rutaArchivo As String = GenerarArchivoReporte()

            System.Diagnostics.Process.Start(rutaArchivo)

        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Private Sub UltraLabel15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel15.Click

    End Sub

    Private Sub txtProductoNroGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UltraLabel41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UltraLabel20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel20.Click

    End Sub

    Private Sub dtpMuestraFechaEntrega_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpMuestraFechaEntrega.ValueChanged
        Try
            Dim fecha As DateTime = dtpMuestraFechaEntrega.DateTime

            For Each muestra As ETReclamoMuestra In SOURCE.ListaMuestras
                muestra.FECHA_INICIO = fecha
            Next
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Private Sub gbDatosMuestra_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbDatosMuestra.Enter

    End Sub

    Private Sub btnCorreos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorreos.Click

        If SOURCE.ClienteCodigo.Length = 0 Then
            MsgBox("Seleccione un cliente", MsgBoxStyle.OkOnly, msgComacsa)
            Return
        End If

        Dim frmCorreos As New frmReclamoCorreo
        frmCorreos.PermitirAgregar = True
        frmCorreos.ListaCorreos = SOURCE.ListaEmailsCliente

        If frmCorreos.ShowDialog() = Windows.Forms.DialogResult.OK Then

            SOURCE.ListaEmailsCliente = frmCorreos.ListaCorreos
            Dim fila As Int32 = 0
            fila = frmCorreos.ugCorreos.ActiveRow.Index
            If SOURCE.ListaEmailsCliente.Count > 0 Then
                txtClienteEmail.Text = frmCorreos.ugCorreos.ActiveRow.Cells("correo").Value 'SOURCE.ListaEmailsCliente(fila).Correo
                txtSolucionEmail.Text = frmCorreos.ugCorreos.ActiveRow.Cells("correo").Value 'SOURCE.ListaEmailsCliente(fila).Correo
            Else
                txtClienteEmail.Text = String.Empty
                txtSolucionEmail.Text = String.Empty
            End If

            If SOURCE.Id <> 0 Then
                NReclamo.RegistrarCorreosCliente(SOURCE, "CORREOCLIENTE")
            End If

        End If

    End Sub

    Private Sub rbtEvidenciaSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEvidenciaSI.CheckedChanged
        grpEvidenciaDatos.Enabled = rbtEvidenciaSI.Checked
    End Sub

    Private Sub rbtEvidenciaNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEvidenciaNO.CheckedChanged
        grpEvidenciaDatos.Enabled = rbtEvidenciaSI.Checked
    End Sub

    Private Sub UTPCMuestras_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UTPCMuestras.Paint

    End Sub

    Sub DesHabilitarRadiosServicio(ByVal grp As GroupBox)
        For Each ctrl As Control In grp.Controls
            If TypeOf ctrl Is RadioButton Then
                DirectCast(ctrl, RadioButton).Checked = False
            End If
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).ReadOnly = True
            End If
        Next
    End Sub


    Sub DesHabilitarRadiosProducto(ByVal grp As GroupBox)
        For Each ctrl As Control In grp.Controls
            If TypeOf ctrl Is RadioButton Then
                DirectCast(ctrl, RadioButton).Checked = False
            End If
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).ReadOnly = True
            End If
        Next
    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        DesHabilitarRadiosServicio(grpServicio01)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DesHabilitarRadiosServicio(grpServicio04)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        DesHabilitarRadiosServicio(grpServicio02)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        DesHabilitarRadiosServicio(grpServicio03)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        DesHabilitarRadiosServicio(grpServicio05)
    End Sub

    Private Sub btnEvidenciaUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvidenciaUpload.Click
        Try
            If OpenFIle.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If OpenFIle.FileName.Length > 0 Then
                    txtEvidenciaArchivo.Text = OpenFIle.SafeFileName
                    System.IO.File.Copy(OpenFIle.FileName, ObtenerNombreReporte(rutaArchivosEvidencia, OpenFIle.SafeFileName))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try
    End Sub

    Function ObtenerNombreReporte(ByVal RutaBase As String, ByVal NombreBase As String)
        Return RutaBase & SOURCE.Nro & "_" & NombreBase
    End Function

    Private Sub btnEvidenciaDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvidenciaDownload.Click
        Try
            Dim oEvidencia As New ETReclamoEvidencia
            Dim sufijo As String = "_" & DateTime.Now.ToString("ddMMyyyyHHmmss")

            Dim NombreArchivoTemporal As String = ObtenerNombreReporte(rutaArchivosTemp, System.IO.Path.GetFileNameWithoutExtension(txtEvidenciaArchivo.Text) & sufijo & System.IO.Path.GetExtension(txtEvidenciaArchivo.Text))

            If txtEvidenciaArchivo.Text.Trim.Length > 0 Then
                'If SOURCE.ListaEvidencias.Count > 0 Then
                oEvidencia.Archivo = txtEvidenciaArchivo.Text.Trim 'SOURCE.ListaEvidencias(0)
                System.IO.File.Copy(ObtenerNombreReporte(rutaArchivosEvidencia, oEvidencia.Archivo), NombreArchivoTemporal)
                System.Diagnostics.Process.Start(NombreArchivoTemporal)
                'End If
            End If
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Private Sub btnSolucionVerCorreos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmReclamoCorreo
        frm.PermitirAgregar = False

        frm.ListaCorreos = SOURCE.ListaEmailsCliente
        frm.ShowDialog()
    End Sub

    Private Sub chkEvidenciaReqAprobProd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEvidenciaReqAprobProd.CheckedChanged
        'grpAprobProduccion.Enabled = chkEvidenciaReqAprobProd.Checked
        'SOURCE.RequiereAprobProd = chkEvidenciaReqAprobProd.Checked
    End Sub

    Private Sub ugDetGuia_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetGuia.ClickCellButton
        If GrillaHabilitada(ugDetGuia) Then
            If e.Cell.Column.Key = "ELIMINAR" Then

                If Confirmar("¿Desea eliminar la guía seleccionada?") = Windows.Forms.DialogResult.No Then
                    Return
                End If

                Dim CODPROD As String = e.Cell.Row.Cells("COD_PRODUCTO").Value
                Dim NROFACT As String = e.Cell.Row.Cells("NRO_FACT").Value
                Dim NROGUIA As String = e.Cell.Row.Cells("NRO_GUIA").Value

                Dim oGuia As ETReclamoProductoDetalle = _
                    SOURCE.Producto.ListaDetalles.FirstOrDefault(Function(g) g.NRO_FACT = NROFACT _
                            AndAlso g.NRO_GUIA = NROGUIA AndAlso g.COD_PRODUCTO = CODPROD)

                If oGuia IsNot Nothing Then
                    SOURCE.Producto.ListaDetalles.Remove(oGuia)
                End If

                ugDetGuia.DeleteSelectedRows()
            End If
        Else
            MostrarAdvertencia("No puede eliminar las guías , la queja ya no está en fase de registro de guías")
        End If

    End Sub


    Function Confirmar(ByVal Mensaje As String) As DialogResult
        Return MessageBox.Show(Mensaje, msgComacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function
    Private Sub UltraTabPageControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl1.Paint

    End Sub

    Private Sub chkEvidenciaReqAprobLab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEvidenciaReqAprobLab.CheckedChanged
        'grpAprobComercial.Enabled = chkEvidenciaReqAprobLab.Checked
        'SOURCE.RequiereAprobLab = chkEvidenciaReqAprobLab.Checked
    End Sub

    Private Sub grpOrigenReclamo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpOrigenReclamo.Enter

    End Sub

    Private Sub ugPrincipal_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugPrincipal.InitializeRow

        Dim oReclamo As ETReclamo = TryCast(e.Row.ListObject, ETReclamo)
        Dim nDias As Integer = 0
        Dim nDiasSIG As Integer = 0
        Dim Dias As Integer = 0
        Dim bColor As Color = Color.White

        If oReclamo IsNot Nothing Then
            Dim dif_muestra As Int32 = 0
            Dim dif_lab As Int32 = 0
            Dim dif_prod As Int32 = 0
            Dim dif_com As Int32 = 0

            Dim dias_sig As Double = 0

            dif_muestra = CInt(e.Row.Cells("DIAS_MUESTRA").Value) - IIf(e.Row.Cells("Tipo").Value = 1, dia_muestra, dia_muestra_serv)
            dias_sig = dias_sig + CInt(e.Row.Cells("DIAS_MUESTRA").Value)
            Select Case dif_muestra
                Case Is <= 0
                    e.Row.Cells("DIAS_MUESTRA").Appearance.BackColor = Color.Green
                Case 1 To 2
                    e.Row.Cells("DIAS_MUESTRA").Appearance.BackColor = Color.Yellow
                Case Is > 2
                    e.Row.Cells("DIAS_MUESTRA").Appearance.BackColor = Color.Red
                Case Else
            End Select

            If e.Row.Cells("DIAS_INFORME").Value <> "" Then
                dif_lab = CInt(e.Row.Cells("DIAS_INFORME").Value) - IIf(e.Row.Cells("Tipo").Value = 1, dia_lab, dia_lab_serv)
                dias_sig = dias_sig + CInt(e.Row.Cells("DIAS_INFORME").Value)
                Select Case dif_lab
                    Case Is <= 0
                        e.Row.Cells("DIAS_INFORME").Appearance.BackColor = Color.Green
                    Case 1 To 2
                        e.Row.Cells("DIAS_INFORME").Appearance.BackColor = Color.Yellow
                    Case Is > 2
                        e.Row.Cells("DIAS_INFORME").Appearance.BackColor = Color.Red
                    Case Else
                End Select

            End If
            If e.Row.Cells("DIAS_PRODUCCION").Value <> "" Then
                dif_prod = CInt(e.Row.Cells("DIAS_PRODUCCION").Value) - IIf(e.Row.Cells("Tipo").Value = 1, dia_prod, dia_prod_serv)
                dias_sig = dias_sig + CInt(e.Row.Cells("DIAS_PRODUCCION").Value)
                Select Case dif_prod
                    Case Is <= 0
                        e.Row.Cells("DIAS_PRODUCCION").Appearance.BackColor = Color.Green
                    Case 1 To 2
                        e.Row.Cells("DIAS_PRODUCCION").Appearance.BackColor = Color.Yellow
                    Case Is > 2
                        e.Row.Cells("DIAS_PRODUCCION").Appearance.BackColor = Color.Red
                    Case Else
                End Select
            End If
            If e.Row.Cells("DIAS_COMERCIAL").Value <> "" Then
                dif_com = CInt(e.Row.Cells("DIAS_COMERCIAL").Value) - IIf(e.Row.Cells("Tipo").Value = 1, dia_com, dia_com_serv)
                dias_sig = dias_sig + CInt(e.Row.Cells("DIAS_COMERCIAL").Value)
                Select Case dif_com
                    Case Is <= 0
                        e.Row.Cells("DIAS_COMERCIAL").Appearance.BackColor = Color.Green
                    Case 1 To 2
                        e.Row.Cells("DIAS_COMERCIAL").Appearance.BackColor = Color.Yellow
                    Case Is > 2
                        e.Row.Cells("DIAS_COMERCIAL").Appearance.BackColor = Color.Red
                    Case Else
                End Select
            End If
            e.Row.Cells("ALERTA_SIG").SetValue(dias_sig, False)
            e.Row.Cells("ALERTA").SetValue(dias_sig, False)
            Dim band As UltraGridBand = ugPrincipal.DisplayLayout.Bands(0)
            band.Columns("ALERTA").Width = 30
            'If oReclamo.EstadoComentado = "FINALIZADO" Then
            '    e.Row.Cells("DIAS_MUESTRA").Appearance.BackColor = Color.White
            '    e.Row.Cells("DIAS_INFORME").Appearance.BackColor = Color.White
            '    e.Row.Cells("DIAS_PRODUCCION").Appearance.BackColor = Color.White
            '    e.Row.Cells("DIAS_COMERCIAL").Appearance.BackColor = Color.White
            '    Exit Sub
            'End If

            dias_sig = dif_com


            If oReclamo.Estado = "CANCELADO" Then
                e.Row.Cells("ALERTA").SetValue("", False)
                e.Row.Cells("ALERTA").Appearance.BackColor = Color.LightGray

                'e.Row.Cells("ALERTA_SIG").SetValue("", False)
                e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.LightGray
                Exit Sub
            End If
            If oReclamo.ReclamoPermisos.AprobacionGerencial Then
                'e.Row.Cells("ALERTA").SetValue("", False)
                e.Row.Cells("ALERTA").Appearance.BackColor = Color.LightBlue

                'e.Row.Cells("ALERTA_SIG").SetValue("", False)
                e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.LightBlue
                Exit Sub
            End If

            'ALERTA SIG - CALCULAR FECHA INICIO - FIN
            'nDiasSIG = DateDiff(DateInterval.Day, DateTime.Now, oReclamo.FechaFin)

            'e.Row.Cells("ALERTA").SetValue(nDiasSIG.ToString(), False)

            Select Case nDiasSIG
                Case Is <= 0
                    e.Row.Cells("ALERTA").Appearance.BackColor = Color.Red
                Case 1 To 2
                    e.Row.Cells("ALERTA").Appearance.BackColor = Color.Yellow
                Case Is > 2
                    e.Row.Cells("ALERTA").Appearance.BackColor = Color.Green
                Case Else
            End Select

            'MsgBox(e.Row.Cells("Tipo").Value)

            'MsgBox(dtConfiguracion.Rows.Count)

            'ALERTA
            'PRODUCTO - SERVICIO , AUN NO SE REGISTRAN LAS MUESTRAS - EVIDENCIAS
            If (oReclamo.Tipo = "1" AndAlso Not oReclamo.ReclamoPermisos.Muestra) OrElse _
             (oReclamo.Tipo = "2" AndAlso Not oReclamo.ReclamoPermisos.Evidencia) Then
                nDias = DateDiff(DateInterval.Day, oReclamo.Fecha, DateTime.Now) '
                'NACIONAL
                If oReclamo.Origen = "1" Then
                    'MOSTRAR LOS DIAS RESTANTES PARA LA ENTREGA DE MUESTRAS
                    Dias = 3 - nDias

                    Select Case Dias
                        Case Is >= 3
                            bColor = Color.Green
                        Case 2
                            bColor = Color.Yellow
                        Case 1
                            bColor = Color.Yellow
                        Case Else
                            bColor = Color.Red
                    End Select

                    'If Dias < 0 Then
                    '    Dias = 0
                    'End If

                Else
                    'EXPORTACION 
                    '- NO APLICA EL CONTROL DE DIAS EN EL CASO DE LAS FECHA DE ENTREGA DE MUESTRAS
                    nDias = 0
                    bColor = Color.Green
                End If

                'e.Row.Cells("ALERTA_SIG").SetValue(Dias, False)
                e.Row.Cells("ALERTA_SIG").Appearance.BackColor = bColor
            Else
                If oReclamo.Tipo = "1" Then
                    nDias = DateDiff(DateInterval.Day, oReclamo.ReclamoPermisos.FechaMuestra, DateTime.Now)
                Else
                    nDias = DateDiff(DateInterval.Day, oReclamo.ReclamoPermisos.FechaEvidencia, DateTime.Now)
                End If

                If oReclamo.Origen = "1" Then
                    Dias = 7 - nDias
                Else
                    Dias = 10 - nDias
                End If

                'e.Row.Cells("ALERTA_SIG").SetValue(Dias.ToString(), False)

                Select Case Dias
                    Case Is > 2
                        e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.Green
                    Case 0 To 2
                        e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.Yellow
                    Case Else
                        e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.Red
                End Select
            End If
        End If



        'Dim fecRegistro As DateTime = e.Row.Cells("Fecha").Value
        'Dim fecTermino As DateTime = fecRegistro.AddDays(7)

        'If e.Row.Cells("Origen").Value = "2" Then
        '    fecTermino = fecTermino.AddDays(3)
        'End If

        'Dim dias_restantes As Integer = DateDiff(DateInterval.Day, Date.Now.Date, fecTermino.Date)

        'e.Row.Cells("ALERTA").SetValue(dias_restantes, False)
        'e.Row.Cells("ALERTA_SIG").SetValue(dias_restantes + 4, False)

        'If dias_restantes <= 0 Then
        '    e.Row.Cells("ALERTA").Appearance.BackColor = Color.Red
        '    e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.Red
        'End If
        'If dias_restantes > 0 And dias_restantes <= 2 Then
        '    e.Row.Cells("ALERTA").Appearance.BackColor = Color.Yellow
        '    e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.Yellow
        'End If
        'If dias_restantes > 2 Then
        '    e.Row.Cells("ALERTA").Appearance.BackColor = Color.Green
        '    e.Row.Cells("ALERTA_SIG").Appearance.BackColor = Color.Green
        'End If

    End Sub

    Private Sub btnReenvioCorreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReenvioCorreo.Click
        Try
            Dim key As String = tabTipoReclamo.SelectedTab.Key
            Dim Asunto As String = String.Empty
            Dim AsuntoSufix As String = " |QUEJA NRO: " & txtNro.Text & " | CLIENTE: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.Value.ToString()
            Dim Contenido As String = String.Empty
            Dim Importancia As MailPriority = MailPriority.Normal
            Dim RutaAdjunto As String = String.Empty
            Dim destinatarios As New List(Of MailAddress)
            Dim destinatarios_aux As New List(Of MailAddress)

            Dim mensaje As String = ""

            Dim r As DialogResult = MessageBox.Show("Escoja el mensaje a enviar" & Environment.NewLine & " (SI) Mensaje Informativo" & Environment.NewLine & "(NO) Reenvio de Alerta", "Reenvio de Email", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If r = Windows.Forms.DialogResult.Yes Then
                mensaje = "Se envia copia del reporte de la queja siguiente , este correo es solo informativo"
            ElseIf r = Windows.Forms.DialogResult.No Then
                mensaje = ""
            Else
                Exit Sub
            End If

            If key = "TT01" OrElse key = "TT02" Then ' producto - servicio

                destinatarios = Correo_ObtenerCorreosRegistroReclamo_1(SOURCE)
                Asunto = "REGISTRO QUEJA" & AsuntoSufix

                If mensaje.Length = 0 Then
                    mensaje = "Se registró la siguiente queja. Recuerde que tiene 24 horas para registrar la entrega de muestras a laboratorio"
                End If

                Contenido = GenerarContenidoReclamo(mensaje)

                EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

            End If
            If key = "TT09" Then ' Evidencias
                If GrabarDatosEvidencia() Then

                    destinatarios = Correo_ObtenerCorreosRevisionLaboratorio_3(SOURCE)
                    Asunto = "REGISTRO DE EVIDENCIA" & AsuntoSufix

                    If mensaje.Length = 0 Then
                        mensaje = "Se han adjuntado las evidencias a la queja, Recuerde que tiene 24 hrs para aprobar o rechazar las evidencias enviadas"
                    End If

                    Contenido = GenerarContenidoReclamo(mensaje)
                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

                End If
            End If
            If key = "TT03" Then ' Muestra


                destinatarios = Correo_ObtenerCorreosEntregaMuestra_2(SOURCE)
                Asunto = "ENTREGA DE MUESTRAS" & AsuntoSufix

                If mensaje.Length = 0 Then
                    mensaje = "Se entregaron las siguientes muestras a laboratorio , Recuerde que tiene 24 horas para registrar la conformidad de las muestras"
                End If

                Contenido = GenerarContenidoReclamo(mensaje)
                EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)


            End If

            If key = "TT04" Then ' Laboratorio


                If SOURCE.Estado = "PRODUCTO" Or SOURCE.Estado = "SERVICIO" Then
                    destinatarios = Correo_ObtenerCorreosRegistroReclamo_1(SOURCE)
                    Asunto = "CONFORMIDAD DE MUESTRAS" & AsuntoSufix

                    If mensaje.Length = 0 Then
                        mensaje = "El area de Laboratorio ha rechazado las muestras enviadas , debe volver a generarlas"
                    End If

                    Contenido = GenerarContenidoReclamo(mensaje)
                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If
                If SOURCE.Estado = ESTLAB_INFORME Then
                    destinatarios = Correo_ObtenerCorreosRevisionLaboratorio_3(SOURCE)
                    Asunto = "INFORME DE LABORATORIO" & AsuntoSufix

                    If mensaje.Length = 0 Then
                        mensaje = "El area de Laboratorio ha entregado el Informe de Muestras, Recuerde que tiene 1 día para aprobar o rechazar los informes"
                    End If

                    Contenido = GenerarContenidoReclamo(mensaje)

                    EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)
                End If


            End If


            If key = "TT08" Then ' Aprobacion Informes


                Dim EstadoReclamo As ETReclamoPermisos = NReclamo.ObtenerEstadoReclamo(SOURCE)
                Dim areas As String = ""
                Dim req As Integer = 0
                Dim aprob As Integer = 0

                If SOURCE.RequiereAprobProd Then
                    req += 1
                    If EstadoReclamo.AprobProduccion Then
                        aprob += 1
                        areas += "Gerencia de Producción"
                    Else
                        destinatarios_aux = Correo_ObtenerCorreosRevision_3_Prod(SOURCE)
                        For Each mail As MailAddress In destinatarios_aux
                            Dim str_mail As String = mail.Address
                            If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                destinatarios.Add(mail)
                            End If
                        Next
                    End If

                End If
                If SOURCE.RequiereAprobLab Then
                    req += 1
                    If EstadoReclamo.AprobLaboratorio Then
                        aprob += 1
                        areas += IIf(areas.Length = 0, "Gerencia de Laboratorio", ",Gerencia de Laboratorio")
                    Else
                        destinatarios_aux = Correo_ObtenerCorreosRevision_3_Lab(SOURCE)
                        For Each mail As MailAddress In destinatarios_aux
                            Dim str_mail As String = mail.Address
                            If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                destinatarios.Add(mail)
                            End If
                        Next
                    End If

                End If
                If SOURCE.RequiereAprobCom Then
                    req += 1
                    If EstadoReclamo.AprobacionComercial Then
                        aprob += 1
                        areas += IIf(areas.Length = 0, "Gerencia Comercial", ",Gerencia Comercial")
                    Else
                        destinatarios_aux = Correo_ObtenerCorreosRevision_3_Com(SOURCE)
                        For Each mail As MailAddress In destinatarios_aux
                            Dim str_mail As String = mail.Address
                            If Not destinatarios.Exists(Function(m) m.Address = str_mail) Then
                                destinatarios.Add(mail)
                            End If
                        Next
                    End If

                End If

                Dim lista_aux2 As List(Of MailAddress) = Correo_ObtenerCorreosAprobacion_4(SOURCE)

                For Each mail As MailAddress In lista_aux2
                    destinatarios.Add(mail)
                Next
                'destinatarios = Correo_ObtenerCorreosAprobacion_4(SOURCE)

                If SOURCE.Tipo = "1" Then
                    Asunto = "APROBACION INFORMES LABORATORIO" & AsuntoSufix
                    Contenido = GenerarContenidoReclamo("Gerencia de Producción ha revisado los informes de Laboratorio , Se requiere la revision del formato que se enviará al cliente")

                Else
                    If req = aprob Then
                        Asunto = "REVISIÓN COMPLETA DE EVIDENCIAS DE LA QUEJA" & AsuntoSufix
                        Contenido = GenerarContenidoReclamo(areas & " ha revisado las evidencias , Se requiere la revision del formato que se enviará al cliente")
                    Else
                        Asunto = "REVISIÓN PARCIAL DE EVIDENCIAS DE LA QUEJA" & AsuntoSufix
                        Contenido = GenerarContenidoReclamo(areas & " ha revisado las evidencias , Se requiere la aprobación de las otras gerencias")
                    End If
                End If

                EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

            End If

            If key = "TT05" Then ' Areas a Solucionar


                destinatarios = Correo_ObtenerCorreosReunion_5(SOURCE)
                Asunto = "PROGRAMACION REUNIÓN" & AsuntoSufix

                If mensaje.Length = 0 Then
                    mensaje = "Se ha agendado una reunión para la siguiente queja"
                End If

                Contenido = GenerarContenidoReclamo(mensaje)

                EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)

            End If

            If key = "TT07" Then ' Analisis del Problema


                destinatarios = Correo_ObtenerCorreosAnalisis_6(SOURCE)
                Asunto = "ANALISIS DE CAUSA" & AsuntoSufix

                If mensaje.Length = 0 Then
                    mensaje = "Se han registrado las causas inmediatas y raiz de la queja, recuerde que debe generar los planes de acción en un plazo no mayor a 24 hrs."
                End If

                Contenido = GenerarContenidoReclamo(mensaje)
                EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)


            End If
            If key = "TT06" Then ' Planes de Accion

                destinatarios = Correo_ObtenerCorreosPlanAccion_7(SOURCE)
                Asunto = "PLAN DE ACCION" & AsuntoSufix

                If mensaje.Length = 0 Then
                    mensaje = "Se han elaborado los planes de accion.Recuerde que debe aprobar su envio al cliente en un plazo de 24 hrs."
                End If

                Contenido = GenerarContenidoReclamo(mensaje)
                'El envio del plan de acción requiere que sea aprobado por gerencia comercial
                'RutaAdjunto = "RECLAMO_" & SOURCE.Nro & ".pdf"
                EnviarMail(destinatarios, Asunto, Contenido, Importancia, RutaAdjunto)


            End If


        Catch ex As Exception
            MostrarError(ex.Message)
        End Try


    End Sub

    Private Sub btnEliminarEvidencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarEvidencias.Click

        Try

            If txtEvidenciaArchivo.Text.Trim().Length > 0 Then

                Dim oEvidencia As ETReclamoEvidencia = Nothing

                If MessageBox.Show("¿Desea retirar las evidencias registradas?", "Sistema de Quejas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    If SOURCE.ListaEvidencias.Count > 0 Then
                        oEvidencia = SOURCE.ListaEvidencias(0)
                        System.IO.File.Delete(ObtenerNombreReporte(rutaArchivosEvidencia, oEvidencia.Archivo))

                    End If

                    txtEvidenciaArchivo.Text = String.Empty
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        DesHabilitarRadiosServicio(grpServicio06)
    End Sub

    Private Sub chkFiltroFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltroFechas.CheckedChanged
        pnlFiltroFechas.Enabled = chkFiltroFechas.Checked
    End Sub

    Private Sub rbtnServOtros29_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnServOtros29.CheckedChanged
        txtServOtros06.ReadOnly = Not rbtnServOtros29.Checked
    End Sub

    Private Sub rbtnAprobacionProdAcepta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAprobacionProdAcepta.CheckedChanged
        txtAprobacionProdPlan.Enabled = rbtnAprobacionProdAcepta.Checked
    End Sub

    Private Sub rbtnAprobacionComAcepta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAprobacionComAcepta.CheckedChanged
        txtAprobacionComPlan.Enabled = rbtnAprobacionComAcepta.Checked
    End Sub

    Private Sub rbtnAprobacionLabAcepta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAprobacionLabAcepta.CheckedChanged
        txtAprobacionLabPlan.Enabled = rbtnAprobacionLabAcepta.Checked
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        btnReporte_Click(Nothing, Nothing)
    End Sub

    Private Sub UltraTabPageControl4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl4.Paint

    End Sub



    Private Sub btnCargarFormato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarFormato.Click
        If MessageBox.Show("Desea descartar todos las modificaciones hechas y cargar el formato de nuevo?", "Formato de Queja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            CargarDatosFormatoReporte()
        End If
    End Sub

    Private Sub btnFormatoVerCorreos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormatoVerCorreos.Click, btnSolucionVerCorreos.Click
        Dim frm As New frmReclamoCorreo
        frm.PermitirAgregar = False
        frm.ListaCorreos = SOURCE.ListaEmailsCliente
        frm.ShowDialog()
    End Sub


    Private Sub gridFormatoComentarios_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridFormatoComentarios.InitializeLayout
        If Not gridFormatoComentarios.DisplayLayout.ValueLists.Exists("ESTADO_APROB") Then
            gridFormatoComentarios.DisplayLayout.Bands(0).Columns("ESTADO").ValueList = ObtenerListaEstadoAprobacion()
        End If
    End Sub

    Private Sub gridFormatoComentarios_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridFormatoComentarios.ClickCellButton
        Try
            If e.Cell.Column.Key = "ELIMINAR" Then
                If MessageBox.Show("Eliminar el item seleccionado?", msgComacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim cod As String = e.Cell.Row.Cells("EncargadoCodigo").Value

                    Dim oPlan As ETReclamoPlanAccion = SOURCE.FormatoComentarios.FirstOrDefault(Function(p) p.EncargadoCodigo = cod)

                    If oPlan IsNot Nothing Then
                        SOURCE.FormatoComentarios.Remove(oPlan)
                    End If
                End If
            End If
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Private Sub gridFormatoPLanAccion_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridFormatoPLanAccion.ClickCellButton
        Try
            If e.Cell.Column.Key = "ELIMINAR" Then

                If MessageBox.Show("Eliminar el item seleccionado?", msgComacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim cod As String = e.Cell.Row.Cells("EncargadoCodigo").Value

                    Dim oPlan As ETReclamoPlanAccion = SOURCE.FormatoPlanes.FirstOrDefault(Function(p) p.EncargadoCodigo = cod)

                    If oPlan IsNot Nothing Then
                        SOURCE.FormatoPlanes.Remove(oPlan)
                    End If
                End If

            End If
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub

    Private Sub btnFormatoEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormatoEnvio.Click
        Dim rutaArchivo As String = GenerarFormatoCliente()

        If rutaArchivo.Length = 0 Then
            MostrarAdvertencia("Debe grabar los datos del formato antes de visualizarlo")
        Else
            If MessageBox.Show("Desea enviar el reporte al cliente?", "Sistema de Quejas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'Threading.Thread.Sleep(5000)
                'MostrarError("Error en el envio")

                Dim contenido As String = GenerarContenidoFormato()
                EnviarMail(Correo_ObtenerCorreosAprobacionFinal_8(SOURCE), "QUEJA |QUEJA NRO: " & txtNro.Text & " | CLIENTE: " & txtClienteRazonSocial.Text & " | " & dtpFechaRegistro.Value.ToString(), contenido & SOURCE.Nro, MailPriority.Normal, rutaArchivo)

                SOURCE.Estado = E_APROBGER
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)

            End If
            System.Diagnostics.Process.Start(rutaArchivo)
        End If
    End Sub

    Private Sub btnEvidenciaGuias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvidenciaGuias.Click
        Try
            Dim oFrmSeleccionGuia As New frmSeleccionGuia
            oFrmSeleccionGuia.Cliente = txtClienteRazonSocial.Text
            oFrmSeleccionGuia.ClienteCodigo = txtClienteCodigo.Text

            If oFrmSeleccionGuia.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim oGuia As ETReclamoProductoDetalle = Nothing

                For Each oNuevaGuia As ETReclamoProductoDetalle In oFrmSeleccionGuia.ListaDetallesProducto

                    Dim oGuiaComparar As ETReclamoProductoDetalle = oNuevaGuia

                    oGuia = SOURCE.Producto.ListaDetalles.FirstOrDefault(Function(p) p.NRO_GUIA = oGuiaComparar.NRO_GUIA _
                                                                             AndAlso p.NRO_FACT = oGuiaComparar.NRO_FACT _
                                                                             AndAlso p.COD_PRODUCTO = oGuiaComparar.COD_PRODUCTO)
                    If oGuia Is Nothing Then
                        SOURCE.Producto.ListaDetalles.Add(oNuevaGuia)
                    End If
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "COMACSA")
        End Try
    End Sub

    Private Sub txtClienteCodigo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClienteCodigo.KeyPress

    End Sub

    Private Sub txtClienteCodigo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClienteCodigo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                Dim xCodCliente As String = txtClienteCodigo.Text.Trim()

                If Len(xCodCliente) > 0 Then
                    Dim oCliente As ETCliente = NReclamo.ObtenerClientePorCodigo("01", xCodCliente)

                    AsignarClienteSeleccionado(oCliente.CodCliente, oCliente.DesCliente)

                End If

            End If
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try
    End Sub


    '--- HVilela 
    Private Sub txtResponsableVenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResponsableVenta.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim xCodCliente As String = txtClienteCodigo.Text.Trim()
                Dim xResponsableVenta As String = txtResponsableVenta.Text.Trim()
                If Len(xCodCliente) > 0 And Len(xResponsableVenta) > 0 Then

                    Dim oResponsableVenta As ETResponsableVenta = NReclamo.ObtenerCorreoPorNombre("01", xResponsableVenta)

                    AsignarCorreoResponsableVenta(oResponsableVenta.Codigo, oResponsableVenta.Nombre, oResponsableVenta.Correo)

                End If
            End If
        Catch ex As Exception
            MostrarError(ex.Message)
        End Try

    End Sub



    Private Sub gridFormatoComentarios_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridFormatoComentarios.AfterCellUpdate
        e.Cell.Row.PerformAutoSize()
    End Sub

    Private Sub gridFormatoPLanAccion_AfterCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridFormatoPLanAccion.AfterCellUpdate
        e.Cell.Row.PerformAutoSize()
    End Sub

    'Private Sub gridFormatoComentarios_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridFormatoComentarios.CellChange
    '    e.Cell.Row.PerformAutoSize()
    'End Sub

    Private Sub btnCerrarReclamo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarReclamo.Click
        If SOURCE.EstadoComentado <> "CORREO ENVIADO A CLIENTE" Then
            MsgBox("Debe registrar la evidencia de envio de correo a cliente", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim rutaArchivo As String = GenerarFormatoCliente()

        If rutaArchivo.Length = 0 Then
            MostrarAdvertencia("Debe grabar los datos del formato antes de visualizarlo")
        Else
            If MessageBox.Show("Desea cerrar la queja sin enviar el reporte al cliente?", "Sistema de Quejas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SOURCE.Estado = E_APROBGER
                NReclamo.ActualizarEstado(SOURCE, User_Sistema)
                CargarDatos(SOURCE)
            End If
            System.Diagnostics.Process.Start(rutaArchivo)
        End If
    End Sub

    Sub Reporte()

        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If ugPrincipal.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTE_RECLAMO.xls")
                File.Copy(RutaReporteERP & "PLANTILLA_RECLAMO.xls", path & "\REPORTE_RECLAMO.xls")
                m_Excel.Workbooks.Open(path & "\REPORTE_RECLAMO.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0
                Dim n_mes As Int32 = 0
                nfila = 2
                nfilaini = 2

                With objHojaExcel
                    .Activate()
                    Dim filaultima As Int32 = 0
                    Dim contactivo As Int32 = 0
                    For i As Int16 = 0 To ugPrincipal.Rows.Count - 1
                        'n_mes = ugPrincipal.Rows(i).Cells("MES").Value
                        .Range("A" & i + nfila).Value = ugPrincipal.Rows(i).Cells("Nro").Value
                        .Range("B" & i + nfila).Value = ugPrincipal.Rows(i).Cells("Fecha").Value
                        .Range("C" & i + nfila).Value = ugPrincipal.Rows(i).Cells("Cliente").Value
                        .Range("D" & i + nfila).Value = ugPrincipal.Rows(i).Cells("Responsable").Value
                        .Range("E" & i + nfila).Value = IIf(ugPrincipal.Rows(i).Cells("Origen").Value = 1, "NACIONAL", "EXTERIOR")
                        .Range("F" & i + nfila).Value = IIf(ugPrincipal.Rows(i).Cells("Tipo").Value = 1, "PRODUCTO", "SERVICIO")
                        .Range("G" & i + nfila).Value = ugPrincipal.Rows(i).Cells("Motivo").Value
                        .Range("H" & i + nfila).Value = ugPrincipal.Rows(i).Cells("Observacion").Value
                        .Range("I" & i + nfila).Value = ugPrincipal.Rows(i).Cells("EstadoComentado").Value
                        .Range("H" & i + nfila).WrapText = False
                    Next
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim path As String = rutaArchivosCorreo
            OpenFIle.ShowDialog()
            If OpenFIle.FileName.Length > 0 Then
                'System.IO.File.Copy(OpenFIle.FileName, ObtenerNombreReporte(path, OpenFIle.SafeFileName), True)
                'txtruta.Text = OpenFIle.SafeFileName
                txtruta.Text = OpenFIle.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkverT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkverT.CheckedChanged
        Try
            Dim band As UltraGridBand = ugPrincipal.DisplayLayout.Bands(0)
            If chkverT.Checked = True Then
                band.Columns("dias_muestra").Hidden = False
                band.Columns("dias_informe").Hidden = False
                band.Columns("dias_produccion").Hidden = False
                band.Columns("dias_comercial").Hidden = False
                band.Columns("ALERTA").Hidden = False
            Else
                band.Columns("dias_muestra").Hidden = True
                band.Columns("dias_informe").Hidden = True
                band.Columns("dias_produccion").Hidden = True
                band.Columns("dias_comercial").Hidden = True
                band.Columns("ALERTA").Hidden = True
            End If
            band.Columns("dias_muestra").Width = 30
            band.Columns("dias_informe").Width = 30
            band.Columns("dias_produccion").Width = 30
            band.Columns("dias_comercial").Width = 30
            band.Columns("ALERTA").Width = 30
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ugPrincipal_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugPrincipal.InitializeLayout
    End Sub

    Private Sub SaveFile_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFile.FileOk
    End Sub

    Private Sub grpProducto_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpProducto.Enter
    End Sub

    Private Sub rbtParetoSI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtParetoSI.CheckedChanged
    End Sub

    Private Sub rbtParetoNO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtParetoNO.CheckedChanged

    End Sub

    Private Sub btnProd01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProd01.Click
        DesHabilitarRadiosProducto(grpProducto01)
    End Sub

    Private Sub btnProd02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProd02.Click
        DesHabilitarRadiosProducto(grpProducto02)
    End Sub

    Private Sub btnProd03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProd03.Click
        DesHabilitarRadiosProducto(grpProducto03)
    End Sub

    Private Sub usPlanAccion_CellDataRequested(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinDataSource.CellDataRequestedEventArgs) Handles usPlanAccion.CellDataRequested
    End Sub

    Private Sub RadioButton42_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProductoOtros01.CheckedChanged
        txtProdOtros01.ReadOnly = Not rbtnProductoOtros01.Checked
    End Sub

    Private Sub rbtnProductoOtros02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProductoOtros02.CheckedChanged
        txtProdOtros02.ReadOnly = Not rbtnProductoOtros02.Checked
    End Sub

    Private Sub rbtnProductoOtros03_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProductoOtros03.CheckedChanged
        txtProdOtros03.ReadOnly = Not rbtnProductoOtros03.Checked
    End Sub

    Private Sub chkReqNotaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReqNotaCredito.Click
        If chkReqNotaCredito.Checked Then
            txtRegNotaCredito.Enabled = True
            txtRegNotaCredito.BackColor = Color.White
        Else
            txtRegNotaCredito.Enabled = False
            txtRegNotaCredito.BackColor = SystemColors.Control
            txtRegNotaCredito.Text = ""
        End If
    End Sub

    Private Sub grpPlanAccion_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpPlanAccion.Enter

    End Sub

    Private Sub txtResponsableVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtResponsableVenta.TextChanged

    End Sub
End Class




